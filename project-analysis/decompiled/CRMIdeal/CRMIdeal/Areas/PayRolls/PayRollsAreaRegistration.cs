using System.Web.Mvc;

namespace CRMIdeal.Areas.PayRolls;

public class PayRollsAreaRegistration : AreaRegistration
{
	public override string AreaName => "PayRolls";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("PayRolls_default", "PayRolls/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.PayRolls.Controllers" });
	}
}
