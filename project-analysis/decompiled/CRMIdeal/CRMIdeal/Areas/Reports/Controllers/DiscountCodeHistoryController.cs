using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Reports.Controllers;

public class DiscountCodeHistoryController : Controller
{
	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPrintDiscountCodeHistory")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult DiscountCodeHistory_Read([DataSourceRequest] DataSourceRequest request, string disCode = "", string fDate = "", string tDate = "")
	{
		List<WSspRpt_DiscountCodeHistory_Result> enumerable = new List<WSspRpt_DiscountCodeHistory_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime? fromDate = null;
			DateTime? toDate = null;
			try
			{
				if (!string.IsNullOrWhiteSpace(fDate))
				{
					string formatetdDate = PersianDate.GetFormatetdDate(fDate.Replace("/", ""));
					fromDate = lCID switch
					{
						1065 => DateTime.Parse(formatetdDate + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception)
			{
				fromDate = null;
			}
			try
			{
				if (!string.IsNullOrWhiteSpace(tDate))
				{
					string formatetdDate2 = PersianDate.GetFormatetdDate(tDate.Replace("/", ""));
					toDate = lCID switch
					{
						1065 => DateTime.Parse(formatetdDate2 + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(formatetdDate2 + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(formatetdDate2 + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception)
			{
				toDate = null;
			}
			List<WSspRpt_DiscountCodeHistory_Result> list = Enumerable.ToList<WSspRpt_DiscountCodeHistory_Result>((IEnumerable<WSspRpt_DiscountCodeHistory_Result>)_dbII.WSspRpt_DiscountCodeHistory(disCode, fromDate, toDate, lCID, result));
			if (list != null)
			{
				foreach (WSspRpt_DiscountCodeHistory_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				enumerable = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}
}
