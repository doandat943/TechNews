using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNews.Models
{
    public class Comment
    {
        [Key]
        public required int CommentId { get; set; }

        public required int PostId { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Content { get; set; }

        public required DateTime CreatedDate { get; set; }

        [ForeignKey("PostId")]
        public virtual Post? Post { get; set; }
    }
}