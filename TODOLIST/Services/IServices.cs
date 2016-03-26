using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TODOLIST.Services
{
    public interface IServices<T,V>
    {
        void Update(T model);
        void Update(T model, params Expression<Func<T, object>>[] propertiesToUpdate);
        void Delete(T model);
        void Add(T model);
        IList<T> GetAll();
        T GetById(V id);
    }
}
