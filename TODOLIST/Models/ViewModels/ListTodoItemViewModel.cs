using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOLIST.Models.ViewModels
{
    public class ListTodoItemViewModel: BaseViewModel
    {
        public List<ToDoItemViewModel> Items { get; set; }
    }
}