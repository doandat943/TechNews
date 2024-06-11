using Microsoft.EntityFrameworkCore;

namespace TechNews.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Account> Account { get; set; }
        
        public DbSet<Menu> Menu { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<AdminMenu> AdminMenu { get; set; }

        public DbSet<AboutUs> AboutUs { get; set; }
    }
}