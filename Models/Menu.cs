using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNews.Models
{
    [Table("menu")]
    public class Menu
    {
        [Key]
        [Column("menu_id")]
        public int MenuId { get; set; }

        [Column("menu_name")]
        public string? MenuName { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("controller_name")]
        public string? ControllerName { get; set; }

        [Column("action_name")]
        public string? ActionName { get; set; }

        [Column("levels")]
        public int Levels { get; set; }

        [Column("parent_id")]
        public int ParentId { get; set; }

        [Column("link")]
        public string? Link { get; set; }

        [Column("menu_order")]
        public int MenuOrder { get; set; }

        [Column("position")]
        public string? Position { get; set; }
    }
}