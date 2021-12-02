using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShopCourseWorkFinal.Models
{
    public class Addons
    {
        public int Id { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(60 ,MinimumLength = 0)]
        public string AddonName { get; set; }

        [Range(0,200)]
        public double Weight { get; set; }
        public bool isToolKitIncluded { get; set; }
        public int Warranty { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}