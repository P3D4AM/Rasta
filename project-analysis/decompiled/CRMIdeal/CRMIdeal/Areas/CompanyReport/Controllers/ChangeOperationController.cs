using System;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.CompanyReport.Controllers;

public class ChangeOperationController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actcmpChangeOperation")]
	public ActionResult Index()
	{
		GetCompanyGroupII();
		GetCompanyGroupIII();
		GetCompanyGroupIV();
		GetCompanyReferUsers();
		GetConversationStatus();
		GetCmpMultiGroupsList();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroupII()
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
			string none = Labels.None;
			string haveNot = Labels.HaveNot;
			List<CRMspRpt_cmpSelCompanyGroupsII_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsII_Result>)_db.CRMspRpt_cmpSelCompanyGroupsII(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsII_Result>)list2, (Func<CRMspRpt_cmpSelCompanyGroupsII_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.Val,
				Value = item.ID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CompanyGroupIIList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroupIII()
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
			string none = Labels.None;
			string haveNot = Labels.HaveNot;
			List<CRMspRpt_cmpSelCompanyGroupsIII_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsIII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIII_Result>)_db.CRMspRpt_cmpSelCompanyGroupsIII(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIII_Result>)list2, (Func<CRMspRpt_cmpSelCompanyGroupsIII_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.Val,
				Value = item.ID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CompanyGroupIIIList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroupIV()
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
			string none = Labels.None;
			string haveNot = Labels.HaveNot;
			List<CRMspRpt_cmpSelCompanyGroupsIV_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsIV_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIV_Result>)_db.CRMspRpt_cmpSelCompanyGroupsIV(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIV_Result>)list2, (Func<CRMspRpt_cmpSelCompanyGroupsIV_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = item.Val,
				Value = item.ID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CompanyGroupIVList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyReferUsers()
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
			string none = Labels.None;
			string haveNot = Labels.HaveNot;
			List<CRMspRpt_cmpSelCompanyReferUsers_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)_db.CRMspRpt_cmpSelCompanyReferUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)list2, (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyReferUsers_Result item) => new SelectListItem
			{
				Text = item.Val,
				Value = item.ID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CompanyReferUsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetConversationStatus()
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
			string none = Labels.None;
			string haveNot = Labels.HaveNot;
			List<CRMspRpt_cmpSelConversationStatus_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatus_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)_db.CRMspRpt_cmpSelConversationStatus(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationStatus_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)list2, (Func<CRMspRpt_cmpSelConversationStatus_Result, SelectListItem>)((CRMspRpt_cmpSelConversationStatus_Result item) => new SelectListItem
			{
				Text = item.Val,
				Value = item.ID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ConversationStatusList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpMultiGroupsList()
	{
		List<MultiGroupItem> list = new List<MultiGroupItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			foreach (CRMspSelectCompanyGroupsMulti_Result item2 in Enumerable.ToList<CRMspSelectCompanyGroupsMulti_Result>((IEnumerable<CRMspSelectCompanyGroupsMulti_Result>)_db.CRMspSelectCompanyGroupsMulti(lCID, result)))
			{
				MultiGroupItem item = new MultiGroupItem
				{
					title = item2.CompanyGroupsMultiName,
					ischeck = false,
					id = item2.CompanyGroupsMultiID
				};
				list.Add(item);
			}
			base.ViewBag.MultiGroups = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string UpdateCompanyReportOperation(int mode, string modeVal, int multiopr)
	{
		string text = "";
		try
		{
			if (mode > 0 && !string.IsNullOrEmpty(modeVal))
			{
				DateTime now = DateTime.Now;
				string userId = UserLogin.CurrentUser.UserId.ToString();
				string year = short.Parse(Financial.Get().Id.ToString()).ToString();
				string month = short.Parse(now.ToString("MM", new PersianCulture())).ToString();
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				_db.CRMspUpdateCompanyReportOperation(userId, year, month, registerDatePersian, mode, modeVal, multiopr, appType, centerId);
				return "1|" + Messages.msgSuccessAction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCompanyReportOperation", ActionName = "actCanDoLinkedCompany")]
	public string DoLinkedCompany(int cmpId)
	{
		string result = "";
		try
		{
			if (cmpId != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				string persianDate = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				_db.CrmspInsertLinkedCompanyGroupFromReport(cmpId, userId, persianDate, now, value2, value, appType, result2, centerId);
			}
			else
			{
				result = Messages.msgErrorNotSelectCompany;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	public JsonResult ProjectTitleFull(string valPrjTitle)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyProjectTitle_Result> list = new List<CRMspSelectCompanyProjectTitle_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			valPrjTitle = valPrjTitle ?? "";
			list = Enumerable.ToList<CRMspSelectCompanyProjectTitle_Result>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)_db.CRMspSelectCompanyProjectTitle(valPrjTitle, UserLogin.CurrentUser.UserId, lCID, result, result2));
			foreach (CRMspSelectCompanyProjectTitle_Result item in list)
			{
				item.prjStatusGroup = item.prjStatusGroup ?? "";
				item.prjTitle = item.prjTitle ?? "";
				item.ProjectTitleGroupId = item.ProjectTitleGroupId.GetValueOrDefault();
				item.ProjectTitleGradeId = item.ProjectTitleGradeId.GetValueOrDefault();
				item.ProjectTitlePriorityId = item.ProjectTitlePriorityId.GetValueOrDefault();
				item.ProjectTitleDesc = item.ProjectTitleDesc ?? "";
				item.ProjectTitleStatusGroupId = item.ProjectTitleStatusGroupId.GetValueOrDefault();
				item.ProjectCategoryId = item.ProjectCategoryId.GetValueOrDefault();
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

	[AjaxOnly]
	public JsonResult GetCnvsStatusGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatusGroups_Result>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)_dbI.CRMspSelectActiveConversationStatusGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)list2, (Func<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>)((CRMspSelectActiveConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = (item.ConversationStatusGroup ?? ""),
				Value = item.ConversationStatusGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatus(int cnvsStatusGroupId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveConversationStatus_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(cnvsStatusGroupId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list2, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
			{
				Text = (item.Status ?? ""),
				Value = item.ConversationStatusID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCnvsReferUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForCnvsReferToUser_Result> list2 = Enumerable.ToList<CRMspSelectUserForCnvsReferToUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)_db.CRMspSelectUserForCnvsReferToUser(userId, 7, 0, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForCnvsReferToUser_Result, SelectListItem>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)list2, (Func<CRMspSelectUserForCnvsReferToUser_Result, SelectListItem>)((CRMspSelectUserForCnvsReferToUser_Result item) => new SelectListItem
			{
				Text = (item.UserName ?? ""),
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ListCnvsReferUser = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCnvsTopics()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectConversationTopics_Result> list2 = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list2, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = (item.Topic ?? ""),
				Value = item.ConversationTopicsID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string InsertConversation(string strJson)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (string.IsNullOrWhiteSpace(strJson))
			{
				return Messages.msgErrorNotSelectedItem;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			InsertConversationFromReportViewModel insertConversationFromReportViewModel = new JavaScriptSerializer().Deserialize<InsertConversationFromReportViewModel>(strJson);
			if (insertConversationFromReportViewModel != null)
			{
				DateTime dateTime = default(DateTime);
				string text2 = "";
				try
				{
					if (!string.IsNullOrWhiteSpace(insertConversationFromReportViewModel.CnvsRemindDate))
					{
						text2 = PersianDate.GetFormatetdDate(insertConversationFromReportViewModel.CnvsRemindDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							insertConversationFromReportViewModel.CnvsRemindDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							insertConversationFromReportViewModel.CnvsRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							insertConversationFromReportViewModel.CnvsRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						insertConversationFromReportViewModel.CnvsRemindDateTime = dateTime;
						if (!string.IsNullOrEmpty(insertConversationFromReportViewModel.CnvsRemindDate))
						{
							string strB = DateTime.Now.ToString("yyyyMMdd");
							DateTimeClass.ConvertDateWOSlashToSlash(insertConversationFromReportViewModel.CnvsRemindDate);
							if (string.Compare(insertConversationFromReportViewModel.CnvsRemindDate, strB) < -1)
							{
								return Messages.msgErrorBeforecnvsRemindDate + "<br>";
							}
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					return string.Format(Messages.ErrorInFormat, Labels.CmpChangeOperationAddCnvsPrjCnvsRemindDate);
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(insertConversationFromReportViewModel.CnvsDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(insertConversationFromReportViewModel.CnvsDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = insertConversationFromReportViewModel.CnvsDesc,
					LanguageId = lCID
				});
				insertConversationFromReportViewModel.CnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				insertConversationFromReportViewModel.CnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				string text3 = "";
				string surveyMainExtrenalLinkLogin = "";
				string surveyMainExtrenalLink = "";
				Uri url = base.HttpContext.Request.Url;
				string text4 = url.Scheme + "://" + url.Authority;
				if (text4.EndsWith("/"))
				{
					text4 = text4.TrimEnd(new char[1] { '/' });
				}
				text4 += "/Survey/Home/SurveyAnswerValues";
				text3 = text4;
				string text5 = "";
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				string text6 = "";
				string text7 = "";
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					text6 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
					text7 = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text6))
				{
					text5 = text6.Trim();
					if (!text5.Contains("http"))
					{
						text5 = url.Scheme + "://" + text5;
					}
					if (text5.EndsWith("/"))
					{
						text5 = text5.TrimEnd(new char[1] { '/' });
					}
					text5 += "/Survey/Home";
					surveyMainExtrenalLinkLogin = text5;
				}
				if (!string.IsNullOrWhiteSpace(text7))
				{
					text5 = text7.Trim();
					if (!text5.Contains("http"))
					{
						text5 = url.Scheme + "://" + text5;
					}
					if (text5.EndsWith("/"))
					{
						text5 = text5.TrimEnd(new char[1] { '/' });
					}
					text5 += "/Survey/Register/Index";
					surveyMainExtrenalLink = text5;
				}
				int maxFOCount = Configuration.MaxFOCount;
				string lblUnknown = Labels.lblUnknown;
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertConversationFromReport(insertConversationFromReportViewModel.CnvsReferUserId, insertConversationFromReportViewModel.CnvsRemindDate, insertConversationFromReportViewModel.CnvsRemindDateTime, insertConversationFromReportViewModel.CnvsDesc, insertConversationFromReportViewModel.CnvsDesc_Lang, insertConversationFromReportViewModel.CnvsTopicId, lblUnknown, userId, value3, value2, value, registerDatePersian, appType, defLangID, centerId, text3, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, maxFOCount));
				int result = 0;
				int.TryParse(mct_I_Result.Result.ToString(), out result);
				if (result == 1)
				{
					return "1";
				}
				return Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotSelectedItem;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public string InsertProject(string strJson)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (string.IsNullOrWhiteSpace(strJson))
			{
				return Messages.msgErrorNotSelectedItem;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			InsertProjectFromReportViewModel insertProjectFromReportViewModel = new JavaScriptSerializer().Deserialize<InsertProjectFromReportViewModel>(strJson);
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (insertProjectFromReportViewModel != null)
			{
				DateTime dateTime = default(DateTime);
				string text2 = "";
				try
				{
					if (!string.IsNullOrWhiteSpace(insertProjectFromReportViewModel.CnvsRemindDate))
					{
						text2 = PersianDate.GetFormatetdDate(insertProjectFromReportViewModel.CnvsRemindDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							insertProjectFromReportViewModel.CnvsRemindDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							insertProjectFromReportViewModel.CnvsRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							insertProjectFromReportViewModel.CnvsRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						insertProjectFromReportViewModel.CnvsRemindDateTime = dateTime;
						if (!string.IsNullOrEmpty(insertProjectFromReportViewModel.CnvsRemindDate))
						{
							string strB = DateTime.Now.ToString("yyyyMMdd");
							DateTimeClass.ConvertDateWOSlashToSlash(insertProjectFromReportViewModel.CnvsRemindDate);
							if (string.Compare(insertProjectFromReportViewModel.CnvsRemindDate, strB) < -1)
							{
								return Messages.msgErrorBeforecnvsRemindDate + "<br>";
							}
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					return string.Format(Messages.ErrorInFormat, Labels.CmpChangeOperationAddCnvsPrjCnvsRemindDate);
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(insertProjectFromReportViewModel.CnvsDesc_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(insertProjectFromReportViewModel.CnvsDesc_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = insertProjectFromReportViewModel.CnvsDesc,
					LanguageId = lCID
				});
				insertProjectFromReportViewModel.CnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				insertProjectFromReportViewModel.CnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(insertProjectFromReportViewModel.PrjTitle_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(insertProjectFromReportViewModel.PrjTitle_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = insertProjectFromReportViewModel.PrjTitle,
					LanguageId = lCID
				});
				insertProjectFromReportViewModel.PrjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				insertProjectFromReportViewModel.PrjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
				string text3 = "";
				string surveyMainExtrenalLinkLogin = "";
				string surveyMainExtrenalLink = "";
				Uri url = base.HttpContext.Request.Url;
				string text4 = url.Scheme + "://" + url.Authority;
				if (text4.EndsWith("/"))
				{
					text4 = text4.TrimEnd(new char[1] { '/' });
				}
				text4 += "/Survey/Home/SurveyAnswerValues";
				text3 = text4;
				string text5 = "";
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				string text6 = "";
				string text7 = "";
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					text6 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
					text7 = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text6))
				{
					text5 = text6.Trim();
					if (!text5.Contains("http"))
					{
						text5 = url.Scheme + "://" + text5;
					}
					if (text5.EndsWith("/"))
					{
						text5 = text5.TrimEnd(new char[1] { '/' });
					}
					text5 += "/Survey/Home";
					surveyMainExtrenalLinkLogin = text5;
				}
				if (!string.IsNullOrWhiteSpace(text7))
				{
					text5 = text7.Trim();
					if (!text5.Contains("http"))
					{
						text5 = url.Scheme + "://" + text5;
					}
					if (text5.EndsWith("/"))
					{
						text5 = text5.TrimEnd(new char[1] { '/' });
					}
					text5 += "/Survey/Register/Index";
					surveyMainExtrenalLink = text5;
				}
				int maxFOCount = Configuration.MaxFOCount;
				string lblUnknown = Labels.lblUnknown;
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertProjectAndConversationFromReport(insertProjectFromReportViewModel.PrjTitle, insertProjectFromReportViewModel.PrjTitle_Lang, insertProjectFromReportViewModel.PrjcnvsStatusGroupId, insertProjectFromReportViewModel.AddCnvs, insertProjectFromReportViewModel.CnvsDesc, insertProjectFromReportViewModel.CnvsDesc_Lang, insertProjectFromReportViewModel.CnvsTopicId, insertProjectFromReportViewModel.CnvsReferUserId, insertProjectFromReportViewModel.CnvsRemindDate, insertProjectFromReportViewModel.CnvsRemindDateTime, insertProjectFromReportViewModel.CnvsStatusId, lblUnknown, userId, value3, value2, value, registerDatePersian, appType, defLangID, centerId, text3, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, maxFOCount));
				int result = 0;
				int.TryParse(mct_I_Result.Result.ToString(), out result);
				if (result == 1)
				{
					return "1";
				}
				return Messages.msgErrorRunFunction;
			}
			return Messages.msgErrorNotSelectedItem;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
