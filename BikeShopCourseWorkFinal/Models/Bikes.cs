using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShopCourseWorkFinal.Models
{
    public class Bikes
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string BikeName { get; set; }
        public bool IsCarbon { get; set; }
        public double Price { get; set; }

        [StringLength(4, MinimumLength = 1)]
        public string Size { get; set; }
        public double Weight { get; set; }
        public int Warranty { get; set; }
        public int SizesId { get; set; }
        public virtual Sizes Sizes { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}