using System.Web.Mvc;

namespace CRMIdeal.Areas.SEO;

public class SEOAreaRegistration : AreaRegistration
{
	public override string AreaName => "SEO";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("SEO_default", "SEO/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.SEO.Controllers" });
	}
}
