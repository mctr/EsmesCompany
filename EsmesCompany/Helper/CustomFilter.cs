using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace EsmesCompany.Helper
{
    public class CustomFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextWrapper wrap = new HttpContextWrapper(HttpContext.Current);
            if (filterContext.HttpContext.Request.Cookies["Username"] == null || String.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["Username"].Value))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Admin" }, { "action", "Login" } });
            }
        }
    }
}