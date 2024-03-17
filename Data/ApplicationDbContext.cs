using Microsoft.EntityFrameworkCore;
using VSBlog.Features.Articles.Models;
using VSBlog.Features.Comments.Models;

namespace VSBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
