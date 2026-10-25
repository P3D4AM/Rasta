using System.Web.Mvc;

namespace CRMIdeal.Areas.FormBase;

public class FormBaseAreaRegistration : AreaRegistration
{
	public override string AreaName => "FormBase";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("FormBase_default", "FormBase/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.FormBase.Controllers" });
	}
}
