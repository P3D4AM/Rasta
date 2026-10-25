using System.Web.Mvc;

namespace CRMIdeal;

public class FilterConfig
{
	public static void RegisterGlobalFilters(GlobalFilterCollection filters)
	{
		filters.Add(new HandleErrorAttribute());
	}
}
