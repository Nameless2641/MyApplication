using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Filters
{
    public class LoggedInAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["LoggedInUser"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "Controller", "Home" }, { "Action", "Login" } }); //Om ingen session finns, skicka till login view
                
            }
            else
            {

            }
            base.OnActionExecuting(filterContext);
            
        }
    }
}