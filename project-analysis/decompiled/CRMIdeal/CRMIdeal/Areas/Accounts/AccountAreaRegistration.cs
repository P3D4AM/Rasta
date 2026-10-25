using System.Web.Mvc;

namespace CRMIdeal.Areas.Accounts;

public class AccountAreaRegistration : AreaRegistration
{
	public override string AreaName => "Accounts";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Accounts_default", "Accounts/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Accounts.Controllers" });
	}
}
