using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyOnline.Entities;
using StudyOnline.Service;
using System.Web.Mvc;
using System.IO;
using StudyOnline.Entities.Models;

namespace StudyOnline.Controllers
{
    public class HomeController : Controller
    {

        StudyOnline.Entities.Models.StudyOnline db = new Entities.Models.StudyOnline();
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

        public ActionResult AddCourse(Course course, long id)
        {
            CourseService courseService = new CourseService();
            courseService.addCourse(course);
            StudyOnline.Entities.Models.User_Teacher_Course teaCourse = new User_Teacher_Course();
            teaCourse.CourseID = course.ID;
            teaCourse.UserID = id;
            teaCourse.CreateDate = DateTime.Now;
            db.User_Teacher_Course.Add(teaCourse);
            db.SaveChanges();
            return Json(course.ID, JsonRequestBehavior.AllowGet);
        }

       
         public ActionResult UpdateCouseCourse(Course course, long id)
        {
            CourseService courseService = new CourseService();
            StudyOnline.Entities.Models.Course teaCourse = courseService.ViewDetail(id);
            teaCourse.CourseName = course.CourseName;
            teaCourse.Description = course.Description;
            teaCourse.Avatar = course.Avatar;
            teaCourse.CourseCategoryID = course.CourseCategoryID;
            teaCourse.Content = course.Content;
            teaCourse.Price = course.Price;
            teaCourse.PriceSale = course.PriceSale;
            teaCourse.VideoIntroduce = course.VideoIntroduce;
            courseService.editCourse(teaCourse);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddSecction(StudyOnline.Entities.Models.Section secction)
        {
            SecctionService secctionService = new SecctionService();
            secctionService.CreateSection(secction);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddLesson(StudyOnline.Entities.Models.Lesson lesson)
        {
            LessonService lessonService = new LessonService();
            lessonService.CreateLesson(lesson);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeletSection(long id)
        {
            SecctionService secctionService = new SecctionService();
            secctionService.DeleteSection(id);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteLesson(long id)
        {
            LessonService lessonService = new LessonService();
            lessonService.DeleteLesson(id);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateLesson(Lesson lesson)
        {
             LessonService lessonService = new LessonService();
             lessonService.UpdateLesson(lesson);
             return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateSection(Section secction)
        {
            SecctionService secctionService = new SecctionService();
            secctionService.UpdateSection(secction);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UserStudyCourse(long userId, long courseId)
        {
            User_Study_Course us = db.User_Study_Course.FirstOrDefault(x => x.UserID == userId && x.CourseID == courseId);
            if (us != null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                User_Study_Course userCourse = new User_Study_Course();
                userCourse.UserID = userId;
                userCourse.CourseID = courseId;
                userCourse.Status = true;
                userCourse.CreateDate = DateTime.Now;
                db.User_Study_Course.Add(userCourse);
                db.SaveChanges();
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCount(long id)
        {
            var count = db.User_Study_Course.Where(x => x.CourseID == id).Count();
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateCourseContentManager()
        {
            return View();
        }
        public ActionResult CourseCategory()
        {
            return View();
        }
    }
}