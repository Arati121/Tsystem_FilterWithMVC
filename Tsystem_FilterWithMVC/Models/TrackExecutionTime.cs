using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace Tsystem_FilterWithMVC.Models
{
    public class TrackExecutionTime :Attribute,IActionFilter,IResultFilter
    {
        public void GetMesage(string msg)
        {
            File.AppendAllText(Path.GetFullPath(@"D:\AllsetupsfromC\Tsystem_FilterWithMVC\Tsystem_FilterWithMVC\Demo\test.txt"), msg);
          
                
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string msg = "\non Action Executed=>" + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string msg = "\non Action Executing=>" + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            string msg = "On result executed=>" + context.RouteData.Values["controller"].ToString() + "==>" +
                context.RouteData.Values["action"].ToString() + " " + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string msg = "On result executing=>" + context.RouteData.Values["controller"].ToString() + "==>" +
               context.RouteData.Values["action"].ToString() + " " + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }
    }
}
