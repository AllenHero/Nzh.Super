using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nzh.Super.Common;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Controllers
{
    public class LoginController : Controller
    {
        public IHttpContextAccessor httpContextAccessor { get; set; }

        private IUserService userService;

        private ILogService logService;

        public LoginController(IUserService _userService, ILogService _logService)
        {
            userService = _userService;
            logService = _logService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = Configs.GetValue("SiteName");
            //ViewBag.CopyRight = Configs.GetValue("CopyRight");
            ViewBag.SiteDomain = Configs.GetValue("SiteDomain");
            return View();
        }

        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode(HttpContext).GetVerifyCode(), @"image/Gif");
        }

        [HttpGet]
        public ActionResult OutLogin()
        {
            var OperatorProvider = new OperatorProvider(HttpContext);
            logService.WriteDbLog(new LogModel
            {
                LogType = DbLogType.Exit.ToString(),
                UserName = OperatorProvider.GetCurrent().UserName,
                RealName = OperatorProvider.GetCurrent().RealName,
                Status = true,
                Description = "安全退出系统",
            }, HttpContext.Connection.RemoteIpAddress.ToString(), HttpContext.Connection.RemoteIpAddress.ToString());
            OperatorProvider.WebHelper.ClearSession();
            OperatorProvider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            LogModel logEntity = new LogModel();
            var OperatorProvider = new OperatorProvider(HttpContext);
            logEntity.ModuleName = "系统登录";
            logEntity.LogType = DbLogType.Login.ToString();
            try
            {
                if (OperatorProvider.WebHelper.GetSession("session_verifycode").IsEmpty() || Md5.md5(code.ToLower(), 16) != OperatorProvider.WebHelper.GetSession("session_verifycode"))
                {
                    throw new Exception("验证码错误，请重新输入");
                }
                UserModel userEntity = userService.CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.Id;
                    operatorModel.UserName = userEntity.UserName;
                    operatorModel.RealName = userEntity.RealName;
                    operatorModel.RoleId = userEntity.RoleId;
                    operatorModel.HeadShot = userEntity.HeadShot;
                    operatorModel.LoginIPAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                    //operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginIPAddressName = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.UserName == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.AddCurrent(operatorModel);
                    logEntity.UserName = userEntity.UserName;
                    logEntity.RealName = userEntity.RealName;
                    logEntity.Status = true;
                    logEntity.Description = "登录成功";
                    logEntity.CreateBy = userEntity.Id;
                    logService.WriteDbLog(logEntity, operatorModel.LoginIPAddress, operatorModel.LoginIPAddressName);
                    return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
                }
                else
                {
                    throw new Exception("用户名或密码错误。");
                }
            }
            catch (Exception ex)
            {
                logEntity.UserName = username;
                logEntity.RealName = username;
                logEntity.Status = false;
                logEntity.Description = "登录失败，" + ex.Message;
                logService.WriteDbLog(logEntity, HttpContext.Connection.RemoteIpAddress.ToString(), HttpContext.Connection.RemoteIpAddress.ToString());
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
