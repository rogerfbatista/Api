using System;

using System.Net.Http;

using System.Web.Http.Cors;

namespace WebApi.Security
{
    public class CorsPolicyFactory : ICorsPolicyProviderFactory
    {
        readonly ICorsPolicyProvider _provider = new MyCorsPolicyAttribute();


        ICorsPolicyProvider ICorsPolicyProviderFactory.GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return _provider;
        }
    }
}