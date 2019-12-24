using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //   GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Tarefa();
        }

        public void Tarefa()
        {
            ThreadPool.QueueUserWorkItem(ThreadProc);


        }

        static async void ThreadProc(Object stateInfo)
        {

            while (true)
            {

                var t = Task.Factory.StartNew(() => StartTarefa());

                t.Wait();

            }
        }

        public async static Task StartTarefa()
        {

            //WebRequest wr = WebRequest.Create("https://localhost:44380/home/index");
            ////  wr.Timeout = (int)TimeSpan.FromSeconds(50).Ticks;

            //try
            //{
            //    HttpWebResponse response = (HttpWebResponse)wr.GetResponse();

            //    await Task.Delay(TimeSpan.FromSeconds(20));
            //}
            //catch (Exception ex)
            //{

            //}


            var myClient = new WebClient();
            try
            {


                var response = myClient.DownloadString("https://localhost:44380/home/index");
                

                await Task.Delay(TimeSpan.FromSeconds(20));

            }
            catch (Exception ex)
            {


            }
        }
    }
}
