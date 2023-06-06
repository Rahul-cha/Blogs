using BlogWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
         
        public DbSet<UserLogin> Logins { get; set; }

        public DbSet<BlogPost> Blogs { get; set; }

        public DbSet<UserDetails> Details { get; set; }
    }
}
