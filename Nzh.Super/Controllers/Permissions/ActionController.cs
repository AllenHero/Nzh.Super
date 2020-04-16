using Microsoft.AspNetCore.Mvc;
using Nzh.Super.Common;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Controllers.Permissions
{
    public class ActionController : BaseController
    {
        private IActionService service;

        public IMenuService menuService { get; set; }

        public ActionController(IActionService _service)
        {
            service = _service;
        }

        [HttpGet]
        public JsonResult List(ActionModel filter, PageInfo pageInfo)
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
            ViewData["Position"] = EnumExt.GetSelectList(typeof(PositionEnum));
            var model = service.ReadModel(Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ActionModel model)
        {
            model.UpdateOn = DateTime.Now;
            model.UpdateBy = Operator.UserId;
            var result = service.UpdateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        public ActionResult Add()
        {
            ViewData["Position"] = EnumExt.GetSelectList(typeof(PositionEnum));
            return View();
        }

        [HttpPost]
        public ActionResult Add(ActionModel model)
        {
            model.CreateOn = DateTime.Now;
            model.CreateBy = Operator.UserId;
            var result = service.CreateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            //删除权限时,同时删除菜单权限,菜单角色权限记录
            var result = service.DeleteActionAllByActionId(Id) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        public ActionResult MenuActionList(int Id)
        {
            var model = menuService.ReadModel(Id);
            ViewBag.Id = model.Id;
            ViewBag.ParentId = model.ParentId;
            ViewBag.MenuName = model.MenuName;
            ViewData["AvailableMenuActionList"] = service.GetActionListByMenuId(Id);
            ViewData["MenuActionList"] = service.GetAll();
            return View();
        }
    }
}
