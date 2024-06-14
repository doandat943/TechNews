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

                AdminMenu.AddRange(
                    new AdminMenu { MenuId = 1, MenuName = "Bảng điều khiển", RoleId = 3, ControllerName = "Home", ActionName = "Index", Level = 1, ParentId = 0, MenuOrder = 1, Target = "forms-nav", Icon = "bi bi-menu-button-wide", IsActive = true },
                    new AdminMenu { MenuId = 2, MenuName = "Quản lý", RoleId = 2, ControllerName = "Home", ActionName = "Index", Level = 1, ParentId = 0, MenuOrder = 2, Target = "components-nav", Icon = "bi bi-layout-text-window-reverse", IsActive = true },
                    new AdminMenu { MenuId = 3, MenuName = "Quản lý bài viết", RoleId = 2, ControllerName = "Post", ActionName = "Index", Level = 2, ParentId = 1, MenuOrder = 1, Target = "", Icon = "bi bi-menu-button-wide", IsActive = true },
                    new AdminMenu { MenuId = 4, MenuName = "Quản lý danh mục", RoleId = 3, ControllerName = "Menu", ActionName = "Index", Level = 2, ParentId = 1, MenuOrder = 2, Target = "", Icon = "bi bi-menu-button-wide", IsActive = true },
                    new AdminMenu { MenuId = 5, MenuName = "Quản lý tài khoản", RoleId = 3, ControllerName = "Account", ActionName = "Index", Level = 2, ParentId = 1, MenuOrder = 3, Target = "", Icon = "bi bi-menu-button-wide", IsActive = true },
                    new AdminMenu { MenuId = 6, MenuName = "Quản lý tập tin", RoleId = 3, ControllerName = "FileManager", ActionName = "Index", Level = 1, ParentId = 0, MenuOrder = 3, Target = "forms-nav", Icon = "bi bi-card-list", IsActive = true },
                    new AdminMenu { MenuId = 7, MenuName = "Thông tin Website", RoleId = 3, ControllerName = "AboutUs", ActionName = "Edit", Level = 1, ParentId = 0, MenuOrder = 4, Target = "forms-nav", Icon = "bi bi-menu-button-wide", IsActive = true }
                );

                Role.AddRange(
                    new Role { RoleId = 1, RoleName = "Người dùng" },
                    new Role { RoleId = 2, RoleName = "Tác giả" },
                    new Role { RoleId = 3, RoleName = "Quản trị viên" }
                );

                Gender.AddRange(
                    new Gender { GenderId = 1, GenderName = "Nam" },
                    new Gender { GenderId = 2, GenderName = "Nữ" },
                    new Gender { GenderId = 3, GenderName = "Khác" }
                );

                Account.AddRange(
                    new Account { AccountId = "admin", Password = Functions.MD5Password("admin"), Name = "Đạt và Kính", Email = "admin@technews.com", GenderId = 1, RoleId = 3 }
                );

                SaveChanges();
            }
        }
    }
}