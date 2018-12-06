using Autofac;
using Autofac.Integration.WebApi;
using Data.MsSqlDataAcceess.Repositories;
using Infrastructure.Data.Infrastructure;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Domain.Interfaces.Repositories;
using Services.Interfaces;
using Services;
using AutoMapper;

using WebApplication1.Mappings.Profiles;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            builder.Register(c =>
                    new MsSqlConnectionStringProvider(ConfigurationManager.ConnectionStrings["DefaultConnectionString"]
                        .ConnectionString))
                .As<IConnectionStringProvider>();

            builder.Register(c => new BuildingsRepository(c.Resolve<IConnectionStringProvider>()))
                .As<IBuildingsRepository>();

            builder.Register(c => new BuildingsService(c.Resolve<IBuildingsRepository>()))
                .As<IBuildingsService>();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .AsImplementedInterfaces();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            Mapper.Initialize(conf =>
            {
                var assembly = Assembly.GetExecutingAssembly();
                conf.AddProfiles(assembly);
                assembly = Assembly.GetAssembly(typeof(BuildingsService));
                conf.AddProfiles(assembly);
            });

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
