using System;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
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
            HttpConfiguration config = new HttpConfiguration();
            config.MessageHandlers.Add(new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));
            config.MessageHandlers.Add(new LogHandler());
            config.MessageHandlers.Add(new CustomThrottlingHandler());

            WebApiConfig.Register(config);
            Injector.ConfiguracaoSimpleInjector.StartSimpleInjetor(config);
            ConfigureOAuth(app, config);
            SwaggerConfig.Register(config);

            app.UseWebApi(config);

        }

        public void ConfigurationTeste(IAppBuilder app)
        {

            var con = Injector.ConfiguracaoSimpleInjector.StartSimpleInjetorTeste();



            HttpConfiguration config = new HttpConfiguration()
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(con),

            };

            ConfigureOAuth(app, config);
            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, HttpConfiguration config)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthAuthorizationServerProvider(Injector.ConfiguracaoSimpleInjector.IClienteBusiness, config)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
