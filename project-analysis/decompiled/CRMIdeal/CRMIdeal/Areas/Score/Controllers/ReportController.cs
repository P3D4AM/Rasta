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
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Score.Controllers;

public class ReportController : Controller
{
	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actScoresReport")]
	public ActionResult Index()
	{
		ScoreReportViewModel model = new ScoreReportViewModel();
		return View(model);
	}

	public List<ScorespReport_Result> ListScoreReport(ScoreReportViewModel indicator)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<ScorespReport_Result> list = new List<ScorespReport_Result>();
		try
		{
			if (indicator != null)
			{
				indicator.ScoreReportFDate = ((!string.IsNullOrWhiteSpace(indicator.ScoreReportFDate)) ? indicator.ScoreReportFDate.Replace("/", "") : "");
				indicator.ScoreReportTDate = ((!string.IsNullOrWhiteSpace(indicator.ScoreReportTDate)) ? indicator.ScoreReportTDate.Replace("/", "") : "");
				indicator.ScoreReportCompanyId = (string.IsNullOrWhiteSpace(indicator.ScoreReportCompanyId) ? "0" : indicator.ScoreReportCompanyId);
				indicator.ScoreReportRuleId = (string.IsNullOrWhiteSpace(indicator.ScoreReportRuleId) ? "0" : indicator.ScoreReportRuleId);
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(indicator.ScoreReportFDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.ScoreReportFDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrWhiteSpace(indicator.ScoreReportTDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(indicator.ScoreReportTDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DateTime now = DateTime.Now;
				string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				string rptDate = now.ToString("yyyy/MM/dd");
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				string textEarningScore = Labels.TextEarningScore;
				string textSpendScore = Labels.TextSpendScore;
				list = Enumerable.ToList<ScorespReport_Result>((IEnumerable<ScorespReport_Result>)_dbIII.ScorespReport((!string.IsNullOrWhiteSpace(indicator.ScoreReportFDate)) ? new DateTime?(value) : null, (!string.IsNullOrWhiteSpace(indicator.ScoreReportTDate)) ? new DateTime?(value2) : null, indicator.ScoreReportRuleId, indicator.ScoreReportCompanyId, textEarningScore, textSpendScore, result2, userId, rptDate, rptDay, lCID, result));
				if (list != null)
				{
					if (Enumerable.Any<ScorespReport_Result>((IEnumerable<ScorespReport_Result>)list))
					{
						foreach (ScorespReport_Result item in list)
						{
							_ = item.ScoreDate;
							item.ScoreDatePersian = item.ScoreDate.ToString("yyyy/MM/dd");
							item.ScoreExpireDatePersian = (item.ScoreExpireDate.HasValue ? item.ScoreExpireDate.Value.ToString("yyyy/MM/dd") : "");
						}
					}
				}
				else
				{
					list = new List<ScorespReport_Result>();
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
	public ActionResult ScoreReport_Read([DataSourceRequest] DataSourceRequest request, string indicator)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		ScoreReportViewModel indicator2 = new JavaScriptSerializer().Deserialize<ScoreReportViewModel>(indicator);
		JsonResult jsonResult = Json(((IEnumerable)ListScoreReport(indicator2)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult ScoreReport(ScoreReportViewModel indicator)
	{
		JsonResult jsonResult = Json(ListScoreReport(indicator), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	private List<SelectListItem> GetScoreRule()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<ScorespSelectActiveScoreRules_Result> list2 = Enumerable.ToList<ScorespSelectActiveScoreRules_Result>((IEnumerable<ScorespSelectActiveScoreRules_Result>)_dbII.ScorespSelectActiveScoreRules(null, lCID, result, result2));
			if (list2 != null && Enumerable.Any<ScorespSelectActiveScoreRules_Result>((IEnumerable<ScorespSelectActiveScoreRules_Result>)list2))
			{
				list.AddRange(Enumerable.Select<ScorespSelectActiveScoreRules_Result, SelectListItem>((IEnumerable<ScorespSelectActiveScoreRules_Result>)list2, (Func<ScorespSelectActiveScoreRules_Result, SelectListItem>)((ScorespSelectActiveScoreRules_Result item) => new SelectListItem
				{
					Text = (item.RuleTitle ?? ""),
					Value = item.RuleId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetObjList(int typ, string selectedId = "")
	{
		string result = "";
		try
		{
			List<SelectListItem> list = new List<SelectListItem>();
			if (typ == 1)
			{
				list = GetScoreRule();
			}
			if (list != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<SelectListItem, nComboBoxListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, nComboBoxListItem>)((SelectListItem item) => new nComboBoxListItem
				{
					Text = item.Text,
					Value = item.Value,
					Selected = (item.Value == selectedId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
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
		List<ScorespReportSearchCompany_Result> list = new List<ScorespReportSearchCompany_Result>();
		try
		{
			list = Enumerable.ToList<ScorespReportSearchCompany_Result>((IEnumerable<ScorespReportSearchCompany_Result>)_dbIII.ScorespReportSearchCompany(value, lCID, result));
			if (list == null)
			{
				list = new List<ScorespReportSearchCompany_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
