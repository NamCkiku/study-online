using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyOnline.Entities;
using StudyOnline.Service;
using System.Web.Mvc;

namespace StudyOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
    }
}