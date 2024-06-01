using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public string MenuName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public string Link { get; set; }

        [Required]
        public int Level { get; set; }

        public int? ParentId { get; set; }

        [Required]
        public int MenuOrder { get; set; }

        [Required]
        public int Area { get; set; }
    }
}