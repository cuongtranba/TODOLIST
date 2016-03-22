namespace TODOLIST.DbContext
{
    public interface IDbFactory<T>
    {
        T GetInstance();
        void SaveChange();
    }
}