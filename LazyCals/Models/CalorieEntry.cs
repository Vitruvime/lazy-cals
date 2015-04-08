using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace LazyCals.Models
{
    public enum FoodQuality
    {
        Healthy,
        KindaHealthy,
        NotHealthy
    }
    public class CalorieEntry
    {
        public int ID { get; set; }
        public int Calories { get; set; }
        public DateTime DateAdded { get; set; }
        public FoodQuality Quality { get; set; }

    }
    public class CalorieEntryDBContext : DbContext
    {
         public CalorieEntryDBContext()
               : base("DefaultConnection")
        

        public DbSet<CalorieEntry> CalorieEntries { get; set; }
    }
    public class MyDbContext : IdentityDbContext<MyUser>
         {
             public MyDbContext() : base("DefaultConnection")
             {
             }
      
             protected override void OnModelCreating(DbModelBuilder modelBuilder)
             {
            public System.Data.Entity.DbSet<CalorieEntry> CalorieEntries { get; set; }
        }
}