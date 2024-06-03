using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Menu
    {
        [Key]
        public required int MenuId { get; set; }

        public required string MenuName { get; set; }

        public required bool IsActive { get; set; }

        public string? Link { get; set; }

        public required int Level { get; set; }

        public int? ParentId { get; set; }

        public required int MenuOrder { get; set; }

        public required int Area { get; set; }
    }
}