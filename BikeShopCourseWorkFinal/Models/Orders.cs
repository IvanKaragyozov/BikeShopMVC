using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShopCourseWorkFinal.Models
{
    public class Orders
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Time of Purchase")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd''hh:mm}")]
        public DateTime TimeOfPurchase { get; set; }
        public bool isForCommercialUse { get; set; }

        [StringLength(15, MinimumLength = 7)]
        public string PhoneNumber { get; set; }

        public int BikeId { get; set; }
        public int AddonsId { get; set; }
        public virtual Bikes Bikes { get; set; }
        public virtual Addons Addons { get; set; }
    }
}