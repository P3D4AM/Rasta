using System;
using System.Web.Mvc;

namespace CRM.General.Security;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class AjaxOnlyAttribute : ActionFilterAttribute
{
	public override void OnActionExecuting(ActionExecutingContext filterContext)
	{
		if (filterContext.HttpContext.Request.IsAjaxRequest())
		{
			base.OnActionExecuting(filterContext);
			return;
		}
		throw new InvalidOperationException("Only Ajax Can Call");
	}
}
