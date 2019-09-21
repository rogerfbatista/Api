using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Owin.Hosting;

namespace WebApi.Teste
{
    [TestClass]
    public class UnitTest1
    {

        private  HttpClient _client;
  
        private  string Url = "https://localhost:44380/";

        [TestInitialize]
        public async Task Init()
        {
            //_webApp = WebApp.Start<Startup>(url: Url);
            //_client = new HttpClient
            //{
            //    BaseAddress = new Uri(Url)
            //};
        }


        [TestMethod]
        public async Task TesteToken()
        {

            //Startup owinStartup = new Startup();
            //Action<IAppBuilder> owinStartupAction = new Action<IAppBuilder>(owinStartup.Configuration);

            //using (var server = TestServer.Create<Startup>())
            //{
            //    var req = server.CreateRequest("api/token");
            //    req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //    req.And(x => x.Content = new StringContent("grant_type=password&username=rogerio&password=123", System.Text.Encoding.ASCII));
            //    var response = await req.GetAsync();

            //    // Did the request produce a 200 OK response?
            //    Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            //    // Retrieve the content of the response
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    // this uses a custom method for deserializing JSON to a dictionary of objects using JSON.NET
            //    Dictionary<string, object> responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

            //    // Did the response come with an access token?
            //    Assert.IsTrue(responseData.ContainsKey("access_token"));

            //}        

            using (WebApp.Start<Startup>(url: Url))
            {
                _client = new HttpClient
                {
                    BaseAddress = new Uri(Url)
                };


                var responseValue = await _client.GetAsync(Url + "api/Values");
                var result = await responseValue.Content.ReadAsStringAsync();

                Assert.IsTrue(result.Contains("Nome"));

            }
        }

    }
}

