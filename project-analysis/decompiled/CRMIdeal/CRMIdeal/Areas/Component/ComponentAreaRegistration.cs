using System.Web.Mvc;

namespace CRMIdeal.Areas.Component;

public class ComponentAreaRegistration : AreaRegistration
{
	public override string AreaName => "Component";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Component_default", "Component/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Component.Controllers" });
	}
}
