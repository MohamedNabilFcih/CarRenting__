using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication1.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();   
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }

        public void CreateDefaultRolesAndUsers()
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!RoleManager.RoleExists("admins"))
            {
                role.Name = "admins";
                RoleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "mohamedadmin";
                user.Email = "mo@gmail.com";
                user.PhoneNumber = "01143450519";
                user.Usertype = "admin";
                user.ssn = "123";
                var check = UserManager.Create(user, "Mo@123");
                if (check.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "admins");
                }

            }
        }
    }
}
