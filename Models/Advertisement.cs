using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechNews.Models
{
    public class Advertisement
    {
        [Key]
        public required int Id { get; set; }

        public required string Company { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Number { get; set; }

        public required string Message { get; set; }

        public required string Image { get; set; }

        public required string Link { get; set; }

        public required bool IsActive { get; set; }
    }
}