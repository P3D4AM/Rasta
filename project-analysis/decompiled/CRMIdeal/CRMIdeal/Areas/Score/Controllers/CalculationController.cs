using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Score.Controllers;

public class CalculationController : Controller
{
	public class ThreadHub
	{
		public class ThreadHubObj
		{
			public bool? IsDone { get; set; }

			public string message { get; set; }

			public int? Percent { get; set; }

			public DateTime RegDate { get; set; }
		}

		private static List<ThreadHubObj> lstThreads = new List<ThreadHubObj>();

		public static int GetLastIndex()
		{
			return lstThreads.Count - 1;
		}

		public static ThreadHubObj GetThreadResult(int indx = -1)
		{
			if (indx != -1 && lstThreads.Count - 1 >= indx)
			{
				return lstThreads[indx];
			}
			return null;
		}

		public static void SetThreadResult(int indx = -1, int percent = 0, string message = null, bool? isDone = null)
		{
			if (indx != -1 && lstThreads.Count - 1 >= indx)
			{
				if (isDone.HasValue)
				{
					lstThreads[indx].IsDone = isDone;
				}
				if (percent != -1)
				{
					lstThreads[indx].Percent = percent;
				}
				if (message != null)
				{
					lstThreads[indx].message = message;
				}
			}
		}

		public static int AddThread(int percent = 0, string message = null, bool? isDone = null)
		{
			for (int i = 0; i < lstThreads.Count; i++)
			{
				if (lstThreads[i] != null && lstThreads[i].RegDate.AddHours(6.0) <= DateTime.Now)
				{
					lstThreads[i] = null;
				}
			}
			lstThreads.Add(new ThreadHubObj
			{
				IsDone = isDone,
				message = message,
				Percent = percent,
				RegDate = DateTime.Now
			});
			return GetLastIndex();
		}

		public static void ClearThreads(bool forceEmpty = false)
		{
			if (lstThreads.Count == Enumerable.ToList<ThreadHubObj>(Enumerable.Where<ThreadHubObj>((IEnumerable<ThreadHubObj>)lstThreads, (Func<ThreadHubObj, bool>)((ThreadHubObj x) => x == null))).Count)
			{
				lstThreads.Clear();
			}
			if (forceEmpty)
			{
				lstThreads.Clear();
			}
		}

		public static void RemoveThread(int indx = -1, bool autoEmpty = false)
		{
			if (indx != -1)
			{
				lstThreads[indx] = null;
			}
			if (autoEmpty)
			{
				ClearThreads();
			}
		}
	}

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actScoreCalculation")]
	public ActionResult Index()
	{
		return View();
	}

	public int ScoreCalculation(string fdate = "", string tdate = "", string ruleIds = "", string cmpId = "")
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				ScoreCalculationAsync(fdate, tdate, ruleIds, cmpId, indx);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 100, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void ScoreCalculationAsync(string fdate = "", string tdate = "", string ruleIds = "", string cmpId = "", int indx = 0)
	{
		CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime value4 = DateTime.Now;
			DateTime value5 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fdate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(fdate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrWhiteSpace(tdate))
			{
				value5 = DateTime.Parse(PersianDate.GetFormatetdDate(tdate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			string textEarningScore = Labels.TextEarningScore;
			string textSpendScore = Labels.TextSpendScore;
			ObjectParameter returnCntRow = new ObjectParameter("returnCntRow", typeof(long));
			((IObjectContextAdapter)cRMSpIIIEntities).ObjectContext.CommandTimeout = 600;
			List<ScorespInsertAndCalcScores_Result> list = Enumerable.ToList<ScorespInsertAndCalcScores_Result>((IEnumerable<ScorespInsertAndCalcScores_Result>)cRMSpIIIEntities.ScorespInsertAndCalcScores((!string.IsNullOrWhiteSpace(fdate)) ? new DateTime?(value4) : null, (!string.IsNullOrWhiteSpace(tdate)) ? new DateTime?(value5) : null, ruleIds, cmpId, now, userId, value2, value3, value, registerDatePersian, appType, lCID, result, true, centerId, false, returnCntRow, textEarningScore, textSpendScore));
			string message = "";
			if (list != null && Enumerable.Any<ScorespInsertAndCalcScores_Result>((IEnumerable<ScorespInsertAndCalcScores_Result>)list))
			{
				foreach (ScorespInsertAndCalcScores_Result item in list)
				{
					item.ScoreDatePersian = (item.ScoreDate.HasValue ? item.ScoreDate.Value.ToString("yyyy/MM/dd") : "");
					item.ScoreExpireDatePersian = (item.ScoreExpireDate.HasValue ? item.ScoreExpireDate.Value.ToString("yyyy/MM/dd") : "");
				}
				message = JsonConvert.SerializeObject(Enumerable.ToList<ScorespInsertAndCalcScores_Result>((IEnumerable<ScorespInsertAndCalcScores_Result>)list));
			}
			ThreadHub.SetThreadResult(indx, 100, message, true);
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 100, ex.Message, false);
		}
		finally
		{
			cRMSpIIIEntities?.Dispose();
		}
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetLinkAccThreadResult(int indx = -1)
	{
		ThreadHub.ThreadHubObj threadResult = ThreadHub.GetThreadResult(indx);
		if (threadResult != null)
		{
			threadResult.IsDone = threadResult.IsDone.GetValueOrDefault();
			if ((threadResult.IsDone.GetValueOrDefault() || threadResult.IsDone == false) && threadResult.message != null)
			{
				ThreadHub.RemoveThread(indx, autoEmpty: true);
			}
		}
		return JsonConvert.SerializeObject(threadResult);
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
