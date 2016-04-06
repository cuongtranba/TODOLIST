using System;

namespace TODOLIST.Models.Entity
{
    public class ToDoListItem : BaseEntity<int>
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int Order { get; set; }
        public DateTime? DoneTime { get; set; }
    }
}