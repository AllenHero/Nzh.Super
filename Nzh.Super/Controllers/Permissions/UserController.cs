﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nzh.Super.Common;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Controllers.Permissions
{
    public class UserController : BaseController
    {
        public IUserService userService { get; set; }

        public IRoleService roleService { get; set; }

        public SelectList RoleList { get { return new SelectList(roleService.GetRoleList(), "Id", "RoleName"); } }

        public override ActionResult Index(int? id)
        {
            ViewBag.RoleId = RoleList;
            base.Index(id);
            return View();
        }

        [HttpGet]
        public JsonResult List(UserModel filter, PageInfo pageInfo)
        {
            var result = userService.GetListByFilter(filter, pageInfo);
            return Json(result);
        }

        public ActionResult Detail(int Id)
        {
            var model = userService.GetDetail(Id);
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var model = userService.ReadModel(Id);
            ViewBag.RoleId = RoleList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            model.UpdateOn = DateTime.Now;
            model.UpdateBy = Operator.UserId;
            var result = userService.UpdateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        public ActionResult Add()
        {
            ViewBag.RoleId = RoleList;
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            model.CreateOn = DateTime.Now;
            model.CreateBy = Operator.UserId;
            model.PassWord = Md5.md5(Configs.GetValue("InitUserPwd"), 32);
            var result = userService.CreateModel(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var result = userService.DeleteModel(Id) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        [HttpPost]
        public ActionResult InitPwd(int Id)
        {
            var initPwd = Md5.md5(Configs.GetValue("InitUserPwd"), 32);
            UserModel model = new UserModel { Id = Id, PassWord = initPwd };
            var result = userService.InitPwd(model) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
    }
}
