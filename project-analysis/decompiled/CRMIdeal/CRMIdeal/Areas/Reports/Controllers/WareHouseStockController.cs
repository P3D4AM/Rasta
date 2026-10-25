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
using CRM.Models.ReportModel.WareHouseStockPrintRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class WareHouseStockController : Controller
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
	public ActionResult Index(WareHouseStockViewModel model)
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptWrhsStock")]
	public ActionResult Print(string model, string fileName)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		base.ViewBag.FileName = fileName;
		WareHouseStockViewModel value = new WareHouseStockViewModel();
		if (model != "")
		{
			value = new JavaScriptSerializer().Deserialize<WareHouseStockViewModel>(model);
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
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_085f: Expected O, but got Unknown
		//IL_088a: Unknown result type (might be due to invalid IL or missing references)
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
			WareHouseStockViewModel wareHouseStockViewModel = new WareHouseStockViewModel();
			if (base.TempData["model"] != null)
			{
				wareHouseStockViewModel = (WareHouseStockViewModel)base.TempData["model"];
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
			wareHouseStockViewModel.Tracing = ConvertCharacter.DecodeTracing(wareHouseStockViewModel.Tracing);
			if (!string.IsNullOrEmpty(wareHouseStockViewModel.Tracing))
			{
				if (wareHouseStockViewModel.Tracing == "-1")
				{
					wareHouseStockViewModel.Tracing = "#-1#";
				}
			}
			else
			{
				wareHouseStockViewModel.Tracing = null;
			}
			string text4 = "";
			try
			{
				if (!string.IsNullOrEmpty(wareHouseStockViewModel.FDate) && !string.IsNullOrWhiteSpace(wareHouseStockViewModel.TDate))
				{
					text4 = PersianDate.GetFormatetdDate(wareHouseStockViewModel.FDate.Replace("/", ""));
					wareHouseStockViewModel.FDateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
					text4 = PersianDate.GetFormatetdDate(wareHouseStockViewModel.TDate.Replace("/", ""));
					wareHouseStockViewModel.TDateTime = lCID switch
					{
						1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
						1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
					};
				}
				else
				{
					wareHouseStockViewModel.FDateTime = null;
					wareHouseStockViewModel.TDateTime = null;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				wareHouseStockViewModel.FDateTime = null;
				wareHouseStockViewModel.TDateTime = null;
			}
			parameters.NotUsed_ListWareHouseStock = Enumerable.ToList<WSspRpt_WareHouseStock_Result>((IEnumerable<WSspRpt_WareHouseStock_Result>)_dbI.WSspRpt_WareHouseStock(wareHouseStockViewModel.Mode, userId: UserLogin.CurrentUser.UserId, rptDate: now.ToString("yyyy/MM/dd HH:mm:ss"), rptDay: DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), fPId: Financial.Get().Id, wHID: wareHouseStockViewModel.WHId, fGId: wareHouseStockViewModel.FGId, sGId: wareHouseStockViewModel.SGId, prdId: wareHouseStockViewModel.PrdId, maxStkVal: wareHouseStockViewModel.MaxStkVal, minStkVal: wareHouseStockViewModel.MinStkVal, equalStkVal: wareHouseStockViewModel.EqualStkVal, prdModel: wareHouseStockViewModel.PrdModel, languageID: lCID, defaultLanguageID: result2, tracing: wareHouseStockViewModel.Tracing, prdKind: wareHouseStockViewModel.PrdKind, prdInActive: wareHouseStockViewModel.PrdInActive, fDate: wareHouseStockViewModel.FDateTime, tDate: wareHouseStockViewModel.TDateTime, isNotUsePrdInDoc: wareHouseStockViewModel.isNotUsePrdInDoc, prdType: wareHouseStockViewModel.PrdType, centerId: result));
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			foreach (WSspRpt_WareHouseStock_Result item in parameters.NotUsed_ListWareHouseStock)
			{
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = item.PrdId.ToString(),
					LanguageId = item.WHId.GetValueOrDefault()
				});
			}
			string js = JsonConvert.SerializeObject(list).Replace("Value", "PrdId").Replace("LanguageId", "WhId");
			List<WSspReturnDocItemSerialStockByPrdIds_Result> list2 = Enumerable.ToList<WSspReturnDocItemSerialStockByPrdIds_Result>((IEnumerable<WSspReturnDocItemSerialStockByPrdIds_Result>)_dbI.WSspReturnDocItemSerialStockByPrdIds(js, lCID, result2, result));
			parameters.NotUsed_ListDocItemSerialStockByPrdId = new List<WSspReturnDocItemSerialStockByPrdId_Result>();
			if (list2 != null)
			{
				parameters.NotUsed_ListDocItemSerialStockByPrdId.AddRange(Enumerable.Select<WSspReturnDocItemSerialStockByPrdIds_Result, WSspReturnDocItemSerialStockByPrdId_Result>((IEnumerable<WSspReturnDocItemSerialStockByPrdIds_Result>)list2, (Func<WSspReturnDocItemSerialStockByPrdIds_Result, WSspReturnDocItemSerialStockByPrdId_Result>)((WSspReturnDocItemSerialStockByPrdIds_Result x) => new WSspReturnDocItemSerialStockByPrdId_Result
				{
					DocItemSerialID = x.DocItemSerialID,
					ItemId = x.ItemId,
					Serial = x.Serial,
					StatusId = x.StatusId,
					Description = x.Description,
					IsFix = x.IsFix,
					WHId = x.WHId,
					UserId = x.UserId,
					Month1 = x.Month1,
					FPId = x.FPId,
					RegisterDate = x.RegisterDate,
					RegisterDatePersian = x.RegisterDatePersian,
					SerialId = x.SerialId,
					IsAutoBarcode = x.IsAutoBarcode,
					tblTmpBarcodeId = x.tblTmpBarcodeId,
					GUId = x.GUId,
					ExpDate = x.ExpDate,
					ExpDatePersian = x.ExpDatePersian,
					AppType = x.AppType,
					InfoI = x.InfoI,
					InfoII = x.InfoII,
					InfoIII = x.InfoIII,
					InfoIV = x.InfoIV,
					InfoV = x.InfoV,
					InfoVI = x.InfoVI,
					LanguageID = x.LanguageID,
					FirstRegisterUserId = x.FirstRegisterUserId,
					FirstRegisterDatePersian = x.FirstRegisterDatePersian,
					FirstRegisterDate = x.FirstRegisterDate,
					DocISLinkAccItemSerialId = x.DocISLinkAccItemSerialId,
					RootId = x.RootId,
					DocNumber = x.DocNumber,
					DocDate = x.DocDate,
					PrdId = x.PrdId
				})));
				foreach (WSspReturnDocItemSerialStockByPrdId_Result item2 in parameters.NotUsed_ListDocItemSerialStockByPrdId)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrEmpty(item2.RegisterDatePersian))
						{
							item2.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(item2.FirstRegisterDatePersian))
						{
							item2.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(item2.DocDate))
						{
							item2.DocDate = PersianDate.GetShamsi2Miladi(item2.DocDate.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			parameters.NotUsed_ListProductLinkAccData = new List<WareHouseStockLinkAccData>();
			if (parameters.NotUsed_ListWareHouseStock != null && Enumerable.Any<WSspRpt_WareHouseStock_Result>((IEnumerable<WSspRpt_WareHouseStock_Result>)parameters.NotUsed_ListWareHouseStock))
			{
				IEnumerable<int> enumerable = Enumerable.Distinct<int>(Enumerable.Select<WSspRpt_WareHouseStock_Result, int>((IEnumerable<WSspRpt_WareHouseStock_Result>)parameters.NotUsed_ListWareHouseStock, (Func<WSspRpt_WareHouseStock_Result, int>)((WSspRpt_WareHouseStock_Result p) => p.PrdId)));
				if (Enumerable.Any<int>(enumerable))
				{
					foreach (int prdId in enumerable)
					{
						WSspRpt_WareHouseStock_Result wSspRpt_WareHouseStock_Result = Enumerable.FirstOrDefault<WSspRpt_WareHouseStock_Result>((IEnumerable<WSspRpt_WareHouseStock_Result>)parameters.NotUsed_ListWareHouseStock, (Func<WSspRpt_WareHouseStock_Result, bool>)((WSspRpt_WareHouseStock_Result p) => p.PrdId == prdId));
						if (wSspRpt_WareHouseStock_Result != null)
						{
							string prdLinkAccData = wSspRpt_WareHouseStock_Result.PrdLinkAccData;
							if (!string.IsNullOrEmpty(prdLinkAccData))
							{
								List<WareHouseStockLinkAccDataDetail> details = JsonConvert.DeserializeObject<List<WareHouseStockLinkAccDataDetail>>(prdLinkAccData);
								parameters.NotUsed_ListProductLinkAccData.Add(new WareHouseStockLinkAccData
								{
									ProductId = prdId,
									Details = details
								});
							}
						}
					}
				}
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "WareHouseStockPrint.xsd");
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
