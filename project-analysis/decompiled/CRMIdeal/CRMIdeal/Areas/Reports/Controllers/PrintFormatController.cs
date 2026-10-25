using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Areas.Reports.Controllers;

public class PrintFormatController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	public ActionResult Index(int printFormatTypeId, string param1 = "", string param2 = "", string param3 = "", string param4 = "", int sysPartId = 0, int sysPartObjId = 0)
	{
		base.ViewBag.Param1 = param1;
		base.ViewBag.Param2 = param2;
		base.ViewBag.Param3 = param3;
		base.ViewBag.Param4 = param4;
		base.ViewBag.SysPartId = sysPartId;
		base.ViewBag.SysPartObjId = sysPartObjId;
		FillDropdownPrintFormat(printFormatTypeId, sysPartId, sysPartObjId);
		return View(printFormatTypeId);
	}

	private void FillDropdownPrintFormat(int printFormatTypeId, int sysPartId = 0, int sysPartObjId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectPrintFormatByTypeId_Result> printFortants = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFortants(result2, printFormatTypeId, sysPartId, sysPartObjId);
			list.AddRange(Enumerable.Select<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)printFortants, (Func<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>)((CRMspSelectPrintFormatByTypeId_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.FileNameWeb + "|" + item.PrintFormatID + "|" + item.IsDefault.GetValueOrDefault(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.printFormatTypeList = list;
	}

	[AjaxOnly]
	public JsonResult GetPrintFormatList(int prtTypeId, int sysPartId = 0, int sysPartObjId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectPrintFormatByTypeId_Result> printFortants = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFortants(result2, prtTypeId, sysPartId, sysPartObjId);
			list.AddRange(Enumerable.Select<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>((IEnumerable<CRMspSelectPrintFormatByTypeId_Result>)printFortants, (Func<CRMspSelectPrintFormatByTypeId_Result, SelectListItem>)((CRMspSelectPrintFormatByTypeId_Result item) => new SelectListItem
			{
				Selected = false,
				Text = item.Title,
				Value = item.FileNameWeb + "|" + item.PrintFormatID + "|" + item.IsDefault.GetValueOrDefault()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.printFormatTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
