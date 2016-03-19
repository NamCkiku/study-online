using StudyOnline.Entities.Models;
using StudyOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetListCouse()
        {
            TeacherService cs = new TeacherService();
            List<Tuple<User, Course>> lst = new List<Tuple<User, Course>>();
            lst = cs.GetListByTearcherId(1);
            return Json(lst, JsonRequestBehavior.AllowGet);
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