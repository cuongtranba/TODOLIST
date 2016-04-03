using System.Collections.Generic;
using AutoMapper;
using TODOLIST.Models.Entity;
using TODOLIST.ViewModels;

namespace TODOLIST
{
    public class AutoMapperBootStrapper
    {
        public static void BootStrap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ToDoListItem, ToDoItemViewModel>().ReverseMap();
                cfg.CreateMap<ToDoListItem, ToDoItemUpdatePositionViewModel>().ReverseMap();
                cfg.CreateMap<List<ToDoListItem>, ListTodoItemViewModel>().ForMember(dest => dest.Items, opt => opt.MapFrom(
                                src => Mapper.Map<List<ToDoListItem>,
                                                  List<ToDoItemViewModel>>(src))).ReverseMap();
                cfg.CreateMap<AddToDoItemViewModel, ToDoListItem>();
                cfg.CreateMap<MarkTaskDoneViewModel, ToDoListItem>();
                cfg.CreateMap<ToDoListItem, TaskDoneViewModel>();
                cfg.CreateMap<DeleteTaskViewModel, ToDoListItem>();
            });
        }
    }


}