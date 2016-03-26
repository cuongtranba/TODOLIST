using System;
using TODOLIST.Models.Entity;
using TODOLIST.ViewModels;

namespace TODOLIST.Services.Interfaces
{
    public interface IToDoItemService : IServices<ToDoListItem, int>
    {
        void UpdatePosition(ToDoItemUpdatePositionViewModel toDoItemUpdatePositionViewModel);
    }
}
