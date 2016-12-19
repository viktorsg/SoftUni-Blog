using Microsoft.Owin;
using Owin;
using SoftUni_Blog.Migrations;
using SoftUni_Blog.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(SoftUni_Blog.Startup))]
namespace SoftUni_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDBContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
