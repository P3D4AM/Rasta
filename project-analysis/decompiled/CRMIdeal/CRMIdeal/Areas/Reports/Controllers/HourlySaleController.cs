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
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.HourlySalePrintRpt;
using CRM.Models.ViewModel.Reports;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class HourlySaleController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptHourlySale")]
	public ActionResult Index()
	{
		return View();
	}

	public JsonResult GetResuls(string referUserIds = "-1", string orderOprIds = "-1", string fromDate = null, string toDate = null)
	{
		int? centerId = null;
		int userId = UserLogin.CurrentUser.UserId;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		DateTime? dateTime = null;
		DateTime? dateTime2 = null;
		try
		{
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrWhiteSpace(fromDate))
			{
				text = PersianDate.GetFormatetdDate(fromDate.Replace("/", ""));
				dateTime = lCID switch
				{
					1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
					1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
				};
				text = PersianDate.GetFormatetdDate(toDate.Replace("/", ""));
				dateTime2 = lCID switch
				{
					1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
					1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
				};
			}
			else
			{
				dateTime = null;
				dateTime2 = null;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			dateTime = null;
			dateTime2 = null;
		}
		List<WSspRpt_HourlySale_Result> items = Enumerable.ToList<WSspRpt_HourlySale_Result>((IEnumerable<WSspRpt_HourlySale_Result>)_dbII.WSspRpt_HourlySale(referUserIds, dateTime, dateTime2, orderOprIds, userId, centerId));
		return Json(new { items }, JsonRequestBehavior.AllowGet);
	}

	public ActionResult HourlySaleInfo(short startHour, string referUserIds = "-1", string orderOprIds = "-1", string fromDate = null, string toDate = null)
	{
		base.ViewBag.StartHour = startHour;
		base.ViewBag.ReferUserIds = referUserIds;
		base.ViewBag.orderOprIds = orderOprIds;
		base.ViewBag.FromDate = fromDate;
		base.ViewBag.ToDate = toDate;
		return View();
	}

	public ActionResult GetHourlySaleInfo(short startHour, string referUserIds = "-1", string orderOprIds = "-1", string fromDate = null, string toDate = null, int pageNumber = 1, int pageSize = 50)
	{
		int? centerId = null;
		int userId = UserLogin.CurrentUser.UserId;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		DateTime? dateTime = null;
		DateTime? dateTime2 = null;
		try
		{
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrWhiteSpace(fromDate))
			{
				text = PersianDate.GetFormatetdDate(fromDate.Replace("/", ""));
				dateTime = lCID switch
				{
					1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
					1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
				};
				text = PersianDate.GetFormatetdDate(toDate.Replace("/", ""));
				dateTime2 = lCID switch
				{
					1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
					1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
				};
			}
			else
			{
				dateTime = null;
				dateTime2 = null;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			dateTime = null;
			dateTime2 = null;
		}
		CRMSpIIEntities dbII = _dbII;
		DateTime? fromDate2 = dateTime;
		DateTime? toDate2 = dateTime2;
		int? userId2 = userId;
		List<WSspRpt_HourlySaleInfo_Result> list = Enumerable.ToList<WSspRpt_HourlySaleInfo_Result>((IEnumerable<WSspRpt_HourlySaleInfo_Result>)dbII.WSspRpt_HourlySaleInfo(referUserIds, fromDate2, toDate2, orderOprIds, centerId, userId2, lCID, result, startHour, pageNumber, pageSize));
		foreach (WSspRpt_HourlySaleInfo_Result item in list)
		{
			item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
		}
		return Json(new
		{
			items = list,
			totalPages = (Enumerable.FirstOrDefault<WSspRpt_HourlySaleInfo_Result>((IEnumerable<WSspRpt_HourlySaleInfo_Result>)list)?.AllPage).GetValueOrDefault()
		}, JsonRequestBehavior.AllowGet);
	}

	public string GetOrderOpr()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list.Add(new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "-1",
					Selected = false
				});
			}
			list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.OrderOprID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	public string GetOrdUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSelectOrderReferUsers_Result> list2 = Enumerable.ToList<WSspSelectOrderReferUsers_Result>((IEnumerable<WSspSelectOrderReferUsers_Result>)_db.WSspSelectOrderReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "-1",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectOrderReferUsers_Result, SelectListItem>((IEnumerable<WSspSelectOrderReferUsers_Result>)list2, (Func<WSspSelectOrderReferUsers_Result, SelectListItem>)((WSspSelectOrderReferUsers_Result item) => new SelectListItem
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
		return JsonConvert.SerializeObject(list);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptWrhsReserveStock")]
	public ActionResult Print(string model, string fileName)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		base.ViewBag.FileName = fileName;
		HourlySaleViewModel value = new HourlySaleViewModel();
		if (model != "")
		{
			value = new JavaScriptSerializer().Deserialize<HourlySaleViewModel>(model);
		}
		base.TempData["model"] = value;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		StiReport stiReport = new StiReport();
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
			int result3 = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result3);
				base.TempData["PFCId"] = null;
			}
			HourlySaleViewModel hourlySaleViewModel = new HourlySaleViewModel();
			if (base.TempData["model"] != null)
			{
				hourlySaleViewModel = (HourlySaleViewModel)base.TempData["model"];
			}
			base.TempData["model"] = null;
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
			string text4 = "";
			try
			{
				if (!string.IsNullOrEmpty(hourlySaleViewModel.FromDate) && !string.IsNullOrWhiteSpace(hourlySaleViewModel.ToDate))
				{
					text4 = PersianDate.GetFormatetdDate(hourlySaleViewModel.FromDate.Replace("/", ""));
					hourlySaleViewModel.FromDateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
					text4 = PersianDate.GetFormatetdDate(hourlySaleViewModel.ToDate.Replace("/", ""));
					hourlySaleViewModel.ToDateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				else
				{
					hourlySaleViewModel.FromDateTime = null;
					hourlySaleViewModel.ToDateTime = null;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				hourlySaleViewModel.FromDateTime = null;
				hourlySaleViewModel.ToDateTime = null;
			}
			int userId = UserLogin.CurrentUser.UserId;
			parameters.NotUsed_ListHourlySale = Enumerable.ToList<WSspRpt_HourlySale_Result>((IEnumerable<WSspRpt_HourlySale_Result>)_dbII.WSspRpt_HourlySale(hourlySaleViewModel.ReferUserIds, hourlySaleViewModel.FromDateTime, hourlySaleViewModel.ToDateTime, hourlySaleViewModel.OrderOprIds, userId, result));
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "PrintHourlySale.xsd");
			XElement val4 = XElement.Parse(stringWriter.ToString());
			val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
			if (result3 != 0 && !string.IsNullOrWhiteSpace(text2))
			{
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				text2 = text2 + result3 + "/";
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return StiMvcViewer.GetReportResult(stiReport);
	}

	public ActionResult ViewerEvent()
	{
		return StiMvcViewer.ViewerEventResult();
	}
}
