using System.Web.Mvc;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class AddPatternToTextController : Controller
{
	public ActionResult Index(string formName, string itemName, string itemType, int mode, string positionName)
	{
		base.ViewBag.FormName = formName;
		base.ViewBag.ItemName = itemName;
		base.ViewBag.ItemType = itemType;
		base.ViewBag.Mode = mode;
		base.ViewBag.PositionName = positionName;
		return View();
	}
}
