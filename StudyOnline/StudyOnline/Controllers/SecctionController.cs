using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
     
        public ActionResult UpdateSection(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Data/Videos/"), fileName);
                file.SaveAs(path);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}