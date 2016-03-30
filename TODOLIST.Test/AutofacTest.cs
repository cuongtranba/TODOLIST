using Autofac;
using NUnit.Framework;
using TODOLIST.Models.Entity;
using TODOLIST.Services;
using TODOLIST.Services.Implements;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Test
{
    [TestFixture]
    public class AutofacTest:BaseTest
    {
        [Test]
        public void ShouldResolveService()
        {
            var services = container.Resolve<IServices<ToDoListItem>>();
            Assert.IsNotNull(services);
        }
    }
}
