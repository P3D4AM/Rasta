using System.Web.Mvc;

namespace CRMIdeal.Areas.Cms;

public class CmsAreaRegistration : AreaRegistration
{
	public override string AreaName => "Cms";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Cms_default", "Cms/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Cms.Controllers" });
	}
}
