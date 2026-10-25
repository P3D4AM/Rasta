using System.Web.Mvc;

namespace CRMIdeal.Areas.Fund;

public class FundAreaRegistration : AreaRegistration
{
	public override string AreaName => "Fund";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Fund_default", "Fund/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Fund.Controllers" });
	}
}
