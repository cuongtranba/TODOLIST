using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;

namespace TODOLIST.Services.Implements
{
    public abstract class BaseService<T> where T : BaseEntity
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
        public void Update(T model, PropertyInfo[] propertiesToUpdate)
        {
            DbFactory.GetInstance().Set<T>().Attach(model);

            foreach (var p in propertiesToUpdate)
            {
                DbFactory.GetInstance().Entry(model).Property(p.Name).IsModified = true;
            }
        }

        public void Update<TModel>(TModel viewModel)
        {
            T entity = Mapper.Map<TModel, T>(viewModel);
            DbFactory.GetInstance().Set<T>().Attach(entity);
            foreach (var propertyInfo in viewModel.GetType().GetProperties())
            {
                DbFactory.GetInstance().Entry(entity).Property(propertyInfo.Name).IsModified = true;
            }
        }


        public virtual void Delete(T model)
        {
            model.IsDeleted = true;
        }
        public virtual void Add(T model)
        {
            DbSet.Add(model);
        }

        public virtual IQueryable<T> Get()
        {
            return DbSet.Where(c => c.IsDeleted == false);
        }

    }

}