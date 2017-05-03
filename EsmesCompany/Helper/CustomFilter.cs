using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace EsmesCompany.Helper
{
    public class CustomFilter : ActionFilterAttribute//, FilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Username"] == null)
            {
                filterContext.Result = new RedirectResult("~/Admin/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}