using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Car_Renting.Models;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "SSN")]
        public string ssn { get; set; }

        [Display(Name = "wallet")]  
        public int wallet { get; set; }


        [Display(Name = " Preferred car type")]
        public string PreferredCart { get; set; }
        public string IsBlocked { get; set; }


        public string Usertype { get; set; }


        public virtual  ICollection<Cars> car { get; set; }




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Car_Renting.Models.category> categories { get; set; }

        public System.Data.Entity.DbSet<Car_Renting.Models.Cars> Cars { get; set; }

        public System.Data.Entity.DbSet<Car_Renting.Models.RentCar> RentCars { get; set; }

    }
}