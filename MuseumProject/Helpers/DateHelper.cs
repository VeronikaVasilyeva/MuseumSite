using System;

namespace MuseumProject.Helpers
{
    public static class DateHelper
    {
        public static string ToStandardFormat(this DateTime date)
        {
            return date.ToString("d MMM yyyy");
        }

        public static string ToStandardFormatWithTime(this DateTime date)
        {
            return date.ToString("hh:mm d MMM yyyy");
        }
    }
}