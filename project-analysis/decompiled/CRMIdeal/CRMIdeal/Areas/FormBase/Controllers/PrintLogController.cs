using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class PrintLogController : Controller
{
	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index(int objId, int printFormatTypeId, string partName = "")
	{
		base.ViewBag.ObjectId = objId;
		base.ViewBag.PrintFormatTypeId = printFormatTypeId;
		base.ViewBag.PartName = partName;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPrintLog(int objId, int printFormatTypeId, int topValue, long lastRowNumber)
	{
		PrintLogListViewModel printLogListViewModel = new PrintLogListViewModel();
		printLogListViewModel.ListPrintLog = new List<PrintLogViewModel>();
		printLogListViewModel.LastRowNumber = 0L;
		printLogListViewModel.LastPrintLogId = 0;
		printLogListViewModel.LoadMore = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			printLogListViewModel = PrintLog.GetListPrintLog(objId, printFormatTypeId, topValue, lastRowNumber);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(printLogListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
