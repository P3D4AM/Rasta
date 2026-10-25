using System.Web.Mvc;

namespace CRMIdealApi;

public class FilterConfig
{
	public static void RegisterGlobalFilters(GlobalFilterCollection filters)
	{
		filters.Add(new HandleErrorAttribute());
	}
}
