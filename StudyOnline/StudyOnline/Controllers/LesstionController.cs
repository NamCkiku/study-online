using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyOnline.Controllers
{
    public class LesstionController : Controller
    {
        // GET: Lesstion
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _UpdateLesstion()
        {
            return PartialView();
        }
    }
}