using System;

namespace TODOLIST.ViewModels
{
    public class MarkTaskDoneViewModel : BaseViewModel
    {
        public bool IsDone { get; set; }

        public DateTime? DoneTime
        {
            get
            {
                if (IsDone)
                {
                    return DateTime.Now;
                }
                return null;
            }
        }
    }
}