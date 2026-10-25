using System.Web.Mvc;

namespace CRMIdeal.Areas.Survey;

public class SurveyAreaRegistration : AreaRegistration
{
	public override string AreaName => "Survey";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Survey_default", "Survey/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Survey.Controllers" });
	}
}
