using LearnVisualStudioAdmin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearnVisualStudioAdmin.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LearnVisualStudioAdmin.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LearnVisualStudioAdmin.Models.ApplicationDbContext";
        }

        protected override void Seed(LearnVisualStudioAdmin.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // TODO: Change this hardcoded admin password!!!
            // Remember: Passwords must be at least 6 characters.

            var user = userManager.FindByEmail("admin@learnvisualstudio.net");
            if (user == null)
            {
                user = new ApplicationUser { UserName = "Admin", Email = "admin@learnvisualstudio.net" };
                var result = userManager.Create(user, "YourPasswordHere");
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot create default admin account!");
                }
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var admin = roleManager.FindByName("Administrator");
            if (admin == null)
            {
                admin = new IdentityRole("Administrator");
                var result = roleManager.Create(admin);
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot create the Administrator role.");
                }
            }

            var author = roleManager.FindByName("Author");
            if (author == null)
            {
                author = new IdentityRole("Author");
                var result = roleManager.Create(author);
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot create the Author role.");
                }
            }

            var lifetime = roleManager.FindByName("Lifetime");
            if (lifetime == null)
            {
                lifetime = new IdentityRole("Lifetime");
                var result = roleManager.Create(lifetime);
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot create the Lifetime role.");
                }
            }


            var oneyear = roleManager.FindByName("1Year");
            if (oneyear == null)
            {
                oneyear = new IdentityRole("1Year");
                var result = roleManager.Create(oneyear);
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot create the 1Year role.");
                }
            }

            var free = roleManager.FindByName("Free");
            if (free == null)
            {
                free = new IdentityRole("Free");
                var result = roleManager.Create(free);
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot create the Free role.");
                }
            }

            if (user.Roles.FirstOrDefault(r => r.RoleId.ToString() == admin.Id.ToString()) == null)
            {
                userManager.AddToRole(user.Id, "Administrator");
            }

        }
    }
}
