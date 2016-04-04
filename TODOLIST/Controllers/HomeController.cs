using System.Collections.Generic;
using System.Web.Mvc;
using TODOLIST.Services.Interfaces;
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
            toDoItemService.Add(newItem);
            return Json(new { isSuccess = true });
        }

        [HttpPost]
        public JsonResult MarkTaskDone(MarkTaskDoneViewModel taskDone)
        {
            toDoItemService.MarkTaskDone(taskDone);
            return Json(new { isSuccess = true });
        }

        [HttpPost]
        public JsonResult UpdatePosition(List<ToDoItemUpdatePositionViewModel> toDoItemViewModel)
        {
            toDoItemService.UpdatePosition(toDoItemViewModel);
            return Json(new { isSuccess = true });
        }

        [HttpPost]
        public JsonResult DeleteTask(DeleteTaskViewModel model)
        {
            toDoItemService.Delete(model);
            return Json(new { isSuccess = true });
        }

        [HttpPost]
        public JsonResult MarkAllTaskDone(List<MarkTaskDoneViewModel> models)
        {
            toDoItemService.MarkAllTaskDone(models);
            return Json(new { isSuccess = true });
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