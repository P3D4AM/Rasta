using System.Web.Mvc;

namespace CRMIdeal.Areas.Emails;

public class EmailsAreaRegistration : AreaRegistration
{
	public override string AreaName => "Emails";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Emails_default", "Emails/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Emails.Controllers" });
	}
}
