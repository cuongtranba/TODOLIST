using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TODOLIST.Utility
{
    public static class JsonHelper
    {
        public static JsonResult SuccessJsonResult()
        {
            var jsonResule = new JsonResult {Data = new {isSuccess = true}};
            return jsonResule;
        }
        public static JsonResult FailJsonResult()
        {
            var jsonResule = new JsonResult { Data = new { isSuccess = false } };
            return jsonResule;
        }

        public static JsonResult Append(this JsonResult jsonResult, object dataAppend)
        {
            var data = JObject.Parse(JsonConvert.SerializeObject(jsonResult.Data));
            var newData = JObject.Parse(JsonConvert.SerializeObject(dataAppend));
            data.Merge(newData, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Concat
            });
            var jss = new JavaScriptSerializer();
            jsonResult.Data = jss.Deserialize<dynamic>(data.ToString(Formatting.None));
            jsonResult.ContentType = "application/json";
            return jsonResult;
        }
    }
}
