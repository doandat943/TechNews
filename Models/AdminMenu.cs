using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNews.Models
{
    public class AdminMenu
    {
        [Key]
        public required int MenuId { get; set; }

        public required string MenuName { get; set; }

        public required int RoleId { get; set; }

        public required string ControllerName { get; set; }

        public required string ActionName { get; set; }

        public required int Level { get; set; }

        public int? ParentId { get; set; }

        public required int MenuOrder { get; set; }

        public required string Target { get; set; }

        public required string Icon { get; set; }

        public required bool IsActive { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
    }
}