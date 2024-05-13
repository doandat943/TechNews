using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlugGenerator;

namespace TechNews.Ultilities
{
    public class Functions
    {
        public static string TitleSlugGeneration(string type, string? title, long id)
        {
            return type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
        }

        public static string getCurrentDate() {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}