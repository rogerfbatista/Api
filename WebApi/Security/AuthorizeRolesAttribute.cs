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