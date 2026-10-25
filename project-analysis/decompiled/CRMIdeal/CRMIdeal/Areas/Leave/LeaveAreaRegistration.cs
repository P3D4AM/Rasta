using System.Web.Mvc;

namespace CRMIdeal.Areas.Leave;

public class LeaveAreaRegistration : AreaRegistration
{
	public override string AreaName => "Leave";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Leave_default", "Leave/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Leave.Controllers" });
	}
}
