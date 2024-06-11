using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechNews.Models
{
    public class AboutUs
    {
        [Key]
        public required int Id { get; set; }

        public required string WebName { get; set; }

        public required string WebLink { get; set; }

        public required string Image { get; set; }

        public required string Content { get; set; }

        public required string AdminName { get; set; }

        public required string AdminAvatar { get; set; }

        public required string Address { get; set; }

        public required string Number { get; set; }

        public required string Email { get; set; }

        public required string Twitter { get; set; }

        public required string Facebook { get; set; }

        public required string Linkedin { get; set; }

        public required string Instagram { get; set; }

        public required string Youtube { get; set; }
    }
}