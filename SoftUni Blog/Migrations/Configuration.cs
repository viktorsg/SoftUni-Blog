namespace SoftUni_Blog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoftUni_Blog.Models.BlogDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Blog.Models.BlogDbContext";
        }

        protected override void Seed(SoftUni_Blog.Models.BlogDBContext context)
        {
            if (!context.Roles.Any())
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "User");
            }

            if (!context.Users.Any())
            {
                this.CreateUser(context, "admin@admin.com", "Admin", "123");
                this.SetRoleToUser(context, "admin@admin.com", "Admin");
            }
        }

        private void CreateRole(BlogDBContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var result = roleManager.Create(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(BlogDBContext context, string email, string fullName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };

            var admin = new ApplicationUser
            {
                UserName = email,
                FullName = fullName,
                Email = email
            };

            var result = userManager.Create(admin, password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void SetRoleToUser(BlogDBContext context, string email, string role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = context.Users.Where(u => u.Email == email).First();

            var result = userManager.AddToRole(user.Id, role);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }
    }
}
