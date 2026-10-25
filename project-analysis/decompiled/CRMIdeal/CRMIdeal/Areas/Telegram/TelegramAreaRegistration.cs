using System.Web.Mvc;

namespace CRMIdeal.Areas.Telegram;

public class TelegramAreaRegistration : AreaRegistration
{
	public override string AreaName => "Telegram";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Telegram_default", "Telegram/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Telegram.Controllers" });
	}
}
