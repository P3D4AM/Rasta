using System.Web.Mvc;

namespace CRMIdeal.Areas.Tools;

public class ToolsAreaRegistration : AreaRegistration
{
	public override string AreaName => "Tools";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Tools_default", "Tools/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Tools.Controllers" });
	}
}
