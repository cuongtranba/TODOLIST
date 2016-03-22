using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using TODOLIST.Models.Entity;

namespace TODOLIST.DbContext
{
    public class ToDoListContext:System.Data.Entity.DbContext,IDbFactory<ToDoListContext>
    {
        public ToDoListContext():base("ToDoListConnectionString")
        {
            
        } 

        public DbSet<ToDoListItem> ToDoListItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => !String.IsNullOrEmpty(type.Namespace))
               .Where(type => type.BaseType != null && type.BaseType.IsGenericType
            && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }

        public ToDoListContext GetInstance()
        {
            return this;
        }

        public void SaveChange()
        {
            SaveChanges();
        }
    }
}