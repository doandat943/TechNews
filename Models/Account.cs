using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNews.Models
{
    public class Account
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string AccountId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int? GenderId { get; set; }

        [Required]
        public int RoleId { get; set; }

        public string Avatar { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}