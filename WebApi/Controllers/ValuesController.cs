using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Newtonsoft.Json;

namespace WebApi.Controllers
{

    public class ValuesController : BaseController
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

      

        public HttpResponseMessage Post([FromBody]PostRequest req)
        {

            return new HttpResponseMessage()
            {
                //   Content = new StringContent(req.value, System.Text.Encoding.Unicode, "application/json"),
                Content = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.Unicode),


            };

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
