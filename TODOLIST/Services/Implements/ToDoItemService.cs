using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Services.Implements
{
    public class ToDoItemService:BaseService<ToDoListItem,int>, IToDoItemService
    {
        public ToDoItemService(IDbFactory<ToDoListContext> dbFactory) : base(dbFactory)
        {

        }
    }
}