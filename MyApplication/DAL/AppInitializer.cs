using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Models;
using System.Web.Helpers;

namespace MyApplication.DAL
{
    public class MyAppInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<MyAppContext>
    {
        protected override void Seed(MyAppContext context)
        {
            var users = new List<User>
            {
                new User{UserID=Guid.NewGuid(),UserName="testuser1", Name="Anders", Lastname="Andersson",Email="test1@test.com", Password=Crypto.HashPassword("test1"), IsAdmin = true},
                new User{UserID=Guid.NewGuid(),UserName="testuser2", Name="Bengt", Lastname="Bengtsson",Email="test2@test.com", Password=Crypto.HashPassword("test2"), IsAdmin = false},
                new User{UserID=Guid.NewGuid(),UserName="testuser3", Name="Carl", Lastname="Carlsson",Email="test3@test.com", Password=Crypto.HashPassword("test3"),  IsAdmin = false}
            };
            foreach (var u in users)
                context.Users.Add(u);
            context.SaveChanges();

            var entries = new List<Entry>
            {
                new Entry{EntryID=Guid.NewGuid(), UserID = users.ElementAt(0).UserID, Title="test1 user1", StartTime = DateTime.Now.AddDays(1).ToString("yyyy'-'MM'-'dd'T'HH':'mm'-'ss"), Description= "Test av kalenderinlägg för user1: Anders", EndTime = DateTime.Now.AddHours(25).ToString("yyyy'-'MM'-'dd'T'HH':'mm'-'ss") },
                new Entry{EntryID=Guid.NewGuid(), UserID = users.ElementAt(1).UserID, Title="test1 user2", StartTime = DateTime.Now.AddDays(2).ToString("yyyy'-'MM'-'dd'T'HH':'mm'-'ss"), Description= "Test av kalenderinlägg för user2: Bengt", EndTime = DateTime.Now.AddHours(50).ToString("yyyy'-'MM'-'dd'T'HH':'mm'-'ss") },
                new Entry{EntryID=Guid.NewGuid(), UserID = users.ElementAt(2).UserID, Title="test1 user3", StartTime = DateTime.Now.AddDays(3).ToString("yyyy'-'MM'-'dd'T'HH':'mm'-'ss"), Description= "Test av kalenderinlägg för user3: Carl",EndTime = DateTime.Now.AddHours(73).ToString("yyyy'-'MM'-'dd'T'HH':'mm'-'ss") }

            };
            foreach (var e in entries)
                context.Entries.Add(e);
            context.SaveChanges();
        }
    }
}