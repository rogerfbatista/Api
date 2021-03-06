﻿using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using WebApi.Atributtes;
using WebApi.OutputCache.V2;
using WebApi.Security;
using static WebApi.Atributtes.ExceptionAttribute;

namespace WebApi.Controllers
{

    [AuthorizeRolesAttribute]
    [ExceptionAttribute]
    [ValidateModelAttribute]
    public class BaseController : ApiController
    {
        public string Url;

        public static int Segundos
        {
            get { return 1; }
        }



        public BaseController()
        {
            var identity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var claims = identity.Claims.ToList();

            Url = claims.FirstOrDefault(c => c.Type == "url")?.Value;
        }

    }
}
