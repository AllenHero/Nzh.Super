using Microsoft.AspNetCore.Mvc;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Controllers.Permissions
{
    public class MenuActionController : BaseController
    {
        private readonly IMenuActionService service;

        public MenuActionController(IMenuActionService _service)
        {
            service = _service;
        }

        [HttpPost]
        public ActionResult InsertBatch(IEnumerable<MenuActionModel> list, int menuId)
        {
            var result = service.SavePermission(list, menuId) > 0 ? SuccessTip() : ErrorTip();
            return Json(result);
        }
    }
}
