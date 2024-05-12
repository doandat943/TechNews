using System.ComponentModel.DataAnnotations;

namespace TechNews.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public string? Link { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? AuthorId { get; set; }
        public int MenuId { get; set; }
    }
}