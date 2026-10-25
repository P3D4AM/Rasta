using System.Web.Mvc;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;

namespace CRMIdeal.Areas.Component.Controllers;

public class InnerMultiLangController : Controller
{
	[HttpPost]
	[LoginAuthorize]
	public string GetCultures()
	{
		return Public.nComponentGetCulturesJs(returnCurrLangAsItems: true);
	}
}
