using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nzh.Super.Common;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Controllers.SysSet
{
    public class InfoController : BaseController
    {
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public IUserService userService { get; set; }

        public override ActionResult Index(int? id)
        {
            base.Index(id);
            ViewBag.MaxFileUpload = Configs.GetValue("MaxFileUpload");
            ViewBag.UploadFileType = Configs.GetValue("UploadFileType");
            var _userId = Operator.UserId;
            var model = userService.GetDetail(_userId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            model.UpdateOn = DateTime.Now;
            model.UpdateBy = Operator.UserId;
            model.Id = Operator.UserId;
            var result = userService.UpdateModel(model, "UpdateOn,UpdateBy,RealName,Gender,HeadShot,Phone,Email,Remark") ? SuccessText : ErrorText;
            ViewBag.Msg = result;
            return View("Index", model);
        }

        public JsonResult ExportFile()
        {
            UploadFile uploadFile = new UploadFile();
            try
            {
                var file = Request.Form.Files[0];    //获取选中文件
                var filecombin = file.FileName.Split('.');
                if (file == null || string.IsNullOrEmpty(file.FileName) || file.Length == 0 || filecombin.Length < 2)
                {
                    uploadFile.code = -1;
                    uploadFile.src = "";
                    uploadFile.msg = "上传出错!请检查文件名或文件内容";
                    return Json(uploadFile);
                }
                //定义本地路径位置
                string localPath = WebHostEnvironment.WebRootPath + @"/Upload";
                string filePathName = string.Empty; //最终文件名
                filePathName = Common.Common.CreateNo() + "." + filecombin[1];
                //Upload不存在则创建文件夹
                if (!System.IO.Directory.Exists(localPath))
                {
                    System.IO.Directory.CreateDirectory(localPath);
                }
                using (FileStream fs = System.IO.File.Create(Path.Combine(localPath, filePathName)))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                uploadFile.code = 0;
                uploadFile.src = Path.Combine("/Upload/", filePathName);
                uploadFile.msg = "上传成功";
                return Json(uploadFile);
            }
            catch (Exception)
            {
                uploadFile.code = -1;
                uploadFile.src = "";
                uploadFile.msg = "上传出错!程序异常";
                return Json(uploadFile);
            }
        }
    }
}
