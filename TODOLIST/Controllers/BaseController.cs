using System.Web.Mvc;
using TODOLIST.DbContext;

namespace TODOLIST.Controllers
{
    public class BaseController : Controller
    {
        public IDbFactory<ToDoListContext> dbFactory { get; set; }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            dbFactory.SaveChange();
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var result = filterContext.Result as JsonResult;
            if (result != null)
            {
                result.JsonRequestBehavior=JsonRequestBehavior.AllowGet;
            }
        }
    }
}