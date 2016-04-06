using System.Collections.Generic;
using System.Web.Mvc;
using TODOLIST.Services.Interfaces;
using TODOLIST.Utility;
using TODOLIST.ViewModels;

namespace TODOLIST.Controllers
{
    public class HomeController : BaseController
    {

        private IToDoItemService toDoItemService;

        public HomeController(IToDoItemService toDoItemService)
        {
            this.toDoItemService = toDoItemService;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "ToDoList";
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetListToDoItem()
        {
            var model = toDoItemService.GetToDoListItem();
            return PartialView("ListToDoItem", model);
        }

        [HttpPost]
        public JsonResult CreateTodo(AddToDoItemViewModel newItem)
        {
            var id = toDoItemService.GetIdAfterAdd(newItem);
            return JsonHelper.SuccessJsonResult().Append(new { id });
        }

        public JsonResult GetTask()
        {
            return JsonHelper.SuccessJsonResult();
        }


        [HttpPost]
        public JsonResult MarkTaskDone(MarkTaskDoneViewModel taskDone)
        {
            toDoItemService.MarkTaskDone(taskDone);
            return JsonHelper.SuccessJsonResult();
        }

        [HttpPost]
        public JsonResult UpdatePosition(List<ToDoItemUpdatePositionViewModel> toDoItemViewModel)
        {
            toDoItemService.UpdatePosition(toDoItemViewModel);
            return JsonHelper.SuccessJsonResult();
        }

        [HttpPost]
        public JsonResult DeleteTask(DeleteTaskViewModel model)
        {
            toDoItemService.Delete(model);
            return JsonHelper.SuccessJsonResult();
        }

        [HttpPost]
        public JsonResult MarkAllTaskDone(List<MarkTaskDoneViewModel> models)
        {
            toDoItemService.MarkAllTaskDone(models);
            return JsonHelper.SuccessJsonResult();
        }

        [ChildActionOnly]
        public ActionResult ListItemDone()
        {
            return PartialView(toDoItemService.GetItemDone());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}