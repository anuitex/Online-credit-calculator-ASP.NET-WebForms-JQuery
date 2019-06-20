namespace DAL.Migrations
{
    using CreditCalculator.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //ContextKey = "CreditCalculator.DAL.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "BankAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "BankAdmin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                user.IsAdmin = true;

                manager.Create(user, "Admin12345");
                manager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "bankAdmin@bankAdmin.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser();
                user.UserName = "bankAdmin@bankAdmin.com";
                user.Email = "bankAdmin@bankAdmin.com";
                //user.BankId = "725a0ca1-13b4-4f8e-a67b-915ca61b7291";

                manager.Create(user, "BankAdmin12345");
                manager.AddToRole(user.Id, "BankAdmin");

            }
            if (!context.Users.Any(u => u.UserName == "user@user.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser();
                user.UserName = "user@user.com";
                user.Email = "user@user.com";

                manager.Create(user, "User12345");
                manager.AddToRole(user.Id, "User");
            }
        }
    }
}
