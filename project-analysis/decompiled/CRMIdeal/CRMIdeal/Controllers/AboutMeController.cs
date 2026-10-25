using System.Web.Mvc;
using CRMIdeal.Classes;

namespace CRMIdeal.Controllers;

public class AboutMeController : Controller
{
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actAboutMe")]
	public ActionResult Index()
	{
		return View();
	}
}
