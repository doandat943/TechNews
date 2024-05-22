using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mysqlx.Resultset;
using SlugGenerator;
using TechNews.Models;

namespace TechNews.Ultilities
{
    public class Functions
    {
        public static string TitleSlugGeneration(string type, string? title, long id)
        {
            return type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
        }

        public static string getCurrentTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        public static string getDiffTime(DateTime inputDate)
        {
            var timeDifference = DateTime.Now - inputDate;
            if (timeDifference.TotalDays == 0){
                return timeDifference.TotalHours + " giờ trước";
            }
            else if (timeDifference.TotalHours == 0){
                return timeDifference.TotalMinutes + " phút trước";
            }
            else {
                return inputDate.ToString("yyyy-MM-dd HH:mm");
            }
            
        }
    }
}