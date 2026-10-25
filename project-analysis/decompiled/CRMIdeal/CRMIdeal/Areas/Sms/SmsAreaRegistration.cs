using System.Web.Mvc;

namespace CRMIdeal.Areas.Sms;

public class SmsAreaRegistration : AreaRegistration
{
	public override string AreaName => "Sms";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Sms_default", "Sms/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Sms.Controllers" });
	}
}
