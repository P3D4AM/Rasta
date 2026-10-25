using System.Web.Mvc;

namespace CRMIdeal.Areas.Company;

public class CompanyAreaRegistration : AreaRegistration
{
	public override string AreaName => "Company";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Company_default", "Company/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Company.Controllers" });
	}
}
