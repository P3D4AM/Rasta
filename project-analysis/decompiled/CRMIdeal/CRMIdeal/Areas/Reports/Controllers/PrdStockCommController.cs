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
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.PrdStockCommPrintRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class PrdStockCommController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptPrdStockComm")]
	public ActionResult Index()
	{
		GetWareHouse();
		GetFirstGroup();
		GetSecondGroup();
		return View();
	}

	public JsonResult SearchProducts(string prdName = "", string prdBarcode = "", int prdFirstGroup = 0, int prdSecondGroup = 0, int prdKind = 1, int prdShowMode = 0, int prdInActive = 0)
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
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetWareHouse()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectWareHouseForRepParam_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouseForRepParam();
			list.AddRange(Enumerable.Select<CRMspSelectWareHouseForRepParam_Result, SelectListItem>((IEnumerable<CRMspSelectWareHouseForRepParam_Result>)list2, (Func<CRMspSelectWareHouseForRepParam_Result, SelectListItem>)((CRMspSelectWareHouseForRepParam_Result item) => new SelectListItem
			{
				Text = item.WrhsName,
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WareHouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
			List<CRMspSelectProductFirstGroupWithAllForRepParam_Result> list2 = Enumerable.ToList<CRMspSelectProductFirstGroupWithAllForRepParam_Result>((IEnumerable<CRMspSelectProductFirstGroupWithAllForRepParam_Result>)_db.CRMspSelectProductFirstGroupWithAllForRepParam(lCID, result, Labels.All));
			list.AddRange(Enumerable.Select<CRMspSelectProductFirstGroupWithAllForRepParam_Result, SelectListItem>((IEnumerable<CRMspSelectProductFirstGroupWithAllForRepParam_Result>)list2, (Func<CRMspSelectProductFirstGroupWithAllForRepParam_Result, SelectListItem>)((CRMspSelectProductFirstGroupWithAllForRepParam_Result item) => new SelectListItem
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
	public JsonResult GetSecondGroup(string fgId = "0")
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
			List<CRMspSelectProductSecondGroupWithAllForRepParam_Result> list2 = Enumerable.ToList<CRMspSelectProductSecondGroupWithAllForRepParam_Result>((IEnumerable<CRMspSelectProductSecondGroupWithAllForRepParam_Result>)_db.CRMspSelectProductSecondGroupWithAllForRepParam(fgId, lCID, result, Labels.All));
			list.AddRange(Enumerable.Select<CRMspSelectProductSecondGroupWithAllForRepParam_Result, SelectListItem>((IEnumerable<CRMspSelectProductSecondGroupWithAllForRepParam_Result>)list2, (Func<CRMspSelectProductSecondGroupWithAllForRepParam_Result, SelectListItem>)((CRMspSelectProductSecondGroupWithAllForRepParam_Result item) => new SelectListItem
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

	public List<WSspRpt_PrdStockComm_Result> GetList(int whId, int fgId, int sgId, int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspRpt_PrdStockComm_Result> list = new List<WSspRpt_PrdStockComm_Result>();
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
			list = Enumerable.ToList<WSspRpt_PrdStockComm_Result>((IEnumerable<WSspRpt_PrdStockComm_Result>)_dbII.WSspRpt_PrdStockComm(fgId, sgId, prdId, whId, now, userId, rptDate, rptDay, lCID, result, result2));
			if (list == null)
			{
				list = new List<WSspRpt_PrdStockComm_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult ResultList_Read([DataSourceRequest] DataSourceRequest request, int whId, int fgId, int sgId, int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspRpt_PrdStockComm_Result> enumerable = new List<WSspRpt_PrdStockComm_Result>();
		try
		{
			enumerable = GetList(whId, fgId, sgId, prdId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptPrdStockComm")]
	public ActionResult Print(string fileName, int whId = 0, int fgId = 0, int sgId = 0, int prdId = 0)
	{
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		base.TempData["FileName"] = fileName;
		base.TempData["FGId"] = fgId;
		base.TempData["SGId"] = sgId;
		base.TempData["PrdId"] = prdId;
		base.TempData["WHId"] = whId;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
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
			int result3 = 0;
			int.TryParse(base.TempData["FGId"].ToString(), out result3);
			int result4 = 0;
			int.TryParse(base.TempData["SGId"].ToString(), out result4);
			int result5 = 0;
			int.TryParse(base.TempData["PrdId"].ToString(), out result5);
			int result6 = 0;
			int.TryParse(base.TempData["WHId"].ToString(), out result6);
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
			parameters.NotUsed_ListWSspRpt_PrdStockComm = new List<WSspRpt_PrdStockComm_Result>();
			parameters.NotUsed_ListWSspRpt_PrdStockComm = GetList(result6, result3, result4, result5);
			if (parameters.NotUsed_ListWSspRpt_PrdStockComm == null)
			{
				parameters.NotUsed_ListWSspRpt_PrdStockComm = new List<WSspRpt_PrdStockComm_Result>();
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "PrdStockCommPrint.xsd");
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
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
