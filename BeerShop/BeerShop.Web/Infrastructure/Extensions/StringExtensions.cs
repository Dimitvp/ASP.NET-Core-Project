namespace BeerShop.Web.Infrastructure.Extensions
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string text)
            => Regex
                .Replace(text, @"[^A-Za-z0-9_\.~]+", "-")
                .ToLower();


        public static string ToDashedString(this string text)
            => Regex
                .Replace(text, @"\s+", "-")
                .ToLower();

        public static string ToImageName(this string text, int id, string productType)
            => text
                .Substring(text.LastIndexOf('.'))
                .Insert(0, $"{id}-{productType}")
                .ToLower();
    }
}
