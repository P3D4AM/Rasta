using System.Web.Mvc;

namespace CRMIdeal.Areas.OtherSystems;

public class OtherSystemsAreaRegistration : AreaRegistration
{
	public override string AreaName => "OtherSystems";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("OtherSystems_default", "OtherSystems/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.OtherSystems.Controllers" });
	}
}
