using System.Data.Entity.ModelConfiguration;
using TODOLIST.Models.Entity;

namespace TODOLIST.Models.EntityConfigurations
{
    public class ToDoListItemConfiguration: EntityTypeConfiguration<ToDoListItem>
    {
        public ToDoListItemConfiguration()
        {
            this.Map(c => c.MapInheritedProperties());
            this.Property(c => c.Description).HasMaxLength(100);
            this.Property(c => c.IsDone);
        }
    }
}