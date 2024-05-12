using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechNews.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public bool IsActive { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? Link { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; } // Nullable to represent root categories
        public int MenuOrder { get; set; }
        public int Area { get; set; }
    }
}