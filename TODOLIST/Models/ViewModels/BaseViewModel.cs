using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TODOLIST.Models.ViewModels
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}