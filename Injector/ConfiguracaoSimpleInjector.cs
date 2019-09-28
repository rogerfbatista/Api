using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Business;
using Data;
using Domain;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Injector
{
    public class ConfiguracaoSimpleInjector
    {
        public static IClienteBusiness IClienteBusiness;

        public static void StartSimpleInjetor()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
              
            container.Register<IClienteBusiness, ClienteBusiness>();
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Singleton);

            // Register your types, for instance using the scoped lifestyle:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
          container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            IClienteBusiness = container.GetInstance<IClienteBusiness>();


            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            //iniciar Map
            Data.RegisterMappings.Register();

           
        }


        public static Container StartSimpleInjetorTeste()
        {

           // GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), new TestAssembliesResolver());

           var container = new Container();


            //var container = new Container();
            //container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IClienteBusiness, ClienteBusiness>();
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Singleton);

            // Register your types, for instance using the scoped lifestyle:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            var ass = Assembly.GetExecutingAssembly();

           container.RegisterWebApiControllers(GlobalConfiguration.Configuration,ass);
       

            container.Verify();

            IClienteBusiness = container.GetInstance<IClienteBusiness>();


          //  GlobalConfiguration.Configuration.DependencyResolver =   new SimpleInjectorWebApiDependencyResolver(container);

            //iniciar Map
            Data.RegisterMappings.Register();

            return container;

        }


    }

    public class TestAssembliesResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}
