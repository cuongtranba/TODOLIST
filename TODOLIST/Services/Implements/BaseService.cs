using System;
using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;

namespace TODOLIST.Services.Implements
{
    public abstract class BaseService<T,V> where T : BaseEntity<V>
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

        //ref http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record
        public void Update(T model, params Expression<Func<T, object>>[] propertiesToUpdate)
        {
            DbFactory.GetInstance().Set<T>().Attach(model);
            foreach (var p in propertiesToUpdate)
            {
                DbFactory.GetInstance().Entry(model).Property(p).IsModified = true;
            }
        }
   
        public virtual void Delete(T model)
        {
            model.IsDeleted = true;
        }
        public virtual void Add(T model)
        {
            DbFactory.GetInstance().Entry(model).State=EntityState.Added;
        }

        public virtual V GetIdAfterAdd(T Model)
        {
            DbFactory.GetInstance().Entry(Model).State = EntityState.Added;
            DbFactory.GetInstance().SaveChange();
            return Model.Id;
        }


        public virtual IQueryable<T> Get()
        {
            return DbSet.Where(c => c.IsDeleted == false);
        }
    }
}