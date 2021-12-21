using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Models;
using System.Web.Helpers;

namespace MyApplication.Tools
{
    public class RegisterTools
    {
        User U;
        public RegisterTools(RegisterModel R)
        {
            U = new User();
            U.Name = R.Name;
            U.Lastname = R.Lastname;
            U.Email = R.Email;
            U.Password = Crypto.HashPassword(R.Password);
            R.Password = ""; //Remove unhashed password
        }

        public User ReturnUserModel()
        {
            return U;
        }

        public bool EmailUnique()//Controlling if the email address already exists in the database
        {
            User Us;
            try
            {
                using (DAL.MyAppContext db = new DAL.MyAppContext())
                {
                    Us = db.Users.FirstOrDefault(u => u.Email == U.Email);
                    if (Us == null)
                        return true;
                    else
                        return false;
                }
            }
            catch(Exception e)
            {
                
                return false;
            }
        }

        public bool RegisterUser()
        {
            try
            {
                using (DAL.MyAppContext db = new DAL.MyAppContext())
                {
                    db.Users.Add(U);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
    
}