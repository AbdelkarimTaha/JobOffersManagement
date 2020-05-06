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

            if (!roleManager.RoleExists("Admin"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                ApplicationUser user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "Admin@JobOffer.com";

                var check = userManager.Create(user, "Admin@JobOffer.com12345");
                if (check.Succeeded)
                    userManager.AddToRole(user.Id, "Admin");
            }

        }
    }
}
