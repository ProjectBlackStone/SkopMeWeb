using SkopMe.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Thinktecture.IdentityModel.Authorization.Mvc;

namespace SkopMe.WebApi.Controllers
{
    [TokenValidationFilter]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "id:value1", "content:value2" };            
        }

        // GET api/values
        [HttpGet]
        public HttpResponseMessage Test()
        {
            HttpResponseMessage msg = new HttpResponseMessage { Content = new StringContent(@"{""id"":1,""content"":""Test1""}", System.Text.Encoding.UTF8, "application/json")   };
            msg.Headers.Add("Authorization-Token", "ACBCCC");
            return msg;
            //return new string[] { "id:value1", "content:value2" };
            //return @"{""id"":1,""content"":""Test1""}";
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}