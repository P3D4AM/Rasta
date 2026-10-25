using System.Web.Mvc;

namespace CRMIdeal.Areas.StockSupply;

public class StockSupplyAreaRegistration : AreaRegistration
{
	public override string AreaName => "StockSupply";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("StockSupply_default", "StockSupply/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.StockSupply.Controllers" });
	}
}
