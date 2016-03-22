using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODOLIST.DbContext;

namespace TODOLIST.Controllers
{
    public class BaseController: Controller
    {
        public IDbFactory<ToDoListContext> dbFactory { get; set; }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            dbFactory.SaveChange();
        }
    }
}