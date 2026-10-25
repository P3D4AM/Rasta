using System.Web.Mvc;

namespace CRMIdeal.Areas.Cartables;

public class CartablesAreaRegistration : AreaRegistration
{
	public override string AreaName => "Cartables";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Cartables_default", "Cartables/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Cartables.Controllers" });
	}
}
