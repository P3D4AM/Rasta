using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Score.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public ScorespSelectScoreRulesWithId_Result sp;

		public int currLangID;

		internal bool _003CRuleInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRuleInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRuleInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_1
	{
		public ScoreRules findedRecord;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass18_1 CS_0024_003C_003E8__locals1;

		internal bool _003CRuleInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRuleInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRuleInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRuleInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	private readonly CRMSpIIEntities _db_II = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _db_III = new CRMSpIIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private const string JobName = "CalcAndInsertOrderScores";

	public ActionResult Index()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmCompanyScores", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int sysPartId = 0, int objId = 0, int scoreId = 0, int cmpId = 0, int ordId = 0, int scoreKind = 0)
	{
		ScorespSelectScoreWithId_Result scorespSelectScoreWithId_Result = new ScorespSelectScoreWithId_Result();
		scorespSelectScoreWithId_Result.ScoreSysPartId = sysPartId;
		scorespSelectScoreWithId_Result.ScoreObjectId = objId;
		scorespSelectScoreWithId_Result.ScoreCmpId = cmpId;
		scorespSelectScoreWithId_Result.ScoreOrderId = ordId;
		scorespSelectScoreWithId_Result.ScoreDatePersian = DateTime.Now.ToString("yyyy/MM/dd");
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		try
		{
			if (scoreId != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				ScorespSelectScoreWithId_Result scorespSelectScoreWithId_Result2 = Enumerable.FirstOrDefault<ScorespSelectScoreWithId_Result>((IEnumerable<ScorespSelectScoreWithId_Result>)_db_I.ScorespSelectScoreWithId(scoreId, lCID, result2));
				if (scorespSelectScoreWithId_Result2 != null)
				{
					scorespSelectScoreWithId_Result = scorespSelectScoreWithId_Result2;
				}
			}
			CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)_db_I.CRMspReturnSumCompanyScores(scorespSelectScoreWithId_Result.ScoreCmpId, result));
			if (cRMspReturnSumCompanyScores_Result != null)
			{
				scorespSelectScoreWithId_Result.CmpAllSumScores = cRMspReturnSumCompanyScores_Result.SumScores;
				scorespSelectScoreWithId_Result.CmpSumUsableScores = cRMspReturnSumCompanyScores_Result.SumUsableScores;
			}
			scorespSelectScoreWithId_Result.ScoreKind = scoreKind;
			if (scorespSelectScoreWithId_Result.ScoreKind == 0)
			{
				if (scorespSelectScoreWithId_Result.Score < 0.0)
				{
					scorespSelectScoreWithId_Result.ScoreKind = -1;
				}
				else if (scorespSelectScoreWithId_Result.Score > 0.0)
				{
					scorespSelectScoreWithId_Result.ScoreKind = 1;
				}
				else
				{
					scorespSelectScoreWithId_Result.ScoreKind = -1;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		string sysPartIds = "";
		if (scorespSelectScoreWithId_Result.ScoreId == 0)
		{
			switch (scoreKind)
			{
			case -1:
				sysPartIds = "90,95";
				break;
			case 1:
				sysPartIds = "80,95";
				break;
			}
		}
		base.ViewBag.SystemParts = GetScoreSystemParts(scorespSelectScoreWithId_Result.ScoreSysPartId.GetValueOrDefault(), sysPartIds);
		base.ViewBag.ScoreRules = GetScoreRulesSelectListItem(scorespSelectScoreWithId_Result.ScoreSysPartId.GetValueOrDefault(), scorespSelectScoreWithId_Result.ScoreRuleId.GetValueOrDefault());
		base.ViewBag.CompanyId = cmpId;
		return View(scorespSelectScoreWithId_Result);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCompanyScoresDataEntry", ActionName = "actPost")]
	public string InsertEdit(int scoreId = 0, string scoreDatePersian = null, double score = 0.0, int? scoreRuleId = null, int? scoreOrderId = null, int? scoreCmpId = null, int? orderView = null, int? scoreSysPartId = null, int? scoreObjectId = null, int? scoreOprType = null, string scoreExpireDatePersian = null, int? scoreExpireDay = null, bool? scoreIsExpired = null, string scoreDescription = null, string scoreDescription_Lang = null, decimal price = 0m, int? companyId = null, string otherInfoJs = "", int scoreKind = -1, float? scoreRuleRate = null)
	{
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			int value2 = int.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(Financial.Get().Id.ToString());
			short value4 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("Result", 0);
			DateTime dateTime = default(DateTime);
			string text = "";
			DateTime? scoreDate = null;
			DateTime? dateTime2 = null;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			dateTime = default(DateTime);
			text = "";
			try
			{
				if (!string.IsNullOrEmpty(scoreDatePersian))
				{
					text = PersianDate.GetFormatetdDate(scoreDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						scoreDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						scoreDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						scoreDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					scoreDate = dateTime;
				}
				else
				{
					scoreDatePersian = null;
				}
			}
			catch (Exception)
			{
				return Messages.WrongDateTime;
			}
			dateTime = default(DateTime);
			text = "";
			try
			{
				if (!string.IsNullOrEmpty(scoreExpireDatePersian))
				{
					text = PersianDate.GetFormatetdDate(scoreExpireDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						scoreExpireDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						scoreExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						scoreExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					dateTime2 = dateTime;
				}
				else
				{
					dateTime2 = null;
					scoreExpireDatePersian = null;
				}
			}
			catch (Exception)
			{
				return Messages.WrongDateTime;
			}
			if (!dateTime2.HasValue && scoreExpireDay.GetValueOrDefault() != 0)
			{
				try
				{
					dateTime2 = DateTime.Now.AddDays(scoreExpireDay.GetValueOrDefault());
					scoreExpireDatePersian = dateTime2?.ToString("yyyyMMdd", new PersianCulture());
				}
				catch (Exception)
				{
					dateTime2 = null;
					scoreExpireDatePersian = null;
				}
			}
			if (!scoreOprType.HasValue)
			{
				if (score > 0.0)
				{
					scoreOprType = 1;
				}
				else if (score <= 0.0)
				{
					scoreOprType = 2;
				}
			}
			if (scoreSysPartId.GetValueOrDefault() == 80)
			{
				string arg = "";
				if (!string.IsNullOrWhiteSpace(otherInfoJs) && otherInfoJs.Replace("[]", "") != "" && otherInfoJs.Replace("{}", "") != "")
				{
					WSDiscountCodeLanguageViewModel wSDiscountCodeLanguageViewModel = JsonConvert.DeserializeObject<WSDiscountCodeLanguageViewModel>(otherInfoJs);
					wSDiscountCodeLanguageViewModel.DisCmpId = scoreCmpId;
					arg = wSDiscountCodeLanguageViewModel.DisCode;
					wSDiscountCodeLanguageViewModel.ScoreRate = score;
					dateTime = default(DateTime);
					text = "";
					try
					{
						if (!string.IsNullOrEmpty(wSDiscountCodeLanguageViewModel.DisExpDatePersian))
						{
							text = PersianDate.GetFormatetdDate(wSDiscountCodeLanguageViewModel.DisExpDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								wSDiscountCodeLanguageViewModel.DisExpDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								wSDiscountCodeLanguageViewModel.DisExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								wSDiscountCodeLanguageViewModel.DisExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							wSDiscountCodeLanguageViewModel.DisExpDate = dateTime;
						}
						else
						{
							wSDiscountCodeLanguageViewModel.DisExpDatePersian = null;
						}
					}
					catch (Exception)
					{
						return Messages.WrongDateTime;
					}
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(wSDiscountCodeLanguageViewModel.DisTitle_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(wSDiscountCodeLanguageViewModel.DisTitle_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = wSDiscountCodeLanguageViewModel.DisTitle,
						LanguageId = lCID
					});
					if (string.IsNullOrEmpty(wSDiscountCodeLanguageViewModel.DisTitle))
					{
						return string.Format(Messages.ErrorEmpty, Labels.DisCodeTitle) + "<br/>";
					}
					if (!checkMultiLanguage(wSDiscountCodeLanguageViewModel.DisTitle, list))
					{
						return string.Format(Messages.CheckFieldInLang, Labels.DisCodeTitle) + "<br>";
					}
					otherInfoJs = JsonConvert.SerializeObject(wSDiscountCodeLanguageViewModel);
				}
				else
				{
					otherInfoJs = "";
				}
				if (scoreId == 0)
				{
					scoreDescription = scoreDescription + " " + string.Format(Messages.msgAutoInsertToDiscountCodeHistory, score.ToString("#,#"), arg);
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrWhiteSpace(scoreDescription_Lang))
					{
						list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(scoreDescription_Lang);
					}
					else
					{
						foreach (Languages item in Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages x) => x.LanguageID != defLangID)))
						{
							list2.Add(new CommonMultiLanguageViewModel
							{
								LanguageId = item.LanguageID
							});
						}
					}
					foreach (CommonMultiLanguageViewModel item2 in list2)
					{
						item2.Value = item2.Value + " " + string.Format(Messages.ResourceManager.GetString("msgAutoInsertToDiscountCodeHistory", new CultureInfo(item2.LanguageId)), score.ToString("#,#"), arg);
					}
					scoreDescription_Lang = JsonConvert.SerializeObject(list2);
				}
			}
			else if (scoreSysPartId.GetValueOrDefault() == 90 && scoreId == 0)
			{
				scoreDescription = scoreDescription + " " + string.Format(Messages.msgAutoInsertToMoneyBag, price.ToString("#,#"), Labels.LanguageMainCurrency, scoreRuleRate.ToString());
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(scoreDescription_Lang))
				{
					list3 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(scoreDescription_Lang);
				}
				else
				{
					foreach (Languages item3 in Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages x) => x.LanguageID != defLangID)))
					{
						list3.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = item3.LanguageID
						});
					}
				}
				foreach (CommonMultiLanguageViewModel item4 in list3)
				{
					item4.Value = item4.Value + ((item4.Value != null) ? " " : "") + string.Format(Messages.ResourceManager.GetString("msgAutoInsertToMoneyBag", new CultureInfo(item4.LanguageId)), price.ToString("#,#"), Labels.ResourceManager.GetString("LanguageMainCurrency", new CultureInfo(item4.LanguageId)), scoreRuleRate.ToString());
				}
				scoreDescription_Lang = JsonConvert.SerializeObject(list3);
			}
			if (scoreId != 0)
			{
				_db_I.ScorespUpdateScore(scoreId, scoreDate, score, (scoreRuleId == 0) ? null : scoreRuleId, orderView, value2, userId, value3, value4, value, appType, lCID, defLangID, scoreSysPartId, (scoreObjectId == 0) ? null : scoreObjectId, scoreOprType, dateTime2, scoreIsExpired, scoreDescription, scoreDescription_Lang, otherInfoJs, companyId, price, objectParameter, scoreKind, result2);
			}
			else
			{
				_db_I.ScorespInsertScore(scoreDate, score, (scoreOrderId == 0) ? null : scoreOrderId, scoreCmpId, (scoreRuleId == 0) ? null : scoreRuleId, orderView, value2, userId, value3, value4, value, appType, lCID, defLangID, scoreSysPartId, (scoreObjectId == 0) ? null : scoreObjectId, scoreOprType, dateTime2, scoreIsExpired, scoreDescription, scoreDescription_Lang, otherInfoJs, companyId, price, objectParameter, scoreKind, result2);
			}
			if (objectParameter != null && int.Parse(objectParameter.Value.ToString()) == 0)
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex5)
		{
			Public.InsExceptToElmah(ex5);
			result = ex5.Message;
		}
		return result;
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCompanyScores", ActionName = "actDelete")]
	public string Delete(int scoreId = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_db_I.ScorespDeleteScore(scoreId, userId, value2, value, now, registerDatePersian, appType, result2, centerId));
			if (mct_I_Result != null && mct_I_Result.Result != 1 && mct_I_Result.Result == 0)
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public List<SelectListItem> GetScoreSystemParts(int selectedId = 0, string sysPartIds = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (string.IsNullOrWhiteSpace(sysPartIds))
			{
				sysPartIds = "80,90,95";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_db_I.CRMspSelectActiveSystemParts(lCID, result, sysPartIds));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2, (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result x) => x.Type == "CRM" && (x.SystemPartId == 80 || x.SystemPartId == 90 || x.SystemPartId == 95))), (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result x) => new SelectListItem
				{
					Text = x.PartTitle,
					Value = x.SystemPartId.ToString(),
					Selected = (x.SystemPartId == selectedId)
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	public List<SelectListItem> GetScoreRulesSelectListItem(int sysPartId = 0, int ruleId = 0)
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
			List<ScorespSelectScoreRules_Result> list2 = Enumerable.ToList<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)_db_I.ScorespSelectScoreRules(0, lCID, result, result2));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<ScorespSelectScoreRules_Result, SelectListItem>((IEnumerable<ScorespSelectScoreRules_Result>)list2, (Func<ScorespSelectScoreRules_Result, SelectListItem>)((ScorespSelectScoreRules_Result x) => new SelectListItem
				{
					Text = x.RuleTitle,
					Value = x.RuleId.ToString(),
					Selected = (x.RuleId == ruleId)
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	public string GetScoreRulesSelectListItemJs(int sysPartId = 0, int ruleId = 0)
	{
		return JsonConvert.SerializeObject(GetScoreRulesSelectListItem(sysPartId, ruleId));
	}

	[HttpPost]
	public string GetScoreRulesJs(int sysPartId = 0, int ruleId = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<ScorespSelectScoreRules_Result> list = Enumerable.ToList<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)_db_I.ScorespSelectScoreRules(sysPartId, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineScoreRules")]
	public ActionResult Rule()
	{
		List<CRMspSelectScoreRulesSetting_Result> list = new List<CRMspSelectScoreRulesSetting_Result>();
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			list = Enumerable.ToList<CRMspSelectScoreRulesSetting_Result>((IEnumerable<CRMspSelectScoreRulesSetting_Result>)_db_I.CRMspSelectScoreRulesSetting(result));
			if (list == null)
			{
				list = new List<CRMspSelectScoreRulesSetting_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ScoreRulesSettingJs = JsonConvert.SerializeObject(list);
		base.ViewBag.SystemParts = GetRuleSysParts();
		return View();
	}

	public List<ScorespSelectScoreRules_Result> SelectScoreRules(int systemPartId)
	{
		List<ScorespSelectScoreRules_Result> list = new List<ScorespSelectScoreRules_Result>();
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
			list = Enumerable.ToList<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)_db_I.ScorespSelectScoreRules(systemPartId, lCID, result, result2));
			if (list != null)
			{
				foreach (ScorespSelectScoreRules_Result item in list)
				{
					item.RuleFromDatePersian = (item.RuleFromDate.HasValue ? item.RuleFromDate?.ToString("yyyy/MM/dd") : "");
					item.RuleToDatePersian = (item.RuleFromDate.HasValue ? item.RuleToDate?.ToString("yyyy/MM/dd") : "");
					_ = item.FirstRegisterDate;
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd");
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
					item.RuleExpireDatePersian = (item.RuleExpireDate.HasValue ? item.RuleExpireDate?.ToString("yyyy/MM/dd") : "");
					item.RuleScoreExpireDatePersian = (item.RuleScoreExpireDate.HasValue ? item.RuleScoreExpireDate?.ToString("yyyy/MM/dd") : "");
					item.RulePrdFGNames = Product.GetFirstGroupNames(item.RulePrdFGIds);
					item.RulePrdSGNames = Product.GetSecondGroupNames(item.RulePrdSGIds);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ScoreRules = list;
		return list;
	}

	public ActionResult ScoreRules_Read([DataSourceRequest] DataSourceRequest request, int systemPartId = 0)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectScoreRules(systemPartId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmDefineScoreRule", ActionName = "actInsert,actEdit")]
	public ActionResult RuleInsertEdit(int scoreRuleId = 0, int sysPartId = 0)
	{
		ScoreRulesViewModel scoreRulesViewModel = new ScoreRulesViewModel();
		scoreRulesViewModel.RuleSysPartId = sysPartId;
		if (scoreRuleId <= 0)
		{
			base.ViewBag.IsBuying = VersionBuyer.Score;
		}
		else
		{
			_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			CS_0024_003C_003E8__locals0.sp = Enumerable.FirstOrDefault<ScorespSelectScoreRulesWithId_Result>((IEnumerable<ScorespSelectScoreRulesWithId_Result>)_db_I.ScorespSelectScoreRulesWithId(scoreRuleId, CS_0024_003C_003E8__locals0.currLangID, result));
			if (CS_0024_003C_003E8__locals0.sp == null)
			{
				base.ViewBag.IsBuying = VersionBuyer.Score;
			}
			else
			{
				scoreRulesViewModel.RuleId = CS_0024_003C_003E8__locals0.sp.RuleId;
				scoreRulesViewModel.RuleSysPartId = CS_0024_003C_003E8__locals0.sp.RuleSysPartId;
				scoreRulesViewModel.RuleScoreRate = CS_0024_003C_003E8__locals0.sp.RuleScoreRate;
				scoreRulesViewModel.RuleFromAmount = CS_0024_003C_003E8__locals0.sp.RuleFromAmount;
				scoreRulesViewModel.RuleToAmount = CS_0024_003C_003E8__locals0.sp.RuleToAmount;
				scoreRulesViewModel.RuleFromDate = CS_0024_003C_003E8__locals0.sp.RuleFromDate;
				scoreRulesViewModel.RuleFromDatePersian = ((!CS_0024_003C_003E8__locals0.sp.RuleFromDate.HasValue) ? "" : CS_0024_003C_003E8__locals0.sp.RuleFromDate?.ToString("yyyy/MM/dd"));
				scoreRulesViewModel.RuleToDate = CS_0024_003C_003E8__locals0.sp.RuleToDate;
				scoreRulesViewModel.RuleToDatePersian = ((!CS_0024_003C_003E8__locals0.sp.RuleToDate.HasValue) ? "" : CS_0024_003C_003E8__locals0.sp.RuleToDate?.ToString("yyyy/MM/dd"));
				scoreRulesViewModel.RuleInActive = CS_0024_003C_003E8__locals0.sp.RuleInActive;
				scoreRulesViewModel.OrderView = CS_0024_003C_003E8__locals0.sp.OrderView;
				scoreRulesViewModel.RuleFromTotalAmount = CS_0024_003C_003E8__locals0.sp.RuleFromTotalAmount;
				scoreRulesViewModel.RuleToTotalAmount = CS_0024_003C_003E8__locals0.sp.RuleToTotalAmount;
				scoreRulesViewModel.RuleFromTotalCount = CS_0024_003C_003E8__locals0.sp.RuleFromTotalCount;
				scoreRulesViewModel.RuleToTotalCount = CS_0024_003C_003E8__locals0.sp.RuleToTotalCount;
				scoreRulesViewModel.RuleDistanceDaysWithLastObj = CS_0024_003C_003E8__locals0.sp.RuleDistanceDaysWithLastObj;
				scoreRulesViewModel.RulePrdIds = CS_0024_003C_003E8__locals0.sp.RulePrdIds;
				scoreRulesViewModel.RulePrds = CS_0024_003C_003E8__locals0.sp.RulePrds;
				scoreRulesViewModel.RulePayIsComplete = CS_0024_003C_003E8__locals0.sp.RulePayIsComplete;
				scoreRulesViewModel.RuleRowCnt = CS_0024_003C_003E8__locals0.sp.RuleRowCnt;
				scoreRulesViewModel.RuleScoreAmount = CS_0024_003C_003E8__locals0.sp.RuleScoreAmount;
				scoreRulesViewModel.RuleDyFormIds = CS_0024_003C_003E8__locals0.sp.RuleDyFormIds;
				scoreRulesViewModel.RuleDyForms = CS_0024_003C_003E8__locals0.sp.RuleDyForms;
				scoreRulesViewModel.RuleSurveyIds = CS_0024_003C_003E8__locals0.sp.RuleSurveyIds;
				scoreRulesViewModel.RuleSurveys = CS_0024_003C_003E8__locals0.sp.RuleSurveys;
				scoreRulesViewModel.RuleIsCmpScore = CS_0024_003C_003E8__locals0.sp.RuleIsCmpScore;
				scoreRulesViewModel.RuleIsUserScore = CS_0024_003C_003E8__locals0.sp.RuleIsUserScore;
				scoreRulesViewModel.RuleUserScoreInfo = CS_0024_003C_003E8__locals0.sp.RuleUserScoreInfo;
				scoreRulesViewModel.RuleUserScoreInfoJs = CS_0024_003C_003E8__locals0.sp.RuleUserScoreInfoJs;
				scoreRulesViewModel.RuleScoreAmountPercent = CS_0024_003C_003E8__locals0.sp.RuleScoreAmountPercent;
				scoreRulesViewModel.RuleExpireDate = CS_0024_003C_003E8__locals0.sp.RuleExpireDate;
				scoreRulesViewModel.RuleExpireDatePersian = CS_0024_003C_003E8__locals0.sp.RuleExpireDate?.ToString("yyyy/MM/dd");
				scoreRulesViewModel.RuleScoreExpireDay = CS_0024_003C_003E8__locals0.sp.RuleScoreExpireDay;
				scoreRulesViewModel.RuleScoreExpireDate = CS_0024_003C_003E8__locals0.sp.RuleScoreExpireDate;
				scoreRulesViewModel.RuleScoreExpireDatePersian = CS_0024_003C_003E8__locals0.sp.RuleScoreExpireDate?.ToString("yyyy/MM/dd");
				scoreRulesViewModel.RulePrdQty = CS_0024_003C_003E8__locals0.sp.RulePrdQty;
				scoreRulesViewModel.RulePrdQtyCalcWithRepeat = CS_0024_003C_003E8__locals0.sp.RulePrdQtyCalcWithRepeat;
				scoreRulesViewModel.RuleRowCntCalcWithRepeat = CS_0024_003C_003E8__locals0.sp.RuleRowCntCalcWithRepeat;
				scoreRulesViewModel.RuleObjectIsVerified = CS_0024_003C_003E8__locals0.sp.RuleObjectIsVerified;
				scoreRulesViewModel.RuleCalcAutoScoreInIssue = CS_0024_003C_003E8__locals0.sp.RuleCalcAutoScoreInIssue;
				scoreRulesViewModel.RuleCalcAutoScoreInVerify = CS_0024_003C_003E8__locals0.sp.RuleCalcAutoScoreInVerify;
				scoreRulesViewModel.RuleCalcAutoScoreDailyTime = CS_0024_003C_003E8__locals0.sp.RuleCalcAutoScoreDailyTime;
				scoreRulesViewModel.RuleCalcAutoScoreHourly = CS_0024_003C_003E8__locals0.sp.RuleCalcAutoScoreHourly;
				scoreRulesViewModel.RulePrdSumQty = CS_0024_003C_003E8__locals0.sp.RulePrdSumQty;
				scoreRulesViewModel.RulePrdSumQtyCalcWithRepeat = CS_0024_003C_003E8__locals0.sp.RulePrdSumQtyCalcWithRepeat;
				scoreRulesViewModel.RuleCalcAutoScoreSendNewTicket = CS_0024_003C_003E8__locals0.sp.RuleCalcAutoScoreSendNewTicket;
				scoreRulesViewModel.RuleCalcAutoScoreSurveyInsertData = CS_0024_003C_003E8__locals0.sp.RuleCalcAutoScoreSurveyInsertData;
				scoreRulesViewModel.RuleCalcAutoScoreFODyFormInsertData = CS_0024_003C_003E8__locals0.sp.RuleCalcAutoScoreFODyFormInsertData;
				scoreRulesViewModel.RulePrdFGIds = CS_0024_003C_003E8__locals0.sp.RulePrdFGIds;
				scoreRulesViewModel.RulePrdSGIds = CS_0024_003C_003E8__locals0.sp.RulePrdSGIds;
				scoreRulesViewModel.RuleCId = CS_0024_003C_003E8__locals0.sp.RuleCId;
				scoreRulesViewModel.RuleCenterName = CS_0024_003C_003E8__locals0.sp.RuleCenterName;
				scoreRulesViewModel.RuleUpdateCmpGroup = CS_0024_003C_003E8__locals0.sp.RuleUpdateCmpGroup;
				scoreRulesViewModel.RuleUpdateCmpSubGroup = CS_0024_003C_003E8__locals0.sp.RuleUpdateCmpSubGroup;
				scoreRulesViewModel.RuleUpdateCmpGroupII = CS_0024_003C_003E8__locals0.sp.RuleUpdateCmpGroupII;
				scoreRulesViewModel.RuleUpdateCmpGroupIII = CS_0024_003C_003E8__locals0.sp.RuleUpdateCmpGroupIII;
				scoreRulesViewModel.RuleUpdateCmpGroupIV = CS_0024_003C_003E8__locals0.sp.RuleUpdateCmpGroupIV;
				scoreRulesViewModel.RuleToTotalAmountCalcWithRepeat = CS_0024_003C_003E8__locals0.sp.RuleToTotalAmountCalcWithRepeat;
				scoreRulesViewModel.RulePriority = CS_0024_003C_003E8__locals0.sp.RulePriority;
				scoreRulesViewModel.RuleAmountJson = CS_0024_003C_003E8__locals0.sp.RuleAmountJson;
				scoreRulesViewModel.RuleOrdTotalWithPrdMode = CS_0024_003C_003E8__locals0.sp.RuleOrdTotalWithPrdMode;
				scoreRulesViewModel.RuleOrdTotalWithPrdGroupMode = CS_0024_003C_003E8__locals0.sp.RuleOrdTotalWithPrdGroupMode;
				scoreRulesViewModel.RuleOprIds = CS_0024_003C_003E8__locals0.sp.RuleOprIds;
				scoreRulesViewModel.RuleStatusIds = CS_0024_003C_003E8__locals0.sp.RuleStatusIds;
				scoreRulesViewModel.RuleOprNames = CS_0024_003C_003E8__locals0.sp.RuleOprNames;
				scoreRulesViewModel.RuleStatusTitles = CS_0024_003C_003E8__locals0.sp.RuleStatusTitles;
				DbSet<ScoreRules_Lang> scoreRules_Lang = _dbTbl.ScoreRules_Lang;
				ParameterExpression val = Expression.Parameter(typeof(ScoreRules_Lang), "c");
				List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<ScoreRules_Lang, CommonMultiLanguageViewModel>((IEnumerable<ScoreRules_Lang>)Enumerable.ToList<ScoreRules_Lang>((IEnumerable<ScoreRules_Lang>)Queryable.Where<ScoreRules_Lang>((IQueryable<ScoreRules_Lang>)scoreRules_Lang, Expression.Lambda<Func<ScoreRules_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<ScoreRules_Lang, CommonMultiLanguageViewModel>)((ScoreRules_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.RuleTitle,
					LanguageId = item.LanguageID
				})));
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.sp.RuleTitle,
					LanguageId = result
				});
				scoreRulesViewModel.RuleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				scoreRulesViewModel.RuleTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			}
		}
		base.ViewBag.SystemParts = GetRuleSysParts(null, sysPartId);
		base.ViewBag.EventPolicyReceivers = GetEventPolicyReceiversByPartName("SCORERULE");
		base.ViewBag.ModelJs = JsonConvert.SerializeObject(scoreRulesViewModel);
		return View(scoreRulesViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineScoreRuleDataEntry", ActionName = "actPost")]
	public string RuleInsertEdit(string model = "")
	{
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short year = short.Parse(Financial.Get().Id.ToString());
			short month = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			ScoreRulesViewModel vm = null;
			if (!string.IsNullOrWhiteSpace(model))
			{
				vm = JsonConvert.DeserializeObject<ScoreRulesViewModel>(HttpUtility.UrlDecode(model));
			}
			if (vm == null)
			{
				return Messages.frmErrorEmpty;
			}
			if (vm.RuleId <= 0 && !VersionBuyer.Score)
			{
				DbSet<ScoreRules> scoreRules = _dbTbl.ScoreRules;
				ParameterExpression val = Expression.Parameter(typeof(ScoreRules), "c");
				if (Queryable.Any<ScoreRules>((IQueryable<ScoreRules>)scoreRules, Expression.Lambda<Func<ScoreRules, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)5, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					return "BV|" + string.Format(Messages.VersionBuyWithCount, "5");
				}
			}
			string text2 = "";
			int num = 0;
			int num2 = 0;
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			string text3 = "";
			if (!string.IsNullOrEmpty(vm.RuleTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.RuleTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.RuleTitle,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(vm.RuleTitle))
			{
				text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.ScoreRuleTitle) + "<br/>";
			}
			else if (!checkMultiLanguage(vm.RuleTitle, list))
			{
				text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.ScoreRuleTitle) + "<br>";
			}
			string arg = "";
			List<SelectListItem> ruleSysParts = GetRuleSysParts();
			if (ruleSysParts != null)
			{
				arg = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)ruleSysParts, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == vm.RuleSysPartId.ToString())).Text;
			}
			if (vm.RuleSysPartId == 150 || vm.RuleSysPartId == 160)
			{
				List<ScorespSelectScoreRules_Result> list2 = Enumerable.ToList<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)_db_I.ScorespSelectScoreRules(vm.RuleSysPartId, lCID, defLangID, result));
				if (list2 != null)
				{
					List<ScorespSelectScoreRules_Result> list3 = Enumerable.ToList<ScorespSelectScoreRules_Result>(Enumerable.Where<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)list2, (Func<ScorespSelectScoreRules_Result, bool>)((ScorespSelectScoreRules_Result x) => x.RuleId != vm.RuleId)));
					if (list3 != null && list3.Count > 0)
					{
						text3 = text3 + string.Format(Messages.ScoreRuleOnlyOneInEverySystemPart, arg) + "<br>";
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				return text3;
			}
			if (!base.ModelState.IsValid)
			{
				return string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			_003C_003Ec__DisplayClass18_1 _003C_003Ec__DisplayClass18_ = new _003C_003Ec__DisplayClass18_1();
			_003C_003Ec__DisplayClass18_.findedRecord = _dbTbl.ScoreRules.Find(vm.RuleId);
			DateTime dateTime2 = default(DateTime);
			string text4 = "";
			if (_003C_003Ec__DisplayClass18_.findedRecord != null)
			{
				text2 = _003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreDailyTime;
				num = _003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreHourly.GetValueOrDefault();
				num2 = _003C_003Ec__DisplayClass18_.findedRecord.RuleSysPartId;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				_003C_003Ec__DisplayClass18_.findedRecord.RuleTitle = vm.RuleTitle;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleSysPartId = vm.RuleSysPartId;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleScoreRate = vm.RuleScoreRate;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleFromAmount = vm.RuleFromAmount;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleToAmount = vm.RuleToAmount;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleInActive = vm.RuleInActive;
				try
				{
					if (!string.IsNullOrEmpty(vm.RuleFromDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.RuleFromDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.RuleFromDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.RuleFromDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.RuleFromDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.RuleFromDate = dateTime2;
					}
					else
					{
						vm.RuleFromDate = null;
						vm.RuleFromDatePersian = null;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					return Messages.WrongDateTime;
				}
				if (vm.RuleFromDatePersian != null)
				{
					vm.RuleFromDatePersian = vm.RuleFromDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				_003C_003Ec__DisplayClass18_.findedRecord.RuleFromDate = vm.RuleFromDate;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleFromDatePersian = vm.RuleFromDatePersian;
				try
				{
					if (!string.IsNullOrEmpty(vm.RuleToDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.RuleToDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.RuleToDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.RuleToDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.RuleToDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.RuleToDate = dateTime2;
					}
					else
					{
						vm.RuleToDate = null;
						vm.RuleToDatePersian = null;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					return Messages.WrongDateTime;
				}
				if (vm.RuleToDatePersian != null)
				{
					vm.RuleToDatePersian = vm.RuleToDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				_003C_003Ec__DisplayClass18_.findedRecord.RuleToDate = vm.RuleToDate;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleToDatePersian = vm.RuleToDatePersian;
				if (!_003C_003Ec__DisplayClass18_.findedRecord.OrderView.HasValue || _003C_003Ec__DisplayClass18_.findedRecord.OrderView <= 0)
				{
					List<ScorespSelectScoreRules_Result> list4 = Enumerable.ToList<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)_db_I.ScorespSelectScoreRules(0, lCID, defLangID, result));
					_ = Enumerable.FirstOrDefault<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)Enumerable.OrderByDescending<ScorespSelectScoreRules_Result, int?>((IEnumerable<ScorespSelectScoreRules_Result>)list4, (Func<ScorespSelectScoreRules_Result, int?>)((ScorespSelectScoreRules_Result m) => m.OrderView)))?.OrderView;
					int num3 = (Enumerable.Any<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)list4) ? Enumerable.Count<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)list4) : 0);
					_003C_003Ec__DisplayClass18_.findedRecord.OrderView = num3 + 10 + num3 * 9 - 5;
				}
				else if (vm.OrderView > 0)
				{
					_003C_003Ec__DisplayClass18_.findedRecord.OrderView = vm.OrderView;
				}
				_003C_003Ec__DisplayClass18_.findedRecord.Month1 = month;
				_003C_003Ec__DisplayClass18_.findedRecord.UserId = userId;
				_003C_003Ec__DisplayClass18_.findedRecord.RegisterDate = dateTime;
				_003C_003Ec__DisplayClass18_.findedRecord.RegisterDatePersian = text;
				_003C_003Ec__DisplayClass18_.findedRecord.AppType = appType;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleFromTotalAmount = vm.RuleFromTotalAmount;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleToTotalAmount = vm.RuleToTotalAmount;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleFromTotalCount = vm.RuleFromTotalCount;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleToTotalCount = vm.RuleToTotalCount;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleDistanceDaysWithLastObj = vm.RuleDistanceDaysWithLastObj;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePrdIds = vm.RulePrdIds;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePayIsComplete = vm.RulePayIsComplete;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleRowCnt = vm.RuleRowCnt;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleScoreAmount = vm.RuleScoreAmount;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleDyFormIds = vm.RuleDyFormIds;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleSurveyIds = vm.RuleSurveyIds;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleIsCmpScore = vm.RuleIsCmpScore;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleIsUserScore = vm.RuleIsUserScore;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleUserScoreInfo = vm.RuleUserScoreInfo;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleScoreAmountPercent = vm.RuleScoreAmountPercent;
				try
				{
					if (!string.IsNullOrEmpty(vm.RuleExpireDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.RuleExpireDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.RuleExpireDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.RuleExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.RuleExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.RuleExpireDate = dateTime2;
					}
					else
					{
						vm.RuleExpireDate = null;
						vm.RuleExpireDatePersian = null;
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					return Messages.WrongDateTime;
				}
				if (vm.RuleExpireDatePersian != null)
				{
					vm.RuleExpireDatePersian = vm.RuleExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				_003C_003Ec__DisplayClass18_.findedRecord.RuleExpireDate = vm.RuleExpireDate;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleExpireDatePersian = vm.RuleExpireDatePersian;
				try
				{
					if (!string.IsNullOrEmpty(vm.RuleScoreExpireDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.RuleScoreExpireDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.RuleScoreExpireDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.RuleScoreExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.RuleScoreExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.RuleScoreExpireDate = dateTime2;
					}
					else
					{
						vm.RuleScoreExpireDate = null;
						vm.RuleScoreExpireDatePersian = null;
					}
				}
				catch (Exception e4)
				{
					ErrorSignal.FromCurrentContext().Raise(e4);
					return Messages.WrongDateTime;
				}
				if (vm.RuleScoreExpireDatePersian != null)
				{
					vm.RuleScoreExpireDatePersian = vm.RuleScoreExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				_003C_003Ec__DisplayClass18_.findedRecord.RuleScoreExpireDay = vm.RuleScoreExpireDay;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleScoreExpireDate = vm.RuleScoreExpireDate;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleScoreExpireDatePersian = vm.RuleScoreExpireDatePersian;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePrdQty = vm.RulePrdQty;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePrdQtyCalcWithRepeat = vm.RulePrdQtyCalcWithRepeat;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleRowCntCalcWithRepeat = vm.RuleRowCntCalcWithRepeat;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleObjectIsVerified = vm.RuleObjectIsVerified;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreInIssue = vm.RuleCalcAutoScoreInIssue;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreInVerify = vm.RuleCalcAutoScoreInVerify;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreDailyTime = vm.RuleCalcAutoScoreDailyTime;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreHourly = vm.RuleCalcAutoScoreHourly;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePrdSumQty = vm.RulePrdSumQty;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePrdSumQtyCalcWithRepeat = vm.RulePrdSumQtyCalcWithRepeat;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreSendNewTicket = vm.RuleCalcAutoScoreSendNewTicket;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreSurveyInsertData = vm.RuleCalcAutoScoreSurveyInsertData;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleCalcAutoScoreFODyFormInsertData = vm.RuleCalcAutoScoreFODyFormInsertData;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePrdFGIds = vm.RulePrdFGIds;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePrdSGIds = vm.RulePrdSGIds;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleUpdateCmpGroup = vm.RuleUpdateCmpGroup;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleUpdateCmpSubGroup = vm.RuleUpdateCmpSubGroup;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleUpdateCmpGroupII = vm.RuleUpdateCmpGroupII;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleUpdateCmpGroupIII = vm.RuleUpdateCmpGroupIII;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleUpdateCmpGroupIV = vm.RuleUpdateCmpGroupIV;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleToTotalAmountCalcWithRepeat = vm.RuleToTotalAmountCalcWithRepeat;
				_003C_003Ec__DisplayClass18_.findedRecord.RulePriority = vm.RulePriority;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleAmountJson = vm.RuleAmountJson;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleOrdTotalWithPrdMode = vm.RuleOrdTotalWithPrdMode;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleOrdTotalWithPrdGroupMode = vm.RuleOrdTotalWithPrdGroupMode;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleOprIds = vm.RuleOprIds;
				_003C_003Ec__DisplayClass18_.findedRecord.RuleStatusIds = vm.RuleStatusIds;
				_dbTbl.Entry(_003C_003Ec__DisplayClass18_.findedRecord).State = EntityState.Modified;
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass18_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass18_2();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass18_;
						CS_0024_003C_003E8__locals1.lang = enumerator.Current;
						DbSet<ScoreRules_Lang> scoreRules_Lang = _dbTbl.ScoreRules_Lang;
						ParameterExpression val = Expression.Parameter(typeof(ScoreRules_Lang), "c");
						ScoreRules_Lang scoreRules_Lang2 = Queryable.FirstOrDefault<ScoreRules_Lang>((IQueryable<ScoreRules_Lang>)scoreRules_Lang, Expression.Lambda<Func<ScoreRules_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass18_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass18_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (scoreRules_Lang2 != null)
						{
							scoreRules_Lang2.RuleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.Entry(scoreRules_Lang2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							continue;
						}
						scoreRules_Lang2 = new ScoreRules_Lang
						{
							LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
							RuleId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.findedRecord.RuleId,
							RuleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
						};
						_dbTbl.ScoreRules_Lang.Add(scoreRules_Lang2);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
				}
				base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
			}
			else
			{
				try
				{
					if (!string.IsNullOrEmpty(vm.RuleFromDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.RuleFromDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.RuleFromDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.RuleFromDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.RuleFromDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.RuleFromDate = dateTime2;
					}
				}
				catch (Exception e5)
				{
					ErrorSignal.FromCurrentContext().Raise(e5);
					return Messages.WrongDateTime;
				}
				if (vm.RuleFromDatePersian != null)
				{
					vm.RuleFromDatePersian = vm.RuleFromDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				try
				{
					if (!string.IsNullOrEmpty(vm.RuleToDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.RuleToDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.RuleToDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.RuleToDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.RuleToDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.RuleToDate = dateTime2;
					}
				}
				catch (Exception e6)
				{
					ErrorSignal.FromCurrentContext().Raise(e6);
					return Messages.WrongDateTime;
				}
				if (vm.RuleToDatePersian != null)
				{
					vm.RuleToDatePersian = vm.RuleToDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				try
				{
					if (!string.IsNullOrEmpty(vm.RuleExpireDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.RuleExpireDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.RuleExpireDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.RuleExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.RuleExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.RuleExpireDate = dateTime2;
					}
					else
					{
						vm.RuleExpireDate = null;
						vm.RuleExpireDatePersian = null;
					}
				}
				catch (Exception e7)
				{
					ErrorSignal.FromCurrentContext().Raise(e7);
					return Messages.WrongDateTime;
				}
				if (vm.RuleExpireDatePersian != null)
				{
					vm.RuleExpireDatePersian = vm.RuleExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				try
				{
					if (!string.IsNullOrEmpty(vm.RuleScoreExpireDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.RuleScoreExpireDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.RuleScoreExpireDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.RuleScoreExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.RuleScoreExpireDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.RuleScoreExpireDate = dateTime2;
					}
					else
					{
						vm.RuleScoreExpireDate = null;
						vm.RuleScoreExpireDatePersian = null;
					}
				}
				catch (Exception e8)
				{
					ErrorSignal.FromCurrentContext().Raise(e8);
					return Messages.WrongDateTime;
				}
				if (vm.RuleScoreExpireDatePersian != null)
				{
					vm.RuleScoreExpireDatePersian = vm.RuleScoreExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				if (!vm.OrderView.HasValue || vm.OrderView <= 0)
				{
					List<ScorespSelectScoreRules_Result> list5 = Enumerable.ToList<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)_db_I.ScorespSelectScoreRules(0, lCID, defLangID, result));
					_ = Enumerable.FirstOrDefault<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)Enumerable.OrderByDescending<ScorespSelectScoreRules_Result, int?>((IEnumerable<ScorespSelectScoreRules_Result>)list5, (Func<ScorespSelectScoreRules_Result, int?>)((ScorespSelectScoreRules_Result m) => m.OrderView)))?.OrderView;
					int num4 = (Enumerable.Any<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)list5) ? Enumerable.Count<ScorespSelectScoreRules_Result>((IEnumerable<ScorespSelectScoreRules_Result>)list5) : 0);
					vm.OrderView = num4 + 10 + num4 * 9 - 5;
				}
				ScoreRules scoreRules2 = new ScoreRules
				{
					RuleId = vm.RuleId,
					RuleTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					RuleSysPartId = ((vm.RuleSysPartId <= 0) ? 30 : vm.RuleSysPartId),
					RuleScoreRate = vm.RuleScoreRate,
					RuleFromAmount = vm.RuleFromAmount,
					RuleToAmount = vm.RuleToAmount,
					RuleFromDate = vm.RuleFromDate,
					RuleFromDatePersian = vm.RuleFromDatePersian,
					RuleToDate = vm.RuleToDate,
					RuleToDatePersian = vm.RuleToDatePersian,
					RuleInActive = vm.RuleInActive,
					OrderView = vm.OrderView,
					GUId = System.Guid.NewGuid(),
					FirstRegisterUserId = userId,
					FirstRegisterDate = dateTime,
					FirstRegisterDatePersian = text,
					Year1 = year,
					Month1 = month,
					UserId = userId,
					RegisterDate = dateTime,
					RegisterDatePersian = text,
					AppType = appType,
					LanguageID = defLangID,
					RuleFromTotalAmount = vm.RuleFromTotalAmount,
					RuleToTotalAmount = vm.RuleToTotalAmount,
					RuleFromTotalCount = vm.RuleFromTotalCount,
					RuleToTotalCount = vm.RuleToTotalCount,
					RuleDistanceDaysWithLastObj = vm.RuleDistanceDaysWithLastObj,
					RulePrdIds = vm.RulePrdIds,
					RulePayIsComplete = vm.RulePayIsComplete,
					RuleRowCnt = vm.RuleRowCnt,
					RuleScoreAmount = vm.RuleScoreAmount,
					RuleDyFormIds = vm.RuleDyFormIds,
					RuleSurveyIds = vm.RuleSurveyIds,
					RuleIsCmpScore = vm.RuleIsCmpScore,
					RuleIsUserScore = vm.RuleIsUserScore,
					RuleUserScoreInfo = vm.RuleUserScoreInfo,
					RuleScoreAmountPercent = vm.RuleScoreAmountPercent,
					RuleExpireDate = vm.RuleExpireDate,
					RuleExpireDatePersian = vm.RuleExpireDatePersian,
					RuleScoreExpireDay = vm.RuleScoreExpireDay,
					RuleScoreExpireDate = vm.RuleScoreExpireDate,
					RuleScoreExpireDatePersian = vm.RuleScoreExpireDatePersian,
					RulePrdQty = vm.RulePrdQty,
					RulePrdQtyCalcWithRepeat = vm.RulePrdQtyCalcWithRepeat,
					RuleRowCntCalcWithRepeat = vm.RuleRowCntCalcWithRepeat,
					RuleObjectIsVerified = vm.RuleObjectIsVerified,
					RuleCalcAutoScoreInIssue = vm.RuleCalcAutoScoreInIssue,
					RuleCalcAutoScoreInVerify = vm.RuleCalcAutoScoreInVerify,
					RuleCalcAutoScoreDailyTime = vm.RuleCalcAutoScoreDailyTime,
					RuleCalcAutoScoreHourly = vm.RuleCalcAutoScoreHourly,
					RulePrdSumQty = vm.RulePrdSumQty,
					RulePrdSumQtyCalcWithRepeat = vm.RulePrdSumQtyCalcWithRepeat,
					RuleCalcAutoScoreSendNewTicket = vm.RuleCalcAutoScoreSendNewTicket,
					RuleCalcAutoScoreSurveyInsertData = vm.RuleCalcAutoScoreSurveyInsertData,
					RuleCalcAutoScoreFODyFormInsertData = vm.RuleCalcAutoScoreFODyFormInsertData,
					RulePrdFGIds = vm.RulePrdFGIds,
					RulePrdSGIds = vm.RulePrdSGIds,
					RuleCId = result,
					RuleUpdateCmpGroup = vm.RuleUpdateCmpGroup,
					RuleUpdateCmpSubGroup = vm.RuleUpdateCmpSubGroup,
					RuleUpdateCmpGroupII = vm.RuleUpdateCmpGroupII,
					RuleUpdateCmpGroupIII = vm.RuleUpdateCmpGroupIII,
					RuleUpdateCmpGroupIV = vm.RuleUpdateCmpGroupIV,
					RuleToTotalAmountCalcWithRepeat = vm.RuleToTotalAmountCalcWithRepeat,
					RulePriority = vm.RulePriority,
					RuleAmountJson = vm.RuleAmountJson,
					RuleOrdTotalWithPrdMode = vm.RuleOrdTotalWithPrdMode,
					RuleOrdTotalWithPrdGroupMode = vm.RuleOrdTotalWithPrdGroupMode,
					RuleOprIds = vm.RuleOprIds,
					RuleStatusIds = vm.RuleStatusIds
				};
				_dbTbl.ScoreRules.Add(scoreRules2);
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					ScoreRules_Lang entity = new ScoreRules_Lang
					{
						LanguageID = lang.LanguageID,
						RuleId = scoreRules2.RuleId,
						RuleTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
					};
					_dbTbl.ScoreRules_Lang.Add(entity);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
				base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
			}
			if (vm.RuleId != 0)
			{
				string jobName = "CalcAndInsertOrderScores_Rule" + vm.RuleId + "_Hourly";
				string jobName2 = "CalcAndInsertOrderScores_Rule" + vm.RuleId + "_Daily";
				if ((num2 == 30 || num2 == 10) && num2 != vm.RuleSysPartId)
				{
					_db_II.DeleteSqlJob(jobName);
					_db_II.DeleteSqlJob(jobName2);
				}
				if (vm.RuleSysPartId == 30 || vm.RuleSysPartId == 10)
				{
					string stepCommand = "DECLARE @CurrDate DATETIME = GETDATE() DECLARE @CurrDatePer VARCHAR(8) = FORMAT(@CurrDate, 'yyyyMMdd', 'fa-IR') DECLARE @Month1 SMALLINT = CAST(FORMAT(@CurrDate, 'MM', 'fa-IR') AS INT) EXEC [dbo].[ScorespInsertAndCalcOrderScores] @RuleId=" + vm.RuleId + ",@CurrDate=@CurrDate, @UserId=" + userId + ", @Year1=1,@Month1 = @Month1,@RegisterDate = @CurrDate,@RegisterDatePersian = @CurrDatePer,@AppType = N'" + appType + "',@LanguageID = " + lCID + ",@DefaultLanguageID = " + defLangID + ",@ReturnResult = 0,@UpdateCompanyGroups = 1,@CenterId=" + result;
					if (string.IsNullOrWhiteSpace(vm.RuleCalcAutoScoreDailyTime))
					{
						_db_II.DeleteSqlJob(jobName2);
					}
					else if (!string.IsNullOrWhiteSpace(vm.RuleCalcAutoScoreDailyTime) && text2 != vm.RuleCalcAutoScoreDailyTime)
					{
						_db_II.DeleteSqlJob("CalcAndInsertOrderScores");
						_db_II.DeleteSqlJob(jobName2);
						_db_II.CreateNewSqlJob(jobName2, null, "StepI", stepCommand, "Sch_Daily", DateTime.Now, null, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + vm.RuleCalcAutoScoreDailyTime + ":00"), null, 1, 0, null);
					}
					if (vm.RuleCalcAutoScoreHourly.GetValueOrDefault() == 0)
					{
						_db_II.DeleteSqlJob(jobName);
					}
					else if (num != vm.RuleCalcAutoScoreHourly)
					{
						_db_II.DeleteSqlJob("CalcAndInsertOrderScores");
						_db_II.DeleteSqlJob(jobName);
						_db_II.CreateNewSqlJob(jobName, null, "StepI", stepCommand, "Sch_Hourly", DateTime.Now, null, null, null, 1, vm.RuleCalcAutoScoreHourly, null);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return ex.Message;
		}
		base.ViewBag.SystemParts = GetRuleSysParts();
		return "";
	}

	[DynamicAuthorize(ControllerName = "frmDefineScoreRule", ActionName = "actDelete")]
	[HttpPost]
	public string DeleteRule(int scoreRuleId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmDefineScoreRule", "actDelete", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (scoreRuleId != 0)
			{
				string jobName = "CalcAndInsertOrderScores_Rule" + scoreRuleId + "_Hourly";
				string jobName2 = "CalcAndInsertOrderScores_Rule" + scoreRuleId + "_Daily";
				_db_II.DeleteSqlJob(jobName2);
				_db_II.DeleteSqlJob(jobName);
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_db_I.ScorespDeleteScoreRule(scoreRuleId));
				result = ((mct_I_Result == null || mct_I_Result.Result <= 0) ? "-2" : Messages.frmDeleteSuccessMessage);
			}
			else
			{
				result = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<SelectListItem> GetRuleSysParts(string systemPartIds = "", int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (string.IsNullOrWhiteSpace(systemPartIds))
			{
				systemPartIds = "30,90,150,160,170,10";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_db_I.CRMspSelectActiveSystemParts(lCID, result, systemPartIds));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2, (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result x) => new SelectListItem
				{
					Text = ((x.SystemPartId == 10) ? "lblCmpOrds".OrderLabels() : x.PartTitle),
					Value = x.SystemPartId.ToString(),
					Selected = ((selectedId != 0 && x.SystemPartId == selectedId) ? true : false)
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[AjaxOnly]
	public string InsertDupRule(int ruleId)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmDefineScoreRule", "actInsertDupRule", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (!VersionBuyer.Score)
			{
				DbSet<ScoreRules> scoreRules = _dbTbl.ScoreRules;
				ParameterExpression val = Expression.Parameter(typeof(ScoreRules), "c");
				if (Queryable.Any<ScoreRules>((IQueryable<ScoreRules>)scoreRules, Expression.Lambda<Func<ScoreRules, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)5, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					return "BV|" + string.Format(Messages.VersionBuyWithCount, "5");
				}
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			string text2 = "";
			foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
			{
				CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
				commonMultiLanguageViewModel.LanguageId = item.LanguageID;
				commonMultiLanguageViewModel.Value = MyResource.GetResourceString("lblDuplicate", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
				list.Add(commonMultiLanguageViewModel);
			}
			text2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list));
			ObjectParameter objectParameter = new ObjectParameter("InsertedRuleId", typeof(int));
			_db_III.ScorespInsertDuplicateScoreRule(ruleId, text2, userId, value2, value3, value, registerDatePersian, appType, result, objectParameter);
			int result2 = 0;
			if (objectParameter != null && objectParameter.Value != null)
			{
				int.TryParse(objectParameter.Value.ToString(), out result2);
			}
			if (result2 != 0)
			{
				return "1|" + result2;
			}
			return Messages.msgErrorRunFunction;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetDiscountCodeByDisCode(string code = "", int cmpId = 0, bool isLoad = false)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (code != "")
			{
				WSspSelectDiscountCodeByDisCode_Result wSspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<WSspSelectDiscountCodeByDisCode_Result>((IEnumerable<WSspSelectDiscountCodeByDisCode_Result>)_db_I.WSspSelectDiscountCodeByDisCode(code, lCID, result2));
				if (wSspSelectDiscountCodeByDisCode_Result != null)
				{
					int result3 = 0;
					int.TryParse(wSspSelectDiscountCodeByDisCode_Result.DisExpDate.ToString("yyyyMMdd"), out result3);
					int num = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
					if (!isLoad)
					{
						if (result3 < num)
						{
							result = "-1";
						}
						else if (!wSspSelectDiscountCodeByDisCode_Result.DisCanChangeToScore.GetValueOrDefault())
						{
							result = "-2";
						}
						else
						{
							_ = wSspSelectDiscountCodeByDisCode_Result.DisExpDate;
							wSspSelectDiscountCodeByDisCode_Result.DisExpDatePersian = wSspSelectDiscountCodeByDisCode_Result.DisExpDate.ToString("yyyy/MM/dd");
							wSspSelectDiscountCodeByDisCode_Result.UsedCount = 0;
							if (cmpId != 0)
							{
								List<WSspSelectDiscountCodeHistoryWithCmpId_Result> list = Enumerable.ToList<WSspSelectDiscountCodeHistoryWithCmpId_Result>((IEnumerable<WSspSelectDiscountCodeHistoryWithCmpId_Result>)_db.WSspSelectDiscountCodeHistoryWithCmpId(cmpId, lCID, result2));
								if (list != null)
								{
									List<WSspSelectDiscountCodeHistoryWithCmpId_Result> list2 = Enumerable.ToList<WSspSelectDiscountCodeHistoryWithCmpId_Result>(Enumerable.Where<WSspSelectDiscountCodeHistoryWithCmpId_Result>((IEnumerable<WSspSelectDiscountCodeHistoryWithCmpId_Result>)list, (Func<WSspSelectDiscountCodeHistoryWithCmpId_Result, bool>)((WSspSelectDiscountCodeHistoryWithCmpId_Result x) => x.DisCode == code)));
									if (list2 != null)
									{
										wSspSelectDiscountCodeByDisCode_Result.UsedCount = list2.Count;
									}
								}
							}
						}
					}
					result = JsonConvert.SerializeObject(wSspSelectDiscountCodeByDisCode_Result);
				}
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
	public string SearchUsers(string val = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSearchUsers_Result> list = Enumerable.ToList<CRMspSearchUsers_Result>((IEnumerable<CRMspSearchUsers_Result>)_db.CRMspSearchUsers(val, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<CRMspSearchUsers_Result>(Enumerable.Take<CRMspSearchUsers_Result>((IEnumerable<CRMspSearchUsers_Result>)list, 50)));
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
	public string GetEventPolicyReceiversByPartName(string partName)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveEventPolicyReceiversByPartName_Result> list = Enumerable.ToList<CRMspSelectActiveEventPolicyReceiversByPartName_Result>((IEnumerable<CRMspSelectActiveEventPolicyReceiversByPartName_Result>)_db_I.CRMspSelectActiveEventPolicyReceiversByPartName(partName, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectSurveyWithTitle(string title = "", int lastRowId = 0, int pageSize = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspSelectSurveyWithTitle_Result> list = Enumerable.ToList<CRMspSelectSurveyWithTitle_Result>((IEnumerable<CRMspSelectSurveyWithTitle_Result>)_db_II.CRMspSelectSurveyWithTitle(title, lCID, result2, lastRowId, pageSize, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
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
	public string SearchFormsWithParentTitle(string title = "", int lastRowId = 0, int pageSize = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspDySearchFormsWithParentTitle_Result> list = Enumerable.ToList<CRMspDySearchFormsWithParentTitle_Result>((IEnumerable<CRMspDySearchFormsWithParentTitle_Result>)_db_II.CRMspDySearchFormsWithParentTitle(title, lCID, result2, lastRowId, pageSize));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	private List<SelectListItem> GetOrderOpr()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list2 = Enumerable.ToList<WSspSelectOrderOpr_Result>(Enumerable.Where<WSspSelectOrderOpr_Result>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, bool>)((WSspSelectOrderOpr_Result m) => m.OrderOprID > 0)));
			}
			if (list2 != null && Enumerable.Any<WSspSelectOrderOpr_Result>((IEnumerable<WSspSelectOrderOpr_Result>)list2))
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
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

	private List<SelectListItem> GetOrdStatus()
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
			List<WSspSelectOrderStatus_Result> list2 = Enumerable.ToList<WSspSelectOrderStatus_Result>((IEnumerable<WSspSelectOrderStatus_Result>)_db.WSspSelectOrderStatus(lCID, result));
			if (list2 != null && Enumerable.Any<WSspSelectOrderStatus_Result>((IEnumerable<WSspSelectOrderStatus_Result>)list2))
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectOrderStatus_Result>)list2, (Func<WSspSelectOrderStatus_Result, SelectListItem>)((WSspSelectOrderStatus_Result item) => new SelectListItem
				{
					Text = item.OrderStatus,
					Value = item.OrderStatusId.ToString(),
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
			switch (typ)
			{
			case 1:
				list = GetOrderOpr();
				break;
			case 2:
				list = GetOrdStatus();
				break;
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

	[LoginAuthorize]
	public ActionResult ShowScores(int position, string fDate = "", string tDate = "", string ruleIds = "", string cmpId = "", string sUserIds = "", string sysPartIds = "", string objIds = "")
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmDyForm";
			text2 = "actShowScores";
			break;
		case 2:
			text = "frmSurManageSurvey";
			text2 = "actEntrySurveyValues";
			break;
		case 3:
			text = "frmProjectPreview";
			text2 = "actShowScores";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.FDate = fDate;
		base.ViewBag.TDate = tDate;
		base.ViewBag.RuleIds = ruleIds;
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.SUserIds = sUserIds;
		base.ViewBag.SysPartIds = sysPartIds;
		base.ViewBag.ObjIds = objIds;
		return View();
	}

	public List<ScorespSelectScores_Result> ListScorest(string fDate = "", string tDate = "", string ruleIds = "", string cmpId = "", string sUserIds = "", string sysPartIds = "", string objIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<ScorespSelectScores_Result> list = new List<ScorespSelectScores_Result>();
		try
		{
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrWhiteSpace(tDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			int result2 = 0;
			int value3 = 0;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out result2);
				value3 = currentUser.UserId;
			}
			string textEarningScore = Labels.TextEarningScore;
			string textSpendScore = Labels.TextSpendScore;
			list = Enumerable.ToList<ScorespSelectScores_Result>((IEnumerable<ScorespSelectScores_Result>)_db_III.ScorespSelectScores((!string.IsNullOrWhiteSpace(fDate)) ? new DateTime?(value) : null, (!string.IsNullOrWhiteSpace(tDate)) ? new DateTime?(value2) : null, ruleIds, cmpId, sUserIds, sysPartIds, objIds, textEarningScore, textSpendScore, result2, value3, lCID, result));
			if (list != null)
			{
				if (Enumerable.Any<ScorespSelectScores_Result>((IEnumerable<ScorespSelectScores_Result>)list))
				{
					foreach (ScorespSelectScores_Result item in list)
					{
						_ = item.ScoreDate;
						item.ScoreDatePersian = item.ScoreDate.ToString("yyyy/MM/dd");
						item.ScoreExpireDatePersian = (item.ScoreExpireDate.HasValue ? item.ScoreExpireDate.Value.ToString("yyyy/MM/dd") : "");
					}
				}
			}
			else
			{
				list = new List<ScorespSelectScores_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult Scores_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string ruleIds = "", string cmpId = "", string sUserIds = "", string sysPartIds = "", string objIds = "")
	{
		JsonResult jsonResult = Json(((IEnumerable)ListScorest(fDate, tDate, ruleIds, cmpId, sUserIds, sysPartIds, objIds)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult Scores(string fDate = "", string tDate = "", string ruleIds = "", string cmpId = "", string sUserIds = "", string sysPartIds = "", string objIds = "")
	{
		JsonResult jsonResult = Json(ListScorest(fDate, tDate, ruleIds, cmpId, sUserIds, sysPartIds, objIds), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmShowScores", ActionName = "actDelete")]
	public string DeleteScore(int scoreId = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_db_I.ScorespDeleteScore(scoreId, userId, value2, value, now, registerDatePersian, appType, result2, centerId));
			if (mct_I_Result != null && mct_I_Result.Result != 1 && mct_I_Result.Result == 0)
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = ex.Message;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_db_I.Dispose();
		_db_II.Dispose();
		_db_III.Dispose();
		base.Dispose(disposing);
	}
}
