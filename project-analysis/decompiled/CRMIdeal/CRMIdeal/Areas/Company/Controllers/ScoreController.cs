using System;
using System.Collections.Generic;
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
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Company.Controllers;

public class ScoreController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private const string _Type_ErrorTitle = "Error";

	public ActionResult Index(int position, int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmCompanyI";
			text2 = "actShowCmpScore";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			string text3 = "";
			string text4 = "0";
			string text5 = "0";
			try
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					text3 = companyById.CompanyName ?? "";
					CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)_dbI.CRMspReturnSumCompanyScores(cmpId, result2));
					if (cRMspReturnSumCompanyScores_Result != null)
					{
						double result3 = 0.0;
						double result4 = 0.0;
						double.TryParse(cRMspReturnSumCompanyScores_Result.SumScores.ToString(), out result3);
						double.TryParse(cRMspReturnSumCompanyScores_Result.SumUsableScores.ToString(), out result4);
						text4 = result3.ToString();
						text5 = result4.ToString();
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			base.ViewBag.Position = position;
			base.ViewBag.CmpId = cmpId;
			base.ViewBag.CmpName = text3;
			base.ViewBag.CmpSumScores = text4;
			base.ViewBag.CmpSumUsableScores = text5;
			return View();
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	[AjaxOnly]
	public JsonResult GetCompanyScores(int cmpId, string fromDate, string toDate, int pageNumber = 1, int pageSize = 100)
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
		CompanyScoresViewModel companyScoresViewModel = new CompanyScoresViewModel();
		companyScoresViewModel.CompanyScores = new List<ScorespSelectCompanyScores_Result>();
		companyScoresViewModel.IsFind = false;
		companyScoresViewModel.Message = "";
		companyScoresViewModel.TotalPage = 0L;
		try
		{
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			try
			{
				if (!string.IsNullOrEmpty(fromDate))
				{
					fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					value = lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
					};
				}
				else
				{
					companyScoresViewModel.Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.CompanyScoreFromDate);
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				companyScoresViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.CompanyScoreFromDate);
			}
			try
			{
				if (!string.IsNullOrEmpty(toDate))
				{
					toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					value2 = lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
					};
				}
				else
				{
					companyScoresViewModel.Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.CompanyScoreToDate);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				companyScoresViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.CompanyScoreToDate);
			}
			if (cmpId == 0)
			{
				companyScoresViewModel.Message = Messages.msgErrorNotSelectCompany;
			}
			if (string.IsNullOrWhiteSpace(companyScoresViewModel.Message))
			{
				string textRemaindScoreBefore = Labels.TextRemaindScoreBefore;
				string textEarningScore = Labels.TextEarningScore;
				string textSpendScore = Labels.TextSpendScore;
				companyScoresViewModel.CompanyScores = Enumerable.ToList<ScorespSelectCompanyScores_Result>((IEnumerable<ScorespSelectCompanyScores_Result>)_dbI.ScorespSelectCompanyScores(cmpId, value, value2, textRemaindScoreBefore, textEarningScore, textSpendScore, pageNumber, pageSize, lCID, result, result2));
				if (companyScoresViewModel.CompanyScores != null && Enumerable.Any<ScorespSelectCompanyScores_Result>((IEnumerable<ScorespSelectCompanyScores_Result>)companyScoresViewModel.CompanyScores))
				{
					companyScoresViewModel.IsFind = true;
					foreach (ScorespSelectCompanyScores_Result companyScore in companyScoresViewModel.CompanyScores)
					{
						companyScore.ScoreDatePersian = (companyScore.ScoreDate.HasValue ? companyScore.ScoreDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						companyScore.ScoreExpireDatePersian = (companyScore.ScoreExpireDate.HasValue ? companyScore.ScoreExpireDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					}
					ScorespSelectCompanyScores_Result scorespSelectCompanyScores_Result = Enumerable.FirstOrDefault<ScorespSelectCompanyScores_Result>((IEnumerable<ScorespSelectCompanyScores_Result>)companyScoresViewModel.CompanyScores);
					long result3 = 0L;
					if (scorespSelectCompanyScores_Result != null)
					{
						long.TryParse(scorespSelectCompanyScores_Result.AllPage.ToString(), out result3);
					}
					companyScoresViewModel.TotalPage = result3;
				}
				else
				{
					companyScoresViewModel.CompanyScores = new List<ScorespSelectCompanyScores_Result>();
					companyScoresViewModel.Message = Messages.ErrorNotFound;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			companyScoresViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(companyScoresViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCompanyUsableScore(int cmpId = 0)
	{
		string result = "";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)_dbI.CRMspReturnSumCompanyScores(cmpId, result2));
			if (cRMspReturnSumCompanyScores_Result != null)
			{
				result = cRMspReturnSumCompanyScores_Result.SumUsableScores + "," + cRMspReturnSumCompanyScores_Result.SumScores;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string CalcCompanyScore(int? replyCompanyId = null, int? replyUserId = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<ScorespInsertAndCalcSurveyScores_Result> list2 = new List<ScorespInsertAndCalcSurveyScores_Result>();
			List<ScorespInsertAndCalcSurveyScores_Result> list3 = Enumerable.ToList<ScorespInsertAndCalcSurveyScores_Result>((IEnumerable<ScorespInsertAndCalcSurveyScores_Result>)cRMSpIIEntities.ScorespInsertAndCalcSurveyScores(null, null, replyCompanyId, replyUserId, userId, value2, value3, value, registerDatePersian, appType, lCID, result, null, result2, true));
			if (list3 != null)
			{
				list2.AddRange(list3);
			}
			List<ScorespInsertAndCalcDyFormScores_Result> list4 = Enumerable.ToList<ScorespInsertAndCalcDyFormScores_Result>((IEnumerable<ScorespInsertAndCalcDyFormScores_Result>)cRMSpIIEntities.ScorespInsertAndCalcDyFormScores(null, null, replyCompanyId, replyUserId, userId, value2, value3, value, registerDatePersian, appType, lCID, result, null, null, result2, true));
			if (list4 != null)
			{
				list2.AddRange(Enumerable.Select<ScorespInsertAndCalcDyFormScores_Result, ScorespInsertAndCalcSurveyScores_Result>((IEnumerable<ScorespInsertAndCalcDyFormScores_Result>)list4, (Func<ScorespInsertAndCalcDyFormScores_Result, ScorespInsertAndCalcSurveyScores_Result>)((ScorespInsertAndCalcDyFormScores_Result x) => new ScorespInsertAndCalcSurveyScores_Result
				{
					ScoreId = x.ScoreId,
					RuleId = x.RuleId,
					SurveyId = x.FormId,
					SurTitle = x.Form,
					RegisterDate = x.RegisterDate,
					RegisterDatePersian = x.RegisterDatePersian,
					ObjFirstRegisterDate = x.ObjFirstRegisterDate,
					ObjFirstRegisterDatePersian = x.ObjFirstRegisterDatePersian,
					RuleTitle = x.RuleTitle,
					RuleIsCmpScore = x.RuleIsCmpScore,
					CmpScore = x.CmpScore,
					CmpScore_CmpId = x.CmpScore_CmpId,
					CmpScore_Cmp = x.CmpScore_Cmp,
					RuleIsUserScore = x.RuleIsUserScore,
					UserScore = x.UserScore,
					UserScore_EPId = x.UserScore_EPId,
					UserScore_EP = x.UserScore_EP,
					UserScore_UserId = x.UserScore_UserId,
					UserScore_User = x.UserScore_User,
					CalcExpireDate = x.CalcExpireDate,
					CalcExpireDatePersian = x.CalcExpireDatePersian
				})));
			}
			List<ScorespInsertAndCalcTicketScores_Result> list5 = Enumerable.ToList<ScorespInsertAndCalcTicketScores_Result>((IEnumerable<ScorespInsertAndCalcTicketScores_Result>)cRMSpIIEntities.ScorespInsertAndCalcTicketScores(null, replyCompanyId, replyUserId, userId, value2, value3, value, registerDatePersian, appType, lCID, result, null, result2, true));
			if (list5 != null)
			{
				list2.AddRange(Enumerable.Select<ScorespInsertAndCalcTicketScores_Result, ScorespInsertAndCalcSurveyScores_Result>((IEnumerable<ScorespInsertAndCalcTicketScores_Result>)list5, (Func<ScorespInsertAndCalcTicketScores_Result, ScorespInsertAndCalcSurveyScores_Result>)((ScorespInsertAndCalcTicketScores_Result x) => new ScorespInsertAndCalcSurveyScores_Result
				{
					ScoreId = x.ScoreId,
					RuleId = x.RuleId,
					SurveyId = x.ProjectId,
					SurTitle = x.Project,
					RegisterDate = x.RegisterDate,
					RegisterDatePersian = x.RegisterDatePersian,
					ObjFirstRegisterDate = x.ObjFirstRegisterDate,
					ObjFirstRegisterDatePersian = x.ObjFirstRegisterDatePersian,
					RuleTitle = x.RuleTitle,
					RuleIsCmpScore = x.RuleIsCmpScore,
					CmpScore = x.CmpScore,
					CmpScore_CmpId = x.CmpScore_CmpId,
					CmpScore_Cmp = x.CmpScore_Cmp,
					RuleIsUserScore = x.RuleIsUserScore,
					UserScore = x.UserScore,
					UserScore_EPId = x.UserScore_EPId,
					UserScore_EP = x.UserScore_EP,
					UserScore_UserId = x.UserScore_UserId,
					UserScore_User = x.UserScore_User,
					CalcExpireDate = x.CalcExpireDate,
					CalcExpireDatePersian = x.CalcExpireDatePersian
				})));
			}
			if (list2.Count > 0)
			{
				list.Add(new SelectListItem
				{
					Text = "Data",
					Value = JsonConvert.SerializeObject(list2)
				});
			}
		}
		catch (Exception ex)
		{
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = ex.Message
			});
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
		return JsonConvert.SerializeObject(list);
	}

	public static string CalcDyFormScores(int? masterValueId = null, int? dyFormId = null, int? replyCompanyId = null, int? replyUserId = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int? masterValueId2 = masterValueId;
			List<ScorespInsertAndCalcDyFormScores_Result> list2 = Enumerable.ToList<ScorespInsertAndCalcDyFormScores_Result>((IEnumerable<ScorespInsertAndCalcDyFormScores_Result>)cRMSpIIEntities.ScorespInsertAndCalcDyFormScores(dyFormId, masterValueId2, replyCompanyId, replyUserId, userId, value2, value3, value, registerDatePersian, appType, lCID, result, null, null, result2, true));
			if (list2 != null)
			{
				list.Add(new SelectListItem
				{
					Text = "Data",
					Value = JsonConvert.SerializeObject(list2)
				});
			}
		}
		catch (Exception ex)
		{
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = ex.Message
			});
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
		return JsonConvert.SerializeObject(list);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
