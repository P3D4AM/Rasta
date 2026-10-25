using System.Web.Mvc;

namespace CRMIdeal.Areas.BuyOrders;

public class BuyOrdersAreaRegistration : AreaRegistration
{
	public override string AreaName => "BuyOrders";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("BuyOrders_default", "BuyOrders/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.BuyOrders.Controllers" });
	}
}
