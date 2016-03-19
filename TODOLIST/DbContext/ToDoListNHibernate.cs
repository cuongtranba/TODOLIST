using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOLIST.DbContext
{
    public class ToDoListNHibernate:IDbFactory<ToDoListNHibernate>
    {
        public ToDoListNHibernate CreateInstance()
        {
            return this;
        }
    }
}