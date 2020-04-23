using JobOffersWebsite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

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
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("Admins"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);

                ApplicationUser user = new ApplicationUser();
                user.UserName = "Abdelkarim";
                user.Email = "Abdelkarim@gmail.com";

                var check = userManager.Create(user, "ADMIN@vidly.com123");
                if (check.Succeeded)
                    userManager.AddToRole(user.Id, "Admins");
            }

        }
    }
}
