using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using TODOLIST.DbContext;

namespace TODOLIST
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            RegisterMVC(builder);
            RegisterDbFactory(builder);
            RegisterServices(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }

        private static void RegisterDbFactory(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDbFactory<>).Assembly).AsClosedTypesOf(typeof(IDbFactory<>)).InstancePerRequest();
        }

        private static void RegisterMVC(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
        }
    }
}