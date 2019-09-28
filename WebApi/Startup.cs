using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector.Integration.WebApi;
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

            HttpConfiguration config = new HttpConfiguration();
           

            app.UseWebApi(config);

        }

        public void ConfigurationTeste(IAppBuilder app)
        {
            
           var con = Injector.ConfiguracaoSimpleInjector.StartSimpleInjetorTeste();

            ConfigureOAuth(app);

            HttpConfiguration config = new HttpConfiguration()
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(con),
               
            };
            WebApiConfig.Register(config);
           
            app.UseWebApi(config);
        }

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
