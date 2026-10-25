using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Mobile.Classes.Helper;
using Mobile.Models;

namespace Mobile.Classes;

public class MobileAuthorizeAttribute : AuthorizeAttribute
{
	protected override bool IsAuthorized(HttpActionContext httpContext)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		bool flag = httpContext.Request.Headers.Contains("extra");
		if (flag)
		{
			Common common = new Common();
			string text = Enumerable.FirstOrDefault<string>(httpContext.Request.Headers.GetValues("extra"));
			flag = common.CheckExtra(text);
			if (flag)
			{
				flag = httpContext.Request.Headers.Contains("token");
				if (flag)
				{
					string text2 = Enumerable.FirstOrDefault<string>(httpContext.Request.Headers.GetValues("token"));
					Token token = common.GetToken(text2);
					if (token != null)
					{
						flag = text == token.extra;
						if (string.IsNullOrEmpty(Thread.CurrentPrincipal.Identity.Name))
						{
							GenericPrincipal user = (GenericPrincipal)(Thread.CurrentPrincipal = (IPrincipal?)new GenericPrincipal((IIdentity)new GenericIdentity(text2), (string[])null));
							HttpContext.Current.User = (IPrincipal)user;
						}
					}
					else
					{
						flag = false;
					}
				}
			}
		}
		return flag;
	}
}
