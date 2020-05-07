using Microsoft.AspNetCore.Mvc;
using Nzh.Super.Common;
using Nzh.Super.Handler;
using Nzh.Super.IService;
using Nzh.Super;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nzh.Super.Models;

namespace Nzh.Super.Controllers
{
    [HandlerLogin]
    public class BaseController : Controller
    {
        protected const string SuccessText = "操作成功！";

        protected const string ErrorText = "操作失败！";

        public ILogService logService { get; set; }

        public IActionService actionService { get; set; }

        public OperatorModel Operator
        {
            get { return new OperatorProvider(HttpContext).GetCurrent(); }
        }

        public virtual ActionResult Index(int? id)
        {
            var _menuId = id == null ? 0 : id.Value;
            var _roleId = Operator.RoleId;
            if (id != null)
            {
                ViewData["ActionList"] = actionService.GetActionListByMenuIdRoleId(_menuId, _roleId, PositionEnum.FormInside);
                ViewData["ActionFormRightTop"] = actionService.GetActionListByMenuIdRoleId(_menuId, _roleId, PositionEnum.FormRightTop);
            }
            return View();
        }

        protected virtual AjaxResult SuccessTip(string message = SuccessText)
        {
            return new AjaxResult { state = ResultType.success.ToString(), message = message };
        }

        protected virtual AjaxResult ErrorTip(string message = ErrorText)
        {
            return new AjaxResult { state = ResultType.error.ToString(), message = message };
        }

        protected WebSiteModel GetWebSiteInfo()
        {
            return new WebSiteModel
            {
                SiteName = Configs.GetValue("SiteName"),
                SiteDomain = Configs.GetValue("SiteDomain"),
                CacheTime = Configs.GetValue("CacheTime"),
                MaxFileUpload = Configs.GetValue("MaxFileUpload"),
                UploadFileType = Configs.GetValue("UploadFileType"),
                HomeTitle = Configs.GetValue("HomeTitle"),
                MetaKey = Configs.GetValue("MetaKey"),
                MetaDescribe = Configs.GetValue("MetaDescribe"),
                //CopyRight = Configs.GetValue("CopyRight")
            };
        }
    }
}
