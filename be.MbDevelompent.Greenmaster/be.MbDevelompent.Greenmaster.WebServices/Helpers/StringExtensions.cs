using System.Globalization;

namespace be.MbDevelompent.Greenmaster.WebServices.Helpers;

public static class StringExtensions
{
    public static string TrimAndLower(this string value)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentException(nameof(value));
        return value.Trim().ToLower();
    }
    public static string Capitalise(this string value)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentException(nameof(value));
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
    }
}