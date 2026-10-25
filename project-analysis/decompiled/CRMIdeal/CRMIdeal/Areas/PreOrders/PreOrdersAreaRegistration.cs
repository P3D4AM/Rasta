using System.Web.Mvc;

namespace CRMIdeal.Areas.PreOrders;

public class PreOrdersAreaRegistration : AreaRegistration
{
	public override string AreaName => "PreOrders";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("PreOrders_default", "PreOrders/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.PreOrders.Controllers" });
	}
}
