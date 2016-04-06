using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;
using TODOLIST.Services.Interfaces;
using TODOLIST.ViewModels;

namespace TODOLIST.Services.Implements
{
    public class ToDoItemService : BaseService<ToDoListItem,int>, IToDoItemService
    {
        public ToDoItemService(IDbFactory<ToDoListContext> dbFactory) : base(dbFactory)
        {

        }


        public void UpdatePosition(List<ToDoItemUpdatePositionViewModel> toDoItemUpdatePositionViewModel)
        {
            var model = Mapper.Map<List<ToDoItemUpdatePositionViewModel>, List<ToDoListItem>>(toDoItemUpdatePositionViewModel);
            foreach (var item in model)
            {
                Update(item, c=>c.Order);
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

        public int GetIdAfterAdd(AddToDoItemViewModel model)
        {
            var newitem = Mapper.Map<AddToDoItemViewModel, ToDoListItem>(model);
            GetIdAfterAdd(newitem);
            ChangeToDoListItemPosition();
            return newitem.Id;
        }


        public void MarkTaskDone(MarkTaskDoneViewModel taskDone)
        {
            var entity = Mapper.Map<MarkTaskDoneViewModel, ToDoListItem>(taskDone);
            Update(entity,c=>c.IsDone);
        }

        public List<TaskDoneViewModel> GetItemDone()
        {
            return Get().Where(c => c.IsDone).ProjectTo<TaskDoneViewModel>().ToList();
        }

        public void Delete(DeleteTaskViewModel model)
        {
            var entity = Mapper.Map<DeleteTaskViewModel, ToDoListItem>(model);
            Update(entity,c=>c.IsDeleted);
        }

        public void MarkAllTaskDone(List<MarkTaskDoneViewModel> models)
        {
            var entity = Mapper.Map<List<MarkTaskDoneViewModel>, List<ToDoListItem>>(models);
            if (entity.Any())
            {
                foreach (var toDoListItem in entity)
                {
                    Update(toDoListItem, c => c.IsDone);
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