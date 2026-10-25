using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
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

namespace CRMIdeal.Areas.Survey.Controllers;

public class HistoryController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult Index(int position, string formName, int systemPartId, int SystemPartObjectId, int cmpId = 0, int prsId = 0)
	{
		string text = "";
		string text2 = "";
		if (!string.IsNullOrEmpty(formName))
		{
			if (formName == "ORD")
			{
				text = "frmOrder";
				text2 = "actordSurvey";
			}
			else
			{
				if (!(formName == "Cmp"))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				text = "frmCompanyI";
				text2 = "actSurveys";
			}
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			base.ViewBag.SystemPartId = systemPartId;
			base.ViewBag.SystemPartObjectId = SystemPartObjectId;
			base.ViewBag.CmpId = cmpId;
			base.ViewBag.PrsId = prsId;
			return View();
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	[DynamicAuthorize(ControllerName = "frmSurManageSurvey", ActionName = "actInsert")]
	public ActionResult InsertEdit(int systemPartId = 0, int SystemPartObjectId = 0, int cmpId = 0, int prsId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		SurveyHistoryViewModel surveyHistoryViewModel = new SurveyHistoryViewModel();
		surveyHistoryViewModel.surhSystemPartId = systemPartId;
		surveyHistoryViewModel.surhSystemPartObjectId = SystemPartObjectId;
		surveyHistoryViewModel.surhCmpId = cmpId;
		surveyHistoryViewModel.surhPrsId = prsId;
		surveyHistoryViewModel.FirstRegisterUserId = userId;
		surveyHistoryViewModel.FirstRegisterDate = DateTime.Now;
		surveyHistoryViewModel.FirstRegisterDatePersian = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
		GetSurvey(systemPartId);
		GetSurveySendSetting();
		base.ViewBag.IsBuying = VersionBuyer.Survey;
		return View(surveyHistoryViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmSurManageSurveyDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(SurveyHistoryViewModel vm)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		short year = short.Parse(Financial.Get().Id.ToString());
		short month = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		GetSurvey(vm.surhSystemPartId);
		GetSurveySendSetting();
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			string text2 = "";
			if (vm.SurveyHistoryId <= 0 && !VersionBuyer.Survey)
			{
				DbSet<CrmSurveyHistory> crmSurveyHistory = _dbTbl.CrmSurveyHistory;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurveyHistory), "c");
				if (Queryable.Any<CrmSurveyHistory>((IQueryable<CrmSurveyHistory>)crmSurveyHistory, Expression.Lambda<Func<CrmSurveyHistory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)3, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + string.Format(Messages.ImportExcelBuyModuleWithCount, "3");
					return View(vm);
				}
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
				return View(vm);
			}
			if (!base.ModelState.IsValid || vm.SurveyHistoryId > 0)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				DateTime dateTime2 = default(DateTime);
				string text3 = "";
				try
				{
					if (!string.IsNullOrEmpty(vm.surhSendDatePersian))
					{
						text3 = PersianDate.GetFormatetdDate(vm.surhSendDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.surhSendDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.surhSendDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.surhSendDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.surhSendDate = dateTime2;
					}
					else
					{
						vm.surhSendDate = null;
						vm.surhSendDatePersian = null;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(vm);
				}
				if (vm.surhSendDatePersian != null)
				{
					vm.surhSendDatePersian = vm.surhSendDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				DateTime dateTime3 = default(DateTime);
				string text4 = "";
				try
				{
					if (!string.IsNullOrEmpty(vm.surhReplyExpireDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(vm.surhReplyExpireDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime3 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							vm.surhReplyExpireDatePersian = dateTime3.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime3 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							vm.surhReplyExpireDatePersian = dateTime3.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime3 = DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							vm.surhReplyExpireDatePersian = dateTime3.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						vm.surhReplyExpireDate = dateTime3;
					}
					else
					{
						vm.surhReplyExpireDate = null;
						vm.surhReplyExpireDatePersian = null;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(vm);
				}
				if (vm.surhReplyExpireDatePersian != null)
				{
					vm.surhReplyExpireDatePersian = vm.surhReplyExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				CrmSurveyHistory entity = new CrmSurveyHistory
				{
					surhSurveyId = vm.surhSurveyId,
					surhDefSendSettingId = vm.surhDefSendSettingId,
					surhSystemPartId = vm.surhSystemPartId,
					surhSystemPartObjectId = vm.surhSystemPartObjectId,
					surhCmpId = vm.surhCmpId,
					surhPrsId = vm.surhPrsId,
					surhToMobileNumber = vm.surhToMobileNumber,
					surhToEmail = vm.surhToEmail,
					surhSendDate = vm.surhSendDate,
					surhSendDatePersian = vm.surhSendDatePersian,
					surhReplyExpireDate = vm.surhReplyExpireDate,
					surhReplyExpireDatePersian = vm.surhReplyExpireDatePersian,
					OrderView = vm.OrderView,
					GUId = Guid.NewGuid(),
					FirstRegisterUserId = userId,
					FirstRegisterDate = dateTime,
					FirstRegisterDatePersian = text,
					Year1 = year,
					Month1 = month,
					UserId = userId,
					RegisterDate = dateTime,
					RegisterDatePersian = text,
					AppType = appType,
					LanguageID = result,
					surhCId = result2
				};
				_dbTbl.CrmSurveyHistory.Add(entity);
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmSurManageSurvey", ActionName = "actDelete")]
	[AjaxOnly]
	public string DeleteSurveyHistory(int surveyHistoryId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmSurManageSurvey", "actDelete", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (surveyHistoryId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteSurveyHistory(surveyHistoryId));
				result = ((mct_Result == null || mct_Result.Result <= 0) ? "-2" : Messages.frmDeleteSuccessMessage);
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

	[AjaxOnly]
	public ActionResult SurveyHistory_Read([DataSourceRequest] DataSourceRequest request, int systemPartId = 0, int systemPartObjectId = 0)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectSurveyHistory(systemPartId, systemPartObjectId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<SurveyHistoryViewModel> SelectSurveyHistory(int systemPartId = 0, int systemPartObjectId = 0)
	{
		List<SurveyHistoryViewModel> list = new List<SurveyHistoryViewModel>();
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
			List<CRMspSelectSurveyHistory_Result> list2 = Enumerable.ToList<CRMspSelectSurveyHistory_Result>((IEnumerable<CRMspSelectSurveyHistory_Result>)_db.CRMspSelectSurveyHistory(systemPartId, systemPartObjectId, lCID, result, result2));
			int num = 1;
			if (list2 != null)
			{
				foreach (CRMspSelectSurveyHistory_Result item in list2)
				{
					SurveyHistoryViewModel surveyHistoryViewModel = new SurveyHistoryViewModel();
					surveyHistoryViewModel.SurveyHistoryId = item.SurveyHistoryId;
					surveyHistoryViewModel.surhSurveyId = item.surhSurveyId;
					surveyHistoryViewModel.surhSurvey = item.surhSurvey;
					surveyHistoryViewModel.surhDefSendSettingId = item.surhDefSendSettingId;
					surveyHistoryViewModel.surhDefSendSetting = item.surhDefSendSetting;
					surveyHistoryViewModel.surhSystemPartId = item.surhSystemPartId;
					surveyHistoryViewModel.surhSystemPartObjectId = item.surhSystemPartObjectId;
					surveyHistoryViewModel.surhCmpId = item.surhCmpId;
					surveyHistoryViewModel.surhPrsId = item.surhPrsId;
					surveyHistoryViewModel.surhToMobileNumber = item.surhToMobileNumber;
					surveyHistoryViewModel.surhToEmail = item.surhToEmail;
					surveyHistoryViewModel.surhRepliedDate = item.surhRepliedDate;
					if (!string.IsNullOrWhiteSpace(item.surhRepliedDatePersian))
					{
						surveyHistoryViewModel.surhRepliedDatePersian = (item.surhRepliedDate ?? DateTime.Now).ToString("yyyy/MM/dd");
					}
					surveyHistoryViewModel.surhReplyExpireDate = item.surhReplyExpireDate;
					if (!string.IsNullOrWhiteSpace(item.surhReplyExpireDatePersian))
					{
						surveyHistoryViewModel.surhReplyExpireDatePersian = (item.surhReplyExpireDate ?? DateTime.Now).ToString("yyyy/MM/dd");
					}
					surveyHistoryViewModel.surhSendDate = item.surhSendDate;
					if (!string.IsNullOrWhiteSpace(item.surhSendDatePersian))
					{
						surveyHistoryViewModel.surhSendDatePersian = (item.surhSendDate ?? DateTime.Now).ToString("yyyy/MM/dd");
					}
					surveyHistoryViewModel.OrderView = item.OrderView;
					surveyHistoryViewModel.FirstRegisterUserId = item.FirstRegisterUserId;
					surveyHistoryViewModel.FirstRegisterUser = item.FirstRegisterUser;
					surveyHistoryViewModel.FirstRegisterDate = item.FirstRegisterDate;
					if (!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian))
					{
						surveyHistoryViewModel.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					}
					surveyHistoryViewModel.RowNumber = num;
					int num2 = DateTime.Compare(surveyHistoryViewModel.surhReplyExpireDate ?? DateTime.Now, DateTime.Now);
					surveyHistoryViewModel.isExpired = false;
					if (num2 < 0)
					{
						surveyHistoryViewModel.isExpired = true;
					}
					if (!string.IsNullOrWhiteSpace(surveyHistoryViewModel.surhRepliedDatePersian))
					{
						surveyHistoryViewModel.isAnswered = true;
					}
					surveyHistoryViewModel.surhCId = item.surhCId;
					surveyHistoryViewModel.surhCenterName = item.surhCenterName;
					list.Add(surveyHistoryViewModel);
					num++;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
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

	[AjaxOnly]
	public JsonResult GetSurvey(int systemPartId)
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
			List<CRMspSelectSurvey_Result> list2 = Enumerable.ToList<CRMspSelectSurvey_Result>(Enumerable.Where<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)_db.CRMspSelectSurvey(lCID, result, result2), (Func<CRMspSelectSurvey_Result, bool>)((CRMspSelectSurvey_Result m) => m.surSystemPartId == systemPartId && !m.surInactive.GetValueOrDefault())));
			list.AddRange(Enumerable.Select<CRMspSelectSurvey_Result, SelectListItem>((IEnumerable<CRMspSelectSurvey_Result>)list2, (Func<CRMspSelectSurvey_Result, SelectListItem>)((CRMspSelectSurvey_Result item) => new SelectListItem
			{
				Text = item.surTitle,
				Value = item.SurveyId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstSurvey = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSurveySendSetting()
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
			List<CRMspSelectSurveySendSetting_Result> list2 = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectSurveySendSetting_Result, SelectListItem>((IEnumerable<CRMspSelectSurveySendSetting_Result>)list2, (Func<CRMspSelectSurveySendSetting_Result, SelectListItem>)((CRMspSelectSurveySendSetting_Result item) => new SelectListItem
			{
				Text = item.surssTitle,
				Value = item.SurveySendSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstSendSettings = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
