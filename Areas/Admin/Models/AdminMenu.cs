using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNews.Areas.Admin.Models
{
    [Table("admin_menu")]
    public class AdminMenu
    {
        [Key]
        [Column("admin_menu_id")]
        public int AdminMenuId { get; set; }

        [Column("item_name")]
        public string? ItemName { get; set; }

        [Column("item_level")]
        public int ItemLevel { get; set; }

        [Column("parent_level")]
        public int ParentLevel { get; set; }

        [Column("item_order")]
        public int ItemOrder { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("item_target")]
        public string? ItemTarget { get; set; }

        [Column("area_name")]
        public string? AreaName { get; set; }

        [Column("controller_name")]
        public string? ControllerName { get; set; }

        [Column("action_name")]
        public string? ActionName { get; set; }

        [Column("icon")]
        public string? Icon { get; set; }

        [Column("id_name")]
        public string? IdName { get; set; }
    }
}