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
using CRM.Models.ReportModel.OrderItemsDeliverySchedulePrintRpt;
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

public class OrderItemsDeliveryScheduleController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptOrdItemsDeliverySchedule")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPrdFirstGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductFirstGroup_Result> list = new List<WSspSelectProductFirstGroup_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectProductFirstGroup_Result>();
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
	public JsonResult GetPrdSecondGroup(int fgId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductSecondGroup_Result> list = new List<WSspSelectProductSecondGroup_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fgId, lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectProductSecondGroup_Result>();
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

	public PartialViewResult _PartialDeliveryScheduleDays(string date, int days)
	{
		DateTime dateTime = DateTime.Now;
		DateTime dateTime2 = default(DateTime);
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(date))
			{
				text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
				text += " 00:00:00";
				dateTime = lCID switch
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
		DateTime dateTime3 = dateTime.AddDays(days);
		DateTimeClass.GetDayNumberFormZiro(dateTime3.ToString("dddd", new CultureInfo("en-US")));
		DateTimeClass.DefineDayeOfWeekStartWith7(dateTime3.DayOfWeek.ToString());
		dateTime3.ToString("yyyy/MM/dd");
		base.ViewBag.Days = days;
		base.ViewBag.IdxDateTime = dateTime3;
		return PartialView();
	}

	public OrdItemsDeliveryScheduleListViewModel GetList(int dayNumber, string date, int sgId, bool isPrint = false)
	{
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		OrdItemsDeliveryScheduleListViewModel ordItemsDeliveryScheduleListViewModel = new OrdItemsDeliveryScheduleListViewModel();
		ordItemsDeliveryScheduleListViewModel.ResultList = new List<WSspRpt_OrderItemsDeliverySchedule_Result>();
		ordItemsDeliveryScheduleListViewModel.ResultOrderList = new List<OrderItemsDeliveryScheduleListViewModel>();
		ordItemsDeliveryScheduleListViewModel.TotalRow = 0L;
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
			ordItemsDeliveryScheduleListViewModel.ResultList = Enumerable.ToList<WSspRpt_OrderItemsDeliverySchedule_Result>((IEnumerable<WSspRpt_OrderItemsDeliverySchedule_Result>)_dbI.WSspRpt_OrderItemsDeliverySchedule(sgId.ToString(), dayNumber, value, userId, rptDate, rptDay, lCID, result, result2));
			if (ordItemsDeliveryScheduleListViewModel.ResultList != null && Enumerable.Any<WSspRpt_OrderItemsDeliverySchedule_Result>((IEnumerable<WSspRpt_OrderItemsDeliverySchedule_Result>)ordItemsDeliveryScheduleListViewModel.ResultList))
			{
				foreach (WSspRpt_OrderItemsDeliverySchedule_Result result3 in ordItemsDeliveryScheduleListViewModel.ResultList)
				{
					if (string.IsNullOrWhiteSpace(result3.OrderList))
					{
						continue;
					}
					List<OrderItemsDeliveryScheduleListViewModel> list = new JavaScriptSerializer().Deserialize<List<OrderItemsDeliveryScheduleListViewModel>>(result3.OrderList);
					if (list == null || !Enumerable.Any<OrderItemsDeliveryScheduleListViewModel>((IEnumerable<OrderItemsDeliveryScheduleListViewModel>)list))
					{
						continue;
					}
					if (list.Count > ordItemsDeliveryScheduleListViewModel.TotalRow)
					{
						ordItemsDeliveryScheduleListViewModel.TotalRow = list.Count;
					}
					foreach (OrderItemsDeliveryScheduleListViewModel item in list)
					{
						item.RowNumber = result3.RowNumber;
						item.Title = result3.Title;
						item.FTime = result3.FTime;
						item.TTime = result3.TTime;
						item.Cnt = result3.Cnt;
						item.UsedCount = result3.UsedCount;
						item.PrdId = result3.PrdId;
						item.OrderView = result3.OrderView;
						item.PrdName = result3.PrdName;
						item.PrdCode = result3.PrdCode;
						item.PrdSGId = result3.PrdSGId;
						item.PrdSGName = result3.PrdSGName;
						item.PrdFGId = result3.PrdFGId;
						item.PrdFGName = result3.PrdFGName;
						item.rptUserId = result3.rptUserId;
						item.rptDate = result3.rptDate;
						item.rptDay = result3.rptDay;
						item.rptUserName = result3.rptUserName;
						if (!isPrint)
						{
							item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
							item.ordDeliveryDate = (item.ordDeliveryDateTime.HasValue ? item.ordDeliveryDateTime.Value.ToString("yyyy/MM/dd") : "");
							item.ordDeliveryEndDate = (item.ordDeliveryEndDateTime.HasValue ? item.ordDeliveryEndDateTime.Value.ToString("yyyy/MM/dd") : "");
							item.ordIDeliveryDatePersian = (item.ordIDeliveryDate.HasValue ? item.ordIDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
							item.ordIDeliveryEndDatePersian = (item.ordIDeliveryEndDate.HasValue ? item.ordIDeliveryEndDate.Value.ToString("yyyy/MM/dd") : "");
						}
					}
					ordItemsDeliveryScheduleListViewModel.ResultOrderList.AddRange(list);
				}
			}
			else
			{
				ordItemsDeliveryScheduleListViewModel.ResultList = new List<WSspRpt_OrderItemsDeliverySchedule_Result>();
			}
			if (ordItemsDeliveryScheduleListViewModel.ResultOrderList == null)
			{
				ordItemsDeliveryScheduleListViewModel.ResultOrderList = new List<OrderItemsDeliveryScheduleListViewModel>();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return ordItemsDeliveryScheduleListViewModel;
	}

	[AjaxOnly]
	public JsonResult GetResultList(int dayNumber, string date, int sgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		OrderItemsDeliveryScheduleViewModel orderItemsDeliveryScheduleViewModel = new OrderItemsDeliveryScheduleViewModel();
		orderItemsDeliveryScheduleViewModel.Result = new OrdItemsDeliveryScheduleListViewModel();
		orderItemsDeliveryScheduleViewModel.IsFind = false;
		orderItemsDeliveryScheduleViewModel.Message = "";
		orderItemsDeliveryScheduleViewModel.TotalPage = 0L;
		try
		{
			orderItemsDeliveryScheduleViewModel.Result = GetList(dayNumber, date, sgId);
			if (orderItemsDeliveryScheduleViewModel.Result != null)
			{
				orderItemsDeliveryScheduleViewModel.IsFind = true;
			}
			else
			{
				orderItemsDeliveryScheduleViewModel.Result = new OrdItemsDeliveryScheduleListViewModel();
				orderItemsDeliveryScheduleViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			orderItemsDeliveryScheduleViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(orderItemsDeliveryScheduleViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptOrdItemsDeliverySchedule")]
	public ActionResult Print(string fileName, int dayNumber, string date, int sgId)
	{
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		base.TempData["DayNumber"] = dayNumber;
		base.TempData["DelvDate"] = date;
		base.TempData["FileName"] = fileName;
		base.TempData["SgId"] = sgId;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Expected O, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
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
			int result4 = 0;
			int.TryParse(base.TempData["SgId"].ToString(), out result4);
			result4 = ((result4 != 0) ? result4 : 0);
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
			parameters.NotUsed_ListWSspRpt_OrderItemsDeliverySchedule = new List<WSspRpt_OrderItemsDeliverySchedule_Result>();
			parameters.NotUsed_ListWSspRpt_OrderList = new List<OrderItemsDeliveryScheduleListViewModel>();
			OrdItemsDeliveryScheduleListViewModel list = GetList(result3, text4, result4, isPrint: true);
			if (list != null)
			{
				parameters.NotUsed_ListWSspRpt_OrderItemsDeliverySchedule = list.ResultList;
				parameters.NotUsed_ListWSspRpt_OrderList = list.ResultOrderList;
			}
			if (parameters.NotUsed_ListWSspRpt_OrderItemsDeliverySchedule == null)
			{
				parameters.NotUsed_ListWSspRpt_OrderItemsDeliverySchedule = new List<WSspRpt_OrderItemsDeliverySchedule_Result>();
			}
			if (parameters.NotUsed_ListWSspRpt_OrderList != null && Enumerable.Any<OrderItemsDeliveryScheduleListViewModel>((IEnumerable<OrderItemsDeliveryScheduleListViewModel>)parameters.NotUsed_ListWSspRpt_OrderList))
			{
				foreach (OrderItemsDeliveryScheduleListViewModel notUsed_ListWSspRpt_Order in parameters.NotUsed_ListWSspRpt_OrderList)
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
						if (!string.IsNullOrWhiteSpace(notUsed_ListWSspRpt_Order.ordIDeliveryDatePersian))
						{
							notUsed_ListWSspRpt_Order.ordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListWSspRpt_Order.ordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(notUsed_ListWSspRpt_Order.ordIDeliveryEndDatePersian))
						{
							notUsed_ListWSspRpt_Order.ordIDeliveryEndDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListWSspRpt_Order.ordIDeliveryEndDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			else
			{
				parameters.NotUsed_ListWSspRpt_OrderList = new List<OrderItemsDeliveryScheduleListViewModel>();
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "OrderItemsDeliverySchedulePrint.xsd");
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
