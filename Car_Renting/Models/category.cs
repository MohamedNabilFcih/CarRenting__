using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Renting.Models
{
    public class category
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "car type")]
        public string categoryname { get; set; }
        [Required]
        [Display(Name = " type description ")]
        public string categorydescription { get; set; }

        public virtual ICollection<Cars> cars{ get; set; }


    }
}



