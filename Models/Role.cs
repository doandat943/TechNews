using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }

}