using System.Web;

namespace MuseumProject.Helpers
{
    public static class ConstsHelper
    {
        static ConstsHelper()
        {
            ProjectPhotosFolder = HttpContext.Current.Server.MapPath(@"~\Photos\");
        }

        public const int HomePageNewsCount = 5;
        public static string ProjectPhotosFolder = null;
        public const string AdministratorRole = "Administrator";
        public const int PageSize = 2;
    }
}