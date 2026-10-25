using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Company.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.CompanyReport.Controllers;

public class CompanyReportController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCompanyReport")]
	public ActionResult Index()
	{
		CrmCompanyReportViewModel crmCompanyReportViewModel = new CrmCompanyReportViewModel();
		crmCompanyReportViewModel.prsSel = false;
		crmCompanyReportViewModel.prjSel = false;
		crmCompanyReportViewModel.cnvsSel = false;
		FillDropdownCompany();
		return View(crmCompanyReportViewModel);
	}

	public ActionResult CompanyReportFromIndicator(int position, int type = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmPreOrderIndicator";
			text2 = "actCanSelectcmpFilter";
			break;
		case 2:
			text = "frmBuyOrderIndicator";
			text2 = "actCanSelectcmpFilter";
			break;
		case 3:
			text = "frmOrderIndicator";
			text2 = "actCanSelectcmpFilter";
			break;
		case 4:
			text = "frmDyFormsReport";
			text2 = "actCanSelectcmpFilter";
			break;
		case 5:
			text = "frmStockSupplyIndicator";
			text2 = "actCanSelectcmpFilter";
			break;
		case 6:
			text = "frmDocIndicator";
			text2 = "actCanSelectcmpFilter";
			break;
		case 7:
			text = "frmMain";
			text2 = "actrptCmpAccountingBalance";
			break;
		case 8:
			text = "frmScoresReport";
			text2 = "actCanSelectcmpFilter";
			break;
		case 9:
			text = "frmMain";
			text2 = "actScoreCalculation";
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
		CrmCompanyReportViewModel crmCompanyReportViewModel = new CrmCompanyReportViewModel();
		crmCompanyReportViewModel.prsSel = false;
		crmCompanyReportViewModel.prjSel = false;
		crmCompanyReportViewModel.cnvsSel = false;
		if (type > 0)
		{
			base.ViewBag.TempType = type;
		}
		FillDropdownCompany();
		return View(crmCompanyReportViewModel);
	}

	[LoginAuthorize]
	public ActionResult SmsLoadAndCheckNumberBeforeSend(int reSendSms = 0, int position = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		string text = "";
		string text2 = "";
		string text3 = "";
		switch (position)
		{
		case 0:
			text2 = "frmCompanyReport";
			text3 = "actGetMobileNumber";
			goto IL_00dc;
		case 1:
			text2 = "frmOrderIndicator";
			text3 = "actSendSms";
			goto IL_00dc;
		case 2:
			text2 = "frmPreOrderIndicator";
			text3 = "actSendSms";
			goto IL_00dc;
		case 3:
			text2 = "frmMain";
			text3 = "actcForgetSendSms";
			goto IL_00dc;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		case -1:
			break;
			IL_00dc:
			if (!UserLogin.IsUserAccess(text2, text3, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			break;
		}
		try
		{
			text = GetPattern();
			if (reSendSms == 0)
			{
				db.CRMspInsertSmsTempMobileNumbersFromRptFilterData(UserLogin.CurrentUser.UserId, Configuration.AppType, lCID, result);
			}
			num = Enumerable.ToList<CRMspSelectUserTempNumberInMode_Result>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)db.CRMspSelectUserTempNumberInMode(UserLogin.CurrentUser.UserId, 0)).Count;
			num2 = Enumerable.ToList<CRMspSelectUserTempNumberInMode_Result>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)db.CRMspSelectUserTempNumberInMode(UserLogin.CurrentUser.UserId, 1)).Count;
			num3 = Enumerable.ToList<CRMspSelectUserTempNumberInMode_Result>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)db.CRMspSelectUserTempNumberInMode(UserLogin.CurrentUser.UserId, 2)).Count;
			num4 = Enumerable.ToList<CRMspSelectUserTempNumberInMode_Result>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)db.CRMspSelectUserTempNumberInMode(UserLogin.CurrentUser.UserId, 3)).Count;
			num5 = Enumerable.ToList<CRMspSelectUserTempNumberInMode_Result>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)db.CRMspSelectUserTempNumberInMode(UserLogin.CurrentUser.UserId, 4)).Count;
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.Pattern = text;
		base.ViewBag.filterAll = num;
		base.ViewBag.filterCorrectTel = num2;
		base.ViewBag.filterNotBlackList = num3;
		base.ViewBag.filterIsBlackList = num4;
		base.ViewBag.filterNotCrrectTel = num5;
		return View();
	}

	private void FillDropdownCompany()
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
		List<CRMspRpt_cmpSelCompanyTitle_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyTitle_Result>((IEnumerable<CRMspRpt_cmpSelCompanyTitle_Result>)db.CRMspRpt_cmpSelCompanyTitle(none, haveNot, lCID, result));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyTitle_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyTitle_Result>)list, (Func<CRMspRpt_cmpSelCompanyTitle_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyTitle_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpTitleList = list2;
		List<CRMspRpt_cmpSelCompanyCountry_Result> list3 = Enumerable.ToList<CRMspRpt_cmpSelCompanyCountry_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCountry_Result>)db.CRMspRpt_cmpSelCompanyCountry(none, haveNot, lCID, result));
		List<SelectListItem> list4 = new List<SelectListItem>();
		list4.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyCountry_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyCountry_Result>)list3, (Func<CRMspRpt_cmpSelCompanyCountry_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyCountry_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpCountryList = list4;
		List<CRMspRpt_cmpSelCompanyPresentation_Result> list5 = Enumerable.ToList<CRMspRpt_cmpSelCompanyPresentation_Result>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)db.CRMspRpt_cmpSelCompanyPresentation(none, haveNot, lCID, result));
		List<SelectListItem> list6 = new List<SelectListItem>();
		list6.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)list5, (Func<CRMspRpt_cmpSelCompanyPresentation_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyPresentation_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpPresentationList = list6;
		List<CRMspRpt_cmpSelCompanyType_Result> list7 = Enumerable.ToList<CRMspRpt_cmpSelCompanyType_Result>((IEnumerable<CRMspRpt_cmpSelCompanyType_Result>)db.CRMspRpt_cmpSelCompanyType(none, haveNot, lCID, result));
		List<SelectListItem> list8 = new List<SelectListItem>();
		list8.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyType_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyType_Result>)list7, (Func<CRMspRpt_cmpSelCompanyType_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyType_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpTypeList = list8;
		List<CRMspRpt_cmpSelCompanyGroup_Result> list9 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroup_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroup_Result>)db.CRMspRpt_cmpSelCompanyGroup(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
		List<SelectListItem> list10 = new List<SelectListItem>();
		list10.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroup_Result>)list9, (Func<CRMspRpt_cmpSelCompanyGroup_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyGroup_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpGroupList = list10;
		List<CRMspRpt_cmpSelCompanyGroupsII_Result> list11 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsII_Result>)db.CRMspRpt_cmpSelCompanyGroupsII(none, haveNot, lCID, result));
		List<SelectListItem> list12 = new List<SelectListItem>();
		list12.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsII_Result>)list11, (Func<CRMspRpt_cmpSelCompanyGroupsII_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyGroupsII_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpGroupIIList = list12;
		List<CRMspRpt_cmpSelCompanyGroupsIII_Result> list13 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsIII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIII_Result>)db.CRMspRpt_cmpSelCompanyGroupsIII(none, haveNot, lCID, result));
		List<SelectListItem> list14 = new List<SelectListItem>();
		list14.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIII_Result>)list13, (Func<CRMspRpt_cmpSelCompanyGroupsIII_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyGroupsIII_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpGroupIIIList = list14;
		List<CRMspRpt_cmpSelCompanyGroupsIV_Result> list15 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsIV_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIV_Result>)db.CRMspRpt_cmpSelCompanyGroupsIV(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
		List<SelectListItem> list16 = new List<SelectListItem>();
		list16.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIV_Result>)list15, (Func<CRMspRpt_cmpSelCompanyGroupsIV_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyGroupsIV_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpGroupIVList = list16;
		List<CRMspRpt_cmpSelCompanyGroupsMulti_Result> list17 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsMulti_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsMulti_Result>)db.CRMspRpt_cmpSelCompanyGroupsMulti(none, haveNot, lCID, result));
		List<SelectListItem> list18 = new List<SelectListItem>();
		list18.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsMulti_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsMulti_Result>)list17, (Func<CRMspRpt_cmpSelCompanyGroupsMulti_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyGroupsMulti_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpGroupsMultiList = list18;
		List<CRMspRpt_cmpSelCompanyReferUsers_Result> list19 = Enumerable.ToList<CRMspRpt_cmpSelCompanyReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelCompanyReferUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)db.CRMspRpt_cmpSelCompanyReferUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, int>)((CRMspRpt_cmpSelCompanyReferUsers_Result c) => c.ord)));
		List<SelectListItem> list20 = new List<SelectListItem>();
		list20.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)list19, (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyReferUsers_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpReferUserList = list20;
		List<CRMspRpt_cmpSelCompanyUsers_Result> list21 = Enumerable.ToList<CRMspRpt_cmpSelCompanyUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyUsers_Result>)db.CRMspRpt_cmpSelCompanyUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
		List<SelectListItem> list22 = new List<SelectListItem>();
		list22.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyUsers_Result>)list21, (Func<CRMspRpt_cmpSelCompanyUsers_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyUsers_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cmpUserList = list22;
		List<CRMspRpt_cmpSelPersonUsers_Result> list23 = Enumerable.ToList<CRMspRpt_cmpSelPersonUsers_Result>((IEnumerable<CRMspRpt_cmpSelPersonUsers_Result>)db.CRMspRpt_cmpSelPersonUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
		List<SelectListItem> list24 = new List<SelectListItem>();
		list24.AddRange(Enumerable.Select<CRMspRpt_cmpSelPersonUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelPersonUsers_Result>)list23, (Func<CRMspRpt_cmpSelPersonUsers_Result, SelectListItem>)((CRMspRpt_cmpSelPersonUsers_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.prsUserList = list24;
		List<CRMspRpt_cmpSelConversationUsers2_Result> list25 = Enumerable.ToList<CRMspRpt_cmpSelConversationUsers2_Result>((IEnumerable<CRMspRpt_cmpSelConversationUsers2_Result>)db.CRMspRpt_cmpSelConversationUsers2(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
		List<SelectListItem> list26 = new List<SelectListItem>();
		list26.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationUsers2_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelConversationUsers2_Result>)list25, (Func<CRMspRpt_cmpSelConversationUsers2_Result, SelectListItem>)((CRMspRpt_cmpSelConversationUsers2_Result item) => new SelectListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.cnvsUserList = list26;
		List<CRMspRpt_cmpSelCompanyReferUsers_Result> list27 = Enumerable.ToList<CRMspRpt_cmpSelCompanyReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelCompanyReferUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)db.CRMspRpt_cmpSelCompanyReferUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, int>)((CRMspRpt_cmpSelCompanyReferUsers_Result c) => c.ord)));
		List<SelectListItem> list28 = new List<SelectListItem>();
		if (list27 != null && Enumerable.Any<CRMspRpt_cmpSelCompanyReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)list27))
		{
			list28.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)list27, (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, SelectListItem>)((CRMspRpt_cmpSelCompanyReferUsers_Result item) => new SelectListItem
			{
				Text = item.Val,
				Value = item.ID.ToString(),
				Selected = false
			})));
		}
		base.ViewBag.cmpSuppUserList = list28;
	}

	[AjaxOnly]
	public JsonResult GetProvince(int id)
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyProvince_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelCompanyProvince_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanyProvince_Result>((IEnumerable<CRMspRpt_cmpSelCompanyProvince_Result>)db.CRMspRpt_cmpSelCompanyProvince(UserLogin.CurrentUser.UserId, id, none, haveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelCompanyProvince_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelCompanyProvince_Result province) => new CrmDroupDownItem
		{
			text = province.Val,
			value = province.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCity(int id)
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyCity_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelCompanyCity_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanyCity_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCity_Result>)db.CRMspRpt_cmpSelCompanyCity(UserLogin.CurrentUser.UserId, id, none, haveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelCompanyCity_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelCompanyCity_Result city) => new CrmDroupDownItem
		{
			text = city.Val,
			value = city.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSubGroup(int id)
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelCompanySubGroup_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelCompanySubGroup_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanySubGroup_Result>((IEnumerable<CRMspRpt_cmpSelCompanySubGroup_Result>)db.CRMspRpt_cmpSelCompanySubGroup(UserLogin.CurrentUser.UserId, id, none, haveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelCompanySubGroup_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelCompanySubGroup_Result CrmCompanySubGroups) => new CrmDroupDownItem
		{
			text = CrmCompanySubGroups.Val,
			value = CrmCompanySubGroups.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPersonTitles()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonTitle_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonTitle_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonTitle_Result>((IEnumerable<CRMspRpt_cmpSelPersonTitle_Result>)db.CRMspRpt_cmpSelPersonTitle(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonTitle_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonTitle_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetJobsList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonJobs_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonJobs_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonJobs_Result>((IEnumerable<CRMspRpt_cmpSelPersonJobs_Result>)db.CRMspRpt_cmpSelPersonJobs(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonJobs_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonJobs_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDepartmentList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonDepartments_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonDepartments_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonDepartments_Result>((IEnumerable<CRMspRpt_cmpSelPersonDepartments_Result>)db.CRMspRpt_cmpSelPersonDepartments(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonDepartments_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonDepartments_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprsTypeList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonType_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonType_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonType_Result>((IEnumerable<CRMspRpt_cmpSelPersonType_Result>)db.CRMspRpt_cmpSelPersonType(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonType_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonType_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprsGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonGroups_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonGroups_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonGroups_Result>((IEnumerable<CRMspRpt_cmpSelPersonGroups_Result>)db.CRMspRpt_cmpSelPersonGroups(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonGroups_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonGroups_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetEducationList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonEducation_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonEducation_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonEducation_Result>((IEnumerable<CRMspRpt_cmpSelPersonEducation_Result>)db.CRMspRpt_cmpSelPersonEducation(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonEducation_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonEducation_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSexList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelSex_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelSex_Result>)Enumerable.ToList<CRMspRpt_cmpSelSex_Result>((IEnumerable<CRMspRpt_cmpSelSex_Result>)db.CRMspRpt_cmpSelSex(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelSex_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelSex_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPersonProvince(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonProvince_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonProvince_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonProvince_Result>((IEnumerable<CRMspRpt_cmpSelPersonProvince_Result>)db.CRMspRpt_cmpSelPersonProvince(id, none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonProvince_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonProvince_Result province) => new CrmDroupDownItem
		{
			text = province.Val,
			value = province.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPersonCity(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonCity_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonCity_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonCity_Result>((IEnumerable<CRMspRpt_cmpSelPersonCity_Result>)db.CRMspRpt_cmpSelPersonCity(id, none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonCity_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonCity_Result city) => new CrmDroupDownItem
		{
			text = city.Val,
			value = city.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPersonCountry()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelPersonCountry_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelPersonCountry_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonCountry_Result>((IEnumerable<CRMspRpt_cmpSelPersonCountry_Result>)db.CRMspRpt_cmpSelPersonCountry(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonCountry_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelPersonCountry_Result province) => new CrmDroupDownItem
		{
			text = province.Val,
			value = province.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProjectTitle()
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjects_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjects_Result>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjects_Result, string>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)db.CRMspRpt_cmpSelProjects(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelProjects_Result, string>)((CRMspRpt_cmpSelProjects_Result c) => c.ord))), (Func<CRMspRpt_cmpSelProjects_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjects_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetStatusGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectStatusGroups_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectStatusGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjectStatusGroups_Result, int>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)db.CRMspRpt_cmpSelProjectStatusGroups(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result), (Func<CRMspRpt_cmpSelProjectStatusGroups_Result, int>)((CRMspRpt_cmpSelProjectStatusGroups_Result c) => c.ord))), (Func<CRMspRpt_cmpSelProjectStatusGroups_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectStatusGroups_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjPriorityList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectPriority_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectPriority_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectPriority_Result>((IEnumerable<CRMspRpt_cmpSelProjectPriority_Result>)db.CRMspRpt_cmpSelProjectPriority(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectPriority_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectPriority_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjGradeList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectGrade_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectGrade_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectGrade_Result>((IEnumerable<CRMspRpt_cmpSelProjectGrade_Result>)db.CRMspRpt_cmpSelProjectGrade(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectGrade_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectGrade_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectGroups_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectGroups_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroups_Result>)db.CRMspRpt_cmpSelProjectGroups(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectGroups_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectGroups_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjGroupsMultiList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectGroupsMulti_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMulti_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectGroupsMulti_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMulti_Result>)db.CRMspRpt_cmpSelProjectGroupsMulti(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectGroupsMulti_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectGroupsMulti_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjGroupsMultiIList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectGroupsMultiI_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMultiI_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectGroupsMultiI_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMultiI_Result>)db.CRMspRpt_cmpSelProjectGroupsMultiI(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectGroupsMultiI_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectGroupsMultiI_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjSaveUsersList()
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectSaveUsers_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectSaveUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)db.CRMspRpt_cmpSelProjectSaveUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelProjectSaveUsers_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectSaveUsers_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjEditUsersList()
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectEditUsers_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectEditUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)db.CRMspRpt_cmpSelProjectEditUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelProjectEditUsers_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectEditUsers_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjTreeInfo()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectFieldTitle_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectFieldTitle_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectFieldTitle_Result>((IEnumerable<CRMspRpt_cmpSelProjectFieldTitle_Result>)db.CRMspRpt_cmpSelProjectFieldTitle(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectFieldTitle_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectFieldTitle_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ValueType + "|" + item.ID
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetprjCompanyPresentationList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyPresentation_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanyPresentation_Result>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)db.CRMspRpt_cmpSelCompanyPresentation(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelCompanyPresentation_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelCompanyPresentation_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProjectTitleGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		try
		{
			List<CRMspRpt_cmpSelProjectTitleGroups_Result> list = Enumerable.ToList<CRMspRpt_cmpSelProjectTitleGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjectTitleGroups_Result, string>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)_dbII.CRMspRpt_cmpSelProjectTitleGroups(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result), (Func<CRMspRpt_cmpSelProjectTitleGroups_Result, string>)((CRMspRpt_cmpSelProjectTitleGroups_Result c) => c.ord)));
			if (list != null && Enumerable.Any<CRMspRpt_cmpSelProjectTitleGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)list))
			{
				data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectTitleGroups_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)list, (Func<CRMspRpt_cmpSelProjectTitleGroups_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectTitleGroups_Result item) => new CrmDroupDownItem
				{
					text = item.Val,
					value = item.ID.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcnvsPriorityList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelConversationPriority_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelConversationPriority_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationPriority_Result>((IEnumerable<CRMspRpt_cmpSelConversationPriority_Result>)db.CRMspRpt_cmpSelConversationPriority(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelConversationPriority_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelConversationPriority_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTopicList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelConversationTopics_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelConversationTopics_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationTopics_Result>((IEnumerable<CRMspRpt_cmpSelConversationTopics_Result>)db.CRMspRpt_cmpSelConversationTopics(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelConversationTopics_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelConversationTopics_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcnvsStatusContainList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatusContain_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationStatusContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)db.CRMspRpt_cmpSelConversationStatusContain(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelConversationStatusContain_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelConversationStatusContain_Result item) => new CrmDroupDownItem
		{
			text = (item.Val ?? ""),
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcnvsLastStatusList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatus_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationStatus_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)db.CRMspRpt_cmpSelConversationStatus(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelConversationStatus_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelConversationStatus_Result item) => new CrmDroupDownItem
		{
			text = (item.Val ?? ""),
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcnvsLastStatusResultList(string cnvsStatusIds)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(cnvsStatusIds))
			{
				string none = Labels.None;
				string haveNot = Labels.HaveNot;
				List<CRMspRpt_cmpSelConversationStatusResult_Result> list = Enumerable.ToList<CRMspRpt_cmpSelConversationStatusResult_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)_dbII.CRMspRpt_cmpSelConversationStatusResult(cnvsStatusIds, none, haveNot, lCID, result));
				if (list != null && Enumerable.Any<CRMspRpt_cmpSelConversationStatusResult_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)list))
				{
					data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatusResult_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)list, (Func<CRMspRpt_cmpSelConversationStatusResult_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelConversationStatusResult_Result item) => new CrmDroupDownItem
					{
						text = (item.ResultTitle ?? ""),
						value = item.ConversationStatusResultId.ToString()
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetcnvsStatusResultContainList(string cnvsStatusIds)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(cnvsStatusIds))
			{
				string none = Labels.None;
				string haveNot = Labels.HaveNot;
				List<CRMspRpt_cmpSelConversationStatusResultContain_Result> list = Enumerable.ToList<CRMspRpt_cmpSelConversationStatusResultContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)_dbII.CRMspRpt_cmpSelConversationStatusResultContain(cnvsStatusIds, none, haveNot, lCID, result));
				if (list != null && Enumerable.Any<CRMspRpt_cmpSelConversationStatusResultContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)list))
				{
					data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatusResultContain_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)list, (Func<CRMspRpt_cmpSelConversationStatusResultContain_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelConversationStatusResultContain_Result item) => new CrmDroupDownItem
					{
						text = (item.ResultTitle ?? ""),
						value = item.ConversationStatusResultId.ToString()
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetcnvsReferUsers()
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelConversationReferUsers_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelConversationReferUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)db.CRMspRpt_cmpSelConversationReferUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelConversationReferUsers_Result, int>)((CRMspRpt_cmpSelConversationReferUsers_Result c) => c.ord))), (Func<CRMspRpt_cmpSelConversationReferUsers_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelConversationReferUsers_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetcnvsUsers()
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
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelConversationUsers_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelConversationUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)db.CRMspRpt_cmpSelConversationUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelConversationUsers_Result, int>)((CRMspRpt_cmpSelConversationUsers_Result c) => c.ord))), (Func<CRMspRpt_cmpSelConversationUsers_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelConversationUsers_Result item) => new CrmDroupDownItem
		{
			text = item.Val,
			value = item.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public string GetItemList(string itemName = "")
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
			string none = Labels.None;
			string haveNot = Labels.HaveNot;
			List<SelectListItem> list = new List<SelectListItem>();
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "",
				Selected = false
			});
			switch (itemName)
			{
			case "prjFirstRegisterUser":
			{
				List<CRMspRpt_cmpSelProjectSaveUsers_Result> list4 = Enumerable.ToList<CRMspRpt_cmpSelProjectSaveUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)db.CRMspRpt_cmpSelProjectSaveUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result2, result3));
				if (list4 != null && Enumerable.Any<CRMspRpt_cmpSelProjectSaveUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)list4))
				{
					list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectSaveUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)list4, (Func<CRMspRpt_cmpSelProjectSaveUsers_Result, SelectListItem>)((CRMspRpt_cmpSelProjectSaveUsers_Result item) => new SelectListItem
					{
						Text = item.Val,
						Value = item.ID.ToString(),
						Selected = false
					})));
				}
				break;
			}
			case "prjUser":
			{
				List<CRMspRpt_cmpSelProjectEditUsers_Result> list6 = Enumerable.ToList<CRMspRpt_cmpSelProjectEditUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)db.CRMspRpt_cmpSelProjectEditUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result2, result3));
				if (list6 != null && Enumerable.Any<CRMspRpt_cmpSelProjectEditUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)list6))
				{
					list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectEditUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)list6, (Func<CRMspRpt_cmpSelProjectEditUsers_Result, SelectListItem>)((CRMspRpt_cmpSelProjectEditUsers_Result item) => new SelectListItem
					{
						Text = item.Val,
						Value = item.ID.ToString(),
						Selected = false
					})));
				}
				break;
			}
			case "cnvsUser":
			{
				List<CRMspRpt_cmpSelConversationUsers_Result> list5 = Enumerable.ToList<CRMspRpt_cmpSelConversationUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelConversationUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)db.CRMspRpt_cmpSelConversationUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result2, result3), (Func<CRMspRpt_cmpSelConversationUsers_Result, int>)((CRMspRpt_cmpSelConversationUsers_Result c) => c.ord)));
				if (list5 != null && Enumerable.Any<CRMspRpt_cmpSelConversationUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)list5))
				{
					list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)list5, (Func<CRMspRpt_cmpSelConversationUsers_Result, SelectListItem>)((CRMspRpt_cmpSelConversationUsers_Result item) => new SelectListItem
					{
						Text = item.Val,
						Value = item.ID.ToString(),
						Selected = false
					})));
				}
				break;
			}
			case "cnvsReferUser":
			{
				List<CRMspRpt_cmpSelConversationReferUsers_Result> list3 = Enumerable.ToList<CRMspRpt_cmpSelConversationReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelConversationReferUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)db.CRMspRpt_cmpSelConversationReferUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result2, result3), (Func<CRMspRpt_cmpSelConversationReferUsers_Result, int>)((CRMspRpt_cmpSelConversationReferUsers_Result c) => c.ord)));
				if (list3 != null && Enumerable.Any<CRMspRpt_cmpSelConversationReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)list3))
				{
					list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationReferUsers_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)list3, (Func<CRMspRpt_cmpSelConversationReferUsers_Result, SelectListItem>)((CRMspRpt_cmpSelConversationReferUsers_Result item) => new SelectListItem
					{
						Text = item.Val,
						Value = item.ID.ToString(),
						Selected = false
					})));
				}
				break;
			}
			case "cnvsLastStatusDrp":
			{
				List<CRMspRpt_cmpSelConversationStatus_Result> list7 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatus_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)db.CRMspRpt_cmpSelConversationStatus(none, haveNot, lCID, result2));
				if (list7 != null && Enumerable.Any<CRMspRpt_cmpSelConversationStatus_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)list7))
				{
					list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationStatus_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)list7, (Func<CRMspRpt_cmpSelConversationStatus_Result, SelectListItem>)((CRMspRpt_cmpSelConversationStatus_Result item) => new SelectListItem
					{
						Text = item.Val,
						Value = item.ID.ToString(),
						Selected = false
					})));
				}
				break;
			}
			case "cnvsContainStatusDrp":
			{
				List<CRMspRpt_cmpSelConversationStatusContain_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatusContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)db.CRMspRpt_cmpSelConversationStatusContain(none, haveNot, lCID, result2));
				if (list2 != null && Enumerable.Any<CRMspRpt_cmpSelConversationStatusContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)list2))
				{
					list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationStatusContain_Result, SelectListItem>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)list2, (Func<CRMspRpt_cmpSelConversationStatusContain_Result, SelectListItem>)((CRMspRpt_cmpSelConversationStatusContain_Result item) => new SelectListItem
					{
						Text = item.Val,
						Value = item.ID.ToString(),
						Selected = false
					})));
				}
				break;
			}
			}
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<SelectListItem, nComboBoxListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, nComboBoxListItem>)((SelectListItem item) => new nComboBoxListItem
				{
					Text = item.Text,
					Value = item.Value,
					Selected = false
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public ActionResult _PartialCompanyFilterData(CrmCompanyReportViewModel cmpReport)
	{
		//IL_0973: Unknown result type (might be due to invalid IL or missing references)
		//IL_1967: Unknown result type (might be due to invalid IL or missing references)
		if (cmpReport == null)
		{
			base.ViewBag.ParameterReport = "";
			return PartialView();
		}
		string text = "";
		if (cmpReport.cmpTitleIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpTitleIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpTitpeInFilter + " : " + cmpReport.cmpTitleStr;
		}
		if (cmpReport.cmpPresentationIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpPresentationIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpPresentationInFilter + " : " + cmpReport.cmpPresentationStr;
		}
		if (cmpReport.cmpTypeIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpTypeIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpTypeInFilter + " : " + cmpReport.cmpTypeStr;
		}
		if (cmpReport.cmpCountryIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpCountryIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpCountryInFilter + " : " + cmpReport.cmpCountryStr;
		}
		if (cmpReport.cmpProvinceIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpProvinceIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpProvinceInFilter + " : " + cmpReport.cmpProvinceStr;
		}
		if (cmpReport.cmpCityIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpCityIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpCityInFilter + " : " + cmpReport.cmpCityStr;
		}
		if (!string.IsNullOrEmpty(cmpReport.cmpActivityType))
		{
			text = text + " " + Labels.CmpReportCmpActivityInFilter + " : " + cmpReport.cmpActivityType;
		}
		if (!string.IsNullOrEmpty(cmpReport.cmpName))
		{
			text = text + " " + Labels.CmpReportCmpNameInFilter + " : " + cmpReport.cmpName;
		}
		if (cmpReport.cmpOtherFields != "0" && !string.IsNullOrEmpty(cmpReport.cmpOtherFields))
		{
			text = text + " " + Labels.CmpReportCmpOtherFieldInFilter + " : " + cmpReport.cmpOtherFieldsStr;
		}
		if (cmpReport.cmpOtherFieldValueLikely == null)
		{
			cmpReport.cmpOtherFieldValueLikely = "";
		}
		if (cmpReport.cmpSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.cmpSimilarValue) && cmpReport.cmpOtherFieldValueLikely == "1")
		{
			text = text + " " + Labels.CmpReportCmpSimilarIInFilter + " : " + cmpReport.cmpSimilarValue;
		}
		if (cmpReport.cmpSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.cmpSimilarValue) && cmpReport.cmpOtherFieldValueLikely == "0")
		{
			text = text + " " + Labels.CmpReportCmpSimilarIIInFilter + " : " + cmpReport.cmpSimilarValue;
		}
		if (cmpReport.cmpSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.cmpSimilarValue) && cmpReport.cmpOtherFieldValueLikely == "")
		{
			text = text + " " + Labels.CmpReportCmpSimilarIIInFilter + " : " + cmpReport.cmpSimilarValue;
		}
		if (cmpReport.cmpUserId.HasValue)
		{
			cmpReport.cmpSimilarValue = cmpReport.cmpUserId.ToString();
			Users users = _dbTbl.Users.Find(cmpReport.cmpUserId);
			text = text + " " + Labels.CmpReportCmpSimilarIIInFilter + " : " + ((users != null) ? (users.FName + " " + users.LName) : "");
		}
		if (cmpReport.cmpFirstRegisterUserId.HasValue)
		{
			cmpReport.cmpSimilarValue = cmpReport.cmpFirstRegisterUserId.ToString();
			Users users2 = _dbTbl.Users.Find(cmpReport.cmpFirstRegisterUserId);
			text = text + " " + Labels.CmpReportCmpSimilarIIInFilter + " : " + ((users2 != null) ? (users2.FName + " " + users2.LName) : "");
		}
		if (cmpReport.cmpGroupIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpGroupIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpGroupIInFilter + " : " + cmpReport.cmpGroupStr;
		}
		if (cmpReport.cmpSubGroupIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpSubGroupIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpSubgroupInFilter + " : " + cmpReport.cmpSubGroupStr;
		}
		if (cmpReport.cmpGroupIdIITitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpGroupIdIITitle))
		{
			text = text + " " + Labels.CmpReportCmpGroupIIInFilter + " : " + cmpReport.cmpGroupIIStr;
		}
		if (cmpReport.cmpGroupIdIIITitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpGroupIdIIITitle))
		{
			text = text + " " + Labels.CmpReportCmpGroupIIIInFilter + " : " + cmpReport.cmpGroupIIIStr;
		}
		if (cmpReport.cmpGroupIdIVTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpGroupIdIVTitle))
		{
			text = text + " " + Labels.CmpReportCmpGroupIVInFilter + " : " + cmpReport.cmpGroupIVStr;
		}
		if (cmpReport.cmpGroupIdMultiTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpGroupIdMultiTitle))
		{
			text = text + " " + Labels.CmpReportCmpGroupMultiInFilter + " : " + cmpReport.cmpGroupIIStr;
		}
		if (cmpReport.cmpReferUserIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cmpReferUserIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpReferUserInFilter + " : " + cmpReport.cmpReferUserStr;
		}
		if (cmpReport.cmpTypeDateForSearch == "ImportDate")
		{
			text = text + " " + Labels.CmpReportCmpImportDateInFilter + " : ";
		}
		else if (cmpReport.cmpTypeDateForSearch == "RegisterDatePersian")
		{
			text = text + " " + Labels.CmpReportCmpRegisterDateInFilter + " : ";
		}
		else if (cmpReport.cmpTypeDateForSearch == "cmpEffectiveDatePersian")
		{
			text = text + " " + Labels.CmpReportCmpEffectiveDateInFilter + " : ";
		}
		else if (cmpReport.cmpTypeDateForSearch == "cmpCRMShopActiveDate")
		{
			text = text + " " + Labels.CmpReportCmpCRMShopActiveDateInFilter + " : ";
		}
		else
		{
			cmpReport.cmpTypeDateForSearch = "0";
			cmpReport.cmpFromDate = "0";
			cmpReport.cmpToDate = "0";
		}
		if (cmpReport.cmpFromDate != "0")
		{
			text = text + " " + Labels.CmpReportCmpFromDateInFilter + " : " + DateTimeClass.ConvertDateWOSlashToSlash(cmpReport.cmpFromDate) + ",";
		}
		if (cmpReport.cmpToDate != "0")
		{
			text = text + " " + Labels.CmpReportCmpToDateInFilter + " : " + DateTimeClass.ConvertDateWOSlashToSlash(cmpReport.cmpToDate) + ",";
		}
		if (cmpReport.cmpCampaignIds != "0" && !string.IsNullOrWhiteSpace(cmpReport.cmpCampaignIds) && !string.IsNullOrWhiteSpace(cmpReport.cmpCampaignIdsList))
		{
			string text2 = "";
			List<CommonTreeViewItemViewModel> list = new JavaScriptSerializer().Deserialize<List<CommonTreeViewItemViewModel>>(cmpReport.cmpCampaignIdsList);
			if (list != null && Enumerable.Any<CommonTreeViewItemViewModel>((IEnumerable<CommonTreeViewItemViewModel>)list))
			{
				foreach (CommonTreeViewItemViewModel item in list)
				{
					text2 = text2 + item.Text + " ";
				}
				if (!string.IsNullOrWhiteSpace(text2) && text2.EndsWith(","))
				{
					text2 = text2.TrimEnd(new char[1] { ',' });
				}
			}
			text = text + " " + Labels.CmpReportCmpCampaignInFilter + " : " + text2;
		}
		if (cmpReport.cmpKind != "-1" && !string.IsNullOrWhiteSpace(cmpReport.cmpKind))
		{
			text = text + " " + Labels.CmpReportCmpKindInFilter + " : " + cmpReport.cmpKindStr;
		}
		if (cmpReport.cmpSuppUserIdTitle != "0" && !string.IsNullOrWhiteSpace(cmpReport.cmpSuppUserIdTitle))
		{
			text = text + " " + Labels.CmpReportCmpSuppUserInFilter + " : " + cmpReport.cmpSuppUserStr;
		}
		if (!string.IsNullOrWhiteSpace(cmpReport.cmpFromScore) && !string.IsNullOrWhiteSpace(cmpReport.cmpToScore))
		{
			text = text + " " + Labels.CmpReportCmpScoreInFilter + " : (" + Labels.rptCompanyReportFromScore + " : " + cmpReport.cmpFromScore + " " + Labels.rptCompanyReportToScore + " : " + cmpReport.cmpToScore + ") ";
		}
		if (cmpReport.prsTitleIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsTitleIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsTitleInFilter + " : " + cmpReport.prsTitleStr;
		}
		if (cmpReport.prsJobIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsJobIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsJobInFilter + " : " + cmpReport.prsJobStr;
		}
		if (cmpReport.prsDepartmentIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsDepartmentIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsDepartmentInFilter + " : " + cmpReport.prsDepartmentStr;
		}
		if (cmpReport.prsTypeIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsTypeIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsTypeInFilter + " : " + cmpReport.prsTypeStr;
		}
		if (cmpReport.prsGroupIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsGroupIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsGroupInFilter + " : " + cmpReport.prsGroupStr;
		}
		if (cmpReport.prsSexIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsSexIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsSexInFilter + " : " + cmpReport.prsSexStr;
		}
		if (cmpReport.prsCountryIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsCountryIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsCountryInFilter + " : " + cmpReport.prsCountryStr;
		}
		if (cmpReport.prsProvinceIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsProvinceIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsProvinceInFilter + " : " + cmpReport.prsProvinceStr;
		}
		if (cmpReport.prsCityIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prsCityIdTitle))
		{
			text = text + " " + Labels.CmpReportPrsCityInFilter + " : " + cmpReport.prsCityStr;
		}
		if (cmpReport.prsEducationField != "0" && !string.IsNullOrEmpty(cmpReport.prsEducationField))
		{
			text = text + " " + Labels.CmpReportPrsEducationInFilter + " : " + cmpReport.prsEducationStr;
		}
		if (cmpReport.prsOtherFields != "0" && !string.IsNullOrEmpty(cmpReport.prsOtherFields))
		{
			text = text + " " + Labels.CmpReportPrsOtherFieldInFilter + " : " + cmpReport.prsOtherFieldsStr;
		}
		if (cmpReport.prsOtherFieldValueLikely == null)
		{
			cmpReport.prsOtherFieldValueLikely = "";
		}
		if (cmpReport.prsSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.prsSimilarValue) && cmpReport.prsOtherFieldValueLikely == "1")
		{
			text = text + " " + Labels.CmpReportPrssimilarIInFilter + " : " + cmpReport.prsSimilarValue;
		}
		if (cmpReport.prsSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.prsSimilarValue) && cmpReport.prsOtherFieldValueLikely == "0")
		{
			text = text + " " + Labels.CmpReportPrssimilarIIInFilter + " : " + cmpReport.prsSimilarValue;
		}
		if (cmpReport.prsSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.prsSimilarValue) && cmpReport.prsOtherFieldValueLikely == "")
		{
			text = text + " " + Labels.CmpReportPrssimilarIIInFilter + " : " + cmpReport.prsSimilarValue;
		}
		if (cmpReport.prsUserId.HasValue)
		{
			cmpReport.prsSimilarValue = cmpReport.prsUserId.ToString();
			Users users3 = _dbTbl.Users.Find(cmpReport.prsUserId);
			text = text + " " + Labels.CmpReportPrssimilarIIInFilter + " : " + ((users3 != null) ? (users3.FName + " " + users3.LName) : "");
		}
		if (cmpReport.prsFirstRegisterUserId.HasValue)
		{
			cmpReport.prsSimilarValue = cmpReport.prsFirstRegisterUserId.ToString();
			Users users4 = _dbTbl.Users.Find(cmpReport.prsFirstRegisterUserId);
			text = text + " " + Labels.CmpReportPrssimilarIIInFilter + " : " + ((users4 != null) ? (users4.FName + " " + users4.LName) : "");
		}
		if (cmpReport.prsTypeDateForSearch == "ImportDate")
		{
			text = text + " " + Labels.CmpReportPrsImportDateInFilter + " : ";
		}
		else if (cmpReport.prsTypeDateForSearch == "RegisterDatePersian")
		{
			text = text + " " + Labels.CmpReportPrsRegisterDateInFilter + " : ";
		}
		else
		{
			cmpReport.prsTypeDateForSearch = "0";
			cmpReport.prsFromDate = "0";
			cmpReport.prsToDate = "0";
		}
		if (cmpReport.prsFromDate != "0")
		{
			text = text + " " + Labels.CmpReportPrsFromDateInFilter + " : " + DateTimeClass.ConvertDateWOSlashToSlash(cmpReport.prsFromDate) + ",";
		}
		if (cmpReport.prsToDate != "0")
		{
			text = text + " " + Labels.CmpReportPrsToDateInFilter + " : " + DateTimeClass.ConvertDateWOSlashToSlash(cmpReport.prsToDate) + ",";
		}
		if (cmpReport.prjTitle != "0" && !string.IsNullOrEmpty(cmpReport.prjTitle))
		{
			text = text + " " + Labels.CmpReportPrjTitleInFilter + " : " + cmpReport.prjTitle;
		}
		if (cmpReport.prjGradeIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prjGradeIdTitle))
		{
			text = text + " " + Labels.CmpReportPrjGroupInFilter + " : " + cmpReport.prjGroupStr;
		}
		if (cmpReport.prjPriorityIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prjPriorityIdTitle))
		{
			text = text + " " + Labels.CmpReportPrjPriorityInFilter + " : " + cmpReport.prjPriorityStr;
		}
		if (cmpReport.prjGradeIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prjGradeIdTitle))
		{
			text = text + " " + Labels.CmpReportPrjGradeInFilter + " : " + cmpReport.prjGradeStr;
		}
		if (cmpReport.prjIsFinished != "0" && !string.IsNullOrEmpty(cmpReport.prjIsFinished))
		{
			text = text + " " + Labels.CmpReportPrjIsFinishedInFilter + " : " + Labels.rptCompanyReportArchive;
		}
		if (cmpReport.prjIsFinished == "0" && !string.IsNullOrEmpty(cmpReport.prjIsFinished))
		{
			text = text + " " + Labels.CmpReportPrjIsFinishedInFilter + " : " + Labels.rptCompanyReportNotArchive;
		}
		if (cmpReport.prjcnvsStatusGroupIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prjcnvsStatusGroupIdTitle))
		{
			text = text + " " + Labels.CmpReportPrjCnvsStatuseGroupInFilter + " : " + cmpReport.prjcnvsStatusGroupStr;
		}
		if (cmpReport.prjFirstRegisterUserIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prjFirstRegisterUserIdTitle))
		{
			text = text + " " + Labels.CmpReportPrjFirstRegisterUserIdInFilter + " : " + cmpReport.prjFirstRegisterUserStr;
		}
		if (cmpReport.prjUserIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prjUserIdTitle))
		{
			text = text + " " + Labels.CmpReportPrjUserIdInFilter + " : " + cmpReport.prjUserStr;
		}
		if (cmpReport.prjGroupsMulti != "0" && !string.IsNullOrEmpty(cmpReport.prjGroupsMulti))
		{
			text = text + " " + Labels.CmpReportPrjGroupsMultiInFilter + " : " + cmpReport.prjGroupsMultiStr;
		}
		if (cmpReport.prjGroupsMultiI != "0" && !string.IsNullOrEmpty(cmpReport.prjGroupsMultiI))
		{
			text = text + " " + Labels.CmpReportPrjGroupsMultiIInFilter + " : " + cmpReport.prjGroupsMultiIStr;
		}
		if (cmpReport.prjTreeInfo != "0" && !string.IsNullOrEmpty(cmpReport.prjTreeInfo))
		{
			text = text + " " + Labels.CmpReportPrjTreeInfoInFilter + " : " + cmpReport.prjTreeInfoStr;
		}
		switch ((!string.IsNullOrEmpty(cmpReport.prjTreeInfo)) ? cmpReport.prjTreeInfo.Split(new char[1] { '|' })[0] : "")
		{
		case "0":
			cmpReport.drpPrjTreeInfo = cmpReport.txtPrjTreeInfo;
			if (cmpReport.drpPrjTreeInfo != "0" && !string.IsNullOrEmpty(cmpReport.drpPrjTreeInfo))
			{
				text = text + " " + Labels.CmpReportPrjTreeInfoValueInFilter + " : " + cmpReport.drpPrjTreeInfo;
			}
			if (cmpReport.projectInformationBetweenChecked == "1")
			{
				text = text + " " + Labels.CmpReportPrjTreeInfoValueInFilter + " : ";
				if (cmpReport.projectInformationIdFrom != "")
				{
					text = text + Labels.CmpReportPrjTreeInfoFromInFilter + cmpReport.projectInformationIdFrom;
				}
				if (cmpReport.projectInformationIdTo != "")
				{
					text = text + Labels.CmpReportPrjTreeInfoToInFilter + cmpReport.projectInformationIdTo;
				}
			}
			break;
		case "1":
		case "2":
		case "3":
			cmpReport.drpPrjTreeInfo = cmpReport.drpPrjTreeInfo;
			if (cmpReport.drpPrjTreeInfo != "0" && !string.IsNullOrEmpty(cmpReport.drpPrjTreeInfo))
			{
				text = text + " " + Labels.CmpReportPrjTreeInfoValueInFilter + " : " + cmpReport.drpPrjTreeInfo;
			}
			break;
		default:
			cmpReport.drpPrjTreeInfo = "0";
			break;
		}
		if (cmpReport.prjTypeDateForSearch == "prjFirstRegisterDate")
		{
			text = text + " " + Labels.CmpReportPrjFirstRegisterDateInFilter + " : ";
		}
		else if (cmpReport.prjTypeDateForSearch == "RegisterDatePersian")
		{
			text = text + " " + Labels.CmpReportPrjRegisterDateInFilter + " : ";
		}
		else if (cmpReport.prjTypeDateForSearch == "prjRemindDate")
		{
			text = text + " " + Labels.CmpReportPrjRemindDateInFilter + " : ";
		}
		else if (cmpReport.prjTypeDateForSearch == "PrjInfoRegisterDatePersian")
		{
			text = text + " " + Labels.CmpReportPrjInfoRegisterDatePersianInFilter + " : ";
		}
		else
		{
			cmpReport.prjTypeDateForSearch = "0";
			cmpReport.prjFromDate = "0";
			cmpReport.prjToDate = "0";
		}
		if (cmpReport.prjFromDate != "0")
		{
			text = text + " " + Labels.CmpReportPrjFromDateInFilter + " : " + DateTimeClass.ConvertDateWOSlashToSlash(cmpReport.prjFromDate) + ",";
		}
		if (cmpReport.prjToDate != "0")
		{
			text = text + " " + Labels.CmpReportPrjToDateInFilter + " : " + DateTimeClass.ConvertDateWOSlashToSlash(cmpReport.prjToDate) + ",";
		}
		if (cmpReport.prjcmpCampaignIds != "0" && !string.IsNullOrWhiteSpace(cmpReport.prjcmpCampaignIds) && !string.IsNullOrWhiteSpace(cmpReport.prjcmpCampaignIdsList))
		{
			string text3 = "";
			List<CommonTreeViewItemViewModel> list2 = new JavaScriptSerializer().Deserialize<List<CommonTreeViewItemViewModel>>(cmpReport.prjcmpCampaignIdsList);
			if (list2 != null && Enumerable.Any<CommonTreeViewItemViewModel>((IEnumerable<CommonTreeViewItemViewModel>)list2))
			{
				foreach (CommonTreeViewItemViewModel item2 in list2)
				{
					text3 = text3 + item2.Text + " ";
				}
				if (!string.IsNullOrWhiteSpace(text3) && text3.EndsWith(","))
				{
					text3 = text3.TrimEnd(new char[1] { ',' });
				}
			}
			text = text + " " + Labels.CmpReportPrjCmpCampaignInFilter + " : " + text3;
		}
		if (cmpReport.prjcmpPresentationIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.prjcmpPresentationIdTitle))
		{
			text = text + " " + Labels.CmpReportPrjCmpPresentationInFilter + " : " + cmpReport.prjcmpPresentationStr;
		}
		if (cmpReport.prjTitleGroup != "0" && !string.IsNullOrWhiteSpace(cmpReport.prjTitleGroup))
		{
			text = text + " " + Labels.CmpReportPrjTitleGroupInFilter + " : " + cmpReport.prjTitleGroup;
		}
		if (cmpReport.cnvsTopicIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cnvsTopicIdTitle))
		{
			text = text + " " + Labels.CmpReportCnvsTopicInFilter + " : " + cmpReport.cnvsTopicStr;
		}
		if (cmpReport.cnvsUserIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cnvsUserIdTitle))
		{
			text = text + " " + Labels.CmpReportCnvsUserIdInFilter + " : " + cmpReport.cnvsUserStr;
		}
		if (cmpReport.cnvsReferUserIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cnvsReferUserIdTitle))
		{
			text = text + " " + Labels.CmpReportCnvsReferUserIdInFilter + " : " + cmpReport.cnvsReferUserStr;
		}
		if (cmpReport.cnvsLastStatus != "0" && !string.IsNullOrEmpty(cmpReport.cnvsLastStatus))
		{
			text = text + " " + Labels.CmpReportCnvsLastStatusInFilter + " : " + cmpReport.cnvsLastStatusStr;
		}
		if (cmpReport.cnvsLastStatusResult != "0" && !string.IsNullOrWhiteSpace(cmpReport.cnvsLastStatusResult))
		{
			text = text + " " + Labels.CmpReportCnvsLastStatusResultInFilter + " : " + cmpReport.cnvsLastStatusResultStr;
		}
		if (cmpReport.cnvsContainStatus != "0" && !string.IsNullOrEmpty(cmpReport.cnvsContainStatus))
		{
			text = text + " " + Labels.CmpReportCnvsContainStatusInFilter + " : " + cmpReport.cnvsContainStatusStr;
		}
		if (cmpReport.cnvsContainStatusResult != "0" && !string.IsNullOrWhiteSpace(cmpReport.cnvsContainStatusResult))
		{
			text = text + " " + Labels.CmpReportCnvsContainStatusResultInFilter + " : " + cmpReport.cnvsContainStatusResultStr;
		}
		if (cmpReport.cnvsMinPercentage != 0 && cmpReport.cnvsMinPercentage.HasValue)
		{
			text = text + " " + Labels.CmpReportCnvsMinProgressInFilter + " : " + cmpReport.cnvsMinPercentage;
		}
		if (cmpReport.cnvsMaxPercentage != 0 && cmpReport.cnvsMaxPercentage.HasValue)
		{
			text = text + " " + Labels.CmpReportCnvsMaxProgressInFilter + " : " + cmpReport.cnvsMaxPercentage;
		}
		if (cmpReport.cnvsPriorityIdTitle != "0" && !string.IsNullOrEmpty(cmpReport.cnvsPriorityIdTitle))
		{
			text = text + " " + Labels.CmpReportCnvsPriorityInFilter + " : " + cmpReport.cnvsPriorityStr;
		}
		if (cmpReport.cnvsOtherFields != "0" && !string.IsNullOrEmpty(cmpReport.cnvsOtherFields))
		{
			text = text + " " + Labels.CmpReportCnvsOtherFieldsInFilter + " : " + cmpReport.cnvsOtherFieldsStr;
		}
		if (cmpReport.cnvsOtherFieldValueLikely == null)
		{
			cmpReport.cnvsOtherFieldValueLikely = "";
		}
		if (cmpReport.cnvsSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.cnvsSimilarValue) && cmpReport.cnvsOtherFieldValueLikely == "1")
		{
			text = text + " " + Labels.CmpReportCnvsSimilarIInFilter + " : " + cmpReport.cnvsSimilarValue;
		}
		if (cmpReport.cnvsSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.cnvsSimilarValue) && cmpReport.cnvsOtherFieldValueLikely == "0")
		{
			text = text + " " + Labels.CmpReportCnvsSimilarIIInFilter + " : " + cmpReport.cnvsSimilarValue;
		}
		if (cmpReport.cnvsSimilarValue != "0" && !string.IsNullOrEmpty(cmpReport.cnvsSimilarValue) && cmpReport.cnvsOtherFieldValueLikely == "")
		{
			text = text + " " + Labels.CmpReportCnvsSimilarIIInFilter + " : " + cmpReport.cnvsSimilarValue;
		}
		if (cmpReport.cnvsUserId2.HasValue)
		{
			cmpReport.cnvsSimilarValue = cmpReport.cnvsUserId2.ToString();
			Users users5 = _dbTbl.Users.Find(cmpReport.cnvsUserId2);
			text = text + " " + Labels.CmpReportCnvsSimilarIIInFilter + " : " + ((users5 != null) ? (users5.FName + " " + users5.LName) : "");
		}
		if (cmpReport.cnvsFirstRegisterUserId.HasValue)
		{
			cmpReport.cnvsSimilarValue = cmpReport.cnvsFirstRegisterUserId.ToString();
			Users users6 = _dbTbl.Users.Find(cmpReport.cnvsFirstRegisterUserId);
			text = text + " " + Labels.CmpReportCnvsSimilarIIInFilter + " : " + ((users6 != null) ? (users6.FName + " " + users6.LName) : "");
		}
		if (cmpReport.cnvsTypeDateForSearch == "cnvsFirstRegisterDate")
		{
			text = text + " " + Labels.CmpReportCnvsFirstRegisterDateInFilter + " : ";
		}
		else if (cmpReport.cnvsTypeDateForSearch == "RegisterDatePersian")
		{
			text = text + " " + Labels.CmpReportCnvsRegisterDateInFilter + " : ";
		}
		else
		{
			cmpReport.cnvsTypeDateForSearch = "0";
			cmpReport.cnvsFromDate = "0";
			cmpReport.cnvsToDate = "0";
		}
		if (cmpReport.cnvsFromDate != "0")
		{
			text = text + " " + Labels.CmpReportCnvsFromDateInFilter + " : " + DateTimeClass.ConvertDateWOSlashToSlash(cmpReport.cnvsFromDate) + ",";
		}
		if (cmpReport.cnvsToDate != "0")
		{
			text = text + " " + Labels.CmpReportCnvsToDateInFilter + " : " + DateTimeClass.ConvertDateWOSlashToSlash(cmpReport.cnvsToDate) + ",";
		}
		if (!string.IsNullOrEmpty(cmpReport.prjPostFix))
		{
			text = text + " " + Labels.CmpReportPrjPostFixInFilter + " : " + cmpReport.prjPostFix;
		}
		if (text == "")
		{
			text = Labels.CmpReportAllInfoInFilter;
		}
		base.ViewBag.termText = text;
		string haveCompare = Labels.HaveCompare;
		string haveNotCompare = Labels.HaveNotCompare;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			string text4 = ((!string.IsNullOrEmpty(cmpReport.cmpTitleIdTitle)) ? ("@cmpTitleId=" + cmpReport.cmpTitleIdTitle) : "@cmpTitleId=0");
			string text5 = ((!string.IsNullOrEmpty(cmpReport.cmpPresentationIdTitle)) ? ("@cmpPresentationId=" + cmpReport.cmpPresentationIdTitle) : "@cmpPresentationId=0");
			string text6 = ((!string.IsNullOrEmpty(cmpReport.cmpTypeIdTitle)) ? ("@cmpTypeId=" + cmpReport.cmpTypeIdTitle) : "@cmpTypeId=0");
			string text7 = ((!string.IsNullOrEmpty(cmpReport.cmpCountryIdTitle)) ? ("@cmpCountryId=" + cmpReport.cmpCountryIdTitle) : "@cmpCountryId=0");
			string text8 = ((!string.IsNullOrEmpty(cmpReport.cmpProvinceIdTitle)) ? ("@cmpProvinceId=" + cmpReport.cmpProvinceIdTitle) : "@cmpProvinceId=0");
			string text9 = ((!string.IsNullOrEmpty(cmpReport.cmpCityIdTitle)) ? ("@cmpCityId=" + cmpReport.cmpCityIdTitle) : "@cmpCityId=0");
			string text10 = ((!string.IsNullOrEmpty(cmpReport.cmpActivityType)) ? cmpReport.cmpActivityType : "");
			text10 = ((text10 == haveNotCompare) ? "@cmpActivityType=-1" : ((!(text10 == haveCompare)) ? ("@cmpActivityType=" + text10) : "@cmpActivityType=-2"));
			string text11 = ((!string.IsNullOrEmpty(cmpReport.cmpName)) ? ("@cmpCompanyName=" + cmpReport.cmpName) : "@cmpCompanyName=");
			if (cmpReport.cmpOtherFields == "cmpPassword")
			{
				cmpReport.cmpSimilarValue = ((!string.IsNullOrEmpty(cmpReport.cmpSimilarValue)) ? XorCipher.EncryptByPublicKey(cmpReport.cmpSimilarValue) : string.Empty);
			}
			string text12 = ((!string.IsNullOrEmpty(cmpReport.cmpOtherFields)) ? ("@cmpOtherField=" + cmpReport.cmpOtherFields) : "@cmpOtherField=0");
			string text13 = ((!string.IsNullOrEmpty(cmpReport.cmpSimilarValue)) ? cmpReport.cmpSimilarValue : "0");
			text13 = ((text13 == haveNotCompare) ? "@cmpOtherFieldValue=-1" : ((!(text13 == haveCompare)) ? ("@cmpOtherFieldValue=" + text13) : "@cmpOtherFieldValue=-2"));
			string text14 = ((!string.IsNullOrEmpty(cmpReport.cmpOtherFieldValueLikely)) ? ("@cmpOtherFieldValueLikely=" + cmpReport.cmpOtherFieldValueLikely) : "@cmpOtherFieldValueLikely=0");
			string text15 = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdTitle)) ? ("@cmpGroupId=" + cmpReport.cmpGroupIdTitle) : "@cmpGroupId=0");
			string text16 = ((!string.IsNullOrEmpty(cmpReport.cmpSubGroupIdTitle)) ? ("@cmpSubGroupId=" + cmpReport.cmpSubGroupIdTitle) : "@cmpSubGroupId=0");
			string text17 = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdIITitle)) ? ("@cmpGroupIdII=" + cmpReport.cmpGroupIdIITitle) : "@cmpGroupIdII=0");
			string text18 = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdIIITitle)) ? ("@cmpGroupIdIII=" + cmpReport.cmpGroupIdIIITitle) : "@cmpGroupIdIII=0");
			string text19 = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdIVTitle)) ? ("@cmpGroupIdIV=" + cmpReport.cmpGroupIdIVTitle) : "@cmpGroupIdIV=0");
			string text20 = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdMultiTitle)) ? ("@CompanyGroupsMultiID=" + cmpReport.cmpGroupIdMultiTitle) : "@CompanyGroupsMultiID=0");
			string text21 = ((!string.IsNullOrEmpty(cmpReport.cmpTypeDateForSearch)) ? cmpReport.cmpTypeDateForSearch : "0");
			string text22 = ((!string.IsNullOrEmpty(cmpReport.cmpFromDate)) ? cmpReport.cmpFromDate : "0");
			string text23 = ((!string.IsNullOrEmpty(cmpReport.cmpToDate)) ? cmpReport.cmpToDate : "0");
			if (text21 != "ImportDate" && text21 != "RegisterDatePersian" && text21 != "cmpEffectiveDatePersian" && text21 != "cmpCRMShopActiveDate")
			{
				text21 = "@cmpDateType=0";
				text22 = "0";
				text23 = "0";
			}
			else
			{
				text21 = "@cmpDateType=" + text21;
			}
			string text24 = ((!string.IsNullOrEmpty(cmpReport.cmpReferUserIdTitle)) ? ("@cmpReferUserID=" + cmpReport.cmpReferUserIdTitle) : "@cmpReferUserID=0");
			string text25 = ((!string.IsNullOrEmpty(cmpReport.cmpCampaignIds)) ? ("@cmpCampaignIds=" + cmpReport.cmpCampaignIds) : "@cmpCampaignIds=0");
			string text26 = ((!string.IsNullOrWhiteSpace(cmpReport.cmpKind)) ? ("@cmpKind=" + cmpReport.cmpKind) : "@cmpKind=-1");
			string text27 = ((!string.IsNullOrWhiteSpace(cmpReport.cmpSuppUserIdTitle)) ? ("@cmpSuppUserId=" + cmpReport.cmpSuppUserIdTitle) : "@cmpSuppUserId=0");
			string text28 = ((!string.IsNullOrWhiteSpace(cmpReport.cmpFromScore)) ? ("@cmpFromScore=" + cmpReport.cmpFromScore) : "@cmpFromScore=");
			string text29 = ((!string.IsNullOrWhiteSpace(cmpReport.cmpToScore)) ? ("@cmpToScore=" + cmpReport.cmpToScore) : "@cmpToScore=");
			string text30 = ((!string.IsNullOrEmpty(cmpReport.prsTitleIdTitle)) ? ("@prsTitleId=" + cmpReport.prsTitleIdTitle) : "@prsTitleId=0");
			string text31 = ((!string.IsNullOrEmpty(cmpReport.prsJobIdTitle)) ? ("@prsJobId=" + cmpReport.prsJobIdTitle) : "@prsJobId=0");
			string text32 = ((!string.IsNullOrEmpty(cmpReport.prsDepartmentIdTitle)) ? ("@prsDepartmentId=" + cmpReport.prsDepartmentIdTitle) : "@prsDepartmentId=0");
			string text33 = ((!string.IsNullOrEmpty(cmpReport.prsTypeIdTitle)) ? ("@prsTypeId=" + cmpReport.prsTypeIdTitle) : "@prsTypeId=0");
			string text34 = ((!string.IsNullOrEmpty(cmpReport.prsGroupIdTitle)) ? ("@prsGroupId=" + cmpReport.prsGroupIdTitle) : "@prsGroupId=0");
			string text35 = ((!string.IsNullOrEmpty(cmpReport.prsSexIdTitle)) ? ("@prsSexId=" + cmpReport.prsSexIdTitle) : "@prsSexId=0");
			string text36 = ((!string.IsNullOrEmpty(cmpReport.prsEducationField)) ? ("@prsEducationId=" + cmpReport.prsEducationField) : "@prsEducationId=0");
			string text37 = ((!string.IsNullOrEmpty(cmpReport.prsCountryIdTitle)) ? ("@prsCountryId=" + cmpReport.prsCountryIdTitle) : "@prsCountryId=0");
			string text38 = ((!string.IsNullOrEmpty(cmpReport.prsProvinceIdTitle)) ? ("@prsProvinceId=" + cmpReport.prsProvinceIdTitle) : "@prsProvinceId=0");
			string text39 = ((!string.IsNullOrEmpty(cmpReport.prsCityIdTitle)) ? ("@prsCityId=" + cmpReport.prsCityIdTitle) : "@prsCityId=0");
			string text40 = ((!string.IsNullOrEmpty(cmpReport.prsOtherFields)) ? ("@prsOtherField=" + cmpReport.prsOtherFields) : "@prsOtherField=0");
			string text41 = ((!string.IsNullOrEmpty(cmpReport.prsSimilarValue)) ? cmpReport.prsSimilarValue : "0");
			text41 = ((text41 == haveNotCompare) ? "@prsOtherFieldValue=-1" : ((!(text41 == haveCompare)) ? ("@prsOtherFieldValue=" + text41) : "@prsOtherFieldValue=-2"));
			string text42 = ((!string.IsNullOrEmpty(cmpReport.prsOtherFieldValueLikely)) ? ("@prsOtherFieldValueLikely=" + cmpReport.prsOtherFieldValueLikely) : "@prsOtherFieldValueLikely=0");
			string text43 = ((!string.IsNullOrEmpty(cmpReport.prsTypeDateForSearch)) ? cmpReport.prsTypeDateForSearch : "0");
			string text44 = ((!string.IsNullOrEmpty(cmpReport.prsFromDate)) ? cmpReport.prsFromDate : "0");
			string text45 = ((!string.IsNullOrEmpty(cmpReport.prsToDate)) ? cmpReport.prsToDate : "0");
			if (text43 != "ImportDate" && text43 != "RegisterDatePersian")
			{
				text43 = "@prsDateType=0";
				text44 = "0";
				text45 = "0";
			}
			else
			{
				text43 = "@prsDateType=" + text43;
			}
			string text46 = ((!string.IsNullOrEmpty(cmpReport.prjTitle)) ? cmpReport.prjTitle : "0");
			string[] array = text46.Split(new char[1] { ',' });
			string text47 = "";
			string[] array2 = array;
			foreach (string text48 in array2)
			{
				if (text47 != "")
				{
					text47 += "','";
				}
				text47 += text48;
			}
			text46 = "@ProjectID=" + text47;
			string text49 = ((!string.IsNullOrEmpty(cmpReport.prjGroupIdTitle)) ? ("@prjProjectGroupId=" + cmpReport.prjGroupIdTitle) : "@prjProjectGroupId=0");
			string text50 = ((!string.IsNullOrEmpty(cmpReport.prjPriorityIdTitle)) ? ("@prjPriorityId=" + cmpReport.prjPriorityIdTitle) : "@prjPriorityId=0");
			string text51 = ((!string.IsNullOrEmpty(cmpReport.prjGradeIdTitle)) ? ("@prjGradeId=" + cmpReport.prjGradeIdTitle) : "@prjGradeId=0");
			string text52 = "0";
			text52 = (string.IsNullOrEmpty(cmpReport.prjIsFinished) ? "@prjArchiveStatusId=0" : ((cmpReport.prjIsFinished == "0") ? "@prjArchiveStatusId=False" : "@prjArchiveStatusId=True"));
			string text53 = ((!string.IsNullOrEmpty(cmpReport.prjcnvsStatusGroupIdTitle)) ? ("@prjStatusGroupId=" + cmpReport.prjcnvsStatusGroupIdTitle) : "@prjStatusGroupId=0");
			string text54 = ((!string.IsNullOrEmpty(cmpReport.prjFirstRegisterUserIdTitle)) ? ("@prjSaveUserId=" + cmpReport.prjFirstRegisterUserIdTitle) : "@prjSaveUserId=0");
			string text55 = ((!string.IsNullOrEmpty(cmpReport.prjUserIdTitle)) ? ("@prjEditUserId=" + cmpReport.prjUserIdTitle) : "@prjEditUserId=0");
			string text56 = ((!string.IsNullOrEmpty(cmpReport.prjGroupsMulti)) ? ("@ProjectGroupsMultiId=" + cmpReport.prjGroupsMulti) : "@ProjectGroupsMultiId=0");
			string text57 = ((!string.IsNullOrEmpty(cmpReport.prjGroupsMultiI)) ? ("@ProjectGroupsMultiIId=" + cmpReport.prjGroupsMultiI) : "@ProjectGroupsMultiIId=0");
			string text58 = cmpReport.prjPostFix ?? "";
			text58 = ((text58 == haveNotCompare) ? "@PrjPostfix=-1" : ((!(text58 == haveCompare)) ? ("@PrjPostfix=" + text58) : "@PrjPostfix=-2"));
			string text59 = ((!string.IsNullOrEmpty(cmpReport.prjTreeInfo)) ? cmpReport.prjTreeInfo : "0");
			text59 = ((!(text59.ToLower() == "undefined")) ? text59 : "0");
			string text60 = "0";
			string text61 = "";
			if (!string.IsNullOrEmpty(text59))
			{
				string[] array3 = text59.Split(new char[1] { '|' });
				if (array3.Length > 1)
				{
					text59 = ((array3 != null) ? array3[1] : "");
				}
				text61 = ((array3 != null) ? array3[0] : "");
			}
			switch (text61)
			{
			case "0":
				text60 = cmpReport.txtPrjTreeInfo;
				break;
			case "1":
			case "2":
			case "3":
				text60 = cmpReport.drpPrjTreeInfo;
				break;
			default:
				text60 = "0";
				break;
			}
			string text62 = ((!string.IsNullOrEmpty(cmpReport.projectInformationIdFrom)) ? cmpReport.projectInformationIdFrom : "0");
			string text63 = ((!string.IsNullOrEmpty(cmpReport.projectInformationIdTo)) ? ("@ProjectInformationIdTo=" + cmpReport.projectInformationIdTo) : "@ProjectInformationIdTo=0");
			string text64 = ((!string.IsNullOrEmpty(cmpReport.projectInformationBetweenChecked)) ? cmpReport.projectInformationBetweenChecked : "0");
			if (text64 == "1")
			{
				text60 = text62;
			}
			else
			{
				text64 = "0";
			}
			text60 = "@ProjectInformationId=" + text60;
			text64 = "@ProjectInformationBetweenChecked=" + text64;
			text59 = "@ProjectFieldTitleId=" + text59;
			string text65 = ((!string.IsNullOrEmpty(cmpReport.prjOtherFields)) ? ("@prjOtherField=" + cmpReport.prjOtherFields) : "@prjOtherField=0");
			string text66 = ((!string.IsNullOrEmpty(cmpReport.prjSimilarValue)) ? ("@prjOtherFieldValue=" + cmpReport.prjSimilarValue) : "@prjOtherFieldValue=0");
			string text67 = ((!string.IsNullOrEmpty(cmpReport.prjOtherFieldValueLikely)) ? ("@prjOtherFieldValueLikely=" + cmpReport.prjOtherFieldValueLikely) : "@prjOtherFieldValueLikely=0");
			string text68 = ((!string.IsNullOrEmpty(cmpReport.prjTypeDateForSearch)) ? cmpReport.prjTypeDateForSearch : "0");
			string text69 = ((!string.IsNullOrEmpty(cmpReport.prjFromDate)) ? cmpReport.prjFromDate : "0");
			string text70 = ((!string.IsNullOrEmpty(cmpReport.prjToDate)) ? cmpReport.prjToDate : "0");
			if (text68 != "prjFirstRegisterDate" && text68 != "RegisterDatePersian" && text68 != "prjRemindDate" && text68 != "PrjInfoRegisterDatePersian")
			{
				text68 = "@prjDateType=0";
				text69 = "0";
				text70 = "0";
			}
			else
			{
				text68 = "@prjDateType=" + text68;
			}
			string text71 = ((!string.IsNullOrEmpty(cmpReport.prjcmpCampaignIds)) ? ("@prjcmpCampaignIds=" + cmpReport.prjcmpCampaignIds) : "@prjcmpCampaignIds=0");
			string text72 = ((!string.IsNullOrEmpty(cmpReport.prjcmpPresentationIdTitle)) ? ("@prjcmpPresentationId=" + cmpReport.prjcmpPresentationIdTitle) : "@prjcmpPresentationId=0");
			string text73 = ((!string.IsNullOrWhiteSpace(cmpReport.prjTitleGroup)) ? cmpReport.prjTitleGroup : "0");
			string[] array4 = text73.Split(new char[1] { ',' });
			string text74 = "";
			array2 = array4;
			foreach (string text75 in array2)
			{
				if (text74 != "")
				{
					text74 += "','";
				}
				text74 += text75;
			}
			text73 = "@prjTitleGroup=" + text74;
			string text76 = ((!string.IsNullOrEmpty(cmpReport.cnvsTopicIdTitle)) ? ("@cnvsTopicId=" + cmpReport.cnvsTopicIdTitle) : "@cnvsTopicId=0");
			string text77 = ((!string.IsNullOrEmpty(cmpReport.cnvsUserIdTitle)) ? ("@cnvsUserId=" + cmpReport.cnvsUserIdTitle) : "@cnvsUserId=0");
			string text78 = ((!string.IsNullOrEmpty(cmpReport.cnvsReferUserIdTitle)) ? ("@cnvsReferUserId=" + cmpReport.cnvsReferUserIdTitle) : "@cnvsReferUserId=0");
			string text79 = ((!string.IsNullOrEmpty(cmpReport.cnvsLastStatus)) ? ("@cnvsStatusId=" + cmpReport.cnvsLastStatus) : "@cnvsStatusId=0");
			string text80 = ((!string.IsNullOrEmpty(cmpReport.cnvsContainStatus)) ? ("@cnvsStatusIdContain=" + cmpReport.cnvsContainStatus) : "@cnvsStatusIdContain=0");
			string text81 = ((!string.IsNullOrWhiteSpace(cmpReport.cnvsLastStatusResult)) ? ("@cnvsLastStatusResultIds=" + cmpReport.cnvsLastStatusResult) : "@cnvsLastStatusResultIds=0");
			string text82 = ((!string.IsNullOrWhiteSpace(cmpReport.cnvsContainStatusResult)) ? ("@cnvsContainStatusResultIds=" + cmpReport.cnvsContainStatusResult) : "@cnvsContainStatusResultIds=0");
			int result2 = 0;
			if (cmpReport.cnvsMinPercentage > 0 && cmpReport.cnvsMinPercentage.HasValue)
			{
				int.TryParse(cmpReport.cnvsMinPercentage.ToString(), out result2);
			}
			string text83 = "@ProgressPercent=" + result2;
			int result3 = 0;
			if (cmpReport.cnvsMaxPercentage > 0 && cmpReport.cnvsMaxPercentage.HasValue)
			{
				int.TryParse(cmpReport.cnvsMaxPercentage.ToString(), out result3);
			}
			string text84 = "@ProgressPercentMax=" + result3;
			string text85 = ((!string.IsNullOrEmpty(cmpReport.cnvsPriorityIdTitle)) ? ("@cnvsPriorityId=" + cmpReport.cnvsPriorityIdTitle) : "@cnvsPriorityId=0");
			string text86 = ((!string.IsNullOrEmpty(cmpReport.cnvsOtherFields)) ? ("@cnvsOtherField=" + cmpReport.cnvsOtherFields) : "@cnvsOtherField=0");
			string text87 = ((!string.IsNullOrEmpty(cmpReport.cnvsSimilarValue)) ? cmpReport.cnvsSimilarValue : "0");
			text87 = ((text87 == haveNotCompare) ? "@cnvsOtherFieldValue=-1" : ((!(text87 == haveCompare)) ? ("@cnvsOtherFieldValue=" + text87) : "@cnvsOtherFieldValue=-2"));
			string text88 = ((!string.IsNullOrEmpty(cmpReport.cnvsOtherFieldValueLikely)) ? ("@cnvsOtherFieldValueLikely=" + cmpReport.cnvsOtherFieldValueLikely) : "@cnvsOtherFieldValueLikely=0");
			string text89 = ((!string.IsNullOrEmpty(cmpReport.cnvsTypeDateForSearch)) ? cmpReport.cnvsTypeDateForSearch : "0");
			string text90 = ((!string.IsNullOrEmpty(cmpReport.cnvsFromDate)) ? cmpReport.cnvsFromDate : "0");
			string text91 = ((!string.IsNullOrEmpty(cmpReport.cnvsToDate)) ? cmpReport.cnvsToDate : "0");
			if (text89 != "cnvsFirstRegisterDate" && text89 != "RegisterDatePersian")
			{
				text89 = "@cnvsDateType=0";
				text90 = "0";
				text91 = "0";
			}
			else
			{
				text89 = "@cnvsDateType=" + text89;
			}
			string text92 = "@UserId=" + UserLogin.CurrentUser.UserId;
			string text93 = ((cmpReport.prsSel.HasValue && cmpReport.prsSel != false) ? "@prsSel=1" : "@prsSel=0");
			string text94 = ((cmpReport.prjSel.HasValue && cmpReport.prjSel != false) ? "@prjSel=1" : "@prjSel=0");
			string text95 = ((cmpReport.cnvsSel.HasValue && cmpReport.cnvsSel != false) ? "@cnvsSel=1" : "@cnvsSel=0");
			string text96 = "@Term=" + text;
			string text97 = "@LanguageID=" + lCID;
			string text98 = "@DefaultLanguageID=" + result;
			string text99 = "";
			string text100 = "";
			if (!string.IsNullOrEmpty(text22) && text22 != "0" && text22 != "-1")
			{
				text99 = ((Thread.CurrentThread.CurrentCulture.LCID != 1065) ? (DateTime.Parse(PersianDate.GetFormatetdDate(text22.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 00:00:00") : (DateTime.Parse(PersianDate.GetShamsi2Miladi(text22.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 00:00:00"));
			}
			if (!string.IsNullOrEmpty(text23) && text23 != "0" && text23 != "-1")
			{
				text100 = ((Thread.CurrentThread.CurrentCulture.LCID != 1065) ? (DateTime.Parse(PersianDate.GetFormatetdDate(text23.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 23:59:59") : (DateTime.Parse(PersianDate.GetShamsi2Miladi(text23.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 23:59:59"));
			}
			text22 = "@cmpFDate=" + text22;
			text23 = "@cmpTDate=" + text23;
			string text101 = "@cmpFDateTime=" + text99;
			string text102 = "@cmpTDateTime=" + text100;
			string text103 = "";
			string text104 = "";
			if (!string.IsNullOrEmpty(text44) && text44 != "0" && text44 != "-1")
			{
				text103 = ((Thread.CurrentThread.CurrentCulture.LCID != 1065) ? (DateTime.Parse(PersianDate.GetFormatetdDate(text44.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 00:00:00") : (DateTime.Parse(PersianDate.GetShamsi2Miladi(text44.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 00:00:00"));
			}
			if (!string.IsNullOrEmpty(text45) && text45 != "0" && text45 != "-1")
			{
				text104 = ((Thread.CurrentThread.CurrentCulture.LCID != 1065) ? (DateTime.Parse(PersianDate.GetFormatetdDate(text45.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 23:59:59") : (DateTime.Parse(PersianDate.GetShamsi2Miladi(text45.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 23:59:59"));
			}
			text44 = "@prsFDate=" + text44;
			text45 = "@prsTDate=" + text45;
			string text105 = "@prsFDateTime=" + text103;
			string text106 = "@prsTDateTime=" + text104;
			string text107 = "";
			string text108 = "";
			if (!string.IsNullOrEmpty(text69) && text69 != "0" && text69 != "-1")
			{
				text107 = ((Thread.CurrentThread.CurrentCulture.LCID != 1065) ? (DateTime.Parse(PersianDate.GetFormatetdDate(text69.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 00:00:00") : (DateTime.Parse(PersianDate.GetShamsi2Miladi(text69.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 00:00:00"));
			}
			if (!string.IsNullOrEmpty(text70) && text70 != "0" && text70 != "-1")
			{
				text108 = ((Thread.CurrentThread.CurrentCulture.LCID != 1065) ? (DateTime.Parse(PersianDate.GetFormatetdDate(text70.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 23:59:59") : (DateTime.Parse(PersianDate.GetShamsi2Miladi(text70.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 23:59:59"));
			}
			text69 = "@prjFDate=" + text69;
			text70 = "@prjTDate=" + text70;
			string text109 = "@prjFDateTime=" + text107;
			string text110 = "@prjTDateTime=" + text108;
			string text111 = "";
			string text112 = "";
			if (!string.IsNullOrEmpty(text90) && text90 != "0" && text90 != "-1")
			{
				text111 = ((Thread.CurrentThread.CurrentCulture.LCID != 1065) ? (DateTime.Parse(PersianDate.GetFormatetdDate(text90.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 00:00:00") : (DateTime.Parse(PersianDate.GetShamsi2Miladi(text90.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 00:00:00"));
			}
			if (!string.IsNullOrEmpty(text91) && text91 != "0" && text91 != "-1")
			{
				text112 = ((Thread.CurrentThread.CurrentCulture.LCID != 1065) ? (DateTime.Parse(PersianDate.GetFormatetdDate(text91.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 23:59:59") : (DateTime.Parse(PersianDate.GetShamsi2Miladi(text91.Replace("/", ""))).ToString("yyyy-MM-dd", new CultureInfo("en-US")) + " 23:59:59"));
			}
			text90 = "@cnvsFDate=" + text90;
			text91 = "@cnvsTDate=" + text91;
			string text113 = "@cnvsFDateTime=" + text111;
			string text114 = "@cnvsTDateTime=" + text112;
			string txt = text4 + "|" + text5 + "|" + text6 + "|" + text7 + "|" + text8 + "|" + text9 + "|" + text10 + "|" + text11 + "|" + text12 + "|" + text13 + "|" + text14 + "|" + text15 + "|" + text16 + "|" + text17 + "|" + text18 + "|" + text19 + "|" + text20 + "|" + text21 + "|" + text22 + "|" + text23 + "|" + text24 + "|" + text30 + "|" + text31 + "|" + text32 + "|" + text33 + "|" + text34 + "|" + text35 + "|" + text36 + "|" + text37 + "|" + text38 + "|" + text39 + "|" + text40 + "|" + text41 + "|" + text42 + "|" + text43 + "|" + text44 + "|" + text45 + "|" + text46 + "|" + text49 + "|" + text50 + "|" + text51 + "|" + text52 + "|" + text53 + "|" + text54 + "|" + text55 + "|" + text56 + "|" + text57 + "|" + text58 + "|" + text59 + "|" + text60 + "|" + text63 + "|" + text64 + "|" + text65 + "|" + text66 + "|" + text67 + "|" + text68 + "|" + text69 + "|" + text70 + "|" + text76 + "|" + text77 + "|" + text78 + "|" + text79 + "|" + text80 + "|" + text83 + "|" + text84 + "|" + text85 + "|" + text86 + "|" + text87 + "|" + text88 + "|" + text89 + "|" + text90 + "|" + text91 + "|" + text92 + "|" + text93 + "|" + text94 + "|" + text95 + "|" + text96 + "|" + text97 + "|" + text98 + "|" + text101 + "|" + text102 + "|" + text105 + "|" + text106 + "|" + text109 + "|" + text110 + "|" + text113 + "|" + text114 + "|" + text25 + "|" + text71 + "|" + text72 + "|" + text26 + "|" + text27 + "|" + text28 + "|" + text29 + "|" + text73 + "|" + text81 + "|" + text82 + "|";
			int userId = UserLogin.CurrentUser.UserId;
			string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			db.CRMspInsertCrmSysDBTempInfoFormCompanyFilterData(userId, 2, txt, firstRegisterDatePersian, result, appType);
			base.ViewBag.ParameterReport = "GotoCompanyFormWithData";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.ParameterReport = "";
		}
		return PartialView();
	}

	public ActionResult CompanyFilterData_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<mct_CRMspRpt_CompanyFilterData_Result> list = new List<mct_CRMspRpt_CompanyFilterData_Result>();
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			list = Enumerable.ToList<mct_CRMspRpt_CompanyFilterData_Result>((IEnumerable<mct_CRMspRpt_CompanyFilterData_Result>)db.mfi_CRMspRpt_CompanyFilterDataFillParam(UserLogin.CurrentUser.UserId, 2, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		List<CRMspRptCompanyFilterDataViewModel> enumerable = Enumerable.ToList<CRMspRptCompanyFilterDataViewModel>(Enumerable.Select<mct_CRMspRpt_CompanyFilterData_Result, CRMspRptCompanyFilterDataViewModel>((IEnumerable<mct_CRMspRpt_CompanyFilterData_Result>)list, (Func<mct_CRMspRpt_CompanyFilterData_Result, CRMspRptCompanyFilterDataViewModel>)((mct_CRMspRpt_CompanyFilterData_Result item) => new CRMspRptCompanyFilterDataViewModel
		{
			CompanyID = item.CompanyID,
			cmpNumber = item.cmpNumber,
			cmpName = item.cmpName,
			prsName = item.prsName,
			cmpActivityType = item.cmpActivityType,
			prjTitle = item.prjTitle,
			ConversationStatus = item.ConversationStatus,
			ProjectId = item.ProjectId
		})));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult CompanyShowItems(string mode)
	{
		base.ViewBag.mode = mode;
		return View();
	}

	public ActionResult _PartialCompanyShowItems(string mode)
	{
		base.ViewBag.mode = mode;
		return PartialView();
	}

	public ActionResult CompanyShowItems_Read([DataSourceRequest] DataSourceRequest request, string mode)
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
		List<CrmListItemViewModel> list = new List<CrmListItemViewModel>();
		switch (mode)
		{
		case "CompanyTitle":
		{
			List<CRMspRpt_cmpSelCompanyTitle_Result> list10 = Enumerable.ToList<CRMspRpt_cmpSelCompanyTitle_Result>((IEnumerable<CRMspRpt_cmpSelCompanyTitle_Result>)db.CRMspRpt_cmpSelCompanyTitle(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyTitle_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyTitle_Result>((IEnumerable<CRMspRpt_cmpSelCompanyTitle_Result>)list10, (Func<CRMspRpt_cmpSelCompanyTitle_Result, bool>)((CRMspRpt_cmpSelCompanyTitle_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyTitle_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyTitle_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "CompanyPresentation":
		{
			List<CRMspRpt_cmpSelCompanyPresentation_Result> list8 = Enumerable.ToList<CRMspRpt_cmpSelCompanyPresentation_Result>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)db.CRMspRpt_cmpSelCompanyPresentation(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyPresentation_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyPresentation_Result>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)list8, (Func<CRMspRpt_cmpSelCompanyPresentation_Result, bool>)((CRMspRpt_cmpSelCompanyPresentation_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyPresentation_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyPresentation_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "CompanyType":
		{
			List<CRMspRpt_cmpSelCompanyType_Result> list7 = Enumerable.ToList<CRMspRpt_cmpSelCompanyType_Result>((IEnumerable<CRMspRpt_cmpSelCompanyType_Result>)db.CRMspRpt_cmpSelCompanyType(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyType_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyType_Result>((IEnumerable<CRMspRpt_cmpSelCompanyType_Result>)list7, (Func<CRMspRpt_cmpSelCompanyType_Result, bool>)((CRMspRpt_cmpSelCompanyType_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyType_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyType_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "CompanyGroup":
		{
			List<CRMspRpt_cmpSelCompanyGroup_Result> list3 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroup_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroup_Result>)db.CRMspRpt_cmpSelCompanyGroup(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroup_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyGroup_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroup_Result>)list3, (Func<CRMspRpt_cmpSelCompanyGroup_Result, bool>)((CRMspRpt_cmpSelCompanyGroup_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyGroup_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyGroup_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "CompanyGroupII":
		{
			List<CRMspRpt_cmpSelCompanyGroupsII_Result> list4 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsII_Result>)db.CRMspRpt_cmpSelCompanyGroupsII(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsII_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyGroupsII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsII_Result>)list4, (Func<CRMspRpt_cmpSelCompanyGroupsII_Result, bool>)((CRMspRpt_cmpSelCompanyGroupsII_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyGroupsII_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyGroupsII_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "CompanyGroupIII":
		{
			List<CRMspRpt_cmpSelCompanyGroupsIII_Result> list6 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsIII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIII_Result>)db.CRMspRpt_cmpSelCompanyGroupsIII(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsIII_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyGroupsIII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIII_Result>)list6, (Func<CRMspRpt_cmpSelCompanyGroupsIII_Result, bool>)((CRMspRpt_cmpSelCompanyGroupsIII_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyGroupsIII_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyGroupsIII_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "CompanyGroupIV":
		{
			List<CRMspRpt_cmpSelCompanyGroupsIV_Result> list5 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsIV_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIV_Result>)db.CRMspRpt_cmpSelCompanyGroupsIV(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsIV_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyGroupsIV_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIV_Result>)list5, (Func<CRMspRpt_cmpSelCompanyGroupsIV_Result, bool>)((CRMspRpt_cmpSelCompanyGroupsIV_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyGroupsIV_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyGroupsIV_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "CompanyGroupMulti":
		{
			List<CRMspRpt_cmpSelCompanyGroupsMulti_Result> list9 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsMulti_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsMulti_Result>)db.CRMspRpt_cmpSelCompanyGroupsMulti(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsMulti_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyGroupsMulti_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsMulti_Result>)list9, (Func<CRMspRpt_cmpSelCompanyGroupsMulti_Result, bool>)((CRMspRpt_cmpSelCompanyGroupsMulti_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyGroupsMulti_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyGroupsMulti_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "CompanySuppUser":
		case "CompanyReferUser":
		{
			List<CRMspRpt_cmpSelCompanyReferUsers_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelCompanyReferUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)db.CRMspRpt_cmpSelCompanyReferUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, int>)((CRMspRpt_cmpSelCompanyReferUsers_Result c) => c.ord)));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyReferUsers_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)list2, (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, bool>)((CRMspRpt_cmpSelCompanyReferUsers_Result item) => item.ID != 0 && item.ID.GetValueOrDefault() != -1 && item.ID.GetValueOrDefault() != -100)), (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyReferUsers_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID.GetValueOrDefault(),
				ItemName = item.Val
			})));
			break;
		}
		default:
			list = null;
			break;
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	public ActionResult CompanyCountry()
	{
		return View();
	}

	public ActionResult _PartialCompanyCountry()
	{
		return PartialView();
	}

	public ActionResult CompanyCountry_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<Country> enumerable = Enumerable.ToList<Country>(Enumerable.Select<CRMspRpt_cmpSelCompanyCountry_Result, Country>(Enumerable.Where<CRMspRpt_cmpSelCompanyCountry_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCountry_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanyCountry_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCountry_Result>)db.CRMspRpt_cmpSelCompanyCountry(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelCompanyCountry_Result, bool>)((CRMspRpt_cmpSelCompanyCountry_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyCountry_Result, Country>)((CRMspRpt_cmpSelCompanyCountry_Result item) => new Country
		{
			CountryID = item.ID,
			Country1 = item.Val
		})));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult CompanyProvince(int countryId)
	{
		base.ViewBag.countryId = countryId;
		return View();
	}

	public ActionResult _PartialCompanyProvince(int parentId)
	{
		base.ViewBag.parentId = parentId;
		return PartialView();
	}

	public ActionResult CompanyProvince_Read([DataSourceRequest] DataSourceRequest request, int parentId)
	{
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CRMspLoadCompanyProvince_Result> enumerable = Enumerable.ToList<CRMspLoadCompanyProvince_Result>(Enumerable.Select<CRMspRpt_cmpSelCompanyProvince_Result, CRMspLoadCompanyProvince_Result>(Enumerable.Where<CRMspRpt_cmpSelCompanyProvince_Result>((IEnumerable<CRMspRpt_cmpSelCompanyProvince_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanyProvince_Result>((IEnumerable<CRMspRpt_cmpSelCompanyProvince_Result>)db.CRMspRpt_cmpSelCompanyProvince(UserLogin.CurrentUser.UserId, parentId, none, haveNot, lCID, result2, result)), (Func<CRMspRpt_cmpSelCompanyProvince_Result, bool>)((CRMspRpt_cmpSelCompanyProvince_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyProvince_Result, CRMspLoadCompanyProvince_Result>)((CRMspRpt_cmpSelCompanyProvince_Result item) => new CRMspLoadCompanyProvince_Result
		{
			ProvinceID = item.ID,
			Province = item.Val
		})));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult CompanyCity(int provinceId)
	{
		base.ViewBag.parentId = provinceId;
		return View();
	}

	public ActionResult _PartialCompanyCity(int parentId)
	{
		base.ViewBag.parentId = parentId;
		return PartialView();
	}

	public ActionResult CompanyCity_Read([DataSourceRequest] DataSourceRequest request, int parentId)
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
		List<CRMspLoadCompanyCity_Result> enumerable = Enumerable.ToList<CRMspLoadCompanyCity_Result>(Enumerable.Select<CRMspRpt_cmpSelCompanyCity_Result, CRMspLoadCompanyCity_Result>(Enumerable.Where<CRMspRpt_cmpSelCompanyCity_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCity_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanyCity_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCity_Result>)db.CRMspRpt_cmpSelCompanyCity(UserLogin.CurrentUser.UserId, parentId, none, haveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelCompanyCity_Result, bool>)((CRMspRpt_cmpSelCompanyCity_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyCity_Result, CRMspLoadCompanyCity_Result>)((CRMspRpt_cmpSelCompanyCity_Result item) => new CRMspLoadCompanyCity_Result
		{
			CityID = item.ID,
			City = item.Val
		})));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult CompanySubGroup(int groupId)
	{
		base.ViewBag.parentId = groupId;
		return View();
	}

	public ActionResult _PartialCompanySubGroup(int parentId)
	{
		base.ViewBag.parentId = parentId;
		return PartialView();
	}

	public ActionResult CompanySubGroup_Read([DataSourceRequest] DataSourceRequest request, int parentId)
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
		List<CRMspLoadCompanySubGroup_Result> enumerable = Enumerable.ToList<CRMspLoadCompanySubGroup_Result>(Enumerable.Select<CRMspRpt_cmpSelCompanySubGroup_Result, CRMspLoadCompanySubGroup_Result>(Enumerable.Where<CRMspRpt_cmpSelCompanySubGroup_Result>((IEnumerable<CRMspRpt_cmpSelCompanySubGroup_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanySubGroup_Result>((IEnumerable<CRMspRpt_cmpSelCompanySubGroup_Result>)db.CRMspRpt_cmpSelCompanySubGroup(UserLogin.CurrentUser.UserId, parentId, none, haveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelCompanySubGroup_Result, bool>)((CRMspRpt_cmpSelCompanySubGroup_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanySubGroup_Result, CRMspLoadCompanySubGroup_Result>)((CRMspRpt_cmpSelCompanySubGroup_Result item) => new CRMspLoadCompanySubGroup_Result
		{
			CompanySubGroupID = item.ID,
			SubGroupName = item.Val
		})));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult PersonShowItems(string mode)
	{
		base.ViewBag.mode = mode;
		return View();
	}

	public ActionResult _PartialPersonShowItems(string mode)
	{
		base.ViewBag.mode = mode;
		return PartialView();
	}

	public ActionResult PersonShowItems_Read([DataSourceRequest] DataSourceRequest request, string mode)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CrmListItemViewModel> list = new List<CrmListItemViewModel>();
		switch (mode)
		{
		case "PersonTitle":
		{
			List<CRMspRpt_cmpSelPersonTitle_Result> list6 = Enumerable.ToList<CRMspRpt_cmpSelPersonTitle_Result>((IEnumerable<CRMspRpt_cmpSelPersonTitle_Result>)db.CRMspRpt_cmpSelPersonTitle(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelPersonTitle_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelPersonTitle_Result>((IEnumerable<CRMspRpt_cmpSelPersonTitle_Result>)list6, (Func<CRMspRpt_cmpSelPersonTitle_Result, bool>)((CRMspRpt_cmpSelPersonTitle_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonTitle_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelPersonTitle_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "PersonJob":
		{
			List<CRMspRpt_cmpSelPersonJobs_Result> list3 = Enumerable.ToList<CRMspRpt_cmpSelPersonJobs_Result>((IEnumerable<CRMspRpt_cmpSelPersonJobs_Result>)db.CRMspRpt_cmpSelPersonJobs(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelPersonJobs_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelPersonJobs_Result>((IEnumerable<CRMspRpt_cmpSelPersonJobs_Result>)list3, (Func<CRMspRpt_cmpSelPersonJobs_Result, bool>)((CRMspRpt_cmpSelPersonJobs_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonJobs_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelPersonJobs_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "PersonDepartment":
		{
			List<CRMspRpt_cmpSelPersonDepartments_Result> list4 = Enumerable.ToList<CRMspRpt_cmpSelPersonDepartments_Result>((IEnumerable<CRMspRpt_cmpSelPersonDepartments_Result>)db.CRMspRpt_cmpSelPersonDepartments(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelPersonDepartments_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelPersonDepartments_Result>((IEnumerable<CRMspRpt_cmpSelPersonDepartments_Result>)list4, (Func<CRMspRpt_cmpSelPersonDepartments_Result, bool>)((CRMspRpt_cmpSelPersonDepartments_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonDepartments_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelPersonDepartments_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "PersonType":
		{
			List<CRMspRpt_cmpSelPersonType_Result> list8 = Enumerable.ToList<CRMspRpt_cmpSelPersonType_Result>((IEnumerable<CRMspRpt_cmpSelPersonType_Result>)db.CRMspRpt_cmpSelPersonType(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelPersonType_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelPersonType_Result>((IEnumerable<CRMspRpt_cmpSelPersonType_Result>)list8, (Func<CRMspRpt_cmpSelPersonType_Result, bool>)((CRMspRpt_cmpSelPersonType_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonType_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelPersonType_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "PersonGroup":
		{
			List<CRMspRpt_cmpSelPersonGroups_Result> list5 = Enumerable.ToList<CRMspRpt_cmpSelPersonGroups_Result>((IEnumerable<CRMspRpt_cmpSelPersonGroups_Result>)db.CRMspRpt_cmpSelPersonGroups(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelPersonGroups_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelPersonGroups_Result>((IEnumerable<CRMspRpt_cmpSelPersonGroups_Result>)list5, (Func<CRMspRpt_cmpSelPersonGroups_Result, bool>)((CRMspRpt_cmpSelPersonGroups_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonGroups_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelPersonGroups_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "PersonSex":
		{
			List<CRMspRpt_cmpSelSex_Result> list7 = Enumerable.ToList<CRMspRpt_cmpSelSex_Result>((IEnumerable<CRMspRpt_cmpSelSex_Result>)db.CRMspRpt_cmpSelSex(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelSex_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelSex_Result>((IEnumerable<CRMspRpt_cmpSelSex_Result>)list7, (Func<CRMspRpt_cmpSelSex_Result, bool>)((CRMspRpt_cmpSelSex_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelSex_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelSex_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "PersonEducationField":
		{
			List<CRMspRpt_cmpSelPersonEducation_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelPersonEducation_Result>((IEnumerable<CRMspRpt_cmpSelPersonEducation_Result>)db.CRMspRpt_cmpSelPersonEducation(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelPersonEducation_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelPersonEducation_Result>((IEnumerable<CRMspRpt_cmpSelPersonEducation_Result>)list2, (Func<CRMspRpt_cmpSelPersonEducation_Result, bool>)((CRMspRpt_cmpSelPersonEducation_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonEducation_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelPersonEducation_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		default:
			list = null;
			break;
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	public ActionResult PersonCountry()
	{
		return View();
	}

	public ActionResult _PartialPersonCountry()
	{
		return PartialView();
	}

	public ActionResult PersonCountry_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<Country> enumerable = Enumerable.ToList<Country>(Enumerable.Select<CRMspRpt_cmpSelPersonCountry_Result, Country>(Enumerable.Where<CRMspRpt_cmpSelPersonCountry_Result>((IEnumerable<CRMspRpt_cmpSelPersonCountry_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonCountry_Result>((IEnumerable<CRMspRpt_cmpSelPersonCountry_Result>)db.CRMspRpt_cmpSelPersonCountry(none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonCountry_Result, bool>)((CRMspRpt_cmpSelPersonCountry_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonCountry_Result, Country>)((CRMspRpt_cmpSelPersonCountry_Result item) => new Country
		{
			CountryID = item.ID,
			Country1 = item.Val
		})));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult PersonProvince(int countryId)
	{
		base.ViewBag.countryId = countryId;
		return View();
	}

	public ActionResult _PartialPersonProvince(int parentId)
	{
		base.ViewBag.parentId = parentId;
		return PartialView();
	}

	public ActionResult PersonProvince_Read([DataSourceRequest] DataSourceRequest request, int parentId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CRMspLoadCompanyProvince_Result> enumerable = Enumerable.ToList<CRMspLoadCompanyProvince_Result>(Enumerable.Select<CRMspRpt_cmpSelPersonProvince_Result, CRMspLoadCompanyProvince_Result>(Enumerable.Where<CRMspRpt_cmpSelPersonProvince_Result>((IEnumerable<CRMspRpt_cmpSelPersonProvince_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonProvince_Result>((IEnumerable<CRMspRpt_cmpSelPersonProvince_Result>)db.CRMspRpt_cmpSelPersonProvince(parentId, none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonProvince_Result, bool>)((CRMspRpt_cmpSelPersonProvince_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonProvince_Result, CRMspLoadCompanyProvince_Result>)((CRMspRpt_cmpSelPersonProvince_Result item) => new CRMspLoadCompanyProvince_Result
		{
			ProvinceID = item.ID,
			Province = item.Val
		})));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult PersonCity(int provinceId)
	{
		base.ViewBag.parentId = provinceId;
		return View();
	}

	public ActionResult _PartialPersonCity(int parentId)
	{
		base.ViewBag.parentId = parentId;
		return PartialView();
	}

	public ActionResult PersonCity_Read([DataSourceRequest] DataSourceRequest request, int parentId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string none = Labels.None;
		string haveNot = Labels.HaveNot;
		List<CRMspLoadCompanyCity_Result> enumerable = Enumerable.ToList<CRMspLoadCompanyCity_Result>(Enumerable.Select<CRMspRpt_cmpSelPersonCity_Result, CRMspLoadCompanyCity_Result>(Enumerable.Where<CRMspRpt_cmpSelPersonCity_Result>((IEnumerable<CRMspRpt_cmpSelPersonCity_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonCity_Result>((IEnumerable<CRMspRpt_cmpSelPersonCity_Result>)db.CRMspRpt_cmpSelPersonCity(parentId, none, haveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonCity_Result, bool>)((CRMspRpt_cmpSelPersonCity_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelPersonCity_Result, CRMspLoadCompanyCity_Result>)((CRMspRpt_cmpSelPersonCity_Result item) => new CRMspLoadCompanyCity_Result
		{
			CityID = item.ID,
			City = item.Val
		})));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult ProjectShowItems(string mode)
	{
		base.ViewBag.mode = mode;
		return View();
	}

	public ActionResult _PartialProjectShowItems(string mode)
	{
		base.ViewBag.mode = mode;
		return PartialView();
	}

	public ActionResult ProjectShowItems_Read([DataSourceRequest] DataSourceRequest request, string mode)
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
		List<CrmListItemViewModel> list = new List<CrmListItemViewModel>();
		switch (mode)
		{
		case "ProjectGroup":
		{
			List<CRMspRpt_cmpSelProjectGroups_Result> list5 = Enumerable.ToList<CRMspRpt_cmpSelProjectGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroups_Result>)db.CRMspRpt_cmpSelProjectGroups(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectGroups_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelProjectGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroups_Result>)list5, (Func<CRMspRpt_cmpSelProjectGroups_Result, bool>)((CRMspRpt_cmpSelProjectGroups_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelProjectGroups_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelProjectGroups_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "ProjectPriority":
		{
			List<CRMspRpt_cmpSelProjectPriority_Result> list6 = Enumerable.ToList<CRMspRpt_cmpSelProjectPriority_Result>((IEnumerable<CRMspRpt_cmpSelProjectPriority_Result>)db.CRMspRpt_cmpSelProjectPriority(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectPriority_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelProjectPriority_Result>((IEnumerable<CRMspRpt_cmpSelProjectPriority_Result>)list6, (Func<CRMspRpt_cmpSelProjectPriority_Result, bool>)((CRMspRpt_cmpSelProjectPriority_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelProjectPriority_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelProjectPriority_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "ProjectGrade":
		{
			List<CRMspRpt_cmpSelProjectGrade_Result> list8 = Enumerable.ToList<CRMspRpt_cmpSelProjectGrade_Result>((IEnumerable<CRMspRpt_cmpSelProjectGrade_Result>)db.CRMspRpt_cmpSelProjectGrade(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectGrade_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelProjectGrade_Result>((IEnumerable<CRMspRpt_cmpSelProjectGrade_Result>)list8, (Func<CRMspRpt_cmpSelProjectGrade_Result, bool>)((CRMspRpt_cmpSelProjectGrade_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelProjectGrade_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelProjectGrade_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "ProjectcnvsStatusGroup":
		{
			List<CRMspRpt_cmpSelProjectStatusGroups_Result> list10 = Enumerable.ToList<CRMspRpt_cmpSelProjectStatusGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjectStatusGroups_Result, int>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)db.CRMspRpt_cmpSelProjectStatusGroups(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result), (Func<CRMspRpt_cmpSelProjectStatusGroups_Result, int>)((CRMspRpt_cmpSelProjectStatusGroups_Result c) => c.ord)));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectStatusGroups_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelProjectStatusGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)list10, (Func<CRMspRpt_cmpSelProjectStatusGroups_Result, bool>)((CRMspRpt_cmpSelProjectStatusGroups_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelProjectStatusGroups_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelProjectStatusGroups_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "ProjectFirstRegisterUser":
		{
			List<CRMspRpt_cmpSelProjectSaveUsers_Result> list9 = Enumerable.ToList<CRMspRpt_cmpSelProjectSaveUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)db.CRMspRpt_cmpSelProjectSaveUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectSaveUsers_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelProjectSaveUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)list9, (Func<CRMspRpt_cmpSelProjectSaveUsers_Result, bool>)((CRMspRpt_cmpSelProjectSaveUsers_Result item) => item.ID != 0 && item.ID.GetValueOrDefault() != -1 && item.ID.GetValueOrDefault() != -100)), (Func<CRMspRpt_cmpSelProjectSaveUsers_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelProjectSaveUsers_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID.GetValueOrDefault(),
				ItemName = item.Val
			})));
			break;
		}
		case "ProjectUser":
		{
			List<CRMspRpt_cmpSelProjectEditUsers_Result> list4 = Enumerable.ToList<CRMspRpt_cmpSelProjectEditUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)db.CRMspRpt_cmpSelProjectEditUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectEditUsers_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelProjectEditUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)list4, (Func<CRMspRpt_cmpSelProjectEditUsers_Result, bool>)((CRMspRpt_cmpSelProjectEditUsers_Result item) => item.ID != 0 && item.ID.GetValueOrDefault() != -1 && item.ID.GetValueOrDefault() != -100)), (Func<CRMspRpt_cmpSelProjectEditUsers_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelProjectEditUsers_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID.GetValueOrDefault(),
				ItemName = item.Val
			})));
			break;
		}
		case "ProjectGroupsMulti":
		{
			List<CRMspRpt_cmpSelProjectGroupsMulti_Result> list3 = Enumerable.ToList<CRMspRpt_cmpSelProjectGroupsMulti_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMulti_Result>)db.CRMspRpt_cmpSelProjectGroupsMulti(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectGroupsMulti_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelProjectGroupsMulti_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMulti_Result>)list3, (Func<CRMspRpt_cmpSelProjectGroupsMulti_Result, bool>)((CRMspRpt_cmpSelProjectGroupsMulti_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelProjectGroupsMulti_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelProjectGroupsMulti_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "ProjectGroupsMultiI":
		{
			List<CRMspRpt_cmpSelProjectGroupsMultiI_Result> list7 = Enumerable.ToList<CRMspRpt_cmpSelProjectGroupsMultiI_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMultiI_Result>)db.CRMspRpt_cmpSelProjectGroupsMultiI(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelProjectGroupsMultiI_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelProjectGroupsMultiI_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMultiI_Result>)list7, (Func<CRMspRpt_cmpSelProjectGroupsMultiI_Result, bool>)((CRMspRpt_cmpSelProjectGroupsMultiI_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelProjectGroupsMultiI_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelProjectGroupsMultiI_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "ProjectCmpPresentation":
		{
			List<CRMspRpt_cmpSelCompanyPresentation_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyPresentation_Result>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)db.CRMspRpt_cmpSelCompanyPresentation(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelCompanyPresentation_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelCompanyPresentation_Result>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)list2, (Func<CRMspRpt_cmpSelCompanyPresentation_Result, bool>)((CRMspRpt_cmpSelCompanyPresentation_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelCompanyPresentation_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelCompanyPresentation_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		default:
			list = null;
			break;
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	public ActionResult ProjectTitle(string mode = "")
	{
		base.ViewBag.mode = mode;
		return View();
	}

	public ActionResult _PartialProjectTitle(string mode = "")
	{
		base.ViewBag.mode = mode;
		return PartialView();
	}

	public ActionResult ProjectTitle_Read([DataSourceRequest] DataSourceRequest request, string mode = "")
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
		List<CRMspRpt_cmpSelProjects_Result> enumerable = new List<CRMspRpt_cmpSelProjects_Result>();
		try
		{
			if (string.IsNullOrWhiteSpace(mode))
			{
				List<CRMspRpt_cmpSelProjects_Result> list = Enumerable.ToList<CRMspRpt_cmpSelProjects_Result>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjects_Result, string>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)db.CRMspRpt_cmpSelProjects(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelProjects_Result, string>)((CRMspRpt_cmpSelProjects_Result c) => c.ord)));
				if (list != null && Enumerable.Any<CRMspRpt_cmpSelProjects_Result>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)list))
				{
					enumerable = Enumerable.ToList<CRMspRpt_cmpSelProjects_Result>(Enumerable.Select<CRMspRpt_cmpSelProjects_Result, CRMspRpt_cmpSelProjects_Result>(Enumerable.Where<CRMspRpt_cmpSelProjects_Result>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)list, (Func<CRMspRpt_cmpSelProjects_Result, bool>)((CRMspRpt_cmpSelProjects_Result item) => item.ID != "0" && item.ID != "-1" && item.ID != "-100")), (Func<CRMspRpt_cmpSelProjects_Result, CRMspRpt_cmpSelProjects_Result>)((CRMspRpt_cmpSelProjects_Result item) => new CRMspRpt_cmpSelProjects_Result
					{
						ID = item.ID,
						Val = item.Val
					})));
				}
			}
			else if (mode == "ProjectTitleGroup")
			{
				List<CRMspRpt_cmpSelProjectTitleGroups_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelProjectTitleGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjectTitleGroups_Result, string>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)_dbII.CRMspRpt_cmpSelProjectTitleGroups(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result), (Func<CRMspRpt_cmpSelProjectTitleGroups_Result, string>)((CRMspRpt_cmpSelProjectTitleGroups_Result c) => c.ord)));
				if (list2 != null && Enumerable.Any<CRMspRpt_cmpSelProjectTitleGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)list2))
				{
					enumerable = Enumerable.ToList<CRMspRpt_cmpSelProjects_Result>(Enumerable.Select<CRMspRpt_cmpSelProjectTitleGroups_Result, CRMspRpt_cmpSelProjects_Result>(Enumerable.Where<CRMspRpt_cmpSelProjectTitleGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)list2, (Func<CRMspRpt_cmpSelProjectTitleGroups_Result, bool>)((CRMspRpt_cmpSelProjectTitleGroups_Result item) => item.ID != "0" && item.ID != "-1" && item.ID != "-100")), (Func<CRMspRpt_cmpSelProjectTitleGroups_Result, CRMspRpt_cmpSelProjects_Result>)((CRMspRpt_cmpSelProjectTitleGroups_Result item) => new CRMspRpt_cmpSelProjects_Result
					{
						ID = item.ID,
						Val = item.Val
					})));
				}
			}
			else
			{
				List<CRMspRpt_cmpSelProjects_Result> list3 = Enumerable.ToList<CRMspRpt_cmpSelProjects_Result>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjects_Result, string>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)db.CRMspRpt_cmpSelProjects(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelProjects_Result, string>)((CRMspRpt_cmpSelProjects_Result c) => c.ord)));
				if (list3 != null && Enumerable.Any<CRMspRpt_cmpSelProjects_Result>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)list3))
				{
					enumerable = Enumerable.ToList<CRMspRpt_cmpSelProjects_Result>(Enumerable.Select<CRMspRpt_cmpSelProjects_Result, CRMspRpt_cmpSelProjects_Result>(Enumerable.Where<CRMspRpt_cmpSelProjects_Result>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)list3, (Func<CRMspRpt_cmpSelProjects_Result, bool>)((CRMspRpt_cmpSelProjects_Result item) => item.ID != "0" && item.ID != "-1" && item.ID != "-100")), (Func<CRMspRpt_cmpSelProjects_Result, CRMspRpt_cmpSelProjects_Result>)((CRMspRpt_cmpSelProjects_Result item) => new CRMspRpt_cmpSelProjects_Result
					{
						ID = item.ID,
						Val = item.Val
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult ConversationShowItems(string mode, string parentIds = "")
	{
		base.ViewBag.mode = mode;
		base.ViewBag.ParentIds = parentIds;
		return View();
	}

	public ActionResult _PartialConversationShowItems(string mode, string parentIds = "")
	{
		base.ViewBag.mode = mode;
		base.ViewBag.ParentIds = parentIds;
		return PartialView();
	}

	public ActionResult ConversationShowItems_Read([DataSourceRequest] DataSourceRequest request, string mode, string parentIds = "")
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
		List<CrmListItemViewModel> list = new List<CrmListItemViewModel>();
		switch (mode)
		{
		case "ConversationTopic":
			foreach (CRMspRpt_cmpSelConversationTopics_Result item in Enumerable.ToList<CRMspRpt_cmpSelConversationTopics_Result>((IEnumerable<CRMspRpt_cmpSelConversationTopics_Result>)db.CRMspRpt_cmpSelConversationTopics(none, haveNot, lCID, result)))
			{
				if (item.ID != 0 && item.ID != -1 && item.ID != -100)
				{
					CrmListItemViewModel crmListItemViewModel = new CrmListItemViewModel();
					crmListItemViewModel.ItemId = item.ID;
					crmListItemViewModel.ItemName = item.Val;
					list.Add(crmListItemViewModel);
				}
			}
			break;
		case "ConversationUser":
			foreach (CRMspRpt_cmpSelConversationUsers_Result item2 in Enumerable.ToList<CRMspRpt_cmpSelConversationUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelConversationUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelConversationUsers_Result>)db.CRMspRpt_cmpSelConversationUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelConversationUsers_Result, int>)((CRMspRpt_cmpSelConversationUsers_Result c) => c.ord))))
			{
				if (item2.ID != 0 && item2.ID.GetValueOrDefault() != -1 && item2.ID.GetValueOrDefault() != -100)
				{
					CrmListItemViewModel crmListItemViewModel2 = new CrmListItemViewModel();
					crmListItemViewModel2.ItemId = item2.ID.GetValueOrDefault();
					crmListItemViewModel2.ItemName = item2.Val;
					list.Add(crmListItemViewModel2);
				}
			}
			break;
		case "ConversationReferUser":
		{
			List<CRMspRpt_cmpSelConversationReferUsers_Result> list4 = Enumerable.ToList<CRMspRpt_cmpSelConversationReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelConversationReferUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)db.CRMspRpt_cmpSelConversationReferUsers(UserLogin.CurrentUser.UserId, none, haveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelConversationReferUsers_Result, int>)((CRMspRpt_cmpSelConversationReferUsers_Result c) => c.ord)));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationReferUsers_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelConversationReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelConversationReferUsers_Result>)list4, (Func<CRMspRpt_cmpSelConversationReferUsers_Result, bool>)((CRMspRpt_cmpSelConversationReferUsers_Result item) => item.ID != 0 && item.ID.GetValueOrDefault() != -1 && item.ID.GetValueOrDefault() != -100)), (Func<CRMspRpt_cmpSelConversationReferUsers_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelConversationReferUsers_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID.GetValueOrDefault(),
				ItemName = item.Val
			})));
			break;
		}
		case "ConversationContainStatus":
		{
			List<CRMspRpt_cmpSelConversationStatusContain_Result> list6 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatusContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)db.CRMspRpt_cmpSelConversationStatusContain(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationStatusContain_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelConversationStatusContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)list6, (Func<CRMspRpt_cmpSelConversationStatusContain_Result, bool>)((CRMspRpt_cmpSelConversationStatusContain_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelConversationStatusContain_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelConversationStatusContain_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "ConversationLastStatus":
		{
			List<CRMspRpt_cmpSelConversationStatus_Result> list3 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatus_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)db.CRMspRpt_cmpSelConversationStatus(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationStatus_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelConversationStatus_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)list3, (Func<CRMspRpt_cmpSelConversationStatus_Result, bool>)((CRMspRpt_cmpSelConversationStatus_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelConversationStatus_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelConversationStatus_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		case "ConversationContainStatusResult":
		{
			if (string.IsNullOrWhiteSpace(parentIds))
			{
				break;
			}
			List<CRMspRpt_cmpSelConversationStatusResultContain_Result> list7 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatusResultContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)_dbII.CRMspRpt_cmpSelConversationStatusResultContain(parentIds, none, haveNot, lCID, result));
			if (list7 != null && Enumerable.Any<CRMspRpt_cmpSelConversationStatusResultContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)list7))
			{
				list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationStatusResultContain_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelConversationStatusResultContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)list7, (Func<CRMspRpt_cmpSelConversationStatusResultContain_Result, bool>)((CRMspRpt_cmpSelConversationStatusResultContain_Result item) => item.ConversationStatusResultId != 0 && item.ConversationStatusResultId != -1 && item.ConversationStatusResultId != -100)), (Func<CRMspRpt_cmpSelConversationStatusResultContain_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelConversationStatusResultContain_Result item) => new CrmListItemViewModel
				{
					ItemId = item.ConversationStatusResultId,
					ItemName = (item.ResultTitle ?? "")
				})));
			}
			break;
		}
		case "ConversationLastStatusResult":
		{
			if (string.IsNullOrWhiteSpace(parentIds))
			{
				break;
			}
			List<CRMspRpt_cmpSelConversationStatusResult_Result> list5 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatusResult_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)_dbII.CRMspRpt_cmpSelConversationStatusResult(parentIds, none, haveNot, lCID, result));
			if (list5 != null && Enumerable.Any<CRMspRpt_cmpSelConversationStatusResult_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)list5))
			{
				list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationStatusResult_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelConversationStatusResult_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)list5, (Func<CRMspRpt_cmpSelConversationStatusResult_Result, bool>)((CRMspRpt_cmpSelConversationStatusResult_Result item) => item.ConversationStatusResultId != 0 && item.ConversationStatusResultId != -1 && item.ConversationStatusResultId != -100)), (Func<CRMspRpt_cmpSelConversationStatusResult_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelConversationStatusResult_Result item) => new CrmListItemViewModel
				{
					ItemId = item.ConversationStatusResultId,
					ItemName = (item.ResultTitle ?? "")
				})));
			}
			break;
		}
		case "ConversationPriority":
		{
			List<CRMspRpt_cmpSelConversationPriority_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelConversationPriority_Result>((IEnumerable<CRMspRpt_cmpSelConversationPriority_Result>)db.CRMspRpt_cmpSelConversationPriority(none, haveNot, lCID, result));
			list.AddRange(Enumerable.Select<CRMspRpt_cmpSelConversationPriority_Result, CrmListItemViewModel>(Enumerable.Where<CRMspRpt_cmpSelConversationPriority_Result>((IEnumerable<CRMspRpt_cmpSelConversationPriority_Result>)list2, (Func<CRMspRpt_cmpSelConversationPriority_Result, bool>)((CRMspRpt_cmpSelConversationPriority_Result item) => item.ID != 0 && item.ID != -1 && item.ID != -100)), (Func<CRMspRpt_cmpSelConversationPriority_Result, CrmListItemViewModel>)((CRMspRpt_cmpSelConversationPriority_Result item) => new CrmListItemViewModel
			{
				ItemId = item.ID,
				ItemName = item.Val
			})));
			break;
		}
		default:
			list = null;
			break;
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SelectAndSearchCompany(string txtSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelectAndSearchCompany_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelectAndSearchCompany_Result>)Enumerable.ToList<CRMspRpt_cmpSelectAndSearchCompany_Result>((IEnumerable<CRMspRpt_cmpSelectAndSearchCompany_Result>)db.CRMspRpt_cmpSelectAndSearchCompany(txtSearch, UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspRpt_cmpSelectAndSearchCompany_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelectAndSearchCompany_Result item) => new CrmDroupDownItem
			{
				text = item.TitleCompany + " " + item.cmpNumber + " " + item.Province + " " + item.City,
				value = item.CompanyID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SelectAndSearchCompanyPersons(string txtSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result>)Enumerable.ToList<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result>((IEnumerable<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result>)db.CRMspRpt_cmpSelectAndSearchCompanyPersons(txtSearch, UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelectAndSearchCompanyPersons_Result item) => new CrmDroupDownItem
			{
				text = item.Person + " " + item.PersonJob + " " + item.TitleCompany,
				value = item.CompanyPersonID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SelectAndSearchProjectDefualtValue(int id, string txtSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		try
		{
			data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result>)Enumerable.ToList<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result>((IEnumerable<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result>)db.CRMspRpt_cmpSelectAndSearchProjectDefualtValue(id, txtSearch, lCID, result)), (Func<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result item) => new CrmDroupDownItem
			{
				text = item.DefualtValue + " " + item.Description,
				value = item.ProjectDefualtValueId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SelectProjectInformations()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
		try
		{
			string none = Labels.None;
			string haveNot = Labels.HaveNot;
			data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspRpt_cmpSelProjectInformations_Result, CrmDroupDownItem>((IEnumerable<CRMspRpt_cmpSelProjectInformations_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectInformations_Result>((IEnumerable<CRMspRpt_cmpSelProjectInformations_Result>)db.CRMspRpt_cmpSelProjectInformations(lCID, result, none, haveNot)), (Func<CRMspRpt_cmpSelProjectInformations_Result, CrmDroupDownItem>)((CRMspRpt_cmpSelProjectInformations_Result item) => new CrmDroupDownItem
			{
				text = item.Val,
				value = item.ID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ActionResult _PartialSmsLoadAndCheckNumberBeforeSend(int mode)
	{
		base.ViewBag.mode = mode;
		return PartialView();
	}

	public ActionResult GetMobileNumber_Read([DataSourceRequest] DataSourceRequest request, int mode)
	{
		List<CRMspSelectUserTempNumberInModeViewModel> enumerable = new List<CRMspSelectUserTempNumberInModeViewModel>();
		try
		{
			db.CRMspUpdateUserTempNumberSelectorInMode(UserLogin.CurrentUser.UserId, mode);
			enumerable = Enumerable.ToList<CRMspSelectUserTempNumberInModeViewModel>(Enumerable.Select<CRMspSelectUserTempNumberInMode_Result, CRMspSelectUserTempNumberInModeViewModel>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)Enumerable.ToList<CRMspSelectUserTempNumberInMode_Result>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)db.CRMspSelectUserTempNumberInMode(UserLogin.CurrentUser.UserId, mode)), (Func<CRMspSelectUserTempNumberInMode_Result, CRMspSelectUserTempNumberInModeViewModel>)((CRMspSelectUserTempNumberInMode_Result item) => new CRMspSelectUserTempNumberInModeViewModel
			{
				ID = item.ID,
				Selector = item.Selector,
				Mobile = item.Mobile,
				CompanyName = item.CompanyName,
				PersonName = item.PersonName,
				Phone = item.Phone,
				CompanyId = item.CompanyId,
				CompanyPersonId = item.CompanyPersonId,
				MobileLength = item.MobileLength,
				MobilePreNum = item.MobilePreNum,
				UserId = item.UserId,
				cmpTitle = item.cmpTitle,
				cmpName = item.cmpName,
				PrsTitle = item.PrsTitle,
				PrsFName = item.PrsFName,
				PrsLName = item.PrsLName,
				PrsJob = item.PrsJob,
				Body = item.Body,
				BodyCount = item.BodyCount,
				BodyLangType = item.BodyLangType,
				BodyCost = item.BodyCost,
				SID = item.SID
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public string GenerateNumberTogether(int mode, string selectedJs = "")
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		int num = 0;
		if (!string.IsNullOrWhiteSpace(selectedJs))
		{
			ObjectParameter objectParameter = new ObjectParameter("ResultId", 0);
			_dbI.CRMspUpdateSmsTempMobileNumbersSelector(UserLogin.CurrentUser.UserId, selectedJs, Configuration.AppType, objectParameter);
			if (objectParameter != null && objectParameter.Value != null && objectParameter.Value.ToString() == "0")
			{
				return "-2";
			}
		}
		List<CRMspSelectUserTempNumberInMode_Result> list = Enumerable.ToList<CRMspSelectUserTempNumberInMode_Result>(Enumerable.Where<CRMspSelectUserTempNumberInMode_Result>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)db.CRMspSelectUserTempNumberInMode(UserLogin.CurrentUser.UserId, 0), (Func<CRMspSelectUserTempNumberInMode_Result, bool>)((CRMspSelectUserTempNumberInMode_Result model) => model.Selector)));
		num = list.Count;
		if (list.Count > 99999)
		{
			return "-1";
		}
		int num2 = 0;
		foreach (CRMspSelectUserTempNumberInMode_Result item in list)
		{
			text = text + item.Mobile + ",";
			text2 = text2 + item.CompanyId + ",";
			text3 = text3 + item.CompanyPersonId + ",";
			num2++;
		}
		text = text.Substring(0, Enumerable.Count<char>((IEnumerable<char>)text) - 1);
		text2 = text2.Substring(0, Enumerable.Count<char>((IEnumerable<char>)text2) - 1);
		text3 = text3.Substring(0, Enumerable.Count<char>((IEnumerable<char>)text3) - 1);
		return text + "|" + text2 + "|" + text3 + "|" + num;
	}

	[AjaxOnly]
	public string GenerateSendWithName(int mode, string bodyText, string selectedJs = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = null;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		string result2 = "";
		string text = "";
		string text2 = "";
		string text3 = "";
		int num = 0;
		int num2 = 0;
		if (!string.IsNullOrWhiteSpace(selectedJs))
		{
			ObjectParameter objectParameter = new ObjectParameter("ResultId", 0);
			_dbI.CRMspUpdateSmsTempMobileNumbersSelector(UserLogin.CurrentUser.UserId, selectedJs, Configuration.AppType, objectParameter);
			if (objectParameter != null && objectParameter.Value != null && objectParameter.Value.ToString() == "0")
			{
				return "-2";
			}
		}
		List<CRMspSelectUserTempNumberInMode_Result> list = Enumerable.ToList<CRMspSelectUserTempNumberInMode_Result>(Enumerable.Where<CRMspSelectUserTempNumberInMode_Result>((IEnumerable<CRMspSelectUserTempNumberInMode_Result>)db.CRMspSelectUserTempNumberInMode(UserLogin.CurrentUser.UserId, 0), (Func<CRMspSelectUserTempNumberInMode_Result, bool>)((CRMspSelectUserTempNumberInMode_Result model) => model.Selector)));
		num2 = list.Count;
		num = list.Count;
		try
		{
			if (num > 99999)
			{
				result2 = "-1";
				return result2;
			}
			string selectedJs2 = "";
			List<CommonSmsTmpNumViewModel> list2 = new List<CommonSmsTmpNumViewModel>();
			if (list != null)
			{
				foreach (CRMspSelectUserTempNumberInMode_Result item2 in list)
				{
					CommonSmsTmpNumViewModel item = new CommonSmsTmpNumViewModel
					{
						Value = item2.ID,
						Selected = item2.Selector
					};
					list2.Add(item);
				}
			}
			if (list2 != null && Enumerable.Any<CommonSmsTmpNumViewModel>((IEnumerable<CommonSmsTmpNumViewModel>)list2))
			{
				selectedJs2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonSmsTmpNumViewModel>((IEnumerable<CommonSmsTmpNumViewModel>)list2));
			}
			int result3 = 0;
			decimal result4 = default(decimal);
			string text4 = "";
			decimal value = default(decimal);
			decimal value2 = default(decimal);
			int freeSmsCount = CRMIdeal.Classes.Helper.Sms.GetFreeSmsCount();
			if (freeSmsCount > 0)
			{
				new SmsSettingInfoViewModel
				{
					SmsWsUserName = "DemoInternal",
					SmsWsPassword = "DemoAllSoftware1391",
					SmsWsDomainNamed = Configuration.SmsWsDomainNamed,
					SmsWsFromNumber = "30002872500500",
					SmsWsEnCost = "300",
					SmsWsFaCost = "150",
					SmsSendIsActive = true,
					SmsReceiveIsActive = false
				};
				value = 300m;
				value2 = 150m;
			}
			else
			{
				SmsSeting.Get();
			}
			string encryptionKey = XorCipher.PreparePublicKeyForSql();
			CRMspUpdateSmsTempMobileNumbersFromSendWithName_Result cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result = Enumerable.FirstOrDefault<CRMspUpdateSmsTempMobileNumbersFromSendWithName_Result>((IEnumerable<CRMspUpdateSmsTempMobileNumbersFromSendWithName_Result>)_dbI.CRMspUpdateSmsTempMobileNumbersFromSendWithName(UserLogin.CurrentUser.UserId, mode, freeSmsCount, value, value2, bodyText, selectedJs2, Configuration.AppType, lCID, result, encryptionKey, centerId));
			if (cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result == null)
			{
				result2 = "-3";
				return result2;
			}
			int.TryParse(cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result.AllWNBodyCount.ToString(), out result3);
			decimal.TryParse(cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result.AllWNBodyCost.ToString(), out result4);
			text4 = cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result.ProtoType ?? "";
			text2 = cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result.Companies ?? "";
			text3 = cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result.CompanyPersons ?? "";
			text = cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result.Numbers ?? "";
			int.TryParse(cRMspUpdateSmsTempMobileNumbersFromSendWithName_Result.NumbersCount.ToString(), out num2);
			result2 = text + "|" + text2 + "|" + text3 + "|" + result3 + "|" + result4 + "|" + text4 + "|" + num2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public int ReturnSmsBodyLength(string body)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int result = 0;
		for (int i = 0; i < body.Length; i++)
		{
			num = char.Parse(body[i].ToString().ToLower());
			if (num < 97 || num > 122)
			{
				switch (num)
				{
				case 32:
					break;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
					num5++;
					continue;
				default:
					if ((num >= 33 && num <= 47) || (num >= 58 && num <= 64) || (num >= 91 && num <= 96) || (num >= 123 && num <= 126))
					{
						num4++;
						continue;
					}
					switch (num)
					{
					case 10:
						num6++;
						break;
					case 13:
						num6 = num6;
						break;
					default:
						num3++;
						break;
					}
					continue;
				}
			}
			num2++;
		}
		if (num3 > 0)
		{
			result = -(num3 + num2 + num4 + num5 + num6);
		}
		if (num3 == 0)
		{
			result = num3 + num2 + num4 + num5 + num6;
		}
		return result;
	}

	public int ReturnSmsBodyCountLatin(int len)
	{
		int num = len;
		int num2 = 0;
		while (num > 0)
		{
			num2++;
			if (num2 == 1)
			{
				num -= 159;
			}
			else if (num2 == 2)
			{
				num = num - 146 - 1;
			}
			else if (num2 > 2)
			{
				num = num - 152 - 1;
			}
		}
		return num2;
	}

	public int ReturnSmsBodyCountFarsi(int len)
	{
		int num = len;
		int num2 = 0;
		while (num > 0)
		{
			num2++;
			if (num2 == 1)
			{
				num -= 70;
			}
			else if (num2 == 2)
			{
				num = num - 63 - 1;
			}
			else if (num2 > 2)
			{
				num = num - 66 - 1;
			}
		}
		return num2;
	}

	public string GetPattern()
	{
		string result = "";
		try
		{
			SmsspSelectSmsSetting_Result smsspSelectSmsSetting_Result = Enumerable.FirstOrDefault<SmsspSelectSmsSetting_Result>((IEnumerable<SmsspSelectSmsSetting_Result>)db.SmsspSelectSmsSetting());
			if (smsspSelectSmsSetting_Result != null)
			{
				result = smsspSelectSmsSetting_Result.CmpTPattern + "|" + smsspSelectSmsSetting_Result.CmpPattern + "|" + smsspSelectSmsSetting_Result.PrsTPattern + "|" + smsspSelectSmsSetting_Result.PrsFNPattern + "|" + smsspSelectSmsSetting_Result.PrsLNPattern + "|" + smsspSelectSmsSetting_Result.PrsJobPattern + "|" + smsspSelectSmsSetting_Result.CmpUserNamePattern + "|" + smsspSelectSmsSetting_Result.CmpPasswordPattern + "|[#امتیاز مخاطب#]";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string DeleteDupMobNum()
	{
		string result = "-1";
		try
		{
			db.CRMspDeleteDuplicateFromTempMobNum(UserLogin.CurrentUser.UserId);
			result = "1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string SelOrDeSelMobNum(int lstId, bool selectItem)
	{
		string result = "-1";
		try
		{
			if (lstId != 0)
			{
				SmsTempMobileNumbers smsTempMobileNumbers = _dbTbl.SmsTempMobileNumbers.Find(lstId);
				if (smsTempMobileNumbers != null)
				{
					smsTempMobileNumbers.Selector = selectItem;
					smsTempMobileNumbers.AppType = Configuration.AppType;
					_dbTbl.Entry(smsTempMobileNumbers).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public CrmCompanyReportViewModel SetDefultValue(CrmCompanyReportViewModel cmpReport)
	{
		cmpReport.cmpTitleIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpTitleIdTitle)) ? cmpReport.cmpTitleIdTitle : "0");
		cmpReport.cmpPresentationIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpPresentationIdTitle)) ? cmpReport.cmpPresentationIdTitle : "0");
		cmpReport.cmpTypeIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpTypeIdTitle)) ? cmpReport.cmpTypeIdTitle : "0");
		cmpReport.cmpCountryIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpCountryIdTitle)) ? cmpReport.cmpCountryIdTitle : "0");
		cmpReport.cmpProvinceIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpProvinceIdTitle)) ? cmpReport.cmpProvinceIdTitle : "0");
		cmpReport.cmpCityIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpCityIdTitle)) ? cmpReport.cmpCityIdTitle : "0");
		cmpReport.cmpActivityType = ((!string.IsNullOrEmpty(cmpReport.cmpActivityType)) ? cmpReport.cmpActivityType : "");
		cmpReport.cmpName = ((!string.IsNullOrEmpty(cmpReport.cmpName)) ? cmpReport.cmpName : "");
		cmpReport.cmpOtherFields = ((!string.IsNullOrEmpty(cmpReport.cmpOtherFields)) ? cmpReport.cmpOtherFields : "0");
		cmpReport.cmpSimilarValue = ((!string.IsNullOrEmpty(cmpReport.cmpSimilarValue)) ? cmpReport.cmpSimilarValue : "0");
		cmpReport.cmpOtherFieldValueLikely = ((!string.IsNullOrEmpty(cmpReport.cmpOtherFieldValueLikely)) ? cmpReport.cmpOtherFieldValueLikely : "0");
		cmpReport.cmpGroupIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdTitle)) ? cmpReport.cmpGroupIdTitle : "0");
		cmpReport.cmpSubGroupIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpSubGroupIdTitle)) ? cmpReport.cmpSubGroupIdTitle : "0");
		cmpReport.cmpGroupIdIITitle = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdIITitle)) ? cmpReport.cmpGroupIdIITitle : "0");
		cmpReport.cmpGroupIdIIITitle = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdIIITitle)) ? cmpReport.cmpGroupIdIIITitle : "0");
		cmpReport.cmpGroupIdIVTitle = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdIVTitle)) ? cmpReport.cmpGroupIdIVTitle : "0");
		cmpReport.cmpGroupIdMultiTitle = ((!string.IsNullOrEmpty(cmpReport.cmpGroupIdMultiTitle)) ? cmpReport.cmpGroupIdMultiTitle : "0");
		cmpReport.cmpTypeDateForSearch = ((!string.IsNullOrEmpty(cmpReport.cmpTypeDateForSearch)) ? cmpReport.cmpTypeDateForSearch : "0");
		cmpReport.cmpFromDate = ((!string.IsNullOrEmpty(cmpReport.cmpFromDate)) ? cmpReport.cmpFromDate : "0");
		cmpReport.cmpToDate = ((!string.IsNullOrEmpty(cmpReport.cmpToDate)) ? cmpReport.cmpToDate : "0");
		cmpReport.cmpReferUserIdTitle = ((!string.IsNullOrEmpty(cmpReport.cmpReferUserIdTitle)) ? cmpReport.cmpReferUserIdTitle : "0");
		cmpReport.prsTitleIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsTitleIdTitle)) ? cmpReport.prsTitleIdTitle : "0");
		cmpReport.prsJobIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsJobIdTitle)) ? cmpReport.prsJobIdTitle : "0");
		cmpReport.prsDepartmentIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsDepartmentIdTitle)) ? cmpReport.prsDepartmentIdTitle : "0");
		cmpReport.prsTypeIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsTypeIdTitle)) ? cmpReport.prsTypeIdTitle : "0");
		cmpReport.prsGroupIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsGroupIdTitle)) ? cmpReport.prsGroupIdTitle : "0");
		cmpReport.prsSexIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsSexIdTitle)) ? cmpReport.prsSexIdTitle : "0");
		cmpReport.prsEducationField = ((!string.IsNullOrEmpty(cmpReport.prsEducationField)) ? cmpReport.prsEducationField : "0");
		cmpReport.prsCountryIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsCountryIdTitle)) ? cmpReport.prsCountryIdTitle : "0");
		cmpReport.prsProvinceIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsProvinceIdTitle)) ? cmpReport.prsProvinceIdTitle : "0");
		cmpReport.prsCityIdTitle = ((!string.IsNullOrEmpty(cmpReport.prsCityIdTitle)) ? cmpReport.prsCityIdTitle : "0");
		cmpReport.prsOtherFields = ((!string.IsNullOrEmpty(cmpReport.prsOtherFields)) ? cmpReport.prsOtherFields : "0");
		cmpReport.prsSimilarValue = ((!string.IsNullOrEmpty(cmpReport.prsSimilarValue)) ? cmpReport.prsSimilarValue : "0");
		cmpReport.prsOtherFieldValueLikely = ((!string.IsNullOrEmpty(cmpReport.prsOtherFieldValueLikely)) ? cmpReport.prsOtherFieldValueLikely : "0");
		cmpReport.prsTypeDateForSearch = ((!string.IsNullOrEmpty(cmpReport.prsTypeDateForSearch)) ? cmpReport.prsTypeDateForSearch : "0");
		cmpReport.prsFromDate = ((!string.IsNullOrEmpty(cmpReport.prsFromDate)) ? cmpReport.prsFromDate : "0");
		if (!string.IsNullOrEmpty(cmpReport.prsToDate))
		{
			_ = cmpReport.prsToDate;
		}
		cmpReport.prjTitle = ((!string.IsNullOrEmpty(cmpReport.prjTitle)) ? cmpReport.prjTitle : "0");
		cmpReport.prjGroupIdTitle = ((!string.IsNullOrEmpty(cmpReport.prjGroupIdTitle)) ? cmpReport.prjGroupIdTitle : "0");
		cmpReport.prjPriorityIdTitle = ((!string.IsNullOrEmpty(cmpReport.prjPriorityIdTitle)) ? cmpReport.prjPriorityIdTitle : "0");
		cmpReport.prjGradeIdTitle = ((!string.IsNullOrEmpty(cmpReport.prjGradeIdTitle)) ? cmpReport.prjGradeIdTitle : "0");
		cmpReport.prjIsFinished = ((!string.IsNullOrEmpty(cmpReport.prjIsFinished)) ? cmpReport.prjIsFinished : "0");
		cmpReport.prjcnvsStatusGroupIdTitle = ((!string.IsNullOrEmpty(cmpReport.prjcnvsStatusGroupIdTitle)) ? cmpReport.prjcnvsStatusGroupIdTitle : "0");
		cmpReport.prjFirstRegisterUserIdTitle = ((!string.IsNullOrEmpty(cmpReport.prjFirstRegisterUserIdTitle)) ? cmpReport.prjFirstRegisterUserIdTitle : "0");
		cmpReport.prjUserIdTitle = ((!string.IsNullOrEmpty(cmpReport.prjUserIdTitle)) ? cmpReport.prjUserIdTitle : "0");
		cmpReport.prjGroupsMulti = ((!string.IsNullOrEmpty(cmpReport.prjGroupsMulti)) ? cmpReport.prjGroupsMulti : "0");
		cmpReport.prjGroupsMultiI = ((!string.IsNullOrEmpty(cmpReport.prjGroupsMultiI)) ? cmpReport.prjGroupsMultiI : "0");
		cmpReport.drpPrjTreeInfo = ((!string.IsNullOrEmpty(cmpReport.drpPrjTreeInfo)) ? cmpReport.drpPrjTreeInfo : "0");
		cmpReport.prjTreeInfo = ((!string.IsNullOrEmpty(cmpReport.prjTreeInfo)) ? cmpReport.prjTreeInfo : "0");
		cmpReport.prjOtherFields = ((!string.IsNullOrEmpty(cmpReport.prjOtherFields)) ? cmpReport.prjOtherFields : "0");
		cmpReport.prjSimilarValue = ((!string.IsNullOrEmpty(cmpReport.prjSimilarValue)) ? cmpReport.prjSimilarValue : "0");
		cmpReport.prjOtherFieldValueLikely = ((!string.IsNullOrEmpty(cmpReport.prjOtherFieldValueLikely)) ? cmpReport.prjOtherFieldValueLikely : "0");
		cmpReport.prjTypeDateForSearch = ((!string.IsNullOrEmpty(cmpReport.prjTypeDateForSearch)) ? cmpReport.prjTypeDateForSearch : "0");
		cmpReport.prjFromDate = ((!string.IsNullOrEmpty(cmpReport.prjFromDate)) ? cmpReport.prjFromDate : "0");
		cmpReport.prjToDate = ((!string.IsNullOrEmpty(cmpReport.prjToDate)) ? cmpReport.prjToDate : "0");
		cmpReport.cnvsTopicIdTitle = ((!string.IsNullOrEmpty(cmpReport.cnvsTopicIdTitle)) ? cmpReport.cnvsTopicIdTitle : "0");
		cmpReport.cnvsUserIdTitle = ((!string.IsNullOrEmpty(cmpReport.cnvsUserIdTitle)) ? cmpReport.cnvsUserIdTitle : "0");
		cmpReport.cnvsReferUserIdTitle = ((!string.IsNullOrEmpty(cmpReport.cnvsReferUserIdTitle)) ? cmpReport.cnvsReferUserIdTitle : "0");
		cmpReport.cnvsLastStatus = ((!string.IsNullOrEmpty(cmpReport.cnvsLastStatus)) ? cmpReport.cnvsLastStatus : "0");
		cmpReport.cnvsContainStatus = ((!string.IsNullOrEmpty(cmpReport.cnvsContainStatus)) ? cmpReport.cnvsContainStatus : "0");
		cmpReport.cnvsMinPercentage = cmpReport.cnvsMinPercentage.GetValueOrDefault();
		cmpReport.cnvsMaxPercentage = cmpReport.cnvsMaxPercentage.GetValueOrDefault();
		cmpReport.cnvsPriorityIdTitle = ((!string.IsNullOrEmpty(cmpReport.cnvsPriorityIdTitle)) ? cmpReport.cnvsPriorityIdTitle : "0");
		cmpReport.cnvsOtherFields = ((!string.IsNullOrEmpty(cmpReport.cnvsOtherFields)) ? cmpReport.cnvsOtherFields : "0");
		cmpReport.cnvsSimilarValue = ((!string.IsNullOrEmpty(cmpReport.cnvsSimilarValue)) ? cmpReport.cnvsSimilarValue : "0");
		cmpReport.cnvsOtherFieldValueLikely = ((!string.IsNullOrEmpty(cmpReport.cnvsOtherFieldValueLikely)) ? cmpReport.cnvsOtherFieldValueLikely : "0");
		cmpReport.cnvsTypeDateForSearch = ((!string.IsNullOrEmpty(cmpReport.cnvsTypeDateForSearch)) ? cmpReport.cnvsTypeDateForSearch : "0");
		cmpReport.cnvsFromDate = ((!string.IsNullOrEmpty(cmpReport.cnvsFromDate)) ? cmpReport.cnvsFromDate : "0");
		cmpReport.cnvsToDate = ((!string.IsNullOrEmpty(cmpReport.cnvsToDate)) ? cmpReport.cnvsToDate : "0");
		cmpReport.prsSel = cmpReport.prsSel.GetValueOrDefault();
		cmpReport.prjSel = cmpReport.prjSel.GetValueOrDefault();
		cmpReport.cnvsSel = cmpReport.cnvsSel.GetValueOrDefault();
		if (cmpReport.cmpTypeDateForSearch != "ImportDate" && cmpReport.cmpTypeDateForSearch != "RegisterDatePersian" && cmpReport.cmpTypeDateForSearch != "cmpEffectiveDatePersian" && cmpReport.cmpTypeDateForSearch != "cmpCRMShopActiveDate")
		{
			cmpReport.cmpTypeDateForSearch = "0";
			cmpReport.cmpFromDate = "0";
			cmpReport.cmpToDate = "0";
		}
		if (cmpReport.prsTypeDateForSearch != "ImportDate" && cmpReport.prsTypeDateForSearch != "RegisterDatePersian")
		{
			cmpReport.prsTypeDateForSearch = "0";
			cmpReport.prsFromDate = "0";
			cmpReport.prsToDate = "0";
		}
		if (cmpReport.prjTypeDateForSearch != "prjFirstRegisterDate" && cmpReport.prjTypeDateForSearch != "RegisterDatePersian")
		{
			cmpReport.prjTypeDateForSearch = "0";
			cmpReport.prjFromDate = "0";
			cmpReport.prjToDate = "0";
		}
		if (cmpReport.cnvsTypeDateForSearch != "cnvsFirstRegisterDate" && cmpReport.cnvsTypeDateForSearch != "RegisterDatePersian")
		{
			cmpReport.cnvsTypeDateForSearch = "0";
			cmpReport.cnvsFromDate = "0";
			cmpReport.cnvsToDate = "0";
		}
		string haveCompare = Labels.HaveCompare;
		string haveNotCompare = Labels.HaveNotCompare;
		if (cmpReport.cmpActivityType == haveNotCompare)
		{
			cmpReport.cmpActivityType = "-1";
		}
		if (cmpReport.cmpActivityType == haveCompare)
		{
			cmpReport.cmpActivityType = "-2";
		}
		if (cmpReport.cmpSimilarValue == haveNotCompare)
		{
			cmpReport.cmpSimilarValue = "-1";
		}
		if (cmpReport.cmpSimilarValue == haveCompare)
		{
			cmpReport.cmpSimilarValue = "-2";
		}
		if (cmpReport.prsSimilarValue == haveNotCompare)
		{
			cmpReport.prsSimilarValue = "-1";
		}
		if (cmpReport.prsSimilarValue == haveCompare)
		{
			cmpReport.prsSimilarValue = "-2";
		}
		if (cmpReport.cnvsSimilarValue == haveNotCompare)
		{
			cmpReport.cnvsSimilarValue = "-1";
		}
		if (cmpReport.cnvsSimilarValue == haveCompare)
		{
			cmpReport.cnvsSimilarValue = "-2";
		}
		if (cmpReport.prjPostFix == haveNotCompare)
		{
			cmpReport.prjPostFix = "-1";
		}
		if (cmpReport.prjPostFix == haveCompare)
		{
			cmpReport.prjPostFix = "-2";
		}
		return cmpReport;
	}

	public List<TreeViewItemModel> GetCompanyCampaignNodeTree(List<CRMspRpt_cmpSelCompanyCampaignTree_Result> lstCamp, int? currCamId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspRpt_cmpSelCompanyCampaignTree_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyCampaignTree_Result>(Enumerable.Where<CRMspRpt_cmpSelCompanyCampaignTree_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCampaignTree_Result>)lstCamp, (Func<CRMspRpt_cmpSelCompanyCampaignTree_Result, bool>)((CRMspRpt_cmpSelCompanyCampaignTree_Result m) => m.ParentId == currCamId)));
			if (Enumerable.Any<CRMspRpt_cmpSelCompanyCampaignTree_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCampaignTree_Result>)list2))
			{
				foreach (CRMspRpt_cmpSelCompanyCampaignTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.CompanyCampaignId.ToString()));
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("campaignFullName", item.CampaignFullName.ToString()));
					treeViewItemModel.Id = item.CompanyCampaignId.ToString();
					treeViewItemModel.Text = item.CampaignName;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> companyCampaignNodeTree = GetCompanyCampaignNodeTree(lstCamp, item.CompanyCampaignId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(companyCampaignNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetCompanyCampaignTree()
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_cmpSelCompanyCampaignTree_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyCampaignTree_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCampaignTree_Result>)_dbI.CRMspRpt_cmpSelCompanyCampaignTree(lCID, result));
			if (Enumerable.Any<CRMspRpt_cmpSelCompanyCampaignTree_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCampaignTree_Result>)list2))
			{
				List<CRMspRpt_cmpSelCompanyCampaignTree_Result> list3 = Enumerable.ToList<CRMspRpt_cmpSelCompanyCampaignTree_Result>(Enumerable.Where<CRMspRpt_cmpSelCompanyCampaignTree_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCampaignTree_Result>)list2, (Func<CRMspRpt_cmpSelCompanyCampaignTree_Result, bool>)((CRMspRpt_cmpSelCompanyCampaignTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspRpt_cmpSelCompanyCampaignTree_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCampaignTree_Result>)list3))
				{
					foreach (CRMspRpt_cmpSelCompanyCampaignTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.CompanyCampaignId.ToString()));
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("campaignFullName", item.CampaignFullName.ToString()));
						treeViewItemModel.Id = item.CompanyCampaignId.ToString();
						treeViewItemModel.Text = item.CampaignName;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> companyCampaignNodeTree = GetCompanyCampaignNodeTree(list2, item.CompanyCampaignId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(companyCampaignNodeTree);
						list.Add(treeViewItemModel);
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialCompanyCampaignTree()
	{
		try
		{
			List<TreeViewItemModel> companyCampaignTree = GetCompanyCampaignTree();
			base.ViewBag.cmpCampaignTree = companyCampaignTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialProjectCompanyCampaignTree()
	{
		try
		{
			List<TreeViewItemModel> companyCampaignTree = GetCompanyCampaignTree();
			base.ViewBag.prjcmpCampaignTree = companyCampaignTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	public ActionResult SetCompanyReportByType(int typeId)
	{
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			string appType = Configuration.AppType;
			string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_dbII.CRMspInsertAndDeleteSysDBTempInfo(1, typeId, userId, firstRegisterDatePersian, lCID, appType);
			return Json(1, JsonRequestBehavior.AllowGet);
		}
		catch (Exception)
		{
			return Json(0, JsonRequestBehavior.AllowGet);
		}
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actArchiveProject")]
	public ActionResult ArchiveProject(string mode, string textTerm)
	{
		base.ViewBag.TextTerm = textTerm;
		FillDropdownArchiveProject();
		return View();
	}

	[AjaxOnly]
	public string ProjectsToArchive(string prjFinishUsers, string prjFinishedDay, string prjFinishedDate, string prjFinishedTime)
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
			if (prjFinishUsers != null && prjFinishedDay != null && prjFinishedDate != null && prjFinishedTime != null)
			{
				DateTime value = DateTime.Parse(prjFinishedDate + " " + prjFinishedTime);
				prjFinishedDate = prjFinishedDate.Replace("/", "");
				DateTime dateTime = default(DateTime);
				string text2 = "";
				try
				{
					if (!string.IsNullOrEmpty(prjFinishedDate))
					{
						text2 = PersianDate.GetFormatetdDate(prjFinishedDate.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + prjFinishedTime, new PersianCulture());
							prjFinishedDate = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + prjFinishedTime, new CultureInfo("ar-SA"));
							prjFinishedDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + prjFinishedTime, new CultureInfo("en-US"));
							prjFinishedDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						value = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = "-1|" + Messages.ErrorFormatDatePersian;
				}
				int userId = UserLogin.CurrentUser.UserId;
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				if (db.CRMspUpdateFilterProjectsToArchive(userId, prjFinishedDate, prjFinishedDay, prjFinishedTime, value, prjFinishUsers, registerDatePersian, appType) > 0)
				{
					return "1|" + Messages.msgSuccessActionArchiveProject;
				}
				return "-1|" + Messages.msgErrorRunFunction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actArchiveProject")]
	public ActionResult ArchiveProjectExit(string mode, string textTerm)
	{
		base.ViewBag.TextTerm = textTerm;
		return View();
	}

	[AjaxOnly]
	public string ProjectsToArchiveExit()
	{
		string text = "";
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			if (db.CRMspUpdateFilterProjectsExitFromArchive(userId, registerDatePersian, appType) > 0)
			{
				return "1|" + Messages.msgSuccessActionArchiveProject;
			}
			return "-1|" + Messages.msgErrorRunFunction;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	private void FillDropdownArchiveProject()
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
		List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 12, lCID, result, result2)), (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
		{
			Text = item.UserName,
			Value = item.LinkedUserId.ToString(),
			Selected = false
		})));
		base.ViewBag.PrjFinishUsers = list;
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.Add(new SelectListItem
		{
			Text = Labels.Saturday,
			Value = "7",
			Selected = false
		});
		list2.Add(new SelectListItem
		{
			Text = Labels.Sunday,
			Value = "1",
			Selected = false
		});
		list2.Add(new SelectListItem
		{
			Text = Labels.Monday,
			Value = "2",
			Selected = false
		});
		list2.Add(new SelectListItem
		{
			Text = Labels.Tuesday,
			Value = "3",
			Selected = false
		});
		list2.Add(new SelectListItem
		{
			Text = Labels.Wednesday,
			Value = "4",
			Selected = false
		});
		list2.Add(new SelectListItem
		{
			Text = Labels.Thursday,
			Value = "5",
			Selected = false
		});
		list2.Add(new SelectListItem
		{
			Text = Labels.Friday,
			Value = "6",
			Selected = false
		});
		base.ViewBag.Dayslist = list2;
	}

	public ActionResult SelectPrintRange(int printFormatTypeId, string prtParameter, string typeReport, bool? isEncrypt = null)
	{
		base.ViewBag.PrtParameter = prtParameter;
		base.ViewBag.TypeReport = typeReport;
		base.ViewBag.PrintFormatTypeId = printFormatTypeId;
		return View();
	}

	public ActionResult SelectPrintRange_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, int pageSize)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspRptCompanyFilterDataViewModel> enumerable = new List<CRMspRptCompanyFilterDataViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			enumerable = Enumerable.ToList<CRMspRptCompanyFilterDataViewModel>(Enumerable.Select<mct_CRMspRpt_CompanyFilterData_Result, CRMspRptCompanyFilterDataViewModel>((IEnumerable<mct_CRMspRpt_CompanyFilterData_Result>)Enumerable.ToList<mct_CRMspRpt_CompanyFilterData_Result>(Enumerable.Take<mct_CRMspRpt_CompanyFilterData_Result>(Enumerable.Skip<mct_CRMspRpt_CompanyFilterData_Result>((IEnumerable<mct_CRMspRpt_CompanyFilterData_Result>)db.mfi_CRMspRpt_CompanyFilterDataFillParam(UserLogin.CurrentUser.UserId, 2, result2), (pageNumber - 1) * pageSize), pageSize)), (Func<mct_CRMspRpt_CompanyFilterData_Result, CRMspRptCompanyFilterDataViewModel>)((mct_CRMspRpt_CompanyFilterData_Result item) => new CRMspRptCompanyFilterDataViewModel
			{
				CompanyID = item.CompanyID,
				cmpNumber = item.cmpNumber,
				cmpName = item.cmpName,
				prsName = item.prsName,
				cmpActivityType = item.cmpActivityType,
				prjTitle = item.prjTitle,
				ConversationStatus = item.ConversationStatus,
				ProjectId = item.ProjectId
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public JsonResult DeleteAllCmpWithDepFormWithData()
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCompanyReport", "actDeleteAllCmpWithDepFormWithData", UserLogin.CurrentUser))
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.msgErrorRunFunction,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			List<CRMspSelectCompanyFilesFromRptFilterData_Result> list = Enumerable.ToList<CRMspSelectCompanyFilesFromRptFilterData_Result>((IEnumerable<CRMspSelectCompanyFilesFromRptFilterData_Result>)_dbI.CRMspSelectCompanyFilesFromRptFilterData(UserLogin.CurrentUser.UserId, lCID, result2));
			string text3 = "";
			text = "";
			List<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result> list2 = Enumerable.ToList<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>((IEnumerable<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>)_dbI.CRMspDeleteAllCompanyWithDependenciesFromRptFilterData(UserLogin.CurrentUser.UserId, lCID, result2, result));
			if (list2 != null && Enumerable.Any<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>((IEnumerable<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>)list2))
			{
				text = "error";
				text3 = GetFileDeleteAllCmpWithDependenciesFormWithData(list2);
			}
			try
			{
				if ((list != null) & Enumerable.Any<CRMspSelectCompanyFilesFromRptFilterData_Result>((IEnumerable<CRMspSelectCompanyFilesFromRptFilterData_Result>)list))
				{
					foreach (CRMspSelectCompanyFilesFromRptFilterData_Result item in list)
					{
						bool flag = true;
						if (list2 != null && Enumerable.Any<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>((IEnumerable<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>)list2) && Enumerable.FirstOrDefault<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>((IEnumerable<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>)list2, (Func<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result, bool>)((CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result m) => m.CompanyId == item.MasterId.GetValueOrDefault())) != null)
						{
							flag = false;
						}
						if (flag)
						{
							new CompanyInfoController().DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
						}
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				text2 = Messages.msgNotCompeleteSuccessAction;
				text2 = text2 + "<br><a href='" + text3 + "' class='link-excel-file'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
			}
			else
			{
				text2 = Messages.msgSuccessAction;
			}
			commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = "";
			text2 = Messages.msgErrorRunFunction;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
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

	public string GetFileDeleteAllCmpWithDependenciesFormWithData(List<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result> res)
	{
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>((IEnumerable<CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.CmpRptExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.CmpRptExcelListCompanyName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.CmpRptExcelListCompanyNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.frmError;
				foreach (CRMspDeleteAllCompanyWithDependenciesFromRptFilterData_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					string text2 = "";
					string text3 = re.TypeError ?? "";
					if (!string.IsNullOrWhiteSpace(text3))
					{
						string[] array = text3.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "0")
							{
								text2 = Messages.msgErrorRunFunction;
							}
							else
							{
								if (text3.IndexOf("-1", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + "msgErrCmpHasOrd".OrderMessages() + ", ";
								}
								if (text3.IndexOf("-2", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + Messages.msgErrCmpHasBord + ", ";
								}
								if (text3.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + Messages.msgErrCmpHasDoc + ", ";
								}
								if (text3.IndexOf("-4", StringComparison.Ordinal) >= 0)
								{
									text2 += Messages.msgErrCmpHasCtsh;
								}
								if (text3.IndexOf("-5", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + string.Format(Messages.msgErrorNotDeleteItemLinkedByCenter, Labels.lblCmp) + "<br>";
								}
							}
						}
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = text2;
				}
				string text4 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportCmpFilterData\\" + UserLogin.CurrentUser.UserId;
				string text5 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text4 + "\\" + text5;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text4);
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						files[i].Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int i = 0; i < directories.Length; i++)
					{
						directories[i].Delete(recursive: true);
					}
					if (System.IO.Directory.Exists(text4))
					{
						System.IO.Directory.Delete(text4);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text4))
				{
					System.IO.Directory.CreateDirectory(text4);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.CmpRptExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.GenerateAutoCmpUPExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportCmpFilterData/" + userId + "/" + text5;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}
}
