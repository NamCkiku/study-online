using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyOnline.Entities.Models;
using StudyOnline.Service.Users;
using StudyOnline.Service;

namespace StudyOnline.API.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        UserService cal = new UserService();


        TeacherService teacherService = new TeacherService();

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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
