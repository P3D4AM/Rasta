using System.Web.Mvc;
using System.Web.Routing;

namespace CRMIdealApi;

public class RouteConfig
{
	public static void RegisterRoutes(RouteCollection routes)
	{
		routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
		routes.MapRoute("Default", "{controller}/{action}/{id}", new
		{
			controller = "ApiHome",
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdealApi.Controllers" });
	}
}
