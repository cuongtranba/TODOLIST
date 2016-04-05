﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;
using TODOLIST.Services.Interfaces;
using TODOLIST.ViewModels;

namespace TODOLIST.Services.Implements
{
    public class ToDoItemService : BaseService<ToDoListItem>, IToDoItemService
    {
        public ToDoItemService(IDbFactory<ToDoListContext> dbFactory) : base(dbFactory)
        {

        }


        public void UpdatePosition(List<ToDoItemUpdatePositionViewModel> toDoItemUpdatePositionViewModel)
        {
            var model = Mapper.Map<List<ToDoItemUpdatePositionViewModel>, List<ToDoListItem>>(toDoItemUpdatePositionViewModel);
            foreach (var item in model)
            {
                Update(item, toDoItemUpdatePositionViewModel.GetType().GetProperties());
            }
        }

        public ListTodoItemViewModel GetToDoListItem()
        {
            var model = new ListTodoItemViewModel
            {
                Items = Get().Where(c => c.IsDone == false).ProjectTo<ToDoItemViewModel>().OrderBy(c => c.Order).ToList()
            };
            return model;
        }

        public void Add(AddToDoItemViewModel model)
        {
            var newitem = Mapper.Map<AddToDoItemViewModel, ToDoListItem>(model);
            base.Add(newitem);
            ChangeToDoListItemPosition();
        }

        public void MarkTaskDone(MarkTaskDoneViewModel taskDone)
        {
            Update(taskDone);
        }

        public List<TaskDoneViewModel> GetItemDone()
        {
            return Get().Where(c => c.IsDone).ProjectTo<TaskDoneViewModel>().ToList();
        }

        public void Delete(DeleteTaskViewModel model)
        {
            Update(model);
        }

        public void MarkAllTaskDone(List<MarkTaskDoneViewModel> models)
        {
            var entity = Mapper.Map<List<MarkTaskDoneViewModel>, List<ToDoListItem>>(models);
            if (entity.Any())
            {
                foreach (var toDoListItem in entity)
                {
                    Update(toDoListItem, models.GetType().GetProperties());
                }
            }
        }

        private void ChangeToDoListItemPosition()
        {
            var todolist = DbSet.ToList();
            foreach (var item in todolist)
            {
                item.Order += 1;
            }
        }

    }
}