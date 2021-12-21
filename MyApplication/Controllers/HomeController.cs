using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApplication.DAL;
using MyApplication.Models;
using System.Web.Helpers;

namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LoginUser(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                using (MyAppContext db = new MyAppContext())
                {
                    User u = db.Users.FirstOrDefault(v => v.Email == user.Mail);
                    if (u != null)
                    {
                        if (Crypto.VerifyHashedPassword(u.Password, user.Password))
                        {
                            Session["LoggedInUser"] = u.UserID;

                            return RedirectToAction("Home", "User");

                        }
                        else
                        {
                            ViewData["ErrorMessage"] = "Incorrect login details";
                            return View("Login");
                        }

                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "Incorrect login details.";
                        return View("Login");
                    }
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Incorrect login details";
                return View("Login");
            }
            
            
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult RegisterUser(RegisterModel R)
        {
            if (ModelState.IsValid)
            {
                Tools.RegisterTools Tool = new Tools.RegisterTools(R);
                User U = Tool.ReturnUserModel();
                if (Tool.EmailUnique())//Check if email is registered already
                {
                    if (Tool.RegisterUser())//Try to register user in database
                    {
                        TempData["RegistrationMessage"] = "Registration successful!";
                        return RedirectToAction("Index", "Home");//return View("~/Views/Home/Index.cshtml");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    
                } 
                else
                    ViewData["ErrorMessage"] = "Email address already in use.";
            }
            else
                return View("Register", R);

            
            ViewData["Message"] = "";
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session["LoggedInUser"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
            //return View("~/Views/Home/Index.cshtml");


        }
        public ActionResult Index()
        {

            MyAppContext db = new MyAppContext();
            List<User> UserList = db.Users.ToList();
            ViewData["Users"] = UserList;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}