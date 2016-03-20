using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOLIST.Services
{
    public interface IServices<T,V>
    {
        void Update(T model);
        void Delete(T model);
        void Add(T model);
        IList<T> GetAll();
        T GetById(V id);
    }
}
