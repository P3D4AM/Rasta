using System.Web.Mvc;

namespace CRMIdeal.Areas.CompanyReport;

public class CompanyReportAreaRegistration : AreaRegistration
{
	public override string AreaName => "CompanyReport";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("CompanyReport_default", "CompanyReport/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.CompanyReport.Controllers" });
	}
}
