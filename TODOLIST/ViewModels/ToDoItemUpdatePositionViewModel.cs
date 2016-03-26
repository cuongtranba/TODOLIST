using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOLIST.ViewModels
{
    public class ToDoItemUpdatePositionViewModel:BaseViewModel
    {
        public int Order { get; set; }
    }
}