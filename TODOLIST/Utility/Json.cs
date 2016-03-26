using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TODOLIST.Utility
{
    public static class Json
    {
        public static JsonResult SuccessJsonResult()
        {
            var jsonResule = new JsonResult {Data = new {issuccess = true, JsonRequestBehavior.AllowGet}};
            return jsonResule;
        }

    }
}