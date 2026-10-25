using System.Web.Mvc;

namespace CRMIdeal.Areas.UserLocationDetails;

public class UserLocationDetailsAreaRegistration : AreaRegistration
{
	public override string AreaName => "UserLocationDetails";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("UserLocationDetails_default", "UserLocationDetails/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.UserLocationDetails.Controllers" });
	}
}
