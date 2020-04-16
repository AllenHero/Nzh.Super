using Microsoft.AspNetCore.Mvc;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Controllers.Permissions
{
    public class MenuRoleActionController : BaseController
    {
        private readonly IMenuRoleActionService service;

        public MenuRoleActionController(IMenuRoleActionService _service)
        {
            service = _service;
        }

        [HttpPost]
        public ActionResult InsertBatch(IEnumerable<MenuRoleActionModel> list, int roleId)
        {
            var result = service.SavePermission(list, roleId) > 0 ? SuccessTip() : ErrorTip();
            return Json(result);
        }
    }
}
