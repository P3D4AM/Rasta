using System.Web.Mvc;

namespace CRMIdeal.Areas.Setting;

public class SettingAreaRegistration : AreaRegistration
{
	public override string AreaName => "Setting";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Setting_default", "Setting/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Setting.Controllers" });
	}
}
