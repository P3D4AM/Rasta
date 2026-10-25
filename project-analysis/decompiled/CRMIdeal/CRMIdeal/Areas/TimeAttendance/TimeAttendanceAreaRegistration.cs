using System.Web.Mvc;

namespace CRMIdeal.Areas.TimeAttendance;

public class TimeAttendanceAreaRegistration : AreaRegistration
{
	public override string AreaName => "TimeAttendance";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("TimeAttendance_default", "TimeAttendance/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.TimeAttendance.Controllers" });
	}
}
