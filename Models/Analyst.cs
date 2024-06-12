using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechNews.Models
{
    public class Analyst
    {
        [Key]
        public int Id { get; set; }

        public required DateTime Date { get; set; }

        public required int View { get; set; }
    }
}