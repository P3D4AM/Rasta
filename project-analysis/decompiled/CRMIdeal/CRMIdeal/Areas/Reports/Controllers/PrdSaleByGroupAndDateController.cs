using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndCPCityRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndOrderOprRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGSGroupRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIIIRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIIRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIVRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpPresentationRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpReferUserRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpTitleRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpTypeRpt;
using CRM.Models.ReportModel.PrdSaleByGroupAndDateRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class PrdSaleByGroupAndDateController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	public ActionResult Index(string rpt = "")
	{
		rpt = (string.IsNullOrEmpty(rpt) ? "PrdSaleByGroupAndDate" : rpt);
		string text = "actrpt" + rpt;
		if (!UserLogin.IsUserAccess("frmMain", text))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		DateTime now = DateTime.Now;
		PrdSaleByGroupAndDateViewModel prdSaleByGroupAndDateViewModel = new PrdSaleByGroupAndDateViewModel();
		string fromDate = (prdSaleByGroupAndDateViewModel.ToDate = now.ToString("yyyy/MM/dd"));
		prdSaleByGroupAndDateViewModel.FromDate = fromDate;
		prdSaleByGroupAndDateViewModel.Mode = 0;
		prdSaleByGroupAndDateViewModel.FGId = 0;
		prdSaleByGroupAndDateViewModel.SGId = 0;
		prdSaleByGroupAndDateViewModel.Report = rpt;
		switch (rpt)
		{
		case "PrdSaleByGroupAndDate":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDate;
			break;
		case "PrdSaleByGroupAndDateAndOrderOpr":
			prdSaleByGroupAndDateViewModel.ReportName = "actrptPrdSaleByGroupAndDateAndOrderOpr".OrderMenus();
			break;
		case "PrdSaleByGroupAndDateAndCPCity":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndCPCity;
			break;
		case "PrdSaleByGroupAndDateAndcmpReferUser":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndcmpReferUser;
			break;
		case "PrdSaleByGroupAndDateAndcmpTitle":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndcmpTitle;
			break;
		case "PrdSaleByGroupAndDateAndcmpType":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndcmpType;
			break;
		case "PrdSaleByGroupAndDateAndcmpPresentation":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndcmpPresentation;
			break;
		case "PrdSaleByGroupAndDateAndcmpGSGroup":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndcmpGSGroup;
			break;
		case "PrdSaleByGroupAndDateAndcmpGroupII":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndcmpGroupII;
			break;
		case "PrdSaleByGroupAndDateAndcmpGroupIII":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndcmpGroupIII;
			break;
		case "PrdSaleByGroupAndDateAndcmpGroupIV":
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDateAndcmpGroupIV;
			break;
		default:
			prdSaleByGroupAndDateViewModel.ReportName = Menus.actrptPrdSaleByGroupAndDate;
			break;
		}
		GetFirstGroup();
		GetSecondGroup();
		base.ViewBag.ActionName = text;
		return View(prdSaleByGroupAndDateViewModel);
	}

	[AjaxOnly]
	public JsonResult GetFirstGroup()
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
			List<WSspSelectProductFirstGroupActiveInSale_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroupActiveInSale_Result>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)_db.WSspSelectProductFirstGroupActiveInSale(lCID, result));
			list.Add(new SelectListItem
			{
				Selected = true,
				Text = Labels.SelectedListDefValue,
				Value = "0"
			});
			list.AddRange(Enumerable.Select<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupActiveInSale_Result>)list2, (Func<WSspSelectProductFirstGroupActiveInSale_Result, SelectListItem>)((WSspSelectProductFirstGroupActiveInSale_Result item) => new SelectListItem
			{
				Text = item.FGName,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSecondGroup(int fgId = 0)
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
			List<WSspSelectProductSecondGroupActiveInSale_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroupActiveInSale_Result>((IEnumerable<WSspSelectProductSecondGroupActiveInSale_Result>)_db.WSspSelectProductSecondGroupActiveInSale(fgId, lCID, result));
			list.Add(new SelectListItem
			{
				Selected = true,
				Text = Labels.SelectedListDefValue,
				Value = "0"
			});
			list.AddRange(Enumerable.Select<WSspSelectProductSecondGroupActiveInSale_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroupActiveInSale_Result>)list2, (Func<WSspSelectProductSecondGroupActiveInSale_Result, SelectListItem>)((WSspSelectProductSecondGroupActiveInSale_Result item) => new SelectListItem
			{
				Text = item.SGName,
				Value = item.PrdSecondGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SecondGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProducts(int fgId = 0, int sgId = 0, string val = "", int selectPrdId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			List<WSspSearchProducts_Result> list2 = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(fgId, sgId, "", val, selectPrdId, 2, lCID, result, 0, -1, 0, 0, "", null));
			list.AddRange(Enumerable.Select<WSspSearchProducts_Result, WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)list2, (Func<WSspSearchProducts_Result, WSspSearchProducts_Result>)((WSspSearchProducts_Result item) => new WSspSearchProducts_Result
			{
				PrdId = item.PrdId,
				PName = item.PName,
				GName = item.GName
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

	public JsonResult SearchProducts(string prdName = "", string prdBarcode = "", int prdFirstGroup = 0, int prdSecondGroup = 0, int prdKind = 0, int prdShowMode = 2, int prdInActive = -1)
	{
		List<WSspSearchProducts_Result> data = new List<WSspSearchProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			data = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(prdFirstGroup, prdSecondGroup, prdBarcode, prdName, 0, prdShowMode, lCID, result, prdKind, prdInActive, 0, 0, "", null));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ActionResult Print(string modelObj, string fileName)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		PrdSaleByGroupAndDateViewModel prdSaleByGroupAndDateViewModel = new PrdSaleByGroupAndDateViewModel();
		try
		{
			prdSaleByGroupAndDateViewModel = new JavaScriptSerializer().Deserialize<PrdSaleByGroupAndDateViewModel>(modelObj);
			string actionName = "actrpt" + prdSaleByGroupAndDateViewModel.Report;
			if (!UserLogin.IsUserAccess("frmMain", actionName))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			prdSaleByGroupAndDateViewModel.ReportName = fileName;
			base.TempData["model"] = prdSaleByGroupAndDateViewModel;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View(prdSaleByGroupAndDateViewModel);
	}

	public ActionResult GetReportSnapshot()
	{
		StiReport report = new StiReport();
		try
		{
			PrdSaleByGroupAndDateViewModel prdSaleByGroupAndDateViewModel = null;
			if (base.TempData["model"] != null)
			{
				prdSaleByGroupAndDateViewModel = (PrdSaleByGroupAndDateViewModel)base.TempData["model"];
			}
			base.TempData["model"] = null;
			int result = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result);
				base.TempData["PFCId"] = null;
			}
			if (prdSaleByGroupAndDateViewModel != null)
			{
				prdSaleByGroupAndDateViewModel.PFCId = result;
				report = (StiReport)GetType().GetMethod(prdSaleByGroupAndDateViewModel.Report).Invoke(this, new object[1] { prdSaleByGroupAndDateViewModel });
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return StiMvcViewer.GetReportResult(report);
	}

	public ActionResult ViewerEvent()
	{
		return StiMvcViewer.ViewerEventResult();
	}

	public StiReport PrdSaleByGroupAndDate(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDate = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDate_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDate_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDate(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDate_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDate)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDate;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDate.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndOrderOpr(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		_ = MethodBase.GetCurrentMethod().Name;
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndOrderOprRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndOrderOprRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndOrderOpr = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndOrderOpr_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndOrderOpr_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndOrderOpr(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndOrderOpr_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndOrderOpr)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = "actrptPrdSaleByGroupAndDateAndOrderOpr".OrderMenus();
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndOrderOprRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndOrderOpr.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndCPCity(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndCPCityRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndCPCityRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndCPCity = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndCPCity_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndCPCity_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndCPCity(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndCPCity_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndCPCity)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndCPCity;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndCPCityRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndCPCity.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndcmpReferUser(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpReferUserRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpReferUserRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpReferUser = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpReferUser_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpReferUser_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndcmpReferUser(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndcmpReferUser_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpReferUser)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndcmpReferUser;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpReferUserRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndcmpReferUser.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndcmpTitle(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpTitleRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpTitleRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpTitle = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpTitle_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpTitle_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndcmpTitle(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndcmpTitle_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpTitle)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndcmpTitle;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpTitleRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndcmpTitle.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndcmpType(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpTypeRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpTypeRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpType = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpType_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpType_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndcmpType(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndcmpType_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpType)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndcmpType;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpTypeRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndcmpType.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndcmpPresentation(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpPresentationRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpPresentationRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpPresentation = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpPresentation_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpPresentation_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndcmpPresentation(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndcmpPresentation_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpPresentation)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndcmpPresentation;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpPresentationRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndcmpPresentation.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndcmpGSGroup(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGSGroupRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGSGroupRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpGSGroup = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGSGroup_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGSGroup_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndcmpGSGroup(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGSGroup_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpGSGroup)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndcmpGSGroup;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGSGroupRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndcmpGSGroup.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndcmpGroupII(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIIRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIIRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpGroupII = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupII_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupII_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupII(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupII_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpGroupII)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndcmpGroupII;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIIRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndcmpGroupII.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndcmpGroupIII(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIIIRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIIIRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpGroupIII = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupIII_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupIII_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupIII(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupIII_Result item in parameters.NotUsed_ListPrdSaleByGroupAndDateAndcmpGroupIII)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndcmpGroupIII;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIIIRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndcmpGroupIII.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	public StiReport PrdSaleByGroupAndDateAndcmpGroupIV(PrdSaleByGroupAndDateViewModel model)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
			.Replace(" ", "")
			.Replace("_", "");
		DateTime value = DateTime.Now;
		DateTime value2 = DateTime.Now;
		if (!string.IsNullOrEmpty(model.FromDate))
		{
			value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		if (!string.IsNullOrEmpty(model.ToDate))
		{
			value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
			{
				1025 => new CultureInfo("ar-SA"), 
				1065 => new PersianCulture(), 
				_ => new CultureInfo("en-US"), 
			});
		}
		DateTime now = DateTime.Now;
		CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIVRpt.Parameters parameters = new CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIVRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListWSspRpt_PrdSaleByGroupAndDateAndcmpGroupIV = Enumerable.ToList<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupIV_Result>((IEnumerable<mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupIV_Result>)_db.mfi_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupIV(model.FromDate, model.ToDate, model.FGId.ToString(), model.SGId.ToString(), model.PrdId.ToString(), UserLogin.CurrentUser.UserId.ToString(), now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), value, value2, lCID, result, result2));
		foreach (mct_WSspRpt_PrdSaleByGroupAndDateAndcmpGroupIV_Result item in parameters.NotUsed_ListWSspRpt_PrdSaleByGroupAndDateAndcmpGroupIV)
		{
			item.ordDate = ((!string.IsNullOrEmpty(item.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.ordDate.Replace("/", "")).Replace("/", "") : item.ordDate);
		}
		parameters.Parameter1 = Menus.actrptPrdSaleByGroupAndDateAndcmpGroupIV;
		parameters.Parameter2 = model.FromDate;
		parameters.Parameter3 = model.ToDate;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrdSaleByGroupAndDateAndcmpGroupIVRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrdSaleByGroupAndDateAndcmpGroupIV.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		int valueOrDefault = model.PFCId.GetValueOrDefault();
		if (valueOrDefault != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + valueOrDefault + "/";
		}
		stiReport.Load(text2 + model.ReportName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		return stiReport;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
