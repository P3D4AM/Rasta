using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace CRMIdeal.Classes;

public class KaramadAuthorizeAttribute : AuthorizeAttribute
{
	protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
	{
		IOwinContext owinContext = filterContext.HttpContext.GetOwinContext();
		if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
		{
			filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
			owinContext.Authentication.Challenge(new AuthenticationProperties
			{
				RedirectUri = filterContext.HttpContext.Request.RawUrl
			}, "KaramadSSO");
			filterContext.Result = new HttpUnauthorizedResult();
		}
		else
		{
			base.HandleUnauthorizedRequest(filterContext);
		}
	}
}
