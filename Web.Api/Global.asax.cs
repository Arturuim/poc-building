using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Data.MsSqlDataAcceess.Repositories;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Infrastructure;
using Services;
using Services.Interfaces;
using Services.Mappings.Profiles;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web.Api
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

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.UseDataContractJsonSerializer = true;

            var serviceAssembly = typeof(BuildingsService).Assembly;

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(Assembly.GetExecutingAssembly());
                cfg.AddProfiles(serviceAssembly);
            });

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.Register(c => new MsSqlConnectionStringProvider(ConfigurationManager.ConnectionStrings["Buildings"].ConnectionString))
                .As<IConnectionStringProvider>();

            builder.Register(c => new BuildingsRepository(c.Resolve<IConnectionStringProvider>()))
                .As<IBuildingsRepository>();

            builder.Register(c => new BuildingsService(c.Resolve<IBuildingsRepository>()))
                .As<IBuildingsService>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
