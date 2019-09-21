using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebApi.Security;

[assembly: OwinStartup(typeof(WebApi.Startup))]

namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Injector.ConfiguracaoSimpleInjector.StartSimpleInjetor();
            ConfigureOAuth(app);

        }

        //public void Configuration(IAppBuilder app)
        //{
        //    Injector.ConfiguracaoSimpleInjector.StartSimpleInjetorTeste();
        //    ConfigureOAuth(app);

        //    HttpConfiguration config = new HttpConfiguration();
        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );

        //    app.UseWebApi(config);
        //}

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(3),
                Provider = new AuthAuthorizationServerProvider(Injector.ConfiguracaoSimpleInjector.IClienteBusiness)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
