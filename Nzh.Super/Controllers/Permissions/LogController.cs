using Microsoft.AspNetCore.Mvc;
using Nzh.Super.IService;
using Nzh.Super.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nzh.Super.Controllers.Permissions
{
    public class LogController : BaseController
    {
        private readonly ILogService service;

        public LogController(ILogService _service)
        {
            service = _service;
        }

        [HttpGet]
        public JsonResult List(LogModel filter, PageInfo pageInfo)
        {
            var result = service.GetListByFilter(filter, pageInfo);
            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var result = service.DeleteModel(Id) ? SuccessTip() : ErrorTip();
            return Json(result);
        }

        [HttpPost]
        public ActionResult BatchDel(IEnumerable<LogModel> list)
        {
            string where = "";
            List<LogModel> logModelList = list as List<LogModel>;
            foreach (var item in list)
            {
                where += item.Id + ",";
            }
            where = "Where Id in (" + where.Substring(0, where.Length - 1) + ")";
            var result = service.DeleteByWhere(where) ? SuccessTip() : ErrorTip();
            return Json(result);
        }
    }
}
