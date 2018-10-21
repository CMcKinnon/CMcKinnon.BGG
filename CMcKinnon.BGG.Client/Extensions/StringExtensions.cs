using System;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class StringExtensions
    {
        public static DateTime GetSafeDateTime(this string input)
        {
            return !string.IsNullOrEmpty(input) ? DateTime.Parse(input) : DateTime.MinValue;
        }
    }
}
