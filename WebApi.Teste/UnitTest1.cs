using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;

namespace WebApi.Teste
{
    [TestClass]
    public class UnitTest1
    {

        private HttpClient _client;

        private string TOKEN;

        private TestServer SERVER;

        [TestInitialize]
        public async Task ObterTokenValido()
        {

            Startup owinStartup = new Startup();
            Action<IAppBuilder> owinStartupAction = new Action<IAppBuilder>(owinStartup.ConfigurationTeste);

            SERVER = TestServer.Create(owinStartupAction);


            var req = SERVER.CreateRequest("api/token");
            req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            req.And(x => x.Content = new StringContent("grant_type=password&username=rogerio&password=123", System.Text.Encoding.ASCII));
            var response = await req.GetAsync();

            // Did the request produce a 200 OK response?
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            // Retrieve the content of the response
            string responseBody = await response.Content.ReadAsStringAsync();
            // this uses a custom method for deserializing JSON to a dictionary of objects using JSON.NET
            Dictionary<string, object> responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

            TOKEN = responseData["access_token"].ToString();

            // Did the response come with an access token?
            Assert.IsTrue(responseData.ContainsKey("access_token"));
        }





        [TestMethod]
        public async Task ObterListaValida()
        {


            _client = SERVER.HttpClient;
            _client.DefaultRequestHeaders.Add($"Authorization", "Bearer " + TOKEN);


            var responseValue = await SERVER.CreateRequest("api/values")
                .AddHeader("Authorization", "Bearer " + TOKEN)
                .And(x => x.Content = new StringContent("", System.Text.Encoding.ASCII))
                .GetAsync();

            var result = await responseValue.Content.ReadAsStringAsync();

            Assert.IsTrue(result.Contains("Nome"));

        }

        [TestMethod]
        public async Task ObterPostValido()
        {

            var objParametro = new
            {
                value = "teste"
            };

            var json = JsonConvert.SerializeObject(objParametro);


            var resp = SERVER.CreateRequest("api/values")
                             .AddHeader("Authorization", "Bearer " + TOKEN)
                               .And(x => x.Content = new StringContent(json, System.Text.Encoding.Unicode, "application/json"));


            var responseValue = await resp.PostAsync();

            var result = await responseValue.Content.ReadAsStringAsync();
            Assert.AreEqual(responseValue.StatusCode, HttpStatusCode.OK);

            Assert.IsTrue(result.Contains("teste"));

        }


        [TestMethod]
        public async Task ObterPostInvalido()
        {

            var objParametro = new
            {
                value = ""
            };

            var json = JsonConvert.SerializeObject(objParametro);


            var resp = SERVER.CreateRequest("api/values")
                             .AddHeader("Authorization", "Bearer " + TOKEN)
                               .And(x => x.Content = new StringContent(json, System.Text.Encoding.Unicode, "application/json"));


            var responseValue = await resp.PostAsync();

            var result = await responseValue.Content.ReadAsStringAsync();
            Assert.AreEqual(responseValue.StatusCode, HttpStatusCode.BadRequest);

            Assert.IsTrue(result.Contains("Obrigatorio"));

        }
    }

}




