using System.Web.Mvc;

namespace CRMIdeal.Areas.VerificationWorkflow;

public class VerificationWorkflowAreaRegistration : AreaRegistration
{
	public override string AreaName => "VerificationWorkflow";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("VerificationWorkflow_default", "VerificationWorkflow/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.VerificationWorkflow.Controllers" });
	}
}
