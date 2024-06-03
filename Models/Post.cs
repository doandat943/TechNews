using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNews.Models
{
    public class Post
    {
        [Key]
        public required int PostId { get; set; }

        public required string Title { get; set; }

        public required string Summary { get; set; }

        public required string Content { get; set; }

        public required string Image { get; set; }

        public required bool IsActive { get; set; }

        public required DateTime CreatedDate { get; set; }

        public required int View { get; set; }

        public required string AuthorId { get; set; }

        public required int MenuId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Account? Author { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu? Menu { get; set; }
    }
}