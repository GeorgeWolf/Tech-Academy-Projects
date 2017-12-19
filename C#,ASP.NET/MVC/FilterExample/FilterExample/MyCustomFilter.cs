using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterExample
{
    public class MyCustomActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Bob was all up in your OnActionExecuted.</p>");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.User.Identity.Name;
            var ipAddress = filterContext.HttpContext.Request.UserHostAddress;
            var timeRequested = DateTime.UtcNow;
            var url = filterContext.HttpContext.Request.RawUrl;

            var result = String.Format("<p>OnActionExecuting: {0} - {1} - {2} - {3}</p>", user, ipAddress, timeRequested, url);
            filterContext.HttpContext.Response.Write(result);

            // You would probably want to write this to a log file, database, etc.
        }
    }

    public class MyCustomResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>OnResultExecuted</p>");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>OnResultExecuting</p>");
        }
    }
}