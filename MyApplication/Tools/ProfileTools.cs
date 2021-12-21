using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Models;

namespace MyApplication.Tools
{
    public class ProfileTools
    {
        public ProfileTools()
        {

        }
        public User GetUserProfile(Guid UserID)
        {
            try
            {
                DAL.MyAppContext db = new DAL.MyAppContext();
                User user = db.Users.FirstOrDefault(U => U.UserID == UserID);
                db.Dispose();
                user.Password = "";
                return user;
            }
            catch(Exception e)
            {
                User user = null;
                return user;
            }
        }
    }
}