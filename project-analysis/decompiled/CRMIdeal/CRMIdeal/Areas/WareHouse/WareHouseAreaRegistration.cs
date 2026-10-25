using System.Web.Mvc;

namespace CRMIdeal.Areas.WareHouse;

public class WareHouseAreaRegistration : AreaRegistration
{
	public override string AreaName => "WareHouse";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("WareHouse_default", "WareHouse/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.WareHouse.Controllers" });
	}
}
