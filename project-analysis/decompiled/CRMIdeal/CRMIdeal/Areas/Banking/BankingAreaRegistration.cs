using System.Web.Mvc;

namespace CRMIdeal.Areas.Banking;

public class BankingAreaRegistration : AreaRegistration
{
	public override string AreaName => "Banking";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Banking_default", "Banking/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Banking.Controllers" });
	}
}
