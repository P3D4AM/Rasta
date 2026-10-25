using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Company.Controllers;

public class SendCmpNotifToMobController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actSendCmpNotifToMob")]
	public ActionResult Index(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		SendCmpNotifToMobViewModel sendCmpNotifToMobViewModel = new SendCmpNotifToMobViewModel();
		try
		{
			CRMspSelectMobSetting_Result cRMspSelectMobSetting_Result = Enumerable.FirstOrDefault<CRMspSelectMobSetting_Result>((IEnumerable<CRMspSelectMobSetting_Result>)_dbII.CRMspSelectMobSetting(lCID, result));
			if (cRMspSelectMobSetting_Result != null)
			{
				sendCmpNotifToMobViewModel.msgBody = cRMspSelectMobSetting_Result.CmpNotifCnvsDesc;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpId = cmpId;
		return View(sendCmpNotifToMobViewModel);
	}

	[HttpPost]
	public JsonResult ActSendCmpNotifToMob(string parameters, int cmpId)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				SendCmpNotifToMobViewModel sendCmpNotifToMobViewModel = new JavaScriptSerializer().Deserialize<SendCmpNotifToMobViewModel>(parameters);
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				DateTime value4 = now.AddSeconds(-7.0);
				_ = Messages.FOTicketErjaShow;
				short value5 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				string registerDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				string registerTime = now.ToString("HH:mm:ss");
				string text3 = "";
				int num = 0;
				if (!UserLogin.IsUserAccess("frmCompanyI", "actSendCmpNotifToMob", UserLogin.CurrentUser))
				{
					text3 = text3 + Messages.ErrorNotAccess + "<br>";
					num++;
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(sendCmpNotifToMobViewModel.msgSubject_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(sendCmpNotifToMobViewModel.msgSubject_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = sendCmpNotifToMobViewModel.msgSubject,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(sendCmpNotifToMobViewModel.msgBody_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(sendCmpNotifToMobViewModel.msgBody_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = sendCmpNotifToMobViewModel.msgBody,
					LanguageId = lCID
				});
				if (sendCmpNotifToMobViewModel.msgBody == null && sendCmpNotifToMobViewModel.msgBody == "")
				{
					text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(sendCmpNotifToMobViewModel.msgBody, list2))
				{
					text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.SendCmpNotifToMobMsgBody) + "<br>";
					num++;
				}
				if (cmpId == 0)
				{
					text3 += Messages.msgErrorNotSelectCompany;
					num++;
				}
				if (num == 0)
				{
					string text4 = "";
					string text5 = "";
					string text6 = "";
					foreach (Languages lang in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
					{
						text5 = "";
						text6 = "";
						text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
						text6 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : "");
						text4 = text4 + "MsgSubj=" + text5 + "|@#@|MsgBody=" + text6 + "|@#@|LangId=" + lang.LanguageID + "|@#@||^#^|";
					}
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					text = "";
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspSendCompanyNotif(cmpId, text4, userId, value, registerDatePersian, registerDay, registerTime, value4, value5, value3, value2, appType, lCID, result, objectParameter, centerId));
					string text7 = "";
					if (objectParameter.Value != null)
					{
						text7 = objectParameter.Value.ToString();
						if (!string.IsNullOrWhiteSpace(text7))
						{
							if (text7.IndexOf("NoSetting", StringComparison.Ordinal) >= 0)
							{
								text7 = Messages.errorInReadingSetting;
							}
							else if (text7.IndexOf("NoPerson", StringComparison.Ordinal) >= 0)
							{
								text7 = Messages.msgErrorSendCmpNotifToMobNotPerson;
							}
						}
						else if (!string.IsNullOrWhiteSpace(text7))
						{
							text7 = Messages.msgErrorRunFunction;
						}
					}
					if (!string.IsNullOrWhiteSpace(text7))
					{
						text = "";
						text2 = text7;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
					else if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						PushNotif.NewIntMsgNotify();
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("Title", text5);
						dictionary.Add("Message", text6);
						dictionary.Add("MessageType", "InternalMsg");
						PushNotif.NewIntMsgNotifyToCompany(cmpId, dictionary);
						text2 = Messages.msgSuccessAction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					}
					else
					{
						text = "";
						text2 = text7;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
				}
				else
				{
					text = "";
					text2 = text3;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text = "";
				text2 = string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody);
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public JsonResult ActSendCmpNotifToMobFo(string parameters, int cmpId)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				SendCmpNotifToMobViewModel sendCmpNotifToMobViewModel = new JavaScriptSerializer().Deserialize<SendCmpNotifToMobViewModel>(parameters);
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				_ = Configuration.AppType;
				short.Parse(Financial.Get().Id.ToString());
				_ = UserLogin.CurrentUser.UserId;
				now.AddSeconds(-7.0);
				_ = Messages.FOTicketErjaShow;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				now.ToString("HH:mm:ss");
				string text3 = "";
				int num = 0;
				if (!UserLogin.IsUserAccess("frmCompanyI", "actSendCmpNotifToMob", UserLogin.CurrentUser))
				{
					text3 = text3 + Messages.ErrorNotAccess + "<br>";
					num++;
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(sendCmpNotifToMobViewModel.msgSubject_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(sendCmpNotifToMobViewModel.msgSubject_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = sendCmpNotifToMobViewModel.msgSubject,
					LanguageId = currLangID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(sendCmpNotifToMobViewModel.msgBody_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(sendCmpNotifToMobViewModel.msgBody_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = sendCmpNotifToMobViewModel.msgBody,
					LanguageId = currLangID
				});
				if (sendCmpNotifToMobViewModel.msgBody == null && sendCmpNotifToMobViewModel.msgBody == "")
				{
					text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(sendCmpNotifToMobViewModel.msgBody, list2))
				{
					text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.SendCmpNotifToMobMsgBody) + "<br>";
					num++;
				}
				if (cmpId == 0)
				{
					text3 += Messages.msgErrorNotSelectCompany;
					num++;
				}
				if (num == 0)
				{
					string value = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					string value2 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					new Dictionary<string, string>
					{
						{ "NotificationTitle", value },
						{ "NotificationBody", value2 }
					};
					text = "";
					text2 = Messages.msgSuccessAction;
					commonResultStatusViewModel = CommonResultStatusViewModel.Success;
				}
				else
				{
					text = "";
					text2 = text3;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text = "";
				text2 = string.Format(Messages.ErrorEmpty, Labels.SendCmpNotifToMobMsgBody);
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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
		_db.Dispose();
		_dbI.Dispose();
		_dbTbl.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
