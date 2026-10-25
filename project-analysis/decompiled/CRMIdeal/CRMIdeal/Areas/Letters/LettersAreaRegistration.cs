using System.Web.Mvc;

namespace CRMIdeal.Areas.Letters;

public class LettersAreaRegistration : AreaRegistration
{
	public override string AreaName => "Letters";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Letters_default", "Letters/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Letters.Controllers" });
	}
}
