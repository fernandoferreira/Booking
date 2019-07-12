using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FF.MinhaReserva.UI.Web.Helpers
{
    public static class ClaimsHelper
    {
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            return ValidatePermission(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this WebViewPage page, string claimName, string claimValue)
        {
            return ValidatePermission(claimName, claimValue);
        }

        public static  string IfClaimShow(this WebViewPage page, string claimName, string ClaimValue)
        {
            return !ValidatePermission(claimName, ClaimValue) ? "disabled" : "";
        }

        private static bool ValidatePermission(string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}