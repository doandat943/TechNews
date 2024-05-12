using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechNews.Models
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        public string? GenderName { get; set; }
    }
}