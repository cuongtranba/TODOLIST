using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TODOLIST.Models.Entity;

namespace TODOLIST.Services.Implements
{
    public abstract class BaseService<T,V> where T:BaseEntity
    {
        
        public virtual int Update(T model)
        {
            throw new NotImplementedException();
        }
        public virtual int Delete(T model)
        {
            throw new NotImplementedException();
        }
        public virtual int Add(T model)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(V id)
        {
            throw new NotImplementedException();
        }

    }
}