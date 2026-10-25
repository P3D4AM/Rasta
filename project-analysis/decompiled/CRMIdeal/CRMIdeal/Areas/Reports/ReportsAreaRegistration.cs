using System.Web.Mvc;

namespace CRMIdeal.Areas.Reports;

public class ReportsAreaRegistration : AreaRegistration
{
	public override string AreaName => "Reports";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Reports_default", "Reports/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Reports.Controllers" });
	}
}
