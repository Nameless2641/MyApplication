using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyApplication.DAL
{
    public class MyAppContext:DbContext
    {
        public MyAppContext ():base("AppContext")
        {
            this.Configuration.LazyLoadingEnabled = false; //Lazy loading = dåligt
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Ta bort plural i tabellnamn
        }
    }
}