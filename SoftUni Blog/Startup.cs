using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoftUni_Blog.Startup))]
namespace SoftUni_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
