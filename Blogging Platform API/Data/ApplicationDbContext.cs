using Microsoft.EntityFrameworkCore;

namespace Blogging_Platform_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
        }
    }
}
