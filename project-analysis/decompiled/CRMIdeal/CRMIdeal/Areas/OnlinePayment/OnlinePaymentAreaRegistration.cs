using System.Web.Mvc;

namespace CRMIdeal.Areas.OnlinePayment;

public class OnlinePaymentAreaRegistration : AreaRegistration
{
	public override string AreaName => "OnlinePayment";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("OnlinePayment_default", "OnlinePayment/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.OnlinePayment.Controllers" });
	}
}
