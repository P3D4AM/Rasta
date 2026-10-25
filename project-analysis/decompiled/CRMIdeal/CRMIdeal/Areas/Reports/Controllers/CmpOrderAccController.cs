using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using CRM.Models.ReportModel.CmpOrderAccPrintRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class CmpOrderAccController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCmpOrderAcc")]
	public ActionResult Index()
	{
		GetOrderOpr();
		return View();
	}

	public List<WSspRpt_CmpOrderAcc_Result> GetList(int pageNumber = 1, int pageSize = 100, string orderOprIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspRpt_CmpOrderAcc_Result> list = new List<WSspRpt_CmpOrderAcc_Result>();
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
			list = Enumerable.ToList<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)_dbI.WSspRpt_CmpOrderAcc(userId, rptDate, rptDay, pageNumber, pageSize, lCID, result, orderOprIds, result2));
			if (list == null || !Enumerable.Any<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)list))
			{
				list = new List<WSspRpt_CmpOrderAcc_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetResultList(int pageNumber = 1, int pageSize = 100, string orderOprIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CmpOrderAccViewModel cmpOrderAccViewModel = new CmpOrderAccViewModel();
		cmpOrderAccViewModel.ResultList = new List<WSspRpt_CmpOrderAcc_Result>();
		cmpOrderAccViewModel.IsFind = false;
		cmpOrderAccViewModel.Message = "";
		cmpOrderAccViewModel.TotalPage = 0L;
		try
		{
			cmpOrderAccViewModel.ResultList = GetList(pageNumber, pageSize, orderOprIds);
			if (cmpOrderAccViewModel.ResultList != null && Enumerable.Any<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)cmpOrderAccViewModel.ResultList))
			{
				cmpOrderAccViewModel.IsFind = true;
				foreach (WSspRpt_CmpOrderAcc_Result result3 in cmpOrderAccViewModel.ResultList)
				{
					result3.ordDate = (result3.ordDateTime.HasValue ? result3.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					result3.ordDeadlineDatePersian = (result3.ordDeadlineDate.HasValue ? result3.ordDeadlineDate.Value.ToString("yyyy/MM/dd") : "");
					result3.ImportDate = (result3.ImportDateTime.HasValue ? result3.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
					result3.ordpayDocDate = (result3.ordpayDocDateTime.HasValue ? result3.ordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
				}
				WSspRpt_CmpOrderAcc_Result wSspRpt_CmpOrderAcc_Result = Enumerable.FirstOrDefault<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)cmpOrderAccViewModel.ResultList);
				long result2 = 0L;
				if (wSspRpt_CmpOrderAcc_Result != null)
				{
					long.TryParse(wSspRpt_CmpOrderAcc_Result.AllPage.ToString(), out result2);
				}
				cmpOrderAccViewModel.TotalPage = result2;
			}
			else
			{
				cmpOrderAccViewModel.ResultList = new List<WSspRpt_CmpOrderAcc_Result>();
				cmpOrderAccViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			cmpOrderAccViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(cmpOrderAccViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCmpOrderAcc")]
	public ActionResult Print(string fileName, int pageNumber = 1, int pageSize = 100, string orderOprIds = "")
	{
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		base.TempData["PageNumber"] = pageNumber;
		base.TempData["PageSize"] = pageSize;
		base.TempData["FileName"] = fileName;
		base.TempData["OrderOprId"] = orderOprIds;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Expected O, but got Unknown
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
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
			string orderOprIds = "";
			if (base.TempData["OrderOprId"] != null)
			{
				orderOprIds = base.TempData["OrderOprId"].ToString() ?? "";
			}
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
			parameters.NotUsed_ListWSspRpt_CmpOrderAcc = new List<WSspRpt_CmpOrderAcc_Result>();
			parameters.NotUsed_ListWSspRpt_CmpOrderAcc = GetList(result3, result4, orderOprIds);
			List<WSspRpt_CmpOrderAcc_Result> list = new List<WSspRpt_CmpOrderAcc_Result>();
			List<WSspRpt_CmpOrderAcc_Result> list2 = new List<WSspRpt_CmpOrderAcc_Result>();
			if (parameters.NotUsed_ListWSspRpt_CmpOrderAcc != null && Enumerable.Any<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)parameters.NotUsed_ListWSspRpt_CmpOrderAcc))
			{
				foreach (WSspRpt_CmpOrderAcc_Result item in parameters.NotUsed_ListWSspRpt_CmpOrderAcc)
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
						if (!string.IsNullOrWhiteSpace(item.ImportDate))
						{
							item.ImportDate = PersianDate.GetShamsi2Miladi(item.ImportDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item.ordpayDocDate))
						{
							item.ordpayDocDate = PersianDate.GetShamsi2Miladi(item.ordpayDocDate.Replace("/", "")).Replace("/", "");
						}
					}
					bool flag = true;
					if (list != null && Enumerable.Any<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)list) && Enumerable.FirstOrDefault<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)list, (Func<WSspRpt_CmpOrderAcc_Result, bool>)((WSspRpt_CmpOrderAcc_Result m) => m.OrderID == item.OrderID)) != null)
					{
						flag = false;
					}
					if (flag)
					{
						list.Add(item);
					}
					if (item.OrderPaymentId.GetValueOrDefault() != 0)
					{
						bool flag2 = true;
						if (list2 != null && Enumerable.Any<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)list2) && Enumerable.FirstOrDefault<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)list2, (Func<WSspRpt_CmpOrderAcc_Result, bool>)((WSspRpt_CmpOrderAcc_Result m) => m.OrderPaymentId.GetValueOrDefault() == item.OrderPaymentId.GetValueOrDefault())) != null)
						{
							flag2 = false;
						}
						if (flag2)
						{
							list2.Add(item);
						}
					}
				}
			}
			else
			{
				parameters.NotUsed_ListWSspRpt_CmpOrderAcc = new List<WSspRpt_CmpOrderAcc_Result>();
			}
			parameters.SumOrdTotalAmount = default(decimal);
			parameters.SumRemainOrdAmount = default(decimal);
			parameters.SumPayAmount = default(decimal);
			if (list != null && Enumerable.Any<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)list))
			{
				foreach (WSspRpt_CmpOrderAcc_Result item2 in list)
				{
					parameters.SumOrdTotalAmount += (decimal?)item2.ordTotalAmount.GetValueOrDefault();
					parameters.SumRemainOrdAmount += (decimal?)item2.RemainOrdAmount;
				}
			}
			if (list2 != null && Enumerable.Any<WSspRpt_CmpOrderAcc_Result>((IEnumerable<WSspRpt_CmpOrderAcc_Result>)list2))
			{
				foreach (WSspRpt_CmpOrderAcc_Result item3 in list2)
				{
					parameters.SumPayAmount += (decimal?)item3.ordpayAmount.GetValueOrDefault();
				}
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "CmpOrderAccPrint.xsd");
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

	[AjaxOnly]
	public JsonResult GetOrderOpr()
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
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
