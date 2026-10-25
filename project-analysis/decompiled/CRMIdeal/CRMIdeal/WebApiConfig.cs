using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace CRMIdeal;

public static class WebApiConfig
{
	public static void Register(HttpConfiguration config)
	{
		config.Routes.MapHttpRoute("ControllerAndAction", "api/{controller}/{action}/{id}", new
		{
			id = RouteParameter.Optional
		});
		config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new
		{
			id = RouteParameter.Optional
		});
		config.Services.Replace(typeof(IAssembliesResolver), new PluginsResolver());
		config.Services.Replace(typeof(IHttpControllerSelector), new BypassCacheSelector(config));
	}
}
