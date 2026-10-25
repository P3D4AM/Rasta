using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Resources;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Mobile.Cache.Setting;
using Mobile.Classes.Helper;
using Mobile.Models;

namespace Mobile.Controllers;

public class MobErrorLogsController : Controller
{
	private CRMEntities _db = new CRMEntities();

	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult ModErrorLog_Read([DataSourceRequest] DataSourceRequest request, string fDate, string tDate, int cmpId = 0, int prsId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		List<MobspSelectErrorLogs_Result> list = new List<MobspSelectErrorLogs_Result>();
		try
		{
			if (!string.IsNullOrEmpty(fDate))
			{
				fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value = ((lCID != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"));
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value2 = ((lCID != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59"));
			}
			list = Enumerable.ToList<MobspSelectErrorLogs_Result>((IEnumerable<MobspSelectErrorLogs_Result>)_db.MobspSelectErrorLogs(value, value2, cmpId, prsId));
			foreach (MobspSelectErrorLogs_Result item in list)
			{
				item.RegisterDatePersian = DateTimeClass.ConvertDateWoSlashToSlash(item.RegisterDatePersian);
				_ = item.RegisterDate;
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd") + string.Format(" ({0})", item.RegisterDate.ToString("HH:mm:ss"));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}

	public ActionResult LoginError(string msgStr = "")
	{
		if (msgStr == "")
		{
			msgStr = Labels.Error;
		}
		base.ViewBag.message = msgStr;
		return View();
	}
}
