namespace TODOLIST.Models.Entity
{
    public class ToDoListItem:BaseEntity
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }    
        public int Order { get; set; }
    }
}