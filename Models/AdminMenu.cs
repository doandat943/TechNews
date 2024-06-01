using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class AdminMenu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public string MenuName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string ControllerName { get; set; }

        [Required]
        public string ActionName { get; set; }

        [Required]
        public int Level { get; set; }

        public int? ParentId { get; set; }

        [Required]
        public int MenuOrder { get; set; }

        [Required]
        public string Target { get; set; }

        [Required]
        public string Icon { get; set; }
    }
}