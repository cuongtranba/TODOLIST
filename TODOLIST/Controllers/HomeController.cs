using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using AutoMapper;
using TODOLIST.DbContext;
using TODOLIST.Models.Entity;
using TODOLIST.Models.ViewModels;
using TODOLIST.Services;
using TODOLIST.Services.Interfaces;

namespace TODOLIST.Controllers
{
    public class HomeController : Controller
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
            var model = toDoItemService.GetAll();
            var productsDto = Mapper.Map<List<ToDoListItem>, ListTodoItemViewModel>((List<ToDoListItem>) model);

            return PartialView("ListToDoItem", productsDto);
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