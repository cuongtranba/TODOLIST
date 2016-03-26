namespace TODOLIST.ViewModels
{
    public class ToDoItemViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int Order { get; set; }
    }
}