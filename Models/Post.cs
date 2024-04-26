using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNews.Models
{
    [Table("post")]
    public class Post
    {
        [Key]
        [Column("post_id")]
        public int PostId { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("summary")]
        public string? Summary { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("image")]
        public string? Image { get; set; }

        [Column("link")]
        public string? Link { get; set; }

        [Column("author")]
        public string? Author { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("post_order")]
        public int PostOrder { get; set; }

        [Column("menu_id")]
        public int MenuId { get; set; }
    }
}