using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace qiezi.service.content.common
{
    public class AutofacHelper
    {
        public static void Inject()
        {
            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterApiControllers(assembly);

            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterAssemblyTypes(assembly).Where(t => !t.IsAbstract && t.Name.EndsWith("Service")).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly).Where(t =>!t.IsAbstract && typeof(ApiController).IsAssignableFrom(t)).InstancePerLifetimeScope();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
        }
    }
}