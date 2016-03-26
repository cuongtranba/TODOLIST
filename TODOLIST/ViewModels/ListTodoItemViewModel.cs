using System.Collections.Generic;

namespace TODOLIST.ViewModels
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