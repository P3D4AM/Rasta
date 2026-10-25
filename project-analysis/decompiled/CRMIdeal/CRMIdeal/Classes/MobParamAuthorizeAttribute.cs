using System.Web;
using System.Web.Mvc;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;

namespace CRMIdeal.Classes;

public class MobParamAuthorizeAttribute : AuthorizeAttribute
{
	protected override bool AuthorizeCore(HttpContextBase httpContext = null)
	{
		if (httpContext == null)
		{
			Public.InsTextToElmah("MobileAuth__EmptyContext");
			return false;
		}
		if (CRMIdeal.Classes.Helper.Mobile.CheckToken(CRMIdeal.Classes.Helper.Mobile.GetToken()) == 0)
		{
			return false;
		}
		return true;
	}
}
