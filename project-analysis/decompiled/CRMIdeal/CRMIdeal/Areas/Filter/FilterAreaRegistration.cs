using System.Web.Mvc;

namespace CRMIdeal.Areas.Filter;

public class FilterAreaRegistration : AreaRegistration
{
	public override string AreaName => "Filter";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Filter_default", "Filter/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Filter.Controllers" });
	}
}
