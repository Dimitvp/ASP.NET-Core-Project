namespace BeerShop.Web.Infrastructure.Extensions
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string text)
        {
            return Regex.Replace(text, @"[^A-Za-z0-9_\.~]+", "-").ToLower();
        }

        public static string ToDashedString(this string text)
        {
            return Regex.Replace(text, @"\s+", "-").ToLower();
        }
    }
}
