using System.Collections.Generic;
using AutoMapper;
using TODOLIST.Models.Entity;
using TODOLIST.Models.ViewModels;
namespace TODOLIST
{
    public class AutoMapperBootStrapper
    {
        public static void BootStrap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ToDoListItem, ToDoItemViewModel>();
                cfg.CreateMap<List<ToDoListItem>, ListTodoItemViewModel>().ForMember(dest => dest.Items, opt => opt.MapFrom(
                                src => Mapper.Map<List<ToDoListItem>,
                                                  List<ToDoItemViewModel>>(src)));
            });
        }
    }


}