using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Car_Renting.Models
{
    public class RentCar
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string location { get; set; }

        [Required]
        [Display(Name = "Pick Up Date")]
        public DateTime PickUp { get; set; }

        [Required]
        [Display(Name = "Drop off Date ")]
        public DateTime DropOff { get; set; }

        [Display(Name = "Date Of Request")]
        public DateTime date { get; set; }

 



        public int CarId { get; set; }
        public string UserId { get; set; }
        public string UserUserName { get; set; }
        public virtual Cars car { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}