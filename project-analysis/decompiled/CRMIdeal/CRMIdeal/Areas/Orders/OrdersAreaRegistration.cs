using System.Web.Mvc;

namespace CRMIdeal.Areas.Orders;

public class OrdersAreaRegistration : AreaRegistration
{
	public override string AreaName => "Orders";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Orders_default", "Orders/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Orders.Controllers" });
	}
}
