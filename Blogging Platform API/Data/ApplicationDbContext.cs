using Blogging_Platform_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogging_Platform_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
