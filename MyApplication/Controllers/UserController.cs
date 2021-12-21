using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApplication.Tools;
using MyApplication.Models;

namespace MyApplication.Controllers
{
    [Filters.LoggedInAttribute]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Home()
        {
            try
            {
                ProfileTools Tools = new ProfileTools();
                User U = Tools.GetUserProfile(Guid.Parse(Session["LoggedInUser"].ToString()));
                ViewData["User"] = U;
                return View();
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
    }
}