using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class AdminMenu
    {
        [Key]
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public bool IsActive { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? Target { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; } // Nullable to represent root menu items
        public int MenuOrder { get; set; }
        public string? Icon { get; set; }
    }

}