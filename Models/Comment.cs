using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}