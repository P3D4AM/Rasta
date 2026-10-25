using System.Web.Mvc;

namespace CRMIdeal.Areas.Tsp;

public class TspAreaRegistration : AreaRegistration
{
	public override string AreaName => "Tsp";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Tsp_default", "Tsp/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Tsp.Controllers" });
	}
}
