using System.Web.Mvc;

namespace CRMIdeal.Areas.DiscountPolicy;

public class DiscountPolicyAreaRegistration : AreaRegistration
{
	public override string AreaName => "DiscountPolicy";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("DiscountPolicy_default", "DiscountPolicy/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.DiscountPolicy.Controllers" });
	}
}
