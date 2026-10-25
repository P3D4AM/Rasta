using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Classes;

public class DynamicAuthorizeAttribute : AuthorizeAttribute
{
	public string ActionName { get; set; }

	public string ControllerName { get; set; }

	protected override bool AuthorizeCore(HttpContextBase httpContext = null)
	{
		if (httpContext == null)
		{
			Public.InsTextToElmah("BiiiiiiiiiiiiiigBuuuuuuuuuuuuuuuuug2222222222222");
			return false;
		}
		if (httpContext.User.Identity.IsAuthenticated)
		{
			CRMspLoadUserLoginInfoViewModel user = UserLogin.CurrentUser;
			if (user != null && user.FromLoginPage)
			{
				string currentControllerName;
				if (ControllerName != null)
				{
					currentControllerName = ControllerName;
				}
				else
				{
					currentControllerName = httpContext.Request.RequestContext.RouteData.Values["controller"].ToString();
				}
				string[] array = ((ActionName == null) ? new string[1] { httpContext.Request.RequestContext.RouteData.Values["action"].ToString() } : ActionName.Split(new char[1] { ',' }));
				if (Enumerable.Any<string>((IEnumerable<string>)array, (Func<string, bool>)((string act) => UserLogin.IsUserAccess(currentControllerName, act, user))))
				{
					try
					{
						LoginActivityViewModel currentUserActivity = LoginActivity.GetCurrentUserActivity(user.UserId);
						Guid result = default(Guid);
						string value = httpContext.Request.Cookies.Get("CrmIdealLoginAuth").Value;
						Guid.TryParse(value, out result);
						if (currentUserActivity != null && currentUserActivity.CurrGuid == result && !string.IsNullOrWhiteSpace(value) && currentUserActivity.CurrGuid == result)
						{
							Guid? currGuid = null;
							LoginActivity.Update(user.UserId, autoAdd: false, out currGuid);
							return base.AuthorizeCore(httpContext);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
			}
		}
		return false;
	}
}
