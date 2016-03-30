using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyOnline.Service.Users;
using StudyOnline.Entities.Models;
using System.Web.Http.Cors;

namespace StudyOnline.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        //private readonly IUserService userService;
        //public UserController(IUserService userService)
        //{
        //    this.userService = userService;
        //}

        UserService userService = new UserService();
        // GET study-online/user
        public IEnumerable<User> Get()
        {
            var user = userService.ListAllUser();
            return user;

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
