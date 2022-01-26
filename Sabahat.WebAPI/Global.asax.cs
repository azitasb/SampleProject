using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Sabahat.Data.Users;
using Sabahat.Business.Users;
using SimpleInjector.Integration.WebApi;
using System.Web.Optimization;

namespace Sabahat.WebAPI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IUserData, UserData>(Lifestyle.Scoped);
            container.Register<IUserBusiness, UserBusiness>(Lifestyle.Scoped);
            //container.Register<context>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Database.SetInitializer(new PersonInitializer());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}