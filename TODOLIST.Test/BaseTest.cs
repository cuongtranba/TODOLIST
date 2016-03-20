using System.Reflection;
using Autofac;

namespace TODOLIST.Test
{
    public class BaseTest
    {
        protected IContainer container = null;

        public BaseTest()
        {
            var builder = new ContainerBuilder();
            var business = Assembly.Load("TODOLIST");
            builder.RegisterAssemblyTypes(business).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            container = builder.Build();
        }
    }
}
