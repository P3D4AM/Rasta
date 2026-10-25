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
using CRM.Models.ReportModel.OrderDeliverySchedulePrintRpt;
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

public class OrderDeliveryScheduleController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptOrdDeliverySchedule")]
	public ActionResult Index()
	{
		return View();
	}

	public PartialViewResult _PartialDeliveryScheduleDays(int days)
	{
		base.ViewBag.Days = days;
		return PartialView();
	}

	public OrdDeliveryScheduleListViewModel GetList(int dayNumber, string date, bool isPrint = false)
	{
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		OrdDeliveryScheduleListViewModel ordDeliveryScheduleListViewModel = new OrdDeliveryScheduleListViewModel();
		ordDeliveryScheduleListViewModel.ResultList = new List<WSspRpt_OrderDeliverySchedule_Result>();
		ordDeliveryScheduleListViewModel.ResultOrderList = new List<OrderDeliveryScheduleListViewModel>();
		ordDeliveryScheduleListViewModel.TotalRow = 0L;
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
			DateTime value = default(DateTime);
			DateTime dateTime = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(date))
				{
					text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					text += " 00:00:00";
					value = lCID switch
					{
						1065 => DateTime.Parse(text, new PersianCulture()), 
						1025 => DateTime.Parse(text, new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text, new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			ordDeliveryScheduleListViewModel.ResultList = Enumerable.ToList<WSspRpt_OrderDeliverySchedule_Result>((IEnumerable<WSspRpt_OrderDeliverySchedule_Result>)_dbI.WSspRpt_OrderDeliverySchedule(dayNumber, value, userId, rptDate, rptDay, lCID, result, result2));
			if (ordDeliveryScheduleListViewModel.ResultList != null && Enumerable.Any<WSspRpt_OrderDeliverySchedule_Result>((IEnumerable<WSspRpt_OrderDeliverySchedule_Result>)ordDeliveryScheduleListViewModel.ResultList))
			{
				foreach (WSspRpt_OrderDeliverySchedule_Result result3 in ordDeliveryScheduleListViewModel.ResultList)
				{
					if (string.IsNullOrWhiteSpace(result3.OrderList))
					{
						continue;
					}
					List<OrderDeliveryScheduleListViewModel> list = new JavaScriptSerializer().Deserialize<List<OrderDeliveryScheduleListViewModel>>(result3.OrderList);
					if (list == null || !Enumerable.Any<OrderDeliveryScheduleListViewModel>((IEnumerable<OrderDeliveryScheduleListViewModel>)list))
					{
						continue;
					}
					if (list.Count > ordDeliveryScheduleListViewModel.TotalRow)
					{
						ordDeliveryScheduleListViewModel.TotalRow = list.Count;
					}
					foreach (OrderDeliveryScheduleListViewModel item in list)
					{
						item.RowNumber = result3.RowNumber;
						item.Title = result3.Title;
						item.FTime = result3.FTime;
						item.TTime = result3.TTime;
						item.Cnt = result3.Cnt;
						item.UsedCount = result3.UsedCount;
						item.OrderView = result3.OrderView;
						item.rptUserId = result3.rptUserId;
						item.rptDate = result3.rptDate;
						item.rptDay = result3.rptDay;
						item.rptUserName = result3.rptUserName;
						if (!isPrint)
						{
							item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
							item.ordDeliveryDate = (item.ordDeliveryDateTime.HasValue ? item.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
							item.ordDeliveryEndDate = (item.ordDeliveryEndDateTime.HasValue ? item.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
						}
					}
					ordDeliveryScheduleListViewModel.ResultOrderList.AddRange(list);
				}
			}
			else
			{
				ordDeliveryScheduleListViewModel.ResultList = new List<WSspRpt_OrderDeliverySchedule_Result>();
			}
			if (ordDeliveryScheduleListViewModel.ResultOrderList == null)
			{
				ordDeliveryScheduleListViewModel.ResultOrderList = new List<OrderDeliveryScheduleListViewModel>();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return ordDeliveryScheduleListViewModel;
	}

	[AjaxOnly]
	public JsonResult GetResultList(int dayNumber, string date)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		OrderDeliveryScheduleViewModel orderDeliveryScheduleViewModel = new OrderDeliveryScheduleViewModel();
		orderDeliveryScheduleViewModel.Result = new OrdDeliveryScheduleListViewModel();
		orderDeliveryScheduleViewModel.IsFind = false;
		orderDeliveryScheduleViewModel.Message = "";
		orderDeliveryScheduleViewModel.TotalPage = 0L;
		try
		{
			orderDeliveryScheduleViewModel.Result = GetList(dayNumber, date);
			if (orderDeliveryScheduleViewModel.Result != null)
			{
				orderDeliveryScheduleViewModel.IsFind = true;
			}
			else
			{
				orderDeliveryScheduleViewModel.Result = new OrdDeliveryScheduleListViewModel();
				orderDeliveryScheduleViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			orderDeliveryScheduleViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(orderDeliveryScheduleViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptOrdDeliverySchedule")]
	public ActionResult Print(string fileName, int dayNumber, string date)
	{
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		base.TempData["DayNumber"] = dayNumber;
		base.TempData["DelvDate"] = date;
		base.TempData["FileName"] = fileName;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
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
			int result3 = 0;
			int.TryParse(base.TempData["DayNumber"].ToString(), out result3);
			result3 = ((result3 != 0) ? result3 : 0);
			string text4 = base.TempData["DelvDate"].ToString();
			text4 = text4 ?? "";
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
			DateTime deliveryDate = default(DateTime);
			DateTime dateTime = default(DateTime);
			string text5 = "";
			try
			{
				if (!string.IsNullOrWhiteSpace(text4))
				{
					text5 = PersianDate.GetFormatetdDate(text4.Replace("/", ""));
					text5 += " 00:00:00";
					deliveryDate = lCID switch
					{
						1065 => DateTime.Parse(text5, new PersianCulture()), 
						1025 => DateTime.Parse(text5, new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text5, new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			parameters.DeliveryDate = deliveryDate;
			parameters.DeliveryDatePersian = text4;
			parameters.DeliveryDay = result3;
			parameters.DeliveryDayName = DateTimeClass.ConvertNumToDayeOfWeek(result3);
			parameters.NotUsed_ListWSspRpt_OrderDeliverySchedule = new List<WSspRpt_OrderDeliverySchedule_Result>();
			parameters.NotUsed_ListWSspRpt_OrderList = new List<OrderDeliveryScheduleListViewModel>();
			OrdDeliveryScheduleListViewModel list = GetList(result3, text4, isPrint: true);
			if (list != null)
			{
				parameters.NotUsed_ListWSspRpt_OrderDeliverySchedule = list.ResultList;
				parameters.NotUsed_ListWSspRpt_OrderList = list.ResultOrderList;
			}
			if (parameters.NotUsed_ListWSspRpt_OrderDeliverySchedule == null)
			{
				parameters.NotUsed_ListWSspRpt_OrderDeliverySchedule = new List<WSspRpt_OrderDeliverySchedule_Result>();
			}
			if (parameters.NotUsed_ListWSspRpt_OrderList != null && Enumerable.Any<OrderDeliveryScheduleListViewModel>((IEnumerable<OrderDeliveryScheduleListViewModel>)parameters.NotUsed_ListWSspRpt_OrderList))
			{
				foreach (OrderDeliveryScheduleListViewModel notUsed_ListWSspRpt_Order in parameters.NotUsed_ListWSspRpt_OrderList)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrWhiteSpace(notUsed_ListWSspRpt_Order.ordDate))
						{
							notUsed_ListWSspRpt_Order.ordDate = PersianDate.GetShamsi2Miladi(notUsed_ListWSspRpt_Order.ordDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(notUsed_ListWSspRpt_Order.ordDeliveryDate))
						{
							notUsed_ListWSspRpt_Order.ordDeliveryDate = PersianDate.GetShamsi2Miladi(notUsed_ListWSspRpt_Order.ordDeliveryDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(notUsed_ListWSspRpt_Order.ordDeliveryEndDate))
						{
							notUsed_ListWSspRpt_Order.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(notUsed_ListWSspRpt_Order.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			else
			{
				parameters.NotUsed_ListWSspRpt_OrderList = new List<OrderDeliveryScheduleListViewModel>();
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "OrderDeliverySchedulePrint.xsd");
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
			string text6 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
			text6 = text6.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
			text6 = text6.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
			text6 = text6.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
			text6 = text6.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
			((CollectionBase)stiReport.Dictionary.Databases).Clear();
			stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text6));
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
