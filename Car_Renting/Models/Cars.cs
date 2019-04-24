using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Car_Renting.Models
{
    public class Cars
    {
        public int id { get; set; }
        

        [DisplayName("Car Description")]
        public string cardesc{ get; set; }


        [DisplayName("Car Image")]
        public string carimg { get; set; }


        [DisplayName("Price for Day")]
        public int price { get; set; }

        [DisplayName("car name")]
        public int categoryid { get; set; }

        [DisplayName("Color")]
        public string color { get; set; }

        [DisplayName("Number Of Chairs")]
        public int numchairs { get; set; }

        [DisplayName("Model")]
        public string model { get; set; }

        [DisplayName("Avaliable")]
        public string avaliable { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser user { get; set; }

        public virtual category category { get; set; }


    }
}