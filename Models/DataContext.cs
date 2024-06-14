using Microsoft.EntityFrameworkCore;
using TechNews.Ultilities;

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

        public DbSet<Analyst> Analyst { get; set; }

        public void SeedData()
        {
            if (!AboutUs.Any())
            {
                AboutUs.AddRange(
                    new AboutUs { Id = 1, WebName = "TechNews", AdminName = "Quản trị viên", AdminAvatar = "", Email = "admin@technews.com", Number = "0989123456", Address = "Vinh University", Content = "We are TechNews", Image = "", Facebook = "facebook.com", Instagram = "instagram.com", Linkedin = "linkedin.com", Twitter = "twitter.com", Youtube = "youtube.com" }
                );

                Role.AddRange(
                    new Role {RoleId = 1, RoleName = "Người dùng"},
                    new Role {RoleId = 2, RoleName = "Tác giả"},
                    new Role {RoleId = 3, RoleName = "Quản trị viên"}
                );

                Gender.AddRange(
                    new Gender {GenderId = 1, GenderName = "Nam"},
                    new Gender {GenderId = 2, GenderName = "Nữ"},
                    new Gender {GenderId = 3, GenderName = "Khác"}
                );

                Account.AddRange(
                    new Account {AccountId = "admin", Password = Functions.MD5Password("admin"), Name = "Đạt và Kính", Email = "admin@technews.com", GenderId = 1, RoleId = 3}
                );

                SaveChanges();
            }
        }
    }
}