using System.Web.Mvc;

namespace CRMIdealApi.Controllers;

public class ApiHomeController : Controller
{
	public ActionResult Index()
	{
		return View();
	}
}
