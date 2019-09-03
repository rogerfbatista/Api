using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Filters;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using ICorsPolicyProvider = System.Web.Http.Cors.ICorsPolicyProvider;

namespace WebApi.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class MyCorsPolicyAttribute : ActionFilterAttribute, ICorsPolicyProvider
    {

        private readonly CorsPolicy _policy;

        public MyCorsPolicyAttribute()
        {
            // Create a CORS policy.
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
                SupportsCredentials = true,
                AllowAnyOrigin = true
            };

            var identity = (ClaimsIdentity) Thread.CurrentPrincipal.Identity;
            var claims = identity.Claims.ToList();

            var claimUrl = claims.FirstOrDefault(c => c.Type == "url")?.Value;

            if (!string.IsNullOrEmpty(claimUrl))
            {
                // Add allowed origins.
                _policy.Headers.Remove("Cache-Control");
                _policy.Origins.Add(claimUrl);

            }





        }


        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}