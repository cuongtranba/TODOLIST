using System.Linq;
using System.Reflection;

namespace TODOLIST.Services
{
    public interface IServices<T>
    {
        void Update(T model);
        void Update(T model, PropertyInfo[] propertiesToUpdate);
        void Delete(T model);
        void Add(T model);
        IQueryable<T> Get();
    }
}
