using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Account
    {
        [Key]
        public string? AccountId { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int GenderId { get; set; }
        public int RoleId { get; set; }
        public string? Avatar { get; set; }
    }

}