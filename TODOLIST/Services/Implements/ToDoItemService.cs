using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;
using TODOLIST.Services.Interfaces;
using TODOLIST.ViewModels;
using TODOLIST.Models;
namespace TODOLIST.Services.Implements
{
    public class ToDoItemService:BaseService<ToDoListItem,int>, IToDoItemService
    {
        public ToDoItemService(IDbFactory<ToDoListContext> dbFactory) : base(dbFactory)
        {

        }

        public void UpdatePosition(ToDoItemUpdatePositionViewModel toDoItemUpdatePositionViewModel)
        {
            var model = Mapper.Map<ToDoItemUpdatePositionViewModel, ToDoListItem>(toDoItemUpdatePositionViewModel);
            Update(model,c=>c.Order);
        }
    }
}