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
using CRM.Models.ReportModel.CalenderEventRpt;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class CalenderEventController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptcmpprsCalenderEvent")]
	public ActionResult Index()
	{
		CalenderEventViewModel calenderEventViewModel = new CalenderEventViewModel();
		DateTime now = DateTime.Now;
		string fromDate = (calenderEventViewModel.ToDate = now.ToString("yyyy/MM/dd"));
		calenderEventViewModel.FromDate = fromDate;
		calenderEventViewModel.Mode = 1;
		return View(calenderEventViewModel);
	}

	public ActionResult SearchList_Read([DataSourceRequest] DataSourceRequest request, string modelObj)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		List<CRMspRpt_CalenderEvent_Result> enumerable = new List<CRMspRpt_CalenderEvent_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			CalenderEventViewModel calenderEventViewModel = new JavaScriptSerializer().Deserialize<CalenderEventViewModel>(modelObj);
			calenderEventViewModel.ToDate = calenderEventViewModel.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			calenderEventViewModel.FromDate = calenderEventViewModel.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(calenderEventViewModel.FromDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(calenderEventViewModel.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(calenderEventViewModel.ToDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(calenderEventViewModel.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			enumerable = GetCalenderEvent(calenderEventViewModel);
			try
			{
				_db.CRMspFillsmsTempNumberInCalenderEvent(UserLogin.CurrentUser.UserId, calenderEventViewModel.Mode.ToString(), calenderEventViewModel.FromDate, calenderEventViewModel.ToDate, value, value2, firstRegisterDatePersian, appType, lCID, result, result2);
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMspRpt_CalenderEvent_Result> GetCalenderEvent(CalenderEventViewModel model)
	{
		List<CRMspRpt_CalenderEvent_Result> list = new List<CRMspRpt_CalenderEvent_Result>();
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
			list = Enumerable.ToList<CRMspRpt_CalenderEvent_Result>((IEnumerable<CRMspRpt_CalenderEvent_Result>)_db.CRMspRpt_CalenderEvent(UserLogin.CurrentUser.UserId, now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), model.FromDate, model.ToDate, model.Mode, value, value2, lCID, result, result2));
			foreach (CRMspRpt_CalenderEvent_Result item in list)
			{
				if (lCID != 1065)
				{
					if (!string.IsNullOrEmpty(item.BirthDate))
					{
						item.BirthDate = PersianDate.GetShamsi2Miladi(item.BirthDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item.MarriageDate))
					{
						item.MarriageDate = PersianDate.GetShamsi2Miladi(item.MarriageDate.Replace("/", "")).Replace("/", "");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmcmpprsCalenderEvent", ActionName = "actPrint")]
	public ActionResult Print(string modelObj, string fileName)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			CalenderEventViewModel value = new JavaScriptSerializer().Deserialize<CalenderEventViewModel>(modelObj);
			base.TempData["model"] = value;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		StiReport stiReport = new StiReport();
		try
		{
			CalenderEventViewModel model = new CalenderEventViewModel();
			if (base.TempData["model"] != null)
			{
				model = (CalenderEventViewModel)base.TempData["model"];
			}
			base.TempData["model"] = null;
			int result = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result);
				base.TempData["PFCId"] = null;
			}
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
			parameters.NotUsed_ListCalenderEvent = GetCalenderEvent(model);
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "CalenderEventPrint.xsd");
			XElement val4 = XElement.Parse(stringWriter.ToString());
			val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
			if (result != 0 && !string.IsNullOrWhiteSpace(text2))
			{
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				text2 = text2 + result + "/";
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
