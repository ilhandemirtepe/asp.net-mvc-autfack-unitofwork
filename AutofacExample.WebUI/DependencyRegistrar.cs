using Autofac;
using Autofac.Integration.Mvc;
using AutofacExample.Services.IRepository;
using AutofacExample.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutofacExample.WebUI
{
    public static class DependencyRegistrar
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // MVC - OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // MVC - OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // MVC - OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // MVC - OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            //installation localization service
            builder.RegisterType<ProductServices>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            // MVC - Set the dependency resolver to be Autofac.


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}