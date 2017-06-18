using System.Security.Principal;

namespace MuseumProject.Helpers
{
    public static class UserHelper
    {
        public static bool IsAdmin(this IPrincipal iPrincipal)
        {
            return iPrincipal.IsInRole(ConstsHelper.AdministratorRole);
        }

        public static bool IsAuthenticated(this IPrincipal iPrincipal)
        {
            return iPrincipal.Identity.IsAuthenticated;
        }

        public static string GetLogin(this IPrincipal iPrincipal)
        {
            return iPrincipal.Identity.Name;
        }

        public static bool HasLogin(this IPrincipal iPrincipal, string Login)
        {
            return iPrincipal.GetLogin() == Login;
        }

    }
}