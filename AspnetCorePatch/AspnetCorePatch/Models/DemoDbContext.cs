using Microsoft.EntityFrameworkCore;

namespace AspnetCorePatch.Models
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
    }
}