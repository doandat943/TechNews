using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public bool IsActive { get; set; }
        public string? Link { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; } // Nullable to represent root categories
        public int MenuOrder { get; set; }
        public int Area { get; set; }
    }
}