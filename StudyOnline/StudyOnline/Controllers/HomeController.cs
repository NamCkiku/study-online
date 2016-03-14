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
            var listCourse = svCourse.getListCourse();
            return View(listCourse);
        }
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult ContentCourse()
        {
            return View();
        }
	}
}