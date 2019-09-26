using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Domain;
using WebApi.Atributtes;
using WebApi.Security;
using static WebApi.Atributtes.ExceptionAttribute;

namespace WebApi.Controllers
{
    [MyCorsPolicy]
    [AuthorizeRoles]
    [Exception]
    [RoutePrefix("api/Conta")]
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
        [ValidateModel]
        [Route("api/ContaTeste")]
        public HttpRequestMessage Post([FromBody]PostRequest req)
        {
            var http = new HttpRequestMessage()
            {
                Content = new StringContent(req.value, System.Text.Encoding.UTF8),

            };
            return http;
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
