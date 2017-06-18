using System;
using System.IO;
using System.Linq;

namespace MuseumProject.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random Random = new Random();

        public static string GeneratePhotoName(string oldFileName)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var newName = new string(
                Enumerable.Repeat(chars, 20)
                          .Select(s => s[Random.Next(chars.Length)])
                          .ToArray());
            var ext = Path.GetExtension(oldFileName);
            return String.Format("{0}{1}", newName, ext);
        }
    }
}