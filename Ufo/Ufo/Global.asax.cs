﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Ufo.Repositories;
using Ufo.Services;

namespace Ufo
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
			var config = GlobalConfiguration.Configuration;

			builder.RegisterControllers(typeof(WebApiApplication).Assembly);
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// Register components

			builder.RegisterType<MissingPersonsRepository>().As<IMissingPersonsRepository>();
			builder.RegisterType<UfoService>().As<IUfoService>();
			builder.RegisterType<FileService>().As<IFileService>();
			builder.RegisterType<JsonSerializationService>().As<IJsonSerializationService>();
			builder.RegisterType<DataService>().As<IDataService>().SingleInstance();
			

			// Build container
			var container = builder.Build();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}
