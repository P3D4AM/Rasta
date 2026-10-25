using System.Web.Mvc;

namespace CRMIdeal.Areas.Shop;

public class ShopAreaRegistration : AreaRegistration
{
	public override string AreaName => "Shop";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Shop_default", "Shop/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Shop.Controllers" });
	}
}
