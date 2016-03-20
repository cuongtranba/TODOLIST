using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;

namespace TODOLIST.Services.Implements
{
    public abstract class BaseService<T, V> where T : BaseEntity
    {
        private IDbFactory<ToDoListContext> DbFactory;
        protected DbSet<T> DbSet => DbFactory.GetInstance().Set<T>();
        protected BaseService(IDbFactory<ToDoListContext> dbFactory)
        {
            DbFactory = dbFactory;
        }

        public virtual void Update(T model)
        {
            DbFactory.GetInstance().Entry(model).State = EntityState.Modified;
        }
        public virtual void Delete(T model)
        {
            model.IsDeleted = true;
        }
        public virtual void Add(T model)
        {
            DbSet.Add(model);
        }

        public virtual IList<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual T GetById(V id)
        {
            return DbSet.Find(id);
        }

    }
}