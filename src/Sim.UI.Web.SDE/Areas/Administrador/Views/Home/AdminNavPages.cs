using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sim.UI.Web.SDE.Areas.Administrador.Views.Home
{
    public static class AdminNavPages
    {
        public static string Index => "Index";

        public static string Roles => "Roles";

        public static string Claims => "Claims";

        public static string Register => "Register";

        public static string DeletePersonalData => "DeletePersonalData";

        public static string ExternalLogins => "ExternalLogins";

        public static string PersonalData => "PersonalData";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string RolesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Roles);

        public static string ClaimsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Claims);

        public static string RegisterNavClass(ViewContext viewContext) => PageNavClass(viewContext, Register);

        public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
