using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApplication.Tools;

namespace MyApplication.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
        [Filters.LoggedInAttribute]
        [HttpGet]
        public JsonResult GetEntries()
        {
            if (Session["LoggedInUser"] != null)
            {
                Guid UserID = Guid.Parse(Session["LoggedInUser"].ToString());
                CalendarTools Tool = new CalendarTools();
                return Tool.GetEntries(UserID);
            }
            else
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.DenyGet };
            
        }
    }
}