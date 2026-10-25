using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Costsheets.Controllers;

public class IndicatorController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCostSheetIndicator")]
	public ActionResult Index(int position = 0, int cmpId = 0, string cmpName = "")
	{
		CostSheetIndicatorViewModel model = new CostSheetIndicatorViewModel
		{
			CtshIndicatorCompanyId = cmpId.ToString(),
			CtshIndicatorCompanyName = cmpName
		};
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetCompany(string value = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheetIndcSearchCompany_Result> data = new List<WSspSelectCostSheetIndcSearchCompany_Result>();
		try
		{
			data = Enumerable.ToList<WSspSelectCostSheetIndcSearchCompany_Result>((IEnumerable<WSspSelectCostSheetIndcSearchCompany_Result>)_db.WSspSelectCostSheetIndcSearchCompany(value, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public string DefineDayeOfWeekFa(string day)
	{
		return day switch
		{
			"Saturday" => Labels.Saturday, 
			"Sunday" => Labels.Sunday, 
			"Monday" => Labels.Monday, 
			"Tuesday" => Labels.Tuesday, 
			"Wednesday" => Labels.Wednesday, 
			"Thursday" => Labels.Thursday, 
			"Friday" => Labels.Friday, 
			_ => day, 
		};
	}

	public List<WSspCostSheetIndicator_Result> ListCtshIndicator(CostSheetIndicatorViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspCostSheetIndicator_Result> list = new List<WSspCostSheetIndicator_Result>();
		try
		{
			if (indicator != null)
			{
				indicator.CtshIndicatorDate = ((!string.IsNullOrEmpty(indicator.CtshIndicatorDate)) ? indicator.CtshIndicatorDate.Replace("/", "") : "");
				indicator.CtshIndicatorFDate = ((!string.IsNullOrEmpty(indicator.CtshIndicatorFDate)) ? indicator.CtshIndicatorFDate.Replace("/", "") : "");
				indicator.CtshIndicatorTDate = ((!string.IsNullOrEmpty(indicator.CtshIndicatorTDate)) ? indicator.CtshIndicatorTDate.Replace("/", "") : "");
				indicator.CtshIndicatorNumber = (string.IsNullOrEmpty(indicator.CtshIndicatorNumber) ? "0" : indicator.CtshIndicatorNumber);
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(indicator.CtshIndicatorDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.CtshIndicatorDate.Replace("/", "")), lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.CtshIndicatorFDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.CtshIndicatorFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(indicator.CtshIndicatorTDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.CtshIndicatorTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
				list = Enumerable.ToList<WSspCostSheetIndicator_Result>((IEnumerable<WSspCostSheetIndicator_Result>)_db.WSspCostSheetIndicator((!string.IsNullOrEmpty(indicator.CtshIndicatorDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(indicator.CtshIndicatorFDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(indicator.CtshIndicatorTDate)) ? new DateTime?(value3) : null, indicator.CtshIndicatorNumber, indicator.CtshIndicatorCompanyId, lCID, result, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), DefineDayeOfWeekFa(dayOfWeek.ToString())));
			}
			foreach (WSspCostSheetIndicator_Result item in list)
			{
				item.ctshTotalAmount = item.ctshTotalAmount.GetValueOrDefault();
				if (lCID != 1065 && !string.IsNullOrEmpty(item.ctshDatePersian))
				{
					item.ctshDatePersian = PersianDate.GetShamsi2Miladi(item.ctshDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult CtshIndicator_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		CostSheetIndicatorViewModel indicator2 = new JavaScriptSerializer().Deserialize<CostSheetIndicatorViewModel>(indicator);
		return Json(((IEnumerable)ListCtshIndicator(indicator2)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult CtshIndicator(CostSheetIndicatorViewModel indicator)
	{
		return Json(ListCtshIndicator(indicator), JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
