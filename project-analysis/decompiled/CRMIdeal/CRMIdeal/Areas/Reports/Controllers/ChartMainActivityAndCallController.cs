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
using CRM.Models.ReportModel.ChartMainActivityAndCallRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class ChartMainActivityAndCallController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptchartMainActivityAndCall")]
	public ActionResult Index()
	{
		GetUserList();
		ChartMainActivityAndCallViewModel chartMainActivityAndCallViewModel = new ChartMainActivityAndCallViewModel();
		DateTime now = DateTime.Now;
		string fromDate = (chartMainActivityAndCallViewModel.ToDate = now.ToString("yyyy/MM/dd"));
		chartMainActivityAndCallViewModel.FromDate = fromDate;
		return View(chartMainActivityAndCallViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptChartUserActivity")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(ChartMainActivityAndCallViewModel model)
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
	public JsonResult GetUserList(int? id = null, int? selectedId = null)
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
				Selected = (selectedId == item.UserId)
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
		ChartMainActivityAndCallViewModel value = new ChartMainActivityAndCallViewModel();
		if (model != "")
		{
			value = new JavaScriptSerializer().Deserialize<ChartMainActivityAndCallViewModel>(model);
		}
		base.TempData["model"] = value;
		base.TempData["FileName"] = fileName;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_0a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Expected O, but got Unknown
		//IL_0ae4: Unknown result type (might be due to invalid IL or missing references)
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
			int result3 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				value = UserLogin.CurrentUser.UserId;
			}
			ChartMainActivityAndCallViewModel chartMainActivityAndCallViewModel = new ChartMainActivityAndCallViewModel();
			if (base.TempData["model"] != null)
			{
				chartMainActivityAndCallViewModel = (ChartMainActivityAndCallViewModel)base.TempData["model"];
			}
			base.TempData["model"] = null;
			chartMainActivityAndCallViewModel.ToDate = chartMainActivityAndCallViewModel.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			chartMainActivityAndCallViewModel.FromDate = chartMainActivityAndCallViewModel.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrEmpty(chartMainActivityAndCallViewModel.FromDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(chartMainActivityAndCallViewModel.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(chartMainActivityAndCallViewModel.ToDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(chartMainActivityAndCallViewModel.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			string unspecify = Labels.Unspecify;
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
			int? userId = chartMainActivityAndCallViewModel.UserId;
			parameters.NotUsed_ListChartMainActivityAndCall = Enumerable.ToList<CRMspRpt_ChartMainActivityAndCall_Result>((IEnumerable<CRMspRpt_ChartMainActivityAndCall_Result>)_db.CRMspRpt_ChartMainActivityAndCall(userId, now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, chartMainActivityAndCallViewModel.UserId, lCID, result));
			parameters.NotUsed_ListAllCmpUserInMonthInfo = Enumerable.ToList<CRMspRpt_ChartActivityAndCallAllCmpUserInMonthInfoWeb_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallAllCmpUserInMonthInfoWeb_Result>)_dbII.CRMspRpt_ChartActivityAndCallAllCmpUserInMonthInfoWeb(chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, unspecify, userId, result3));
			parameters.NotUsed_ListAllCmpInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallAllCmpInMonthWeb_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallAllCmpInMonthWeb_Result>)_dbII.CRMspRpt_ChartActivityAndCallAllCmpInMonthWeb(chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, userId, result3));
			parameters.NotUsed_ListAllUserCmpInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallAllUserCmpInMonthWeb_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallAllUserCmpInMonthWeb_Result>)_dbII.CRMspRpt_ChartActivityAndCallAllUserCmpInMonthWeb(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, unspecify, result3));
			parameters.NotUsed_ListCmpInProvince = Enumerable.ToList<CRMspRpt_ChartActivityAndCallCmpInProvinceWeb_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallCmpInProvinceWeb_Result>)_dbII.CRMspRpt_ChartActivityAndCallCmpInProvinceWeb(chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, unspecify, userId, result3));
			parameters.NotUsed_ListCmpUser = Enumerable.ToList<CRMspRpt_ChartActivityAndCallCmpUser_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallCmpUser_Result>)_db.CRMspRpt_ChartActivityAndCallCmpUser(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, lCID, result));
			parameters.NotUsed_ListCallCntInLine = Enumerable.ToList<CRMspRpt_ChartActivityAndCallCntInLine_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallCntInLine_Result>)_db.CRMspRpt_ChartActivityAndCallCntInLine(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, value, result3));
			parameters.NotUsed_ListCallCntInLineMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallCntInLineMonth_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallCntInLineMonth_Result>)_db.CRMspRpt_ChartActivityAndCallCntInLineMonth(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListCallCntInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallCntInMonth_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallCntInMonth_Result>)_db.CRMspRpt_ChartActivityAndCallCntInMonth(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListCallFromComp = Enumerable.ToList<CRMspRpt_ChartActivityAndCallFromComp_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallFromComp_Result>)_db.CRMspRpt_ChartActivityAndCallFromComp(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListInCallCntInLine = Enumerable.ToList<CRMspRpt_ChartActivityAndCallInCallCntInLine_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallInCallCntInLine_Result>)_db.CRMspRpt_ChartActivityAndCallInCallCntInLine(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListCallCntInLineInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallInCallCntInLineInMonth_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallInCallCntInLineInMonth_Result>)_db.CRMspRpt_ChartActivityAndCallInCallCntInLineInMonth(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListInNotRegCall = Enumerable.ToList<CRMspRpt_ChartActivityAndCallInNotRegCall_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallInNotRegCall_Result>)_db.CRMspRpt_ChartActivityAndCallInNotRegCall(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListInNotRegCallInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallInNotRegCallInMonth_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallInNotRegCallInMonth_Result>)_db.CRMspRpt_ChartActivityAndCallInNotRegCallInMonth(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListInRegCall = Enumerable.ToList<CRMspRpt_ChartActivityAndCallInRegCall_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallInRegCall_Result>)_db.CRMspRpt_ChartActivityAndCallInRegCall(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListInRegCallInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallInRegCallInMonth_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallInRegCallInMonth_Result>)_db.CRMspRpt_ChartActivityAndCallInRegCallInMonth(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListOutCallCntInLine = Enumerable.ToList<CRMspRpt_ChartActivityAndCallOutCallCntInLine_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallOutCallCntInLine_Result>)_db.CRMspRpt_ChartActivityAndCallOutCallCntInLine(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListOutCallCntInLineInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallOutCallCntInLineInMonth_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallOutCallCntInLineInMonth_Result>)_db.CRMspRpt_ChartActivityAndCallOutCallCntInLineInMonth(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListOutNotRegCall = Enumerable.ToList<CRMspRpt_ChartActivityAndCallOutNotRegCall_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallOutNotRegCall_Result>)_db.CRMspRpt_ChartActivityAndCallOutNotRegCall(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListOutNotRegCallInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallOutNotRegCallInMonth_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallOutNotRegCallInMonth_Result>)_db.CRMspRpt_ChartActivityAndCallOutNotRegCallInMonth(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListOutRegCall = Enumerable.ToList<CRMspRpt_ChartActivityAndCallOutRegCall_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallOutRegCall_Result>)_db.CRMspRpt_ChartActivityAndCallOutRegCall(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListOutRegCallInMonth = Enumerable.ToList<CRMspRpt_ChartActivityAndCallOutRegCallInMonth_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallOutRegCallInMonth_Result>)_db.CRMspRpt_ChartActivityAndCallOutRegCallInMonth(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListCallToComp = Enumerable.ToList<CRMspRpt_ChartActivityAndCallToComp_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallToComp_Result>)_db.CRMspRpt_ChartActivityAndCallToComp(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result, value, result3));
			parameters.NotUsed_ListUserAllCnvs = Enumerable.ToList<CRMspRpt_ChartActivityAndCallUserAllCnvsWeb_Result>((IEnumerable<CRMspRpt_ChartActivityAndCallUserAllCnvsWeb_Result>)_dbII.CRMspRpt_ChartActivityAndCallUserAllCnvsWeb(userId, chartMainActivityAndCallViewModel.FromDate, chartMainActivityAndCallViewModel.ToDate, value2, value3, lCID, result));
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "ChartMainActivityAndCallPrint.xsd");
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
