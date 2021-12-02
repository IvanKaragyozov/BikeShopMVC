using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShopCourseWorkFinal.Models
{
    public class Sizes
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public virtual ICollection<Bikes> Bikes { get; set; }
    }
}