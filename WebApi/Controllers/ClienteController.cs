﻿using NSwag.Annotations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.OutputCache.V2;

namespace WebApi.Controllers
{


    //8 hora

    [CacheOutput(ServerTimeSpan = 60 * 60 * 8)]
    public class ClienteController : BaseController
    {
        // GET: api/Cliente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
