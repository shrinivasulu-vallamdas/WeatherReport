using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WeatherReport.Business.Class;
using WeatherReport.Business.Interface;

namespace WeatherReport.Initializer
{
    /// <summary>
    /// Bootstrap class for initializing Autofac
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Configure and register dependencies
        /// </summary>
        public static void Run()
        {
            
            var builder = new ContainerBuilder();
            builder.RegisterType<Builder>()
               .AsSelf()
               .As<IBuilder>();
            builder.RegisterApiControllers(Assembly.Load("WeatherReport"));

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(container));
            
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}