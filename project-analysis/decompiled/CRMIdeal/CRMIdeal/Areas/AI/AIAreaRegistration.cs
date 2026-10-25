using System.Web.Mvc;

namespace CRMIdeal.Areas.AI;

public class AIAreaRegistration : AreaRegistration
{
	public override string AreaName => "AI";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("AI_default", "AI/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.AI.Controllers" });
	}
}
