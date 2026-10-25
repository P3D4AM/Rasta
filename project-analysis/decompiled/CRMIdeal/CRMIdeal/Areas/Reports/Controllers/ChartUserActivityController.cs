using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.ChartUserActivityRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class ChartUserActivityController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptChartUserActivity")]
	public ActionResult Index()
	{
		GetUserList();
		ChartUserActivityViewModel chartUserActivityViewModel = new ChartUserActivityViewModel();
		DateTime now = DateTime.Now;
		string fromDate = (chartUserActivityViewModel.ToDate = now.ToString("yyyy/MM/dd"));
		chartUserActivityViewModel.FromDate = fromDate;
		return View(chartUserActivityViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptChartUserActivity")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(ChartUserActivityViewModel model)
	{
		try
		{
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				base.TempData["model"] = model;
				base.ViewBag.Successfull = "ok";
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
		}
		GetUserList();
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetUserList(int? id = null)
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
			if (!id.HasValue)
			{
				id = UserLogin.CurrentUser.UserId;
			}
			List<CRMspSelectSingleUsersForRepParam_Result> list2 = Enumerable.ToList<CRMspSelectSingleUsersForRepParam_Result>((IEnumerable<CRMspSelectSingleUsersForRepParam_Result>)_db.CRMspSelectSingleUsersForRepParam(id, 2, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectSingleUsersForRepParam_Result, SelectListItem>((IEnumerable<CRMspSelectSingleUsersForRepParam_Result>)list2, (Func<CRMspSelectSingleUsersForRepParam_Result, SelectListItem>)((CRMspSelectSingleUsersForRepParam_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptChartUserActivity")]
	public ActionResult Print(string model, string fileName)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		ChartUserActivityViewModel value = new ChartUserActivityViewModel();
		if (model != "")
		{
			value = new JavaScriptSerializer().Deserialize<ChartUserActivityViewModel>(model);
		}
		base.TempData["model"] = value;
		base.TempData["FileName"] = fileName;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_1463: Unknown result type (might be due to invalid IL or missing references)
		//IL_1481: Unknown result type (might be due to invalid IL or missing references)
		//IL_1488: Expected O, but got Unknown
		//IL_14b3: Unknown result type (might be due to invalid IL or missing references)
		StiReport stiReport = new StiReport();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result2);
				base.TempData["PFCId"] = null;
			}
			ChartUserActivityViewModel chartUserActivityViewModel = new ChartUserActivityViewModel();
			if (base.TempData["model"] != null)
			{
				chartUserActivityViewModel = (ChartUserActivityViewModel)base.TempData["model"];
			}
			base.TempData["model"] = null;
			chartUserActivityViewModel.ToDate = chartUserActivityViewModel.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			chartUserActivityViewModel.FromDate = chartUserActivityViewModel.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(chartUserActivityViewModel.FromDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(chartUserActivityViewModel.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(chartUserActivityViewModel.ToDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(chartUserActivityViewModel.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			string unspecify = Labels.Unspecify;
			string conversationReferedToSpecificUser = Labels.ConversationReferedToSpecificUser;
			string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
			string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
			string text3 = base.TempData["FileName"].ToString();
			base.TempData["FileName"] = null;
			DateTime now = DateTime.Now;
			Parameters parameters = new Parameters();
			CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
			parameters.SysSetting = reports.GetSysSetting();
			byte[] coLoGo = SysSeting.Get().CoLoGo;
			if (coLoGo != null && coLoGo.Length != 0)
			{
				parameters.CoLogo = Convert.ToBase64String(coLoGo);
			}
			parameters.ReportDateTime = now;
			parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
			parameters.NotUsed_ListChartUserActivity = Enumerable.ToList<CRMspRpt_ChartUserActivity_Result>((IEnumerable<CRMspRpt_ChartUserActivity_Result>)_db.CRMspRpt_ChartUserActivity(UserLogin.CurrentUser.UserId, now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, chartUserActivityViewModel.UserId, lCID, result));
			parameters.NotUsed_ListChartAllcmpInMonth = Enumerable.ToList<CRMspRpt_ChartAllcmpInMonth_Result>((IEnumerable<CRMspRpt_ChartAllcmpInMonth_Result>)_db.CRMspRpt_ChartAllcmpInMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartCmpPresentation = Enumerable.ToList<CRMspRpt_ChartCmpPresentation_Result>((IEnumerable<CRMspRpt_ChartCmpPresentation_Result>)_db.CRMspRpt_ChartCmpPresentation(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpTitle = Enumerable.ToList<CRMspRpt_ChartCmpTitle_Result>((IEnumerable<CRMspRpt_ChartCmpTitle_Result>)_db.CRMspRpt_ChartCmpTitle(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroup = Enumerable.ToList<CRMspRpt_ChartCmpGroup_Result>((IEnumerable<CRMspRpt_ChartCmpGroup_Result>)_db.CRMspRpt_ChartCmpGroup(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpSubGroup = Enumerable.ToList<CRMspRpt_ChartCmpSubGroup_Result>((IEnumerable<CRMspRpt_ChartCmpSubGroup_Result>)_db.CRMspRpt_ChartCmpSubGroup(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupII = Enumerable.ToList<CRMspRpt_ChartCmpGroupII_Result>((IEnumerable<CRMspRpt_ChartCmpGroupII_Result>)_db.CRMspRpt_ChartCmpGroupII(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupIII = Enumerable.ToList<CRMspRpt_ChartCmpGroupIII_Result>((IEnumerable<CRMspRpt_ChartCmpGroupIII_Result>)_db.CRMspRpt_ChartCmpGroupIII(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupIV = Enumerable.ToList<CRMspRpt_ChartCmpGroupIV_Result>((IEnumerable<CRMspRpt_ChartCmpGroupIV_Result>)_db.CRMspRpt_ChartCmpGroupIV(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpType = Enumerable.ToList<CRMspRpt_ChartCmpType_Result>((IEnumerable<CRMspRpt_ChartCmpType_Result>)_db.CRMspRpt_ChartCmpType(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpCountry = Enumerable.ToList<CRMspRpt_ChartCmpCountry_Result>((IEnumerable<CRMspRpt_ChartCmpCountry_Result>)_db.CRMspRpt_ChartCmpCountry(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpProvince = Enumerable.ToList<CRMspRpt_ChartCmpProvince_Result>((IEnumerable<CRMspRpt_ChartCmpProvince_Result>)_db.CRMspRpt_ChartCmpProvince(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpCity = Enumerable.ToList<CRMspRpt_ChartCmpCity_Result>((IEnumerable<CRMspRpt_ChartCmpCity_Result>)_db.CRMspRpt_ChartCmpCity(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpUser = Enumerable.ToList<CRMspRpt_ChartCmpUser_Result>((IEnumerable<CRMspRpt_ChartCmpUser_Result>)_db.CRMspRpt_ChartCmpUser(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpPresentationMonth = Enumerable.ToList<CRMspRpt_ChartCmpPresentationMonth_Result>((IEnumerable<CRMspRpt_ChartCmpPresentationMonth_Result>)_db.CRMspRpt_ChartCmpPresentationMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpTitleMonth = Enumerable.ToList<CRMspRpt_ChartCmpTitleMonth_Result>((IEnumerable<CRMspRpt_ChartCmpTitleMonth_Result>)_db.CRMspRpt_ChartCmpTitleMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupMonth = Enumerable.ToList<CRMspRpt_ChartCmpGroupMonth_Result>((IEnumerable<CRMspRpt_ChartCmpGroupMonth_Result>)_db.CRMspRpt_ChartCmpGroupMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpSubGroupMonth = Enumerable.ToList<CRMspRpt_ChartCmpSubGroupMonth_Result>((IEnumerable<CRMspRpt_ChartCmpSubGroupMonth_Result>)_db.CRMspRpt_ChartCmpSubGroupMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupIIMonth = Enumerable.ToList<CRMspRpt_ChartCmpGroupIIMonth_Result>((IEnumerable<CRMspRpt_ChartCmpGroupIIMonth_Result>)_db.CRMspRpt_ChartCmpGroupIIMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupIIIMonth = Enumerable.ToList<CRMspRpt_ChartCmpGroupIIIMonth_Result>((IEnumerable<CRMspRpt_ChartCmpGroupIIIMonth_Result>)_db.CRMspRpt_ChartCmpGroupIIIMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupIVMonth = Enumerable.ToList<CRMspRpt_ChartCmpGroupIVMonth_Result>((IEnumerable<CRMspRpt_ChartCmpGroupIVMonth_Result>)_db.CRMspRpt_ChartCmpGroupIVMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpTypeMonth = Enumerable.ToList<CRMspRpt_ChartCmpTypeMonth_Result>((IEnumerable<CRMspRpt_ChartCmpTypeMonth_Result>)_db.CRMspRpt_ChartCmpTypeMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpCountryMonth = Enumerable.ToList<CRMspRpt_ChartCmpCountryMonth_Result>((IEnumerable<CRMspRpt_ChartCmpCountryMonth_Result>)_db.CRMspRpt_ChartCmpCountryMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpProvinceMonth = Enumerable.ToList<CRMspRpt_ChartCmpProvinceMonth_Result>((IEnumerable<CRMspRpt_ChartCmpProvinceMonth_Result>)_db.CRMspRpt_ChartCmpProvinceMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpCityMonth = Enumerable.ToList<CRMspRpt_ChartCmpCityMonth_Result>((IEnumerable<CRMspRpt_ChartCmpCityMonth_Result>)_db.CRMspRpt_ChartCmpCityMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpUserMonth = Enumerable.ToList<CRMspRpt_ChartCmpUserMonth_Result>((IEnumerable<CRMspRpt_ChartCmpUserMonth_Result>)_db.CRMspRpt_ChartCmpUserMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartAllCmpInMonthInfo = Enumerable.ToList<CRMspRpt_ChartAllCmpInMonthInfo_Result>((IEnumerable<CRMspRpt_ChartAllCmpInMonthInfo_Result>)_db.CRMspRpt_ChartAllCmpInMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartCmpPresentationMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpPresentationMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpPresentationMonthInfo_Result>)_db.CRMspRpt_ChartCmpPresentationMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpTitleMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpTitleMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpTitleMonthInfo_Result>)_db.CRMspRpt_ChartCmpTitleMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpGroupMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpGroupMonthInfo_Result>)_db.CRMspRpt_ChartCmpGroupMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpSubGroupMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpSubGroupMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpSubGroupMonthInfo_Result>)_db.CRMspRpt_ChartCmpSubGroupMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupIIMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpGroupIIMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpGroupIIMonthInfo_Result>)_db.CRMspRpt_ChartCmpGroupIIMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupIIIMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpGroupIIIMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpGroupIIIMonthInfo_Result>)_db.CRMspRpt_ChartCmpGroupIIIMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpGroupIVMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpGroupIVMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpGroupIVMonthInfo_Result>)_db.CRMspRpt_ChartCmpGroupIVMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpTypeMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpTypeMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpTypeMonthInfo_Result>)_db.CRMspRpt_ChartCmpTypeMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpCountryMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpCountryMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpCountryMonthInfo_Result>)_db.CRMspRpt_ChartCmpCountryMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpProvinceMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpProvinceMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpProvinceMonthInfo_Result>)_db.CRMspRpt_ChartCmpProvinceMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpCityMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpCityMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpCityMonthInfo_Result>)_db.CRMspRpt_ChartCmpCityMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpUserMonthInfo = Enumerable.ToList<CRMspRpt_ChartCmpUserMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCmpUserMonthInfo_Result>)_db.CRMspRpt_ChartCmpUserMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCmpProjects = Enumerable.ToList<CRMspRpt_ChartCmpProjects_Result>((IEnumerable<CRMspRpt_ChartCmpProjects_Result>)_db.CRMspRpt_ChartCmpProjects(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartUserProjects = Enumerable.ToList<CRMspRpt_ChartUserProjects_Result>((IEnumerable<CRMspRpt_ChartUserProjects_Result>)_db.CRMspRpt_ChartUserProjects(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartAllcnvs = Enumerable.ToList<CRMspRpt_ChartAllcnvs_Result>((IEnumerable<CRMspRpt_ChartAllcnvs_Result>)_db.CRMspRpt_ChartAllcnvs(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartCnvsFirstRegisterUser = Enumerable.ToList<CRMspRpt_ChartCnvsFirstRegisterUser_Result>((IEnumerable<CRMspRpt_ChartCnvsFirstRegisterUser_Result>)_db.CRMspRpt_ChartCnvsFirstRegisterUser(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartCnvsUser = Enumerable.ToList<CRMspRpt_ChartCnvsUser_Result>((IEnumerable<CRMspRpt_ChartCnvsUser_Result>)_db.CRMspRpt_ChartCnvsUser(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartCnvsReferUser = Enumerable.ToList<CRMspRpt_ChartCnvsReferUser_Result>((IEnumerable<CRMspRpt_ChartCnvsReferUser_Result>)_db.CRMspRpt_ChartCnvsReferUser(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, conversationReferedToSpecificUser));
			parameters.NotUsed_ListChartCnvsTopic = Enumerable.ToList<CRMspRpt_ChartCnvsTopic_Result>((IEnumerable<CRMspRpt_ChartCnvsTopic_Result>)_db.CRMspRpt_ChartCnvsTopic(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCnvsStatus = Enumerable.ToList<CRMspRpt_ChartCnvsStatus_Result>((IEnumerable<CRMspRpt_ChartCnvsStatus_Result>)_db.CRMspRpt_ChartCnvsStatus(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCnvsStatusP100 = Enumerable.ToList<CRMspRpt_ChartCnvsStatusP100_Result>((IEnumerable<CRMspRpt_ChartCnvsStatusP100_Result>)_db.CRMspRpt_ChartCnvsStatusP100(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartProjectsMonth = Enumerable.ToList<CRMspRpt_ChartProjectsMonth_Result>((IEnumerable<CRMspRpt_ChartProjectsMonth_Result>)_db.CRMspRpt_ChartProjectsMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartUserProjectsMonth = Enumerable.ToList<CRMspRpt_ChartUserProjectsMonth_Result>((IEnumerable<CRMspRpt_ChartUserProjectsMonth_Result>)_db.CRMspRpt_ChartUserProjectsMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartCnvsTopicMonth = Enumerable.ToList<CRMspRpt_ChartCnvsTopicMonth_Result>((IEnumerable<CRMspRpt_ChartCnvsTopicMonth_Result>)_db.CRMspRpt_ChartCnvsTopicMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCnvsStatusMonth = Enumerable.ToList<CRMspRpt_ChartCnvsStatusMonth_Result>((IEnumerable<CRMspRpt_ChartCnvsStatusMonth_Result>)_db.CRMspRpt_ChartCnvsStatusMonth(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartUserProjectsMonthInfo = Enumerable.ToList<CRMspRpt_ChartUserProjectsMonthInfo_Result>((IEnumerable<CRMspRpt_ChartUserProjectsMonthInfo_Result>)_db.CRMspRpt_ChartUserProjectsMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartCnvsReferUserInfo = Enumerable.ToList<CRMspRpt_ChartCnvsReferUserInfo_Result>((IEnumerable<CRMspRpt_ChartCnvsReferUserInfo_Result>)_db.CRMspRpt_ChartCnvsReferUserInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result));
			parameters.NotUsed_ListChartCnvsTopicMonthInfo = Enumerable.ToList<CRMspRpt_ChartCnvsTopicMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCnvsTopicMonthInfo_Result>)_db.CRMspRpt_ChartCnvsTopicMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCnvsStatusMonthInfo = Enumerable.ToList<CRMspRpt_ChartCnvsStatusMonthInfo_Result>((IEnumerable<CRMspRpt_ChartCnvsStatusMonthInfo_Result>)_db.CRMspRpt_ChartCnvsStatusMonthInfo(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			parameters.NotUsed_ListChartCnvsStatusP100Info = Enumerable.ToList<CRMspRpt_ChartCnvsStatusP100Info_Result>((IEnumerable<CRMspRpt_ChartCnvsStatusP100Info_Result>)_db.CRMspRpt_ChartCnvsStatusP100Info(chartUserActivityViewModel.UserId, chartUserActivityViewModel.FromDate, chartUserActivityViewModel.ToDate, value, value2, lCID, result, unspecify));
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "ChartUserActivityPrint.xsd");
			XElement val4 = XElement.Parse(stringWriter.ToString());
			val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
			if (result2 != 0 && !string.IsNullOrWhiteSpace(text2))
			{
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				text2 = text2 + result2 + "/";
			}
			stiReport.Load(text2 + text3);
			string text4 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
			text4 = text4.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
			text4 = text4.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
			text4 = text4.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
			text4 = text4.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
			((CollectionBase)stiReport.Dictionary.Databases).Clear();
			stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text4));
			stiReport.Compile();
			stiReport.RegData(val3);
			stiReport.Render();
			new StiHtmlExportSettings().ChartType = StiHtmlChartType.Vector;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return StiMvcViewer.GetReportResult(stiReport);
	}

	public ActionResult ViewerEvent()
	{
		return StiMvcViewer.ViewerEventResult();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
