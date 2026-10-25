using System.Web.Mvc;

namespace CRMIdeal.Areas.ImportExcel;

public class ImportExcelAreaRegistration : AreaRegistration
{
	public override string AreaName => "ImportExcel";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("ImportExcel_default", "ImportExcel/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.ImportExcel.Controllers" });
	}
}
