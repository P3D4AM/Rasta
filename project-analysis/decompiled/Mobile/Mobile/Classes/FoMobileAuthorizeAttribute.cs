using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using Mobile.Classes.Helper;
using Mobile.Models;

namespace Mobile.Classes;

public class FoMobileAuthorizeAttribute : AuthorizeAttribute
{
	protected override bool IsAuthorized(HttpActionContext httpContext)
	{
		bool flag = httpContext.Request.Headers.Contains("extra");
		if (flag)
		{
			FoCommon foCommon = new FoCommon();
			string text = Enumerable.FirstOrDefault<string>(httpContext.Request.Headers.GetValues("extra"));
			flag = foCommon.CheckExtra(text);
			if (flag)
			{
				flag = httpContext.Request.Headers.Contains("token");
				if (flag)
				{
					string token = Enumerable.FirstOrDefault<string>(httpContext.Request.Headers.GetValues("token"));
					FoToken token2 = foCommon.GetToken(token);
					flag = token2 != null && text == token2.Extra;
				}
			}
		}
		return flag;
	}
}
