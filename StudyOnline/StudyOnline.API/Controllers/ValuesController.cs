﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyOnline.Entities.Models;
using StudyOnline.Service;

namespace StudyOnline.API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        TeacherService cal = new TeacherService();


        [HttpGet, ActionName("getcourseviewcount")]
        public IEnumerable<Section> Get()
        {
            return cal.GetSectionByCourseId(1);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
         [HttpPut, ActionName("get")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
