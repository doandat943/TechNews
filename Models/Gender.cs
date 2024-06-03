using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Gender
    {
        [Key]
        public required int GenderId { get; set; }

        public required string GenderName { get; set; }
    }
}