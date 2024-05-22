namespace TechNews.Ultilities
{
    public class Functions
    {
        public static string TitleSlugGenerate(string type, string? title, long id)
        {
            return type + "/" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString();
        }

        public static string GetDiffTime(DateTime inputDate, bool isShort = false)
        {
            var timeDifference = DateTime.Now - inputDate;
            if (timeDifference.TotalDays == 0)
            {
                return timeDifference.TotalHours + " giờ trước";
            }
            else if (timeDifference.TotalHours == 0)
            {
                return timeDifference.TotalMinutes + " phút trước";
            }
            else if (isShort == true)
            {
                return inputDate.ToString("yyyy-MM-dd");
            }
            else
            {
                return inputDate.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public static string TruncateTitle(string title, int maxLength)
        {
            if (string.IsNullOrEmpty(title) || title.Length <= maxLength)
            {
                return title;
            }

            var truncated = title.Substring(0, maxLength);
            var lastSpaceIndex = truncated.LastIndexOf(' ');
            if (lastSpaceIndex > 0)
            {
                truncated = truncated.Substring(0, lastSpaceIndex);
            }

            return truncated + "...";
        }
    }
}