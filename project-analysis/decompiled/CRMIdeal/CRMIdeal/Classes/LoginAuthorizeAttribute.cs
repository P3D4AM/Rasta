using System;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Classes;

public class LoginAuthorizeAttribute : AuthorizeAttribute
{
	protected override bool AuthorizeCore(HttpContextBase httpContext = null)
	{
		if (httpContext == null)
		{
			Public.InsTextToElmah("BiiiiiiiiiiiiiigBuuuuuuuuuuuuuuuuug");
			return false;
		}
		if (httpContext.User.Identity.IsAuthenticated)
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null && currentUser.FromLoginPage)
			{
				try
				{
					string value = httpContext.Request.Cookies.Get("CrmIdealLoginAuth").Value;
					LoginActivityViewModel currentUserActivity = LoginActivity.GetCurrentUserActivity(currentUser.UserId);
					Guid result = default(Guid);
					Guid.TryParse(value, out result);
					if (currentUserActivity != null && currentUserActivity.CurrGuid == result && !string.IsNullOrWhiteSpace(value) && currentUserActivity.CurrGuid == result)
					{
						Guid? currGuid = null;
						LoginActivity.Update(currentUser.UserId, autoAdd: false, out currGuid);
						return base.AuthorizeCore(httpContext);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
		}
		return false;
	}
}
