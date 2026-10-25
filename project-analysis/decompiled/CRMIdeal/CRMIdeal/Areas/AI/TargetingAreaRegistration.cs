using System.Web.Mvc;

namespace CRMIdeal.Areas.AI;

public class TargetingAreaRegistration : AreaRegistration
{
	public override string AreaName => "Targeting";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Targeting_default", "Targeting/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Targeting.Controllers" });
	}
}
