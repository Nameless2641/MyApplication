using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Models;
using System.Web.Mvc;

namespace MyApplication.Tools
{
    public class CalendarTools
    {
        public CalendarTools()
        {

        }

        public JsonResult GetEntries(Guid UserID)
        {
            try
            {
                List<Entry> Entries;
                using (DAL.MyAppContext db = new DAL.MyAppContext())
                {
                   Entries = db.Entries.Where(E => E.UserID == UserID).ToList();
                }
               
                return new JsonResult { Data = Entries, JsonRequestBehavior =JsonRequestBehavior.AllowGet };
            }
            catch(Exception e)
            {
                return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.DenyGet };
            }

            
        }
            
    }
}