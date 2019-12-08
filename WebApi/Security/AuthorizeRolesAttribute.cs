using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi.Security
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {

        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            try
            {
                // Obtém ou define um valor indicando se a solicitação se origina de um endereço local.

                var local = actionContext.RequestContext.IsLocal;
                //var localIP = ((System.Web.Http.Owin.OwinHttpRequestContext)actionContext.RequestContext.Configuration.["MS_OwinContext"]).LocalIpAddress;
                //var remotoip = ((System.Web.Http.Owin.OwinHttpRequestContext)actionContext.Request.Properties["MS_OwinContext"]).RemoteIpAddress;

              //  var user = actionContext.Reque.Get("User-Agent");

                  
                //NAVEGADOR       
                //var baseRequest = ((HttpContextWrapper)actionContext.Request.Properties["MS_RequestContext"]).Request;
                //var nav = baseRequest.Browser.Browser;
                //var mob = baseRequest.Browser.IsMobileDevice;




                // TODO OBTER DO BANCOS DE DADOS
                var identity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
                var claims = identity.Claims.ToList();

                await base.OnAuthorizationAsync(actionContext, cancellationToken);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}