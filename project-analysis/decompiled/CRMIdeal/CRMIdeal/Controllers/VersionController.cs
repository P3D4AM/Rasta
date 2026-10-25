using System.Web.Mvc;
using CRMIdeal.Classes;

namespace CRMIdeal.Controllers;

public class VersionController : Controller
{
	[LoginAuthorize]
	public ActionResult Index()
	{
		return View();
	}
}
