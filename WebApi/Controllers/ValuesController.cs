using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using WebApi.Security;

namespace WebApi.Controllers
{
    [MyCorsPolicy]
    [AuthorizeRoles]
    public class ValuesController : ApiController
    {
        private readonly Domain.IClienteBusiness _clienteBusiness;
        public ValuesController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }
        // GET api/values
        public IEnumerable<object> Get()
        {
            var list = _clienteBusiness.ObterTodos();
            return list;
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
