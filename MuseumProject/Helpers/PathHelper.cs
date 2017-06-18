using System;

namespace MuseumProject.Helpers
{
    public static class PathHelper
    {
        public static string PathToPhoto(string photoName)
        {
            return String.Format("{0}/{1}", "~/../../../Photos", photoName);
        }
    }
}