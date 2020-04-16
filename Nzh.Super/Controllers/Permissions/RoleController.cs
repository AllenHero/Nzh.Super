using Microsoft.AspNetCore.Mvc;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Controllers.Permissions
{
    public class RoleController : BaseController
    {
        public IRoleService service { get; set; }

        public override ActionResult Index(int? id)
        {
            base.Index(id);
            return View();
        }

        [HttpGet]
        public JsonResult List(PageInfo pageInfo, RoleModel filter)
        {
            var result = service.GetListByFilter(filter, pageInfo);
            return Json(result);
        }

        public ActionResult Detail(int Id)
        {
            var model = service.ReadModel(Id);
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var model = service.ReadModel(Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RoleModel model)
        {
            model.UpdateOn = DateTime.Now;
            model.UpdateBy = Operator.UserId;
            var result = service.UpdateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RoleModel model)
        {
            model.CreateOn = DateTime.Now;
            model.CreateBy = Operator.UserId;
            var result = service.CreateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            //删除角色时,同时删除菜单角色权限记录
            var result = service.DeleteRoleAllByRoleId(Id) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        public ActionResult Assign(int Id)
        {
            ViewBag.RoleId = Id;
            return View();
        }
    }
}
