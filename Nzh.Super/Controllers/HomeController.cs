using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nzh.Super;

namespace Nzh.Super.Controllers
{
    public class HomeController : BaseController
    {
        public override ActionResult Index(int? id)
        {
            ViewBag.RealName = Operator == null ? "" : Operator.RealName;
            ViewBag.HeadShot = Operator == null ? "" : Operator.HeadShot;
            return View(GetWebSiteInfo());
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}
