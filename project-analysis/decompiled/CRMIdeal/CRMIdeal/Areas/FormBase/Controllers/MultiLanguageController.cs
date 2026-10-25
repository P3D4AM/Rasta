using System.Web.Mvc;
using CRM.Models;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class MultiLanguageController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	public ActionResult Index(string type = null, string iframe = null)
	{
		if (string.IsNullOrEmpty(type))
		{
			type = "text";
		}
		base.ViewBag.Type = type;
		if (string.IsNullOrEmpty(iframe))
		{
			iframe = "ifrmContent";
		}
		base.ViewBag.Iframe = iframe;
		return View();
	}

	public ActionResult Editor(string type = null, string iframe = null, string fromPart = "")
	{
		fromPart = ((!string.IsNullOrEmpty(fromPart)) ? fromPart : "DyForm");
		base.ViewBag.FromPart = fromPart;
		if (string.IsNullOrEmpty(type))
		{
			type = "text";
		}
		base.ViewBag.Type = type;
		if (string.IsNullOrEmpty(iframe))
		{
			iframe = "ifrmContent";
		}
		base.ViewBag.Iframe = iframe;
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
