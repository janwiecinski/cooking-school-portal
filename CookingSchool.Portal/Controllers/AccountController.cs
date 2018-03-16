using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;

namespace CookingSchool.Portal.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : Controller
    {
       public void SignIn()
        {
            // To execute a policy, you simply need to trigger an OWIN challenge.
            // You can indicate which policy to use by specifying the policy id as the AuthenticationType
            if (!Request.IsAuthenticated)
            {
                System.Web.HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties() { RedirectUri = "/"}, Startup.defaultPolicy);
            }
        }

        public void SignUp()
        {
            if (!Request.IsAuthenticated)
            {
                System.Web.HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties() { RedirectUri = "/" }, Startup.defaultPolicy);
            }
        }

        public void SignOut()
        {
            if (Request.IsAuthenticated)
            {
                IEnumerable<AuthenticationDescription> authTypes =
                    HttpContext.GetOwinContext().Authentication.GetAuthenticationTypes();

                HttpContext.GetOwinContext().Authentication.SignOut(authTypes.Select(t => t.AuthenticationType).ToArray());
            }
        }
    }
}
