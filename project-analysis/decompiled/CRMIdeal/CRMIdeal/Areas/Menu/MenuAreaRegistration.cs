using System.Web.Mvc;

namespace CRMIdeal.Areas.Menu;

public class MenuAreaRegistration : AreaRegistration
{
	public override string AreaName => "Menu";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Menu_default", "Menu/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Menu.Controllers" });
	}
}
