using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyOnline.Entities.Models;
using StudyOnline.Service.Users;

namespace StudyOnline.API.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        UserService cal = new UserService();

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
