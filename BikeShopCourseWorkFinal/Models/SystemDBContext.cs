using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikeShopCourseWorkFinal.Models
{
    public class SystemDBContext:DbContext
    {
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Bikes> Bikes { get; set; }
        public DbSet<Addons> Addons { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
    }
}