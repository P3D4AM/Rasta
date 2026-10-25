using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.CmpOrdStockPayAccPrintRpt;
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

public class CmpOrdStockPayAccController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCmpOrdStockPayAcc")]
	public ActionResult Index()
	{
		return View();
	}

	public List<WSspRpt_CmpOrdStockPayAccI_Result> GetCmpOrdStockPayAccIList(int pageNumber = 1, int pageSize = 100, string fromDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspRpt_CmpOrdStockPayAccI_Result> list = new List<WSspRpt_CmpOrdStockPayAccI_Result>();
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			string rptDate = now.ToString("yyyy/MM/dd HH:mm:ss");
			string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime dateTime = default(DateTime);
			string text = "";
			DateTime value = DateTime.Now;
			try
			{
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					text = PersianDate.GetFormatetdDate(fromDate.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(text + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			list = Enumerable.ToList<WSspRpt_CmpOrdStockPayAccI_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccI_Result>)_dbI.WSspRpt_CmpOrdStockPayAccI(value, userId, rptDate, rptDay, pageNumber, pageSize, lCID, result, result2));
			if (list == null || !Enumerable.Any<WSspRpt_CmpOrdStockPayAccI_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccI_Result>)list))
			{
				list = new List<WSspRpt_CmpOrdStockPayAccI_Result>();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	public List<WSspRpt_CmpOrdStockPayAccII_Result> GetCmpOrdStockPayAccIIList(int pageNumber = 1, int pageSize = 100, string fromDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspRpt_CmpOrdStockPayAccII_Result> list = new List<WSspRpt_CmpOrdStockPayAccII_Result>();
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			string rptDate = now.ToString("yyyy/MM/dd HH:mm:ss");
			string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime dateTime = default(DateTime);
			string text = "";
			DateTime value = DateTime.Now;
			try
			{
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					text = PersianDate.GetFormatetdDate(fromDate.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(text + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			list = Enumerable.ToList<WSspRpt_CmpOrdStockPayAccII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccII_Result>)_dbI.WSspRpt_CmpOrdStockPayAccII(value, userId, rptDate, rptDay, pageNumber, pageSize, lCID, result, result2));
			if (list == null || !Enumerable.Any<WSspRpt_CmpOrdStockPayAccII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccII_Result>)list))
			{
				list = new List<WSspRpt_CmpOrdStockPayAccII_Result>();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	public List<WSspRpt_CmpOrdStockPayAccIII_Result> GetCmpOrdStockPayAccIIIList(int pageNumber = 1, int pageSize = 100, string fromDate = "", string warehouseIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspRpt_CmpOrdStockPayAccIII_Result> list = new List<WSspRpt_CmpOrdStockPayAccIII_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			string rptDate = now.ToString("yyyy/MM/dd HH:mm:ss");
			string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			DateTime dateTime = default(DateTime);
			string text = "";
			DateTime value = DateTime.Now;
			try
			{
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					text = PersianDate.GetFormatetdDate(fromDate.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(text + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			list = Enumerable.ToList<WSspRpt_CmpOrdStockPayAccIII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccIII_Result>)_dbI.WSspRpt_CmpOrdStockPayAccIII(value, userId, rptDate, rptDay, pageNumber, pageSize, lCID, result, warehouseIds, result2));
			if (list == null || !Enumerable.Any<WSspRpt_CmpOrdStockPayAccIII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccIII_Result>)list))
			{
				list = new List<WSspRpt_CmpOrdStockPayAccIII_Result>();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	public WSspRpt_CmpOrdStockPayAccIV_Result GetCmpOrdStockPayAccIV(string fromDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WSspRpt_CmpOrdStockPayAccIV_Result wSspRpt_CmpOrdStockPayAccIV_Result = new WSspRpt_CmpOrdStockPayAccIV_Result();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			DateTime dateTime = default(DateTime);
			string text = "";
			DateTime value = DateTime.Now;
			try
			{
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					text = PersianDate.GetFormatetdDate(fromDate.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(text + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			wSspRpt_CmpOrdStockPayAccIV_Result = Enumerable.FirstOrDefault<WSspRpt_CmpOrdStockPayAccIV_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccIV_Result>)_dbI.WSspRpt_CmpOrdStockPayAccIV(value));
			if (wSspRpt_CmpOrdStockPayAccIV_Result == null)
			{
				wSspRpt_CmpOrdStockPayAccIV_Result = new WSspRpt_CmpOrdStockPayAccIV_Result();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return wSspRpt_CmpOrdStockPayAccIV_Result;
	}

	[AjaxOnly]
	public JsonResult GetResultListI(int pageNumber = 1, int pageSize = 100, string fromDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CmpOrdStockPayAccViewModel cmpOrdStockPayAccViewModel = new CmpOrdStockPayAccViewModel();
		cmpOrdStockPayAccViewModel.ResultList = new List<WSspRpt_CmpOrdStockPayAccI_Result>();
		cmpOrdStockPayAccViewModel.PayResultList = new List<WSspRpt_CmpOrdStockPayAccII_Result>();
		cmpOrdStockPayAccViewModel.SaleOrdResultList = new List<WSspRpt_CmpOrdStockPayAccIII_Result>();
		cmpOrdStockPayAccViewModel.IsFind = false;
		cmpOrdStockPayAccViewModel.Message = "";
		cmpOrdStockPayAccViewModel.TotalPage = 0L;
		try
		{
			cmpOrdStockPayAccViewModel.ResultList = GetCmpOrdStockPayAccIList(pageNumber, pageSize, fromDate);
			if (cmpOrdStockPayAccViewModel.ResultList != null && Enumerable.Any<WSspRpt_CmpOrdStockPayAccI_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccI_Result>)cmpOrdStockPayAccViewModel.ResultList))
			{
				cmpOrdStockPayAccViewModel.IsFind = true;
				foreach (WSspRpt_CmpOrdStockPayAccI_Result result3 in cmpOrdStockPayAccViewModel.ResultList)
				{
					result3.ordDate = (result3.ordDateTime.HasValue ? result3.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					result3.ordDeadlineDatePersian = (result3.ordDeadlineDate.HasValue ? result3.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
				}
				WSspRpt_CmpOrdStockPayAccI_Result wSspRpt_CmpOrdStockPayAccI_Result = Enumerable.FirstOrDefault<WSspRpt_CmpOrdStockPayAccI_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccI_Result>)cmpOrdStockPayAccViewModel.ResultList);
				long result2 = 0L;
				if (wSspRpt_CmpOrdStockPayAccI_Result != null)
				{
					long.TryParse(wSspRpt_CmpOrdStockPayAccI_Result.AllPage.ToString(), out result2);
				}
				cmpOrdStockPayAccViewModel.TotalPage = result2;
			}
			else
			{
				cmpOrdStockPayAccViewModel.ResultList = new List<WSspRpt_CmpOrdStockPayAccI_Result>();
				cmpOrdStockPayAccViewModel.Message = "Not Find";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			cmpOrdStockPayAccViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(cmpOrdStockPayAccViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetResultListII(int pageNumber = 1, int pageSize = 100, string fromDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CmpOrdStockPayAccViewModel cmpOrdStockPayAccViewModel = new CmpOrdStockPayAccViewModel();
		cmpOrdStockPayAccViewModel.ResultList = new List<WSspRpt_CmpOrdStockPayAccI_Result>();
		cmpOrdStockPayAccViewModel.PayResultList = new List<WSspRpt_CmpOrdStockPayAccII_Result>();
		cmpOrdStockPayAccViewModel.SaleOrdResultList = new List<WSspRpt_CmpOrdStockPayAccIII_Result>();
		cmpOrdStockPayAccViewModel.OrdPayAcc = new WSspRpt_CmpOrdStockPayAccIV_Result();
		cmpOrdStockPayAccViewModel.IsFind = false;
		cmpOrdStockPayAccViewModel.Message = "";
		cmpOrdStockPayAccViewModel.TotalPage = 0L;
		try
		{
			cmpOrdStockPayAccViewModel.PayResultList = GetCmpOrdStockPayAccIIList(pageNumber, pageSize, fromDate);
			if (cmpOrdStockPayAccViewModel.PayResultList != null && Enumerable.Any<WSspRpt_CmpOrdStockPayAccII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccII_Result>)cmpOrdStockPayAccViewModel.PayResultList))
			{
				cmpOrdStockPayAccViewModel.IsFind = true;
				foreach (WSspRpt_CmpOrdStockPayAccII_Result payResult in cmpOrdStockPayAccViewModel.PayResultList)
				{
					payResult.ordDate = (payResult.ordDateTime.HasValue ? payResult.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					payResult.ImportDate = (payResult.ImportDateTime.HasValue ? payResult.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					payResult.ordpayDocDate = (payResult.ordpayDocDateTime.HasValue ? payResult.ordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
				}
				WSspRpt_CmpOrdStockPayAccII_Result wSspRpt_CmpOrdStockPayAccII_Result = Enumerable.FirstOrDefault<WSspRpt_CmpOrdStockPayAccII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccII_Result>)cmpOrdStockPayAccViewModel.PayResultList);
				long result2 = 0L;
				if (wSspRpt_CmpOrdStockPayAccII_Result != null)
				{
					long.TryParse(wSspRpt_CmpOrdStockPayAccII_Result.AllPage.ToString(), out result2);
				}
				cmpOrdStockPayAccViewModel.TotalPage = result2;
			}
			else
			{
				cmpOrdStockPayAccViewModel.PayResultList = new List<WSspRpt_CmpOrdStockPayAccII_Result>();
				cmpOrdStockPayAccViewModel.Message = "Not Find";
			}
			cmpOrdStockPayAccViewModel.OrdPayAcc = GetCmpOrdStockPayAccIV(fromDate);
			if (cmpOrdStockPayAccViewModel.OrdPayAcc == null)
			{
				cmpOrdStockPayAccViewModel.OrdPayAcc = new WSspRpt_CmpOrdStockPayAccIV_Result();
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			cmpOrdStockPayAccViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(cmpOrdStockPayAccViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetResultListIII(int pageNumber = 1, int pageSize = 100, string fromDate = "", string warehouseIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CmpOrdStockPayAccViewModel cmpOrdStockPayAccViewModel = new CmpOrdStockPayAccViewModel();
		cmpOrdStockPayAccViewModel.ResultList = new List<WSspRpt_CmpOrdStockPayAccI_Result>();
		cmpOrdStockPayAccViewModel.PayResultList = new List<WSspRpt_CmpOrdStockPayAccII_Result>();
		cmpOrdStockPayAccViewModel.SaleOrdResultList = new List<WSspRpt_CmpOrdStockPayAccIII_Result>();
		cmpOrdStockPayAccViewModel.IsFind = false;
		cmpOrdStockPayAccViewModel.Message = "";
		cmpOrdStockPayAccViewModel.TotalPage = 0L;
		try
		{
			cmpOrdStockPayAccViewModel.SaleOrdResultList = GetCmpOrdStockPayAccIIIList(pageNumber, pageSize, fromDate, warehouseIds);
			if (cmpOrdStockPayAccViewModel.SaleOrdResultList != null && Enumerable.Any<WSspRpt_CmpOrdStockPayAccIII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccIII_Result>)cmpOrdStockPayAccViewModel.SaleOrdResultList))
			{
				cmpOrdStockPayAccViewModel.IsFind = true;
				WSspRpt_CmpOrdStockPayAccIII_Result wSspRpt_CmpOrdStockPayAccIII_Result = Enumerable.FirstOrDefault<WSspRpt_CmpOrdStockPayAccIII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccIII_Result>)cmpOrdStockPayAccViewModel.SaleOrdResultList);
				long result2 = 0L;
				if (wSspRpt_CmpOrdStockPayAccIII_Result != null)
				{
					long.TryParse(wSspRpt_CmpOrdStockPayAccIII_Result.AllPage.ToString(), out result2);
				}
				cmpOrdStockPayAccViewModel.TotalPage = result2;
			}
			else
			{
				cmpOrdStockPayAccViewModel.SaleOrdResultList = new List<WSspRpt_CmpOrdStockPayAccIII_Result>();
				cmpOrdStockPayAccViewModel.Message = "Not Find";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			cmpOrdStockPayAccViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(cmpOrdStockPayAccViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCmpOrdStockPayAcc")]
	public ActionResult Print(string fileName, int pageNumber = 1, int pageSize = 100, string fromDate = "", int pageNumberI = 1, int pageSizeI = 100, int pageNumberII = 1, int pageSizeII = 100, string warehouseIds = "")
	{
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		base.TempData["PageNumber"] = pageNumber;
		base.TempData["PageSize"] = pageSize;
		base.TempData["FromDate"] = fromDate;
		base.TempData["FileName"] = fileName;
		base.TempData["PageNumberI"] = pageNumberI;
		base.TempData["PageSizeI"] = pageSizeI;
		base.TempData["PageNumberII"] = pageNumberII;
		base.TempData["PageSizeII"] = pageSizeII;
		base.TempData["WarehouseIds"] = warehouseIds;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected O, but got Unknown
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
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
			string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
			string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
			string text3 = base.TempData["FileName"].ToString();
			base.TempData["FileName"] = null;
			int result3 = 1;
			int.TryParse(base.TempData["PageNumber"].ToString(), out result3);
			result3 = ((result3 == 0) ? 1 : result3);
			int result4 = 100;
			int.TryParse(base.TempData["PageSize"].ToString(), out result4);
			result4 = ((result4 == 0) ? 100 : result4);
			string text4 = base.TempData["FromDate"].ToString();
			int result5 = 1;
			int.TryParse(base.TempData["PageNumberI"].ToString(), out result5);
			result5 = ((result5 == 0) ? 1 : result5);
			int result6 = 100;
			int.TryParse(base.TempData["PageSizeI"].ToString(), out result6);
			result6 = ((result6 == 0) ? 100 : result6);
			int result7 = 1;
			int.TryParse(base.TempData["PageNumberII"].ToString(), out result7);
			result7 = ((result7 == 0) ? 1 : result7);
			int result8 = 100;
			int.TryParse(base.TempData["PageSizeII"].ToString(), out result8);
			result8 = ((result8 == 0) ? 100 : result8);
			string warehouseIds = base.TempData["WarehouseIds"].ToString();
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
			parameters.Parameter1 = text4;
			parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccI = new List<WSspRpt_CmpOrdStockPayAccI_Result>();
			parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccII = new List<WSspRpt_CmpOrdStockPayAccII_Result>();
			parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccIII = new List<WSspRpt_CmpOrdStockPayAccIII_Result>();
			parameters.CmpOrdStockPayAccIV = new WSspRpt_CmpOrdStockPayAccIV_Result();
			parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccI = GetCmpOrdStockPayAccIList(result3, result4, text4);
			if (parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccI != null && Enumerable.Any<WSspRpt_CmpOrdStockPayAccI_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccI_Result>)parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccI))
			{
				foreach (WSspRpt_CmpOrdStockPayAccI_Result item in parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccI)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrWhiteSpace(item.ordDate))
						{
							item.ordDate = PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item.ordDeadlineDatePersian))
						{
							item.ordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item.ordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			else
			{
				parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccI = new List<WSspRpt_CmpOrdStockPayAccI_Result>();
			}
			parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccII = GetCmpOrdStockPayAccIIList(result5, result6, text4);
			if (parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccII != null && Enumerable.Any<WSspRpt_CmpOrdStockPayAccII_Result>((IEnumerable<WSspRpt_CmpOrdStockPayAccII_Result>)parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccII))
			{
				foreach (WSspRpt_CmpOrdStockPayAccII_Result item2 in parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccII)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrWhiteSpace(item2.ordDate))
						{
							item2.ordDate = PersianDate.GetShamsi2Miladi(item2.ordDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ImportDate))
						{
							item2.ImportDate = PersianDate.GetShamsi2Miladi(item2.ImportDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordpayDocDate))
						{
							item2.ordpayDocDate = PersianDate.GetShamsi2Miladi(item2.ordpayDocDate.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			else
			{
				parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccII = new List<WSspRpt_CmpOrdStockPayAccII_Result>();
			}
			parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccIII = GetCmpOrdStockPayAccIIIList(result7, result8, text4, warehouseIds);
			if (parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccIII == null)
			{
				parameters.NotUsed_ListWSspRpt_CmpOrdStockPayAccIII = new List<WSspRpt_CmpOrdStockPayAccIII_Result>();
			}
			parameters.CmpOrdStockPayAccIV = GetCmpOrdStockPayAccIV(text4);
			if (parameters.CmpOrdStockPayAccIV == null)
			{
				parameters.CmpOrdStockPayAccIV = new WSspRpt_CmpOrdStockPayAccIV_Result();
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "CmpOrdStockPayAccPrint.xsd");
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
			string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
			text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
			text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
			text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
			text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
			((CollectionBase)stiReport.Dictionary.Databases).Clear();
			stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
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
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
