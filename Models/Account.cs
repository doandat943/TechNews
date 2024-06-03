using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNews.Models
{
    public class Account
    {
        [Key]
        [StringLength(20)]
        public required string AccountId { get; set; }

        public required string Password { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required int GenderId { get; set; }

        public required int RoleId { get; set; }

        public string? Avatar { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender? Gender { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
    }
}