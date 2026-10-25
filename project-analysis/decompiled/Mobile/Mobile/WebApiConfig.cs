using System.Web.Http;

namespace Mobile;

public static class WebApiConfig
{
	public static void Register(HttpConfiguration config)
	{
		config.Routes.MapHttpRoute("ControllerAndAction", "api/{controller}/{action}/{id}", new
		{
			id = RouteParameter.Optional
		});
		config.Routes.MapHttpRoute("ApiById", "api/{controller}/{id}", new
		{
			id = RouteParameter.Optional
		}, new
		{
			id = "^[0-9]+$"
		});
		config.Routes.MapHttpRoute("ApiByName", "api/{controller}/{action}/{name}", null, new
		{
			name = "^[a-z]+$"
		});
		config.Routes.MapHttpRoute("ApiByAction", "api/{controller}/{action}", new
		{
			action = "Get"
		});
		config.EnableSystemDiagnosticsTracing();
	}
}
