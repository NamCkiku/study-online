using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyOnline.Entities;
using StudyOnline.Service;
using System.Web.Mvc;
using System.IO;

namespace StudyOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HomeIndex()
        {
            return View();
        }
        public ActionResult GetListCouse()
        {
            TeacherService ts = new TeacherService();
            return Json(ts.GetListByTearcherId(1), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult ContentCourse()
        {
            return View();
        }
        public ActionResult ViewVideo()
        {
            return View();
        }
        public ActionResult CourseManager()
        {
            return View();
        }
        public ActionResult CreateCourse()
        {
            return View();
        }

        public ActionResult CreateCourseManager()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCourseManager(HttpPostedFileBase file, HttpPostedFileBase filevideo)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Data/Images/"), fileName);
                file.SaveAs(path);
            }

            if (filevideo != null && filevideo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(filevideo.FileName);
                var path = Path.Combine(Server.MapPath("~/Data/Videos/"), fileName);
                filevideo.SaveAs(path);
            }

            return View();
        }
        public ActionResult CreateCourseContentManager()
        {
            return View();
        }
    }
}