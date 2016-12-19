using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SoftUni_Blog.Models
{
    public class BlogDBContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public static BlogDBContext Create()
        {
            return new BlogDBContext();
        }
    }
}