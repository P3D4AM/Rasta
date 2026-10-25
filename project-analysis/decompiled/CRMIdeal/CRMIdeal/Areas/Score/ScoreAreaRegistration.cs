using System.Web.Mvc;

namespace CRMIdeal.Areas.Score;

public class ScoreAreaRegistration : AreaRegistration
{
	public override string AreaName => "Score";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Score_default", "Score/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Score.Controllers" });
	}
}
