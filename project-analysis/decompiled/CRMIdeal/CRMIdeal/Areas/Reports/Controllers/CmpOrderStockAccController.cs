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
using CRM.Models.ReportModel.CmpOrderStockAccPrintRpt;
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

public class CmpOrderStockAccController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCmpOrderStockAcc")]
	public ActionResult Index()
	{
		GetOrderOpr();
		return View();
	}

	public List<CmpOrderStockAccViewModel> GetList(int pageNumber = 1, int pageSize = 100, string warehouseIds = "", string orderOprIds = "", string saleOrderDate = "")
	{
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CmpOrderStockAccViewModel> list = new List<CmpOrderStockAccViewModel>();
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
			_ = DateTime.Now;
			try
			{
				if (!string.IsNullOrWhiteSpace(saleOrderDate))
				{
					text = PersianDate.GetFormatetdDate(saleOrderDate.Replace("/", ""));
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
			List<WSspRpt_CmpOrderStockAcc_Result> list2 = Enumerable.ToList<WSspRpt_CmpOrderStockAcc_Result>((IEnumerable<WSspRpt_CmpOrderStockAcc_Result>)_dbI.WSspRpt_CmpOrderStockAcc(now, warehouseIds, userId, rptDate, rptDay, pageNumber, pageSize, lCID, result, orderOprIds, (!string.IsNullOrWhiteSpace(saleOrderDate)) ? new DateTime?(value) : null, result2));
			if (list2 != null && Enumerable.Any<WSspRpt_CmpOrderStockAcc_Result>((IEnumerable<WSspRpt_CmpOrderStockAcc_Result>)list2))
			{
				foreach (WSspRpt_CmpOrderStockAcc_Result item in list2)
				{
					List<CmpOrderStockAccViewModel> list3 = new List<CmpOrderStockAccViewModel>();
					CmpOrderStockAccViewModel cmpOrderStockAccViewModel = new CmpOrderStockAccViewModel();
					if (!string.IsNullOrWhiteSpace(item.ItemQtyAndSaleJson))
					{
						List<CmpOrderStockAccItemQtyAndSaleViewModel> list4 = new JavaScriptSerializer().Deserialize<List<CmpOrderStockAccItemQtyAndSaleViewModel>>(item.ItemQtyAndSaleJson);
						if (list4 != null && Enumerable.Any<CmpOrderStockAccItemQtyAndSaleViewModel>((IEnumerable<CmpOrderStockAccItemQtyAndSaleViewModel>)list4))
						{
							foreach (CmpOrderStockAccItemQtyAndSaleViewModel item2 in list4)
							{
								cmpOrderStockAccViewModel = new CmpOrderStockAccViewModel
								{
									RowNumber = item.RowNumber,
									rptUserId = item.rptUserId,
									rptDate = item.rptDate,
									rptDay = item.rptDay,
									rptUserName = item.rptUserName,
									PrdId = item.PrdId,
									PrdOrderView = item.PrdOrderView,
									PrdName = item.PrdName,
									PrdCode = item.PrdCode,
									PrdFirstGroupName = item.PrdFirstGroupName,
									PrdFirstGroupCode = item.PrdFirstGroupCode,
									PrdFirstGroupOrderView = item.PrdFirstGroupOrderView,
									PrdFirstGroupId = item.PrdFirstGroupId,
									PrdSecondGroupName = item.PrdSecondGroupName,
									PrdSecondGroupCode = item.PrdSecondGroupCode,
									PrdSecondGroupOrderView = item.PrdSecondGroupOrderView,
									PrdSecondGroupId = item.PrdSecondGroupId,
									SaleOrdCountToday = item.SaleOrdCountToday,
									AllPage = item.AllPage,
									WHId = item2.WHId,
									WrhsName = item2.WrhsName,
									OrderView = item2.OrderView,
									PrdUnitIRate = item2.PrdUnitIRate,
									FCR = item2.FCR,
									Tracing = item2.Tracing,
									RemainCount = item2.RemainCount,
									SaleOrdCountMonth1 = item2.SaleOrdCountMonth1,
									SaleOrdCountMonth2 = item2.SaleOrdCountMonth2,
									SaleOrdCountMonth3 = item2.SaleOrdCountMonth3,
									SaleOrdCountMonth4 = item2.SaleOrdCountMonth4,
									SaleOrdCountMonth5 = item2.SaleOrdCountMonth5,
									SaleOrdCountMonth6 = item2.SaleOrdCountMonth6,
									SaleOrdCountMonth7 = item2.SaleOrdCountMonth7,
									SaleOrdCountMonth8 = item2.SaleOrdCountMonth8,
									SaleOrdCountMonth9 = item2.SaleOrdCountMonth9,
									SaleOrdCountMonth10 = item2.SaleOrdCountMonth10,
									SaleOrdCountMonth11 = item2.SaleOrdCountMonth11,
									SaleOrdCountMonth12 = item2.SaleOrdCountMonth12,
									RemainCountNoTracing = item2.RemainCountNoTracing
								};
								list3.Add(cmpOrderStockAccViewModel);
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(item.RemainCountInWarehouesesJson))
					{
						List<CmpOrderStockAccRemainCountInWarehouesesViewModel> list5 = new JavaScriptSerializer().Deserialize<List<CmpOrderStockAccRemainCountInWarehouesesViewModel>>(item.RemainCountInWarehouesesJson);
						if (list5 != null && Enumerable.Any<CmpOrderStockAccRemainCountInWarehouesesViewModel>((IEnumerable<CmpOrderStockAccRemainCountInWarehouesesViewModel>)list5))
						{
							foreach (CmpOrderStockAccRemainCountInWarehouesesViewModel item3 in list5)
							{
								if (list3 == null || !Enumerable.Any<CmpOrderStockAccViewModel>((IEnumerable<CmpOrderStockAccViewModel>)list3))
								{
									continue;
								}
								foreach (CmpOrderStockAccViewModel item4 in list3)
								{
									if (item4 != null && item4.WHId.GetValueOrDefault() != 0 && item4.WHId == item3.WHId && item4.PrdId == item3.PrdId)
									{
										item4.SelectedWrhsTotalStock = item3.RemainCount;
									}
								}
							}
						}
					}
					list.AddRange(list3);
				}
			}
			if (list == null)
			{
				list = new List<CmpOrderStockAccViewModel>();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetResultList(int pageNumber = 1, int pageSize = 100, string warehouseIds = "", string orderOprIds = "", string saleOrderDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CmpOrderStockAccListViewModel cmpOrderStockAccListViewModel = new CmpOrderStockAccListViewModel();
		cmpOrderStockAccListViewModel.ResultList = new List<CmpOrderStockAccViewModel>();
		cmpOrderStockAccListViewModel.IsFind = false;
		cmpOrderStockAccListViewModel.Message = "";
		cmpOrderStockAccListViewModel.TotalPage = 0L;
		try
		{
			cmpOrderStockAccListViewModel.ResultList = GetList(pageNumber, pageSize, warehouseIds, orderOprIds, saleOrderDate);
			if (cmpOrderStockAccListViewModel.ResultList != null && Enumerable.Any<CmpOrderStockAccViewModel>((IEnumerable<CmpOrderStockAccViewModel>)cmpOrderStockAccListViewModel.ResultList))
			{
				cmpOrderStockAccListViewModel.IsFind = true;
				CmpOrderStockAccViewModel cmpOrderStockAccViewModel = Enumerable.FirstOrDefault<CmpOrderStockAccViewModel>((IEnumerable<CmpOrderStockAccViewModel>)cmpOrderStockAccListViewModel.ResultList);
				long result2 = 0L;
				if (cmpOrderStockAccViewModel != null)
				{
					long.TryParse(cmpOrderStockAccViewModel.AllPage.ToString(), out result2);
				}
				cmpOrderStockAccListViewModel.TotalPage = result2;
			}
			else
			{
				cmpOrderStockAccListViewModel.ResultList = new List<CmpOrderStockAccViewModel>();
				cmpOrderStockAccListViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			cmpOrderStockAccListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(cmpOrderStockAccListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCmpOrderStockAcc")]
	public ActionResult Print(string fileName, int pageNumber = 1, int pageSize = 100, string warehouseIds = "", string orderOprIds = "", string saleOrderDate = "")
	{
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		base.TempData["PageNumber"] = pageNumber;
		base.TempData["PageSize"] = pageSize;
		base.TempData["FileName"] = fileName;
		base.TempData["WarehouseIds"] = warehouseIds;
		base.TempData["OrderOprId"] = orderOprIds;
		base.TempData["SaleOrderDate"] = saleOrderDate;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		StiReport stiReport = new StiReport();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
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
			string warehouseIds = base.TempData["WarehouseIds"].ToString();
			string orderOprIds = "";
			if (base.TempData["OrderOprId"] != null)
			{
				orderOprIds = base.TempData["OrderOprId"].ToString() ?? "";
			}
			string saleOrderDate = "";
			if (base.TempData["SaleOrderDate"] != null)
			{
				saleOrderDate = base.TempData["SaleOrderDate"].ToString();
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
			parameters.NotUsed_ListCmpOrderStockAcc = new List<CmpOrderStockAccViewModel>();
			parameters.NotUsed_ListCmpOrderStockAcc = GetList(result3, result4, warehouseIds, orderOprIds, saleOrderDate);
			if (parameters.NotUsed_ListCmpOrderStockAcc == null)
			{
				parameters.NotUsed_ListCmpOrderStockAcc = new List<CmpOrderStockAccViewModel>();
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "CmpOrderStockAccPrint.xsd");
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
