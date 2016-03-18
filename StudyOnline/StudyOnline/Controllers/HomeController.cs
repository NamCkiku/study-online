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
        CourseService svCourse = new CourseService();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //var listCourse = svCourse.getListCourse();
            //return View(listCourse);
            return View();
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