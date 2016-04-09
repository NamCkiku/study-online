using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyOnline.Entities.Models;
using StudyOnline.Service;

namespace StudyOnline.API.Controllers
{
    public class TeacherCourseController : ApiController
    {
        // GET api/teachercourse
        TeacherService teacherService = new TeacherService();
        CourseCategoryService cal = new CourseCategoryService();
        
        [HttpGet, ActionName("getcourseviewcount")]
        public IEnumerable<Tuple<User, Course>> Get()
         {
            return teacherService.GetListByTearcherId(1).OrderByDescending(x => x.Item2.ViewCount).Skip(1).Take(4);
        }


        [HttpGet, ActionName("getcoursecreatedate")]
        public IEnumerable<Tuple<User, Course>> GetListByTearcherCreateDate()
        {
            return teacherService.GetListByTearcherId(1).OrderByDescending(x => x.Item2.CreateDate).Skip(1).Take(4);

        }

        [HttpGet, ActionName("getcourseprice")]
        public IEnumerable<Tuple<User, Course>> GetListByTearcherPrice()
        {
            return teacherService.GetListByTearcherId(1).OrderByDescending(x => x.Item2.CreateDate).Where(x => x.Item2.Price == 0);

        }

        [HttpGet, ActionName("getcoursebyid")]
        public IEnumerable<Tuple<User, Course>> GetListByCourseById(long id)
        {
            return teacherService.GetListByTearcherId(1).Where(x => x.Item2.ID == id);

        }

        [HttpGet, ActionName("getcoursebycategoryid")]
        public IEnumerable<Tuple<User, Course>> GetListByCourseByCategoryId(long id)
        {
            return teacherService.GetListByTearcherId(1).Where(x => x.Item2.CourseCategoryID == id);

        }

        [HttpGet, ActionName("getsectionbycourseid")]
        public IEnumerable<Section> GetListSectionByCourseId(long id)
        {
            return teacherService.GetSectionByCourseId(id);

        }

        [HttpGet, ActionName("getlessonbysectionid")]
        public IEnumerable<Lesson> GetListLessonBySection()
        {
            return teacherService.GetLessonBySection();

        }

        [HttpGet, ActionName("getcoursecategory")]
        public IEnumerable<CourseCategory> GetListCourseCategory()
        {
            return cal.ListAllCourseCategory();
        }

             [HttpGet, ActionName("getsecctionbyid")]
        public IEnumerable<Section> GetSecctionById(long id)
        {
            SecctionService secctionService = new SecctionService();
            return secctionService.ListAllSection().Where(x=>x.CourseID==id).ToList();
        }

             [HttpGet, ActionName("getlessonbyid")]
             public IEnumerable<Lesson> GetListLessonById(long id)
             {
                 return teacherService.GetLessonBySection().Where(x=>x.ID==id);

             }

        // GET api/teachercourse/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/teachercourse
        public void Post([FromBody]string value)
        {
        }

        // PUT api/teachercourse/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teachercourse/5
        public void Delete(int id)
        {
        }
    }
}
