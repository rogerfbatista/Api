using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Domain;
using Microsoft.Owin.Security.OAuth;

namespace WebApi.Security
{



    public class AuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IClienteBusiness _clienteBusiness;
        private HttpConfiguration _Configuration;

        public AuthAuthorizationServerProvider(IClienteBusiness clienteBusiness, HttpConfiguration config)
        {
            _clienteBusiness = clienteBusiness;
            _Configuration = config;
        }

        //=> Obter Perfil do usuario no retorno do acces_token
        private Dictionary<string, string> _roles;


        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            await Task.FromResult(context);
        }



        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var roles = new List<string>();
            _roles = new Dictionary<string, string>();

            context.OwinContext.Response.Headers.Remove("Cache-Control");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);


            try
            {
                //Todo Obter usuario do banco de dados
                var result = _clienteBusiness.Autenticar(context.UserName, context.Password);
                if (result != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Rogerio"));
                    roles.Add("Rogerio");

                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim("url", result.Ambiente));

                    identity.AddClaim(new Claim("porMinuto", "2"));

                    identity.AddClaim(new Claim("porHora", "10"));


                    var principal = new GenericPrincipal(identity, roles.ToArray());
                    Thread.CurrentPrincipal = principal;

                    // SwaggerConfig.Configuration.MessageHandlers.Add(new LogHandler());

                    //  _Configuration.MessageHandlers.Add(new LogHandler());

                    await Task.FromResult(context.Validated(identity));
                }
                else
                {
                    context.SetError("invalid_grant", "Usuario ou Senha Invalidos");
                }
            }
            catch (Exception ex)
            {

                context.SetError("invalid_grant", ex.Message);
            }
        }
    }
}