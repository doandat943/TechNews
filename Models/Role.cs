using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Role
    {
        [Key]
        public required int RoleId { get; set; }

        public required string RoleName { get; set; }
    }
}