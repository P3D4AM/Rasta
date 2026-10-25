using System.Web.Mvc;

namespace CRMIdeal.Areas.DiscountStrategy;

public class DiscountStrategyAreaRegistration : AreaRegistration
{
	public override string AreaName => "DiscountStrategy";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("DiscountStrategy_default", "DiscountStrategy/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.DiscountStrategy.Controllers" });
	}
}
