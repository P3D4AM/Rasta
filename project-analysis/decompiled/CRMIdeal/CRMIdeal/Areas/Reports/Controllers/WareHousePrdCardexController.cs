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
using CRM.Models.ReportModel.WareHousePrdCardexPrintRpt;
using CRM.Resources;
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

public class WareHousePrdCardexController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptWrhsPrdCardex")]
	public ActionResult Index()
	{
		GetWareHouse();
		GetCompanies();
		return View();
	}

	public ActionResult SerialList_Read([DataSourceRequest] DataSourceRequest request, string modelObj)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		List<WSspRpt_ProductCardex_Result> list = new List<WSspRpt_ProductCardex_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WareHousePrdCardexViewModel model = new JavaScriptSerializer().Deserialize<WareHousePrdCardexViewModel>(modelObj);
			list = GetProductCardex(model);
			foreach (WSspRpt_ProductCardex_Result item in list)
			{
				if (lCID != 1065)
				{
					if (!string.IsNullOrEmpty(item.DocDate))
					{
						item.DocDate = PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item.obDate))
					{
						item.obDate = PersianDate.GetShamsi2Miladi(item.obDate.Replace("/", "")).Replace("/", "");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspRpt_ProductCardex_Result> GetProductCardex(WareHousePrdCardexViewModel model)
	{
		List<WSspRpt_ProductCardex_Result> result = new List<WSspRpt_ProductCardex_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
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
			model.Tracing = ConvertCharacter.DecodeTracing(model.Tracing);
			if (!string.IsNullOrEmpty(model.Tracing))
			{
				if (model.Tracing == "-1")
				{
					model.Tracing = "#-1#";
				}
			}
			else
			{
				model.Tracing = null;
			}
			string stockBeforeFDateText = Labels.StockBeforeFDateText;
			DateTime now = DateTime.Now;
			result = Enumerable.ToList<WSspRpt_ProductCardex_Result>((IEnumerable<WSspRpt_ProductCardex_Result>)_db.WSspRpt_ProductCardex(model.FromDate, userId: UserLogin.CurrentUser.UserId, rptDate: now.ToString("yyyy/MM/dd HH:mm:ss"), rptDay: DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), tDate: model.ToDate, prdId: model.PrdId, wHId: model.WHId, fDateTime: value, tDateTime: value2, languageID: lCID, defaultLanguageID: result2, companyId: model.CompanyId, stockBeforeFDateText: stockBeforeFDateText, fCR: model.FCR, fCRI: model.FCRI, tracing: model.Tracing, centerId: result3));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetWareHouse()
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
			List<WSspSelectWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, SelectListItem>)((WSspSelectWareHouse_Result item) => new SelectListItem
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
	public JsonResult GetProducts(string val = "", int selectPrdId = 0, int showMode = 2, int prdKind = 0, int prdInActive = -1)
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
			List<WSspSearchProducts_Result> list2 = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(0, 0, "", val, selectPrdId, showMode, lCID, result, prdKind, prdInActive, 0, 0, "", null));
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

	[AjaxOnly]
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
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCompanies()
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
			List<CrmspSelectNotForbiddenCompany_Result> list2 = Enumerable.ToList<CrmspSelectNotForbiddenCompany_Result>((IEnumerable<CrmspSelectNotForbiddenCompany_Result>)_db.CrmspSelectNotForbiddenCompany(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CrmspSelectNotForbiddenCompany_Result, SelectListItem>((IEnumerable<CrmspSelectNotForbiddenCompany_Result>)list2, (Func<CrmspSelectNotForbiddenCompany_Result, SelectListItem>)((CrmspSelectNotForbiddenCompany_Result item) => new SelectListItem
			{
				Text = item.cmpName,
				Value = item.CompanyID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CompaniesList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdTracing(int whId, int prdId, string searchVal = "")
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrWhiteSpace(searchVal) && searchVal == Labels.SelectedListDefValue)
			{
				searchVal = "";
			}
			List<WSspSearchProductTracing_Result> list2 = Enumerable.ToList<WSspSearchProductTracing_Result>((IEnumerable<WSspSearchProductTracing_Result>)_dbII.WSspSearchProductTracing(whId, prdId, searchVal, result2));
			if (string.IsNullOrWhiteSpace(searchVal) && list2 != null && Enumerable.Any<WSspSearchProductTracing_Result>((IEnumerable<WSspSearchProductTracing_Result>)list2))
			{
				list2 = Enumerable.ToList<WSspSearchProductTracing_Result>(Enumerable.Take<WSspSearchProductTracing_Result>((IEnumerable<WSspSearchProductTracing_Result>)list2, 100));
			}
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "",
				Selected = true
			};
			list.Add(item2);
			item2 = new SelectListItem
			{
				Text = Labels.HaveNot,
				Value = "-1",
				Selected = false
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSearchProductTracing_Result, SelectListItem>((IEnumerable<WSspSearchProductTracing_Result>)list2, (Func<WSspSearchProductTracing_Result, SelectListItem>)((WSspSearchProductTracing_Result item) => new SelectListItem
			{
				Text = (item.Tracing ?? ""),
				Value = (item.Tracing ?? ""),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdTracingList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmProductCardex", ActionName = "actPrint")]
	public ActionResult Print(string modelObj, string fileName)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			WareHousePrdCardexViewModel value = new JavaScriptSerializer().Deserialize<WareHousePrdCardexViewModel>(modelObj);
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
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
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
			WareHousePrdCardexViewModel model = new WareHousePrdCardexViewModel();
			if (base.TempData["model"] != null)
			{
				model = (WareHousePrdCardexViewModel)base.TempData["model"];
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
			parameters.NotUsed_ListProductCardex = GetProductCardex(model);
			foreach (WSspRpt_ProductCardex_Result item in parameters.NotUsed_ListProductCardex)
			{
				if (lCID != 1065)
				{
					if (!string.IsNullOrEmpty(item.DocDate))
					{
						item.DocDate = PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item.obDate))
					{
						item.obDate = PersianDate.GetShamsi2Miladi(item.obDate.Replace("/", "")).Replace("/", "");
					}
				}
			}
			List<WSspRpt_ProductCardexSerials_Result> list = new List<WSspRpt_ProductCardexSerials_Result>();
			foreach (WSspRpt_ProductCardex_Result item2 in parameters.NotUsed_ListProductCardex)
			{
				List<WSspRpt_ProductCardexSerials_Result> collection = Enumerable.ToList<WSspRpt_ProductCardexSerials_Result>((IEnumerable<WSspRpt_ProductCardexSerials_Result>)_db.WSspRpt_ProductCardexSerials(item2.DocItemId));
				list.AddRange(collection);
			}
			parameters.NotUsed_ListProductCardexSerials = list;
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "WareHousePrdCardexPrint.xsd");
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
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
