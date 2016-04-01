using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOLIST.ViewModels
{
    public class AddToDoItemViewModel:BaseViewModel
    {
        public string Description { get; set; }
        public int Order { get; set; }
    }
}