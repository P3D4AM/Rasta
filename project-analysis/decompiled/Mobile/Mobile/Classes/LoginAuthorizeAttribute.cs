using System.Web;
using System.Web.Mvc;

namespace Mobile.Classes;

public class LoginAuthorizeAttribute : AuthorizeAttribute
{
	protected override bool AuthorizeCore(HttpContextBase httpContext)
	{
		if (httpContext.User.Identity.IsAuthenticated && MobUserLogin.CurrentUser != null)
		{
			return base.AuthorizeCore(httpContext);
		}
		return false;
	}
}
