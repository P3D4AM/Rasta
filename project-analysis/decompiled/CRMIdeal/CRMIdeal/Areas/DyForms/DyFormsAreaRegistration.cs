using System.Web.Mvc;

namespace CRMIdeal.Areas.DyForms;

public class DyFormsAreaRegistration : AreaRegistration
{
	public override string AreaName => "DyForms";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("DyForms_default", "DyForms/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.DyForms.Controllers" });
	}
}
