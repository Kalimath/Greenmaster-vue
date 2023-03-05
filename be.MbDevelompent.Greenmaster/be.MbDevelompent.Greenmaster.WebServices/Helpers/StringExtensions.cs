namespace be.MbDevelompent.Greenmaster.WebServices.Helpers;

public static class StringExtensions
{
    public static string TrimAndLower(this string value)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentException(nameof(value));
        return value.Trim().ToLower();
    }
}