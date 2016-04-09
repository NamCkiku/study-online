using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyOnline.Entities.Models;
using StudyOnline.Service.Users;
using StudyOnline.Service;
using StudyOnline.Entities.ModelsView;

namespace StudyOnline.API.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        UserService cal = new UserService();


        TeacherService teacherService = new TeacherService();
        CourseService courseService = new CourseService();

        [HttpGet, ActionName("list")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet, ActionName("getuserbyid")]
         public IEnumerable<User> GetUserById(long id)
         {
             return cal.GetUserById(id);
         }

        [HttpGet, ActionName("getlistcoursebyuser")]
        public IEnumerable<UserCourseModels> GetListCourseById(long id)
        {
            return cal.GetListByTearcherId(id);
        }

        [HttpGet, ActionName("getcourseviewcount")]
        public IEnumerable<Tuple<User, Course>> GetCourse()
        {
            return teacherService.GetListByTearcherId(1).OrderByDescending(x => x.Item2.ViewCount).Skip(1).Take(4);
        }

        

        // GET api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
         [HttpPost, ActionName("addcourse")]
        public void Post(Course course)
        {
            courseService.addCourse(course);
        }

        // PUT api/user/5
        [ ActionName("demo2")]
        public void Put(int id, [FromBody]string value)
        {
            int a = id;
        }

         [HttpPut, ActionName("demo")]
        public void TestMultipleSimpleValues(Course course,string id)
        {
            courseService.addCourse(course);
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
