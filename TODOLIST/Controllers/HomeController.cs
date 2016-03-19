using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using TODOLIST.DbContext;

namespace TODOLIST.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComponentContext componentContext;

        public HomeController(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public ActionResult Index()
        {
            return View();
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