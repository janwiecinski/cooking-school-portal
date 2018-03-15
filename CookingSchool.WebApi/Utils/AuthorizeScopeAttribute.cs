using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CookingSchool.WebApi.Utils
{
    public class AuthorizeScopeAttribute : AuthorizationFilterAttribute
    {
        private string scope;

        public const string scopeElement = "http://schemas.microsoft.com/identity/claims/scope";

        public AuthorizeScopeAttribute(string scope)
        {
            this.scope = scope;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(!ClaimsPrincipal.Current.FindFirst(scopeElement).Value.Contains(scope))
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = $"The Scope claim does not contain the {scope} permission."
                });
            }
        }
    }
}