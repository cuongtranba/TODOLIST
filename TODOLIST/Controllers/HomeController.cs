using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Autofac;
using AutoMapper;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;
using TODOLIST.Services;
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
            var model = toDoItemService.GetAll().OrderByDescending(c=>c.Order).ToList();

            var listToDoViewModel = Mapper.Map<List<ToDoListItem>, ListTodoItemViewModel>((List<ToDoListItem>) model);

            return PartialView("ListToDoItem", listToDoViewModel);
        }

        [HttpPost]
        public JsonResult CreateTodo(ToDoItemViewModel toDoItemViewModel)
        {
            var model=Mapper.Map<ToDoItemViewModel, ToDoListItem>(toDoItemViewModel);
            toDoItemService.Add(model);
            return Json(new {issuccess = true});
        }

        [HttpPost]
        public JsonResult UpdatePosition(ToDoItemUpdatePositionViewModel toDoItemViewModel)
        {
            toDoItemService.UpdatePosition(toDoItemViewModel);
            return Json(new { issuccess = true });
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