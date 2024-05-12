using Microsoft.EntityFrameworkCore;

namespace TechNews.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<AdminMenu> AdminMenu { get; set; }
    }
}