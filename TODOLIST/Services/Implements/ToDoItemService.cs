using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;
using TODOLIST.Services.Interfaces;
using TODOLIST.ViewModels;
using TODOLIST.Models;
namespace TODOLIST.Services.Implements
{
    public class ToDoItemService : BaseService<ToDoListItem>, IToDoItemService
    {
        public ToDoItemService(IDbFactory<ToDoListContext> dbFactory) : base(dbFactory)
        {

        }

        public void UpdatePosition(List<ToDoItemUpdatePositionViewModel> toDoItemUpdatePositionViewModel)
        {
            var model = Mapper.Map<List<ToDoItemUpdatePositionViewModel>,List< ToDoListItem>>(toDoItemUpdatePositionViewModel);
            foreach (var item in model)
            {
                Update(item, c => c.Order);
            }
        }

        public ListTodoItemViewModel GetToDoListItem()
        {
            var model = new ListTodoItemViewModel
            {
                Items = Get().ProjectTo<ToDoItemViewModel>().OrderBy(c=>c.Order).ToList()
            };
            return model;
        }
    }
}