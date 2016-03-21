using System.Collections.Generic;

namespace TODOLIST.Models.ViewModels
{
    public class ListTodoItemViewModel
    {
        public List<ToDoItemViewModel> Items { get; set; }

        public ListTodoItemViewModel()
        {
            Items=new List<ToDoItemViewModel>();
        }
    }
}