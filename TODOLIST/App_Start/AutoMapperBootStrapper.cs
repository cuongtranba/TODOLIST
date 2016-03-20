using AutoMapper;
using TODOLIST.Models.Entity;
using TODOLIST.Models.ViewModels;
namespace TODOLIST
{
    public class AutoMapperBootStrapper
    {
        public static void BootStrap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ToDoListItem, ToDoItemViewModel>();
            });

        }
    }


}