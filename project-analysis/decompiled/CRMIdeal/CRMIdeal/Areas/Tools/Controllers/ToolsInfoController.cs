using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Classes;

namespace CRMIdeal.Areas.Tools.Controllers;

public class ToolsInfoController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCalenderShamsi")]
	public ActionResult CalenderShamsi()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCalenderMiladi")]
	public ActionResult CalenderMiladi()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCalculator")]
	public ActionResult Calculator()
	{
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		base.Dispose(disposing);
	}
}
