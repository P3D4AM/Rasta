using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
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
using CRM.Models.ReportModel.WarehouseReserveStockPrintRpt;
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

public class WarehouseReserveStockController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptWrhsStock")]
	public ActionResult Index()
	{
		GetWareHouse();
		GetFirstGroup();
		GetSecondGroup();
		GetPrdModel();
		GetPrdKind();
		GetPrdInActive();
		return View();
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptWrhsStock")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(WarehouseReserveStockViewModel model)
	{
		try
		{
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				base.TempData["model"] = model;
				base.ViewBag.Successfull = "ok";
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
		}
		GetWareHouse();
		GetFirstGroup();
		GetSecondGroup();
		GetPrdModel();
		GetPrdKind();
		GetPrdInActive();
		return View(model);
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

	[AjaxOnly]
	public JsonResult GetProducts(string sgId = "0")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectProductsWithAllForRepParam_Result> list = new List<CRMspSelectProductsWithAllForRepParam_Result>();
		try
		{
			List<CRMspSelectProductsWithAllForRepParam_Result> list2 = Enumerable.ToList<CRMspSelectProductsWithAllForRepParam_Result>((IEnumerable<CRMspSelectProductsWithAllForRepParam_Result>)_db.CRMspSelectProductsWithAllForRepParam(sgId, lCID, result, Labels.All));
			list.AddRange(Enumerable.Select<CRMspSelectProductsWithAllForRepParam_Result, CRMspSelectProductsWithAllForRepParam_Result>((IEnumerable<CRMspSelectProductsWithAllForRepParam_Result>)list2, (Func<CRMspSelectProductsWithAllForRepParam_Result, CRMspSelectProductsWithAllForRepParam_Result>)((CRMspSelectProductsWithAllForRepParam_Result item) => new CRMspSelectProductsWithAllForRepParam_Result
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
	public JsonResult GetPrdModel()
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
			List<WSspSelectProductModels_Result> list2 = Enumerable.ToList<WSspSelectProductModels_Result>((IEnumerable<WSspSelectProductModels_Result>)_db.WSspSelectProductModels(1, lCID, result, Messages.NoModelText));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = true
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectProductModels_Result, SelectListItem>((IEnumerable<WSspSelectProductModels_Result>)list2, (Func<WSspSelectProductModels_Result, SelectListItem>)((WSspSelectProductModels_Result item) => new SelectListItem
			{
				Text = item.PrdModelTitle,
				Value = item.PrdModelTitle,
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdModelList = list;
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

	[AjaxOnly]
	public JsonResult GetPrdKind()
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
			SelectListItem item = new SelectListItem
			{
				Text = Labels.PrdKindAll,
				Value = "0",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PrdKindProduct,
				Value = "1",
				Selected = true
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.PrdKindService,
				Value = "2",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdKindList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdInActive()
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
			SelectListItem item = new SelectListItem
			{
				Text = Labels.All,
				Value = "-1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.Active,
				Value = "0",
				Selected = true
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.Passive,
				Value = "1",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdInActiveList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
	public JsonResult GetProductType(string txtSearch = "")
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
			string noTypeText = Labels.noTypeText;
			CRMSpIEntities dbI = _dbI;
			int? mode = 1;
			string noTypeText2 = noTypeText;
			List<WSspSearchProductTypes_Result> list2 = Enumerable.ToList<WSspSearchProductTypes_Result>((IEnumerable<WSspSearchProductTypes_Result>)dbI.WSspSearchProductTypes(mode, txtSearch, lCID, result, noTypeText2));
			list.AddRange(Enumerable.Select<WSspSearchProductTypes_Result, SelectListItem>((IEnumerable<WSspSearchProductTypes_Result>)list2, (Func<WSspSearchProductTypes_Result, SelectListItem>)((WSspSearchProductTypes_Result item) => new SelectListItem
			{
				Text = (item.PrdTypeTitle ?? ""),
				Value = ((item.tmp == 0) ? (item.PrdTypeTitle ?? "") : item.tmp.ToString()),
				Selected = false
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptWrhsReserveStock")]
	public ActionResult Print(string model, string fileName)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		base.ViewBag.FileName = fileName;
		WarehouseReserveStockViewModel value = new WarehouseReserveStockViewModel();
		if (model != "")
		{
			value = new JavaScriptSerializer().Deserialize<WarehouseReserveStockViewModel>(model);
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
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Expected O, but got Unknown
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
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
			WarehouseReserveStockViewModel warehouseReserveStockViewModel = new WarehouseReserveStockViewModel();
			if (base.TempData["model"] != null)
			{
				warehouseReserveStockViewModel = (WarehouseReserveStockViewModel)base.TempData["model"];
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
			warehouseReserveStockViewModel.Tracing = ConvertCharacter.DecodeTracing(warehouseReserveStockViewModel.Tracing);
			if (!string.IsNullOrEmpty(warehouseReserveStockViewModel.Tracing))
			{
				if (warehouseReserveStockViewModel.Tracing == "-1")
				{
					warehouseReserveStockViewModel.Tracing = "#-1#";
				}
			}
			else
			{
				warehouseReserveStockViewModel.Tracing = null;
			}
			string text4 = "";
			try
			{
				if (!string.IsNullOrEmpty(warehouseReserveStockViewModel.FDate) && !string.IsNullOrWhiteSpace(warehouseReserveStockViewModel.TDate))
				{
					text4 = PersianDate.GetFormatetdDate(warehouseReserveStockViewModel.FDate.Replace("/", ""));
					warehouseReserveStockViewModel.FDateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
					text4 = PersianDate.GetFormatetdDate(warehouseReserveStockViewModel.TDate.Replace("/", ""));
					warehouseReserveStockViewModel.TDateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				else
				{
					warehouseReserveStockViewModel.FDateTime = null;
					warehouseReserveStockViewModel.TDateTime = null;
				}
				if (!string.IsNullOrEmpty(warehouseReserveStockViewModel.ExpireFDate))
				{
					text4 = PersianDate.GetFormatetdDate(warehouseReserveStockViewModel.ExpireFDate.Replace("/", ""));
					warehouseReserveStockViewModel.ExpireFDateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				else
				{
					warehouseReserveStockViewModel.ExpireFDateTime = null;
				}
				if (!string.IsNullOrEmpty(warehouseReserveStockViewModel.ExpireTDate))
				{
					text4 = PersianDate.GetFormatetdDate(warehouseReserveStockViewModel.ExpireTDate.Replace("/", ""));
					warehouseReserveStockViewModel.ExpireTDateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				else
				{
					warehouseReserveStockViewModel.ExpireTDateTime = null;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				warehouseReserveStockViewModel.FDateTime = null;
				warehouseReserveStockViewModel.TDateTime = null;
			}
			parameters.NotUsed_ListWareHouseReserveStock = Enumerable.ToList<WSspRpt_WarehouseReserveStock_Result>((IEnumerable<WSspRpt_WarehouseReserveStock_Result>)_dbII.WSspRpt_WarehouseReserveStock(Financial.Get().Id, warehouseReserveStockViewModel.WHId, warehouseReserveStockViewModel.FGId, warehouseReserveStockViewModel.SGId, warehouseReserveStockViewModel.PrdId, UserLogin.CurrentUser.UserId, now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), warehouseReserveStockViewModel.PrdModel, lCID, result2, warehouseReserveStockViewModel.Tracing, warehouseReserveStockViewModel.PrdKind, warehouseReserveStockViewModel.PrdInActive, warehouseReserveStockViewModel.FDateTime, warehouseReserveStockViewModel.TDateTime, warehouseReserveStockViewModel.PrdType, result, warehouseReserveStockViewModel.ExpireFDateTime, warehouseReserveStockViewModel.ExpireTDateTime, warehouseReserveStockViewModel.IsExpireDateEmpty));
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "WareHouseReserveStockPrint.xsd");
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
