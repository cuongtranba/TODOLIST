using System;
using System.Collections.Generic;
using TODOLIST.Models.Entity;
using TODOLIST.ViewModels;

namespace TODOLIST.Services.Interfaces
{
    public interface IToDoItemService : IServices<ToDoListItem>
    {
        void UpdatePosition(List<ToDoItemUpdatePositionViewModel> toDoItemUpdatePositionViewModel);
        ListTodoItemViewModel GetToDoListItem();
        void Add(AddToDoItemViewModel model);
        void MarkTaskDone(MarkTaskDoneViewModel id);
        List<TaskDoneViewModel> GetItemDone();
        void Delete(DeleteTaskViewModel model);
    }
}
