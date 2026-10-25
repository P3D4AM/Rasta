using System.Web.Mvc;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class CenterController : Controller
{
	[LoginAuthorize]
	public ActionResult Index()
	{
		return View();
	}

	public string ImportHamyarCenters()
	{
		return CRMIdeal.Classes.Helper.OtherSystems.SyncCenters(new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).GetCenters());
	}
}
