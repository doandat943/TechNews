using Microsoft.EntityFrameworkCore;

namespace TechNews.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Menu> Menus { get; set; }
        
        public DbSet<Post> Posts { get; set; }

        public DbSet<AdminMenu> AdminMenus { get; set; }
    }
}