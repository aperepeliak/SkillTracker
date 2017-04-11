namespace ST.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ST.DAL.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationContext context)
        {
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = SecurityRoles.Admin },
                new IdentityRole { Name = SecurityRoles.Manager },
                new IdentityRole { Name = SecurityRoles.Developer });

            if (!context.Users.Any(u => u.UserName == "admin@domain.com"))
            {
                var user = new ApplicationUser
                {
                    UserName  = "admin@domain.com",
                    FirstName = "Super",
                    LastName  = "Admin"
                };

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                userManager.Create(user, "password");
                userManager.AddToRole(user.Id, SecurityRoles.Admin);
            }
        }
    }
}
