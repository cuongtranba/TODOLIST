using System.Linq;
using System.Reflection;

namespace TODOLIST.Services
{
    public interface IServices<T,V> 
    {
        void Update(T model);
        void Delete(T model);
        void Add(T model);
        V GetIdAfterAdd(T model);
        IQueryable<T> Get();
    }
}
