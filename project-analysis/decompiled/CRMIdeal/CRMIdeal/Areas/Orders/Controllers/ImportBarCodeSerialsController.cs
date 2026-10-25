using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;

namespace CRMIdeal.Areas.Orders.Controllers;

public class ImportBarCodeSerialsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actImportBarCodeSerials")]
	public ActionResult Index()
	{
		GetWareHouse(2);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetWareHouse(int orderOprId)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				value = UserLogin.CurrentUser.UserId;
			}
			List<WSspSelectOrderOprExceptId_Result> list2 = Enumerable.ToList<WSspSelectOrderOprExceptId_Result>((IEnumerable<WSspSelectOrderOprExceptId_Result>)_db.WSspSelectOrderOprExceptId(orderOprId, lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectOrderOprExceptId_Result, SelectListItem>((IEnumerable<WSspSelectOrderOprExceptId_Result>)list2, (Func<WSspSelectOrderOprExceptId_Result, SelectListItem>)((WSspSelectOrderOprExceptId_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.OrderOprID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WareHouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
