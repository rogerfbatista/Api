using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApiThrottle;

namespace WebApi.Security
{
    public class CustomThrottlingHandler : ThrottlingHandler
    {
        public CustomThrottlingHandler()
            :base( )
        {
            base.Policy = new ThrottlePolicy(1,3)
            {
                IpThrottling = true,
                //scope to clients
                ClientThrottling = true,
             
                EndpointThrottling = true

            };
            Repository = new MemoryCacheRepository();
        }
        protected override RequestIdentity SetIdentity(HttpRequestMessage request)
        {
            
            var identity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var claims = identity.Claims.ToList();

            var porMinuto = string.IsNullOrEmpty(claims.FirstOrDefault(c => c.Type == "porMinuto")?.Value) ? 3 : Convert.ToInt64(claims.FirstOrDefault(c => c.Type == "porMinuto")?.Value);
            var porHora = string.IsNullOrEmpty(claims.FirstOrDefault(c => c.Type == "porHora")?.Value) ? 60 : Convert.ToInt64(claims.FirstOrDefault(c => c.Type == "porHora")?.Value);

            base.Policy = new ThrottlePolicy(null,porMinuto,porHora)
            {
                IpThrottling = true,
                //scope to clients
                ClientThrottling = true,

                EndpointThrottling = true

            };
            Repository = new MemoryCacheRepository();
                   

           return base.SetIdentity(request);
        }
        protected override Task<HttpResponseMessage> QuotaExceededResponse(HttpRequestMessage request, object content, HttpStatusCode responseCode, string retryAfter)
        {
            return base.QuotaExceededResponse(request, content, responseCode, retryAfter);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}