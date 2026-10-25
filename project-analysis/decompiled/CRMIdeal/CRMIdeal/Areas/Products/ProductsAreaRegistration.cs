using System.Web.Mvc;

namespace CRMIdeal.Areas.Products;

public class ProductsAreaRegistration : AreaRegistration
{
	public override string AreaName => "Products";

	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute("Products_default", "Products/{controller}/{action}/{id}", new
		{
			action = "Index",
			id = UrlParameter.Optional
		}, new string[1] { "CRMIdeal.Areas.Products.Controllers" });
	}
}
