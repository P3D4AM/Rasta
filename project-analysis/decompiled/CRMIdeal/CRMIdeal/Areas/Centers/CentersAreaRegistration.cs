using System.Web.Mvc;

namespace CRMIdeal.Areas.Centers;

public class CentersAreaRegistration : AreaRegistration
{
	public override string AreaName => "Centers";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Centers_default", "Centers/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Centers.Controllers" });
	}
}
