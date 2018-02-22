using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Handlers;
using Newtonsoft.Json;
using CustomerFeedbackManagement.Models;

namespace CustomerFeedbackManagement.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private masterEntities1 myDb = new masterEntities1();

        [HttpGet]
        [Route("find/{id}")]
        public HttpResponseMessage find(int id)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(myDb.Testings.Single(p => p.Id == id)));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        [Route("find/all")]
        public HttpResponseMessage findAll()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(myDb.Testings.ToList()));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                //result.Content = new StringContent(JsonConvert.SerializeObject(myDb.Testings.ToList()));
                //result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                myDb.Testings.Remove(myDb.Testings.Single(p => p.Id == id));
                myDb.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public HttpResponseMessage insert(Testing obj)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                //result.Content = new StringContent(JsonConvert.SerializeObject(myDb.Testings.ToList()));
                //result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                myDb.Testings.Add(obj);
                myDb.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public HttpResponseMessage Update(Testing obj)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                //result.Content = new StringContent(JsonConvert.SerializeObject(myDb.Testings.ToList()));
                //result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var newObj = myDb.Testings.Single(p=> p.Id == obj.Id);
                newObj.data = obj.data;
                myDb.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
