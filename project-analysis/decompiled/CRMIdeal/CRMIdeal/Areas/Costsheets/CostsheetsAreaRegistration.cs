using System.Web.Mvc;

namespace CRMIdeal.Areas.Costsheets;

public class CostsheetsAreaRegistration : AreaRegistration
{
	public override string AreaName => "Costsheets";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Costsheets_default", "Costsheets/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Costsheets.Controllers" });
	}
}
