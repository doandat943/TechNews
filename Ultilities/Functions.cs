using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace TechNews.Ultilities
{
    public class Functions
    {
        public static string? _AccountId = String.Empty;
        public static string? _AccountName = String.Empty;
        public static string? _AccountType = String.Empty;
        public static string? _Message = String.Empty;

        public static string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        public static string MD5Password(string text)
        {
            string str = CalculateMD5Hash(text);
            for (int i = 0; i <= 5; i++)
                str = CalculateMD5Hash(str + str);
            return str;
        }

        public static string TitleSlugGenerate(string type, string? title, long id)
        {
            return type + "/" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString();
        }

        public static string GetDiffTime(DateTime inputDate, int typeShow = 0)
        {
            var timeDifference = DateTime.Now - inputDate;

            if (timeDifference.TotalMinutes < 1)
            {
                return "Vừa xong";
            }
            else if (timeDifference.TotalHours < 1)
            {
                return $"{timeDifference.TotalMinutes:F0} phút trước";
            }
            else if (timeDifference.TotalDays < 1)
            {
                return $"{timeDifference.TotalHours:F0} giờ trước";
            }
            else
            {
                return DateFormat(inputDate, typeShow);
            }
        }

        public static string DateFormat(DateTime inputDate, int typeShow = 0)
        {
            CultureInfo.CurrentCulture = new CultureInfo("vi-VN");

            if (typeShow == 1)
            {
                return inputDate.ToString("dd/MM/yyyy");
            }
            else if (typeShow == 2)
            {
                return inputDate.ToString("dd/MM/yyyy | HH:mm");
            }
            return inputDate.ToString("dddd, dd/MM/yyyy | HH:mm");
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