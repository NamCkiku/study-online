using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyOnline.Controllers
{
    public class SecctionController : Controller
    {
        // GET: Secction
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _UpdateSecction()
        {
            return PartialView();
        }
    }
}