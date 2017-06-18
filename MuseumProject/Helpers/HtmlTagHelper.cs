namespace MuseumProject.Helpers
{
    public class HtmlTagHelper
    {
        public static string ReplaceTags(string htmlStr)
        {
            var result = htmlStr.Replace("<", "&lt;");

            return result.Replace("&lt;b>", "<b>")
                         .Replace("&lt;/b>", "</b>")
                         .Replace("&lt;i>", "</i>")
                         .Replace("&lt;/i>", "</i>")
                         .Replace("&lt;u>", "</u>")
                         .Replace("&lt;/u>", "</u>")
                         .Replace("&lt;img", "<img")
                         .Replace("&lt;br", "<br");
        }
    }
}