using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.DiscountCode.Controllers;

public class RulesController : Controller
{
	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	[LoginAuthorize]
	public ActionResult _PartialRules()
	{
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult DiscountCodeRules_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<WSspSelectDiscountCodeRules_Result> list = new List<WSspSelectDiscountCodeRules_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectDiscountCodeRules_Result> list2 = Enumerable.ToList<WSspSelectDiscountCodeRules_Result>((IEnumerable<WSspSelectDiscountCodeRules_Result>)_dbII.WSspSelectDiscountCodeRules(lCID, result));
			if (list2 != null)
			{
				list = list2;
				foreach (WSspSelectDiscountCodeRules_Result item in list)
				{
					item.DisRExpDatePersian = item.DisRExpDate?.ToString("yyyy/MM/dd");
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public ActionResult InsertEdit(int ruleId = 0)
	{
		WSspSelectDiscountCodeRuleWithId_Result wSspSelectDiscountCodeRuleWithId_Result = new WSspSelectDiscountCodeRuleWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectDiscountCodeRuleWithId_Result wSspSelectDiscountCodeRuleWithId_Result2 = Enumerable.FirstOrDefault<WSspSelectDiscountCodeRuleWithId_Result>((IEnumerable<WSspSelectDiscountCodeRuleWithId_Result>)_dbII.WSspSelectDiscountCodeRuleWithId(ruleId, lCID, result));
			if (wSspSelectDiscountCodeRuleWithId_Result2 != null)
			{
				wSspSelectDiscountCodeRuleWithId_Result = wSspSelectDiscountCodeRuleWithId_Result2;
				wSspSelectDiscountCodeRuleWithId_Result.DisRExpDatePersian = wSspSelectDiscountCodeRuleWithId_Result.DisRExpDate?.ToString("yyyy/MM/dd");
				wSspSelectDiscountCodeRuleWithId_Result.FirstRegisterDatePersian = wSspSelectDiscountCodeRuleWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
				wSspSelectDiscountCodeRuleWithId_Result.RegisterDatePersian = wSspSelectDiscountCodeRuleWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return View(wSspSelectDiscountCodeRuleWithId_Result);
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertEdit(int? discountCodeRuleId = null, string disRTitle = null, string disRTitle_Lang = null, string disRPreCode = null, decimal? disRAmount = null, decimal? disRAmountPercent = null, int? disRExpDay = null, string disRExpDatePersian = null, int? disRUseCnt = null, float? disRScoreRate = null, bool? disRCanChangeToScore = null, bool? disRInActive = null)
	{
		string text = "";
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
			short.Parse(Financial.Get().Id.ToString());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			DateTime? dateTime = null;
			try
			{
				if (!string.IsNullOrEmpty(disRExpDatePersian))
				{
					disRExpDatePersian = PersianDate.GetFormatetdDate(disRExpDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(disRExpDatePersian + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						disRExpDatePersian = dateTime?.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(disRExpDatePersian + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						disRExpDatePersian = dateTime?.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(disRExpDatePersian + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						disRExpDatePersian = dateTime?.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
				}
				else
				{
					dateTime = null;
					disRExpDatePersian = null;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.WrongDateTime;
			}
			if (disRExpDatePersian != null)
			{
				disRExpDatePersian = disRExpDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(disRTitle_Lang))
			{
				list = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(HttpUtility.UrlDecode(disRTitle_Lang));
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				LanguageId = lCID,
				Value = disRTitle
			});
			if (string.IsNullOrWhiteSpace(disRTitle))
			{
				text = string.Format(Messages.msgErrorFieldIsRequired, Labels.DisRCodeTitle);
			}
			else if (!checkMultiLanguage(disRTitle, list))
			{
				text = Messages.CheckCurrencyUnitLang;
			}
			if (text == "")
			{
				if (discountCodeRuleId != 0)
				{
					_dbII.WSspUpdateDiscountCodeRule(discountCodeRuleId, JsonConvert.SerializeObject(list), disRPreCode, disRAmount, disRAmountPercent, disRExpDay, dateTime, disRExpDatePersian, disRUseCnt, disRScoreRate, disRCanChangeToScore, disRInActive, userId, id, value2, value, registerDatePersian, appType, lCID, result);
				}
				else
				{
					ObjectParameter insertedId = new ObjectParameter("InsertedId", 0);
					_dbII.WSspInsertDiscountCodeRule(JsonConvert.SerializeObject(list), disRPreCode, disRAmount, disRAmountPercent, disRExpDay, dateTime, disRExpDatePersian, disRUseCnt, disRScoreRate, disRCanChangeToScore, disRInActive, userId, id, value2, value, registerDatePersian, appType, lCID, result, insertedId);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = "0";
		}
		return text;
	}

	[HttpPost]
	[LoginAuthorize]
	public string Delete(int id = 0)
	{
		string result = "";
		try
		{
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteDiscountCodeRule(id));
			if (mct_II_Result != null && mct_II_Result.Result == 0)
			{
				result = Messages.msgErrorOperationFailed;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = "Error: " + Messages.msgErrorOperationFailed;
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

	protected override void Dispose(bool disposing)
	{
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
