using System.Web.Mvc;

namespace CRMIdeal.Areas.DiscountCode;

public class DiscountCodeAreaRegistration : AreaRegistration
{
	public override string AreaName => "DiscountCode";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("DiscountCode_default", "DiscountCode/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.DiscountCode.Controllers" });
	}
}
