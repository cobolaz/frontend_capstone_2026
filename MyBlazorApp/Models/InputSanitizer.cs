public static class InputSanitizer
{
    public static string Clean(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Remove script tags
        input = input.Replace("<script", "", StringComparison.OrdinalIgnoreCase)
                     .Replace("</script>", "", StringComparison.OrdinalIgnoreCase);

        // Encode HTML
        return System.Net.WebUtility.HtmlEncode(input);
    }
}
