﻿namespace TODOLIST.DbContext
{
    public interface IDbFactory<T>
    {
        T CreateInstance();
    }
}