using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Classes;

namespace CRMIdeal.Areas.CompanyReport.Controllers;

public class OtherCompanyReportController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actOtherReport")]
	public ActionResult Index()
	{
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
