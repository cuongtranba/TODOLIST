using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOLIST.Services
{
    public interface IServices<T,V>
    {
        int Update(T model);
        int Delete(T model);
        int Add(T model);
        IList<T> GetAll();
        T GetById(V id);
    }
}
