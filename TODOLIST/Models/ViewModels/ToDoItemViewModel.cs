using TODOLIST.Models.Entity;

namespace TODOLIST.Models.ViewModels
{
    public class ToDoItemViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }    
    }
}