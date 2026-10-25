using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Products.Controllers;

public class ImportExcelController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public string _ImportExcelSpecFieldsSeperator = "-8*#-";

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdImportExcel")]
	public ActionResult ReadListAndMakeExportGrid(int sgId)
	{
		base.ViewBag.PrdSecondGroupId = sgId;
		return View();
	}

	[AjaxOnly]
	public ActionResult MakeExportGrid_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)MakeExportList()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult MakeExportGrid()
	{
		return Json(MakeExportList(), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdImportExcel")]
	public ActionResult FinalCheck(int sgId)
	{
		base.ViewBag.PrdSecondGroupId = sgId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdImportExcel")]
	public ActionResult ImportedData(int sgId)
	{
		base.ViewBag.PrdSecondGroupId = sgId;
		return View();
	}

	public List<ProductImportFromExcelFieldsViewModel> LoadImportedDataGridList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<ProductImportFromExcelFieldsViewModel> list = new List<ProductImportFromExcelFieldsViewModel>();
		try
		{
			List<WSspSelectProductImportFromExcelFields_Result> list2 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result), (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result model) => model.Selector.GetValueOrDefault())));
			if (Enumerable.Any<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2))
			{
				List<string> list3 = Enumerable.ToList<string>(Enumerable.Select<WSspSelectProductImportFromExcelFields_Result, string>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result item) => item.GroupNum.GetValueOrDefault() == 1)), (Func<WSspSelectProductImportFromExcelFields_Result, string>)((WSspSelectProductImportFromExcelFields_Result item) => item.FieldName)));
				List<string> list4 = Enumerable.ToList<string>(Enumerable.Select<WSspSelectProductImportFromExcelFields_Result, string>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result item) => item.GroupNum.GetValueOrDefault() == 2)), (Func<WSspSelectProductImportFromExcelFields_Result, string>)((WSspSelectProductImportFromExcelFields_Result item) => item.FieldName)));
				List<string> list5 = Enumerable.ToList<string>(Enumerable.Select<WSspSelectProductImportFromExcelFields_Result, string>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result item) => item.GroupNum.GetValueOrDefault() == 3)), (Func<WSspSelectProductImportFromExcelFields_Result, string>)((WSspSelectProductImportFromExcelFields_Result item) => item.FieldName)));
				foreach (WSspSelectProductImportFromExcel_Result item in Enumerable.ToList<WSspSelectProductImportFromExcel_Result>(Enumerable.Where<WSspSelectProductImportFromExcel_Result>((IEnumerable<WSspSelectProductImportFromExcel_Result>)_db.WSspSelectProductImportFromExcel(), (Func<WSspSelectProductImportFromExcel_Result, bool>)((WSspSelectProductImportFromExcel_Result model) => model.UserId == UserLogin.CurrentUser.UserId && model.Selector.GetValueOrDefault()))))
				{
					ProductImportFromExcelFieldsViewModel productImportFromExcelFieldsViewModel = new ProductImportFromExcelFieldsViewModel();
					productImportFromExcelFieldsViewModel.Id = item.Id;
					productImportFromExcelFieldsViewModel.Selector = item.Selector;
					productImportFromExcelFieldsViewModel.RelationId = item.RelationId;
					productImportFromExcelFieldsViewModel.IsDuplicate = item.IsDuplicate;
					productImportFromExcelFieldsViewModel.FindedPrdId = item.FindedPrdId;
					productImportFromExcelFieldsViewModel.InsertedPrdId = item.InsertedPrdId;
					productImportFromExcelFieldsViewModel.ErrorMessage = "";
					productImportFromExcelFieldsViewModel.IsValid = true;
					productImportFromExcelFieldsViewModel.DuplicatedIds = item.DuplicatedIds;
					productImportFromExcelFieldsViewModel.InsertedPriceIds = item.InsertedPriceIds;
					productImportFromExcelFieldsViewModel.InsertedCostIds = item.InsertedCostIds;
					productImportFromExcelFieldsViewModel.UpdatedPrdIds = item.UpdatedPrdIds;
					productImportFromExcelFieldsViewModel.UpdatedPriceIds = item.UpdatedPriceIds;
					productImportFromExcelFieldsViewModel.UpdatedCostIds = item.UpdatedCostIds;
					if (Enumerable.Any<string>((IEnumerable<string>)list3))
					{
						string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdCode")));
						productImportFromExcelFieldsViewModel.PrdCodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdName")));
						productImportFromExcelFieldsViewModel.PrdNameVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdLatinName")));
						productImportFromExcelFieldsViewModel.PrdLatinNameVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdType")));
						productImportFromExcelFieldsViewModel.PrdTypeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdDesign")));
						productImportFromExcelFieldsViewModel.PrdDesignVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSize")));
						productImportFromExcelFieldsViewModel.PrdSizeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdColorId")));
						productImportFromExcelFieldsViewModel.PrdColorIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdUnitId")));
						productImportFromExcelFieldsViewModel.PrdUnitIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdMinQty")));
						productImportFromExcelFieldsViewModel.PrdMinQtyVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdMaxQty")));
						productImportFromExcelFieldsViewModel.PrdMaxQtyVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSleepDay")));
						productImportFromExcelFieldsViewModel.PrdSleepDayVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdFirstSerial")));
						productImportFromExcelFieldsViewModel.PrdFirstSerialVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSecondSerial")));
						productImportFromExcelFieldsViewModel.PrdSecondSerialVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdThirdSerial")));
						productImportFromExcelFieldsViewModel.PrdThirdSerialVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdFirstBarcode")));
						productImportFromExcelFieldsViewModel.PrdFirstBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSecondBarcode")));
						productImportFromExcelFieldsViewModel.PrdSecondBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdThirdBarcode")));
						productImportFromExcelFieldsViewModel.PrdThirdBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdDescription")));
						productImportFromExcelFieldsViewModel.PrdDescriptionVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdBarCode")));
						productImportFromExcelFieldsViewModel.PrdBarCodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdBarCodeTypeId")));
						productImportFromExcelFieldsViewModel.PrdBarCodeTypeIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdAutoNumBarcode")));
						productImportFromExcelFieldsViewModel.PrdAutoNumBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdAutoNumBarCodeTypeId")));
						productImportFromExcelFieldsViewModel.PrdAutoNumBarCodeTypeIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdAutoCharBarcode")));
						productImportFromExcelFieldsViewModel.PrdAutoCharBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("prdAutoCharBarCodeTypeId")));
						productImportFromExcelFieldsViewModel.PrdAutoCharBarCodeTypeIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdModel")));
						productImportFromExcelFieldsViewModel.PrdModelVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdInactiveInSale")));
						productImportFromExcelFieldsViewModel.PrdInactiveInSaleVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdInactiveInBuy")));
						productImportFromExcelFieldsViewModel.PrdInactiveInBuyVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPIsActive")));
						productImportFromExcelFieldsViewModel.PrdSHPIsActiveVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPTitle")));
						productImportFromExcelFieldsViewModel.PrdSHPTitleVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPCode")));
						productImportFromExcelFieldsViewModel.PrdSHPCodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPModel")));
						productImportFromExcelFieldsViewModel.PrdSHPModelVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPDescription")));
						productImportFromExcelFieldsViewModel.PrdSHPDescriptionVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPDescriptionII")));
						productImportFromExcelFieldsViewModel.PrdSHPDescriptionIIVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPStockManageTypeId")));
						productImportFromExcelFieldsViewModel.PrdSHPStockManageTypeIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPStockManualyCount")));
						productImportFromExcelFieldsViewModel.PrdSHPStockManualyCountVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPHiddenPriceInNoStock")));
						productImportFromExcelFieldsViewModel.PrdSHPHiddenPriceInNoStockVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPSelfSupplier")));
						productImportFromExcelFieldsViewModel.PrdSHPSelfSupplierVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPOtherSupplierId")));
						productImportFromExcelFieldsViewModel.PrdSHPOtherSupplierIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPQtyFromTracing")));
						productImportFromExcelFieldsViewModel.PrdSHPQtyFromTracingVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdQtyCanDecimal")));
						productImportFromExcelFieldsViewModel.PrdQtyCanDecimalVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdCommissionDisable")));
						productImportFromExcelFieldsViewModel.PrdCommissionDisableVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdCommissionPercentRate")));
						productImportFromExcelFieldsViewModel.PrdCommissionPercentRateVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdIsDefault")));
						productImportFromExcelFieldsViewModel.PrdIsDefaultVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdInActive")));
						productImportFromExcelFieldsViewModel.PrdInActiveVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdKind")));
						productImportFromExcelFieldsViewModel.PrdKindVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdDefQuantity")));
						productImportFromExcelFieldsViewModel.PrdDefQuantityVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdJustDefQuantity")));
						productImportFromExcelFieldsViewModel.PrdJustDefQuantityVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdMinQuantity")));
						productImportFromExcelFieldsViewModel.PrdMinQuantityVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdMaxQuantity")));
						productImportFromExcelFieldsViewModel.PrdMaxQuantityVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
					}
					else
					{
						productImportFromExcelFieldsViewModel.PrdCodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdNameVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdLatinNameVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdTypeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdDesignVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSizeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdColorIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdUnitIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdMinQtyVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdMaxQtyVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSleepDayVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdFirstSerialVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSecondSerialVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdThirdSerialVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdFirstBarcodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSecondBarcodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdThirdBarcodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdDescriptionVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdBarCodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdBarCodeTypeIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdAutoNumBarCodeTypeIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdAutoCharBarcodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdAutoCharBarCodeTypeIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdModelVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdInactiveInSaleVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdInactiveInBuyVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPIsActiveVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPTitleVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPCodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPModelVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPDescriptionVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPDescriptionIIVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPStockManageTypeIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPStockManualyCountVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPHiddenPriceInNoStockVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPSelfSupplierVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPOtherSupplierIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPQtyFromTracingVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdQtyCanDecimalVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdCommissionDisableVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdCommissionPercentRateVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdIsDefaultVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdInActiveVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdKindVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdDefQuantityVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdJustDefQuantityVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdMinQuantityVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdMaxQuantityVisibale = "hidden";
					}
					productImportFromExcelFieldsViewModel.PrdCode = item.PrdCode;
					productImportFromExcelFieldsViewModel.PrdName = item.PrdName;
					productImportFromExcelFieldsViewModel.PrdLatinName = item.PrdLatinName;
					productImportFromExcelFieldsViewModel.PrdType = item.PrdType;
					productImportFromExcelFieldsViewModel.PrdDesign = item.PrdDesign;
					productImportFromExcelFieldsViewModel.PrdSize = item.PrdSize;
					productImportFromExcelFieldsViewModel.PrdColorId = item.PrdColorId;
					productImportFromExcelFieldsViewModel.PrdUnitId = item.PrdUnitId;
					productImportFromExcelFieldsViewModel.PrdMinQty = item.PrdMinQty;
					productImportFromExcelFieldsViewModel.PrdMaxQty = item.PrdMaxQty;
					productImportFromExcelFieldsViewModel.PrdSleepDay = item.PrdSleepDay;
					productImportFromExcelFieldsViewModel.PrdFirstSerial = item.PrdFirstSerial;
					productImportFromExcelFieldsViewModel.PrdSecondSerial = item.PrdSecondSerial;
					productImportFromExcelFieldsViewModel.PrdThirdSerial = item.PrdThirdSerial;
					productImportFromExcelFieldsViewModel.PrdFirstBarcode = item.PrdFirstBarcode;
					productImportFromExcelFieldsViewModel.PrdSecondBarcode = item.PrdSecondBarcode;
					productImportFromExcelFieldsViewModel.PrdThirdBarcode = item.PrdThirdBarcode;
					productImportFromExcelFieldsViewModel.PrdDescription = item.PrdDescription;
					productImportFromExcelFieldsViewModel.PrdBarCode = item.PrdBarCode;
					productImportFromExcelFieldsViewModel.PrdBarCodeTypeId = item.PrdBarCodeTypeId;
					productImportFromExcelFieldsViewModel.PrdAutoNumBarcode = item.PrdAutoNumBarcode;
					productImportFromExcelFieldsViewModel.PrdAutoNumBarCodeTypeId = item.PrdAutoNumBarCodeTypeId;
					productImportFromExcelFieldsViewModel.PrdAutoCharBarcode = item.PrdAutoCharBarcode;
					productImportFromExcelFieldsViewModel.prdAutoCharBarCodeTypeId = item.prdAutoCharBarCodeTypeId;
					productImportFromExcelFieldsViewModel.PrdModel = item.PrdModel;
					productImportFromExcelFieldsViewModel.PrdInactiveInSale = item.PrdInactiveInSale;
					productImportFromExcelFieldsViewModel.PrdInactiveInBuy = item.PrdInactiveInBuy;
					productImportFromExcelFieldsViewModel.PrdSHPIsActive = item.PrdSHPIsActive;
					productImportFromExcelFieldsViewModel.PrdSHPTitle = item.PrdSHPTitle;
					productImportFromExcelFieldsViewModel.PrdSHPCode = item.PrdSHPCode;
					productImportFromExcelFieldsViewModel.PrdSHPModel = item.PrdSHPModel;
					productImportFromExcelFieldsViewModel.PrdSHPDescription = item.PrdSHPDescription;
					productImportFromExcelFieldsViewModel.PrdSHPDescriptionII = item.PrdSHPDescriptionII;
					productImportFromExcelFieldsViewModel.PrdSHPStockManageTypeId = item.PrdSHPStockManageTypeId;
					productImportFromExcelFieldsViewModel.PrdSHPStockManualyCount = item.PrdSHPStockManualyCount;
					productImportFromExcelFieldsViewModel.PrdSHPHiddenPriceInNoStock = item.PrdSHPHiddenPriceInNoStock;
					productImportFromExcelFieldsViewModel.PrdSHPSelfSupplier = item.PrdSHPSelfSupplier;
					productImportFromExcelFieldsViewModel.PrdSHPOtherSupplierId = item.PrdSHPOtherSupplierId;
					productImportFromExcelFieldsViewModel.PrdSHPQtyFromTracing = item.PrdSHPQtyFromTracing;
					productImportFromExcelFieldsViewModel.PrdQtyCanDecimal = item.PrdQtyCanDecimal;
					productImportFromExcelFieldsViewModel.PrdCommissionDisable = item.PrdCommissionDisable;
					productImportFromExcelFieldsViewModel.PrdCommissionPercentRate = item.PrdCommissionPercentRate;
					productImportFromExcelFieldsViewModel.PrdIsDefault = item.PrdIsDefault;
					productImportFromExcelFieldsViewModel.PrdInActive = item.PrdInActive;
					productImportFromExcelFieldsViewModel.PrdKind = item.PrdKind;
					productImportFromExcelFieldsViewModel.PrdDefQuantity = item.PrdDefQuantity;
					productImportFromExcelFieldsViewModel.PrdJustDefQuantity = item.PrdJustDefQuantity;
					productImportFromExcelFieldsViewModel.PrdMinQuantity = item.PrdMinQuantity;
					productImportFromExcelFieldsViewModel.PrdMaxQuantity = item.PrdMaxQuantity;
					if (Enumerable.Any<string>((IEnumerable<string>)list4))
					{
						string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DocDate")));
						productImportFromExcelFieldsViewModel.PriceDocDateVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DocNumber")));
						productImportFromExcelFieldsViewModel.PriceDocNumberVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Price")));
						productImportFromExcelFieldsViewModel.PriceVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CurrencyPrice")));
						productImportFromExcelFieldsViewModel.PriceCurrencyPriceVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CurrencyUnitId")));
						productImportFromExcelFieldsViewModel.PriceCurrencyUnitIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CooperationPrice")));
						productImportFromExcelFieldsViewModel.PriceCooperationPriceVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PricePercent")));
						productImportFromExcelFieldsViewModel.PricePercentVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DiscountPrecent")));
						productImportFromExcelFieldsViewModel.PriceDiscountPrecentVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Discount")));
						productImportFromExcelFieldsViewModel.PriceDiscountVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("OtherPrice")));
						productImportFromExcelFieldsViewModel.PriceOtherPriceVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Description")));
						productImportFromExcelFieldsViewModel.PriceDescriptionVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("ProductPriceGroupId")));
						productImportFromExcelFieldsViewModel.PriceProductPriceGroupIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
					}
					else
					{
						productImportFromExcelFieldsViewModel.PriceDocDateVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceDocNumberVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceCurrencyPriceVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceCurrencyUnitIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceCooperationPriceVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PricePercentVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceDiscountPrecentVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceDiscountVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceOtherPriceVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceDescriptionVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceProductPriceGroupIdVisibale = "hidden";
					}
					productImportFromExcelFieldsViewModel.PriceDocDate = item.PriceDocDate;
					string text2 = DateTimeClass.CheckDate(productImportFromExcelFieldsViewModel.PriceDocDate);
					if (!string.IsNullOrEmpty(text2))
					{
						productImportFromExcelFieldsViewModel.PriceDocDate = text2;
					}
					productImportFromExcelFieldsViewModel.PriceDocNumber = item.PriceDocNumber;
					productImportFromExcelFieldsViewModel.Price = item.Price;
					productImportFromExcelFieldsViewModel.PriceCurrencyPrice = item.PriceCurrencyPrice;
					productImportFromExcelFieldsViewModel.PriceCurrencyUnitId = item.PriceCurrencyUnitId;
					productImportFromExcelFieldsViewModel.PriceCooperationPrice = item.PriceCooperationPrice;
					productImportFromExcelFieldsViewModel.PricePercent = item.PricePercent;
					productImportFromExcelFieldsViewModel.PriceDiscountPrecent = item.PriceDiscountPrecent;
					productImportFromExcelFieldsViewModel.PriceDiscount = item.PriceDiscount;
					productImportFromExcelFieldsViewModel.PriceOtherPrice = item.PriceOtherPrice;
					productImportFromExcelFieldsViewModel.PriceDescription = item.PriceDescription;
					productImportFromExcelFieldsViewModel.PriceProductPriceGroupId = item.PriceProductPriceGroupId;
					if (Enumerable.Any<string>((IEnumerable<string>)list5))
					{
						string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DocDate")));
						productImportFromExcelFieldsViewModel.CostDocDateVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DocNumber")));
						productImportFromExcelFieldsViewModel.CostDocNumberVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Cost")));
						productImportFromExcelFieldsViewModel.CostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CurrencyCost")));
						productImportFromExcelFieldsViewModel.CostCurrencyCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CurrencyUnitId")));
						productImportFromExcelFieldsViewModel.CostCurrencyUnitIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("TransportCost")));
						productImportFromExcelFieldsViewModel.CostTransportCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("ReleasingCost")));
						productImportFromExcelFieldsViewModel.CostReleasingCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("SlagCost")));
						productImportFromExcelFieldsViewModel.CostSlagCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("OtherCost")));
						productImportFromExcelFieldsViewModel.CostOtherCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Description")));
						productImportFromExcelFieldsViewModel.CostDescriptionVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("ProductCostGroupId")));
						productImportFromExcelFieldsViewModel.CostProductCostGroupIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
					}
					else
					{
						productImportFromExcelFieldsViewModel.CostDocDateVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostDocNumberVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostCurrencyCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostCurrencyUnitIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostTransportCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostReleasingCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostSlagCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostOtherCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostDescriptionVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostProductCostGroupIdVisibale = "hidden";
					}
					productImportFromExcelFieldsViewModel.CostDocDate = item.CostDocDate;
					string text3 = DateTimeClass.CheckDate(productImportFromExcelFieldsViewModel.CostDocDate);
					if (!string.IsNullOrEmpty(text3))
					{
						productImportFromExcelFieldsViewModel.CostDocDate = text3;
					}
					productImportFromExcelFieldsViewModel.CostDocNumber = item.CostDocNumber;
					productImportFromExcelFieldsViewModel.Cost = item.Cost;
					productImportFromExcelFieldsViewModel.CostCurrencyCost = item.CostCurrencyCost;
					productImportFromExcelFieldsViewModel.CostCurrencyUnitId = item.CostCurrencyUnitId;
					productImportFromExcelFieldsViewModel.CostTransportCost = item.CostTransportCost;
					productImportFromExcelFieldsViewModel.CostReleasingCost = item.CostReleasingCost;
					productImportFromExcelFieldsViewModel.CostSlagCost = item.CostSlagCost;
					productImportFromExcelFieldsViewModel.CostOtherCost = item.CostOtherCost;
					productImportFromExcelFieldsViewModel.CostDescription = item.CostDescription;
					productImportFromExcelFieldsViewModel.CostProductCostGroupId = item.CostProductCostGroupId;
					if (string.IsNullOrEmpty(productImportFromExcelFieldsViewModel.InsertedCostIds) && string.IsNullOrEmpty(productImportFromExcelFieldsViewModel.InsertedPriceIds) && string.IsNullOrEmpty(productImportFromExcelFieldsViewModel.UpdatedCostIds) && string.IsNullOrEmpty(productImportFromExcelFieldsViewModel.UpdatedPrdIds) && string.IsNullOrEmpty(productImportFromExcelFieldsViewModel.UpdatedPriceIds) && !productImportFromExcelFieldsViewModel.InsertedPrdId.HasValue)
					{
						productImportFromExcelFieldsViewModel.IsValid = false;
						productImportFromExcelFieldsViewModel.Selector = false;
						productImportFromExcelFieldsViewModel.ErrorMessage = Messages.msgErrorOperationFailed;
					}
					list.Add(productImportFromExcelFieldsViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult LoadImportedDataGrid_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)LoadImportedDataGridList()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult LoadImportedDataGrid()
	{
		return Json(LoadImportedDataGridList(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdColor()
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
			List<WSspSelectProductColor_Result> list2 = Enumerable.ToList<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)_db.WSspSelectProductColor(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductColor_Result, SelectListItem>((IEnumerable<WSspSelectProductColor_Result>)list2, (Func<WSspSelectProductColor_Result, SelectListItem>)((WSspSelectProductColor_Result item) => new SelectListItem
			{
				Text = item.Color + ": " + item.ProductColorID,
				Value = item.ProductColorID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ColorList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdUnit()
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
			List<WSspSelectProductUnits_Result> list2 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, SelectListItem>((IEnumerable<WSspSelectProductUnits_Result>)list2, (Func<WSspSelectProductUnits_Result, SelectListItem>)((WSspSelectProductUnits_Result item) => new SelectListItem
			{
				Text = item.Unit + ": " + item.ProductUnitID,
				Value = item.ProductUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdUnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPriceGroup()
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
			List<WSspSelectProductPriceGroup_Result> list2 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list2, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName + ": " + item.ProductPriceGroupID,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PriceGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCostGroup()
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
			List<WSspSelectProductCostGroup_Result> list2 = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductCostGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductCostGroup_Result>)list2, (Func<WSspSelectProductCostGroup_Result, SelectListItem>)((WSspSelectProductCostGroup_Result item) => new SelectListItem
			{
				Text = item.ProductCostGroupName + ": " + item.ProductCostGroupID,
				Value = item.ProductCostGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CostGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUnit()
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
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit + ": " + item.CurrencyUnitID,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetFirstGroup(int? selectedId)
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
			List<WSspSelectProductFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result item) => new SelectListItem
			{
				Text = item.FGName + ": " + item.PrdFirstGroupID,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = (selectedId == item.PrdFirstGroupID)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSecondGroup(int fgId)
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
			List<WSspSelectProductSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fgId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroup_Result>)list2, (Func<WSspSelectProductSecondGroup_Result, SelectListItem>)((WSspSelectProductSecondGroup_Result item) => new SelectListItem
			{
				Text = item.SGName + ": " + item.PrdSecondGroupID,
				Value = item.PrdSecondGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SecondGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public string UpdateSelectorStatus(int recId, int mode)
	{
		string text = "";
		try
		{
			bool value = mode == 1;
			if (recId != 0)
			{
				_db.WSspUpdateSelectUnSelectProductImportFromExcelFields(recId, value);
				return "1|" + Messages.msgSuccessAction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	public string CheckDuplicateInProduct(string checkDuplicateField)
	{
		string text = "";
		try
		{
			if (!string.IsNullOrEmpty(checkDuplicateField))
			{
				_db.WSspCheckDuplicateInProductImportFromExcelByField(UserLogin.CurrentUser.UserId, checkDuplicateField);
				return "1|" + Messages.msgSuccessAction;
			}
			return "-1|" + Messages.msgErrorNotSelectedCheckDuplicateField;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ExportGridUpdateSelectorStatus(int recId, int mode)
	{
		string text = "";
		try
		{
			bool value = mode == 1;
			if (recId > 0)
			{
				WSProductImportFromExcel wSProductImportFromExcel = _dbTbl.WSProductImportFromExcel.Find(recId);
				if (wSProductImportFromExcel != null)
				{
					wSProductImportFromExcel.Selector = value;
					_dbTbl.Entry(wSProductImportFromExcel).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					return "1|" + Messages.msgSuccessAction;
				}
				return "-1|" + Messages.ErrorNotFound;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdImportExcel")]
	public ActionResult Login()
	{
		base.ViewBag.IsBuying = VersionBuyer.ProductImportExcel;
		LoginViewModel model = new LoginViewModel();
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdImportExcel")]
	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	public ActionResult Login(LoginViewModel login)
	{
		base.ViewBag.IsBuying = VersionBuyer.ProductImportExcel;
		try
		{
			if (UserLogin.CurrentUser == null)
			{
				base.ViewBag.Error = Messages.ErrorNotAccess;
				return View(login);
			}
			if (base.ModelState.IsValid)
			{
				string text = new BaseInfo().ConvertMd5(login.Password).ToLower();
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				if (!(login.UserName == currentUser.UserName) || !(text == currentUser.Password))
				{
					base.ViewBag.Error = Messages.msgErrorPasswordIsWrong;
				}
				else
				{
					base.ViewBag.Successful = "True";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(login);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdImportExcel")]
	public ActionResult Index(int sgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductImportFromExcelFields_Result> list = new List<WSspSelectProductImportFromExcelFields_Result>();
		try
		{
			List<CRMspSelectLinkAccSettingDBAll_Result> list2 = CRMIdeal.Classes.Helper.OtherSystems.SelectLinkAccSettingDBAll();
			base.ViewBag.linkAccSettingDbList = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectLinkAccSettingDBAll_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list2, (Func<CRMspSelectLinkAccSettingDBAll_Result, SelectListItem>)((CRMspSelectLinkAccSettingDBAll_Result x) => new SelectListItem
			{
				Text = x.LinkAccSettingDbTitle + " ( " + x.LinkAccSettingDBId + " )",
				Value = x.LinkAccSettingDBId.ToString()
			})));
			list = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result));
			if (list2 != null && list2.Count > 0 && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBAll_Result>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list2, (Func<CRMspSelectLinkAccSettingDBAll_Result, bool>)((CRMspSelectLinkAccSettingDBAll_Result x) => x.LinkAccSettingDBId > -1)) == null)
			{
				list = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result x) => x.FieldName != "LinkAccSettingDBId")));
			}
			if (list != null && !Center.HaveModule)
			{
				list = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result x) => x.FieldName != "PriceCId" && x.FieldName != "CostCId")));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FieldList = list;
		GetSpecificationFieldsList();
		GetPrdColor();
		GetPrdUnit();
		GetPriceGroup();
		GetCostGroup();
		GetUnit();
		WSProductSecondGroup wSProductSecondGroup = _dbTbl.WSProductSecondGroup.Find(sgId);
		GetFirstGroup(wSProductSecondGroup?.FirstGroupId ?? 0);
		GetSecondGroup(wSProductSecondGroup?.FirstGroupId ?? 0);
		base.ViewBag.SelectedSecondGroupId = sgId;
		base.ViewBag.SelectedFirstGroupId = wSProductSecondGroup?.FirstGroupId ?? 0;
		base.ViewBag.PrdSecondGroupId = sgId;
		CommonTreeViewItemViewModel model = new CommonTreeViewItemViewModel
		{
			Id = sgId.ToString(),
			Text = ""
		};
		return View(model);
	}

	[LoginAuthorize]
	public List<SelectListItem> GetSpecificationFieldsList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductSpecificationFields_Result> list2 = Enumerable.ToList<WSspSelectProductSpecificationFields_Result>((IEnumerable<WSspSelectProductSpecificationFields_Result>)_dbII.WSspSelectProductSpecificationFields(0, lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectProductSpecificationFields_Result, SelectListItem>((IEnumerable<WSspSelectProductSpecificationFields_Result>)list2, (Func<WSspSelectProductSpecificationFields_Result, SelectListItem>)((WSspSelectProductSpecificationFields_Result x) => new SelectListItem
				{
					Text = (string.IsNullOrWhiteSpace(x.specSHPTitle) ? x.specTitle : x.specSHPTitle) + (string.IsNullOrWhiteSpace(x.specGroup) ? "" : (" ( " + x.specGroup + " )")),
					Value = x.SpecificationFieldID.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.SpecificationFieldsList = list;
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdImportExcel")]
	[HttpPost]
	public ActionResult Index(CommonTreeViewItemViewModel model, string specFieldsJs = "")
	{
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingDBAll_Result> list = CRMIdeal.Classes.Helper.OtherSystems.SelectLinkAccSettingDBAll();
		base.ViewBag.linkAccSettingDbList = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectLinkAccSettingDBAll_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list, (Func<CRMspSelectLinkAccSettingDBAll_Result, SelectListItem>)((CRMspSelectLinkAccSettingDBAll_Result x) => new SelectListItem
		{
			Text = x.LinkAccSettingDbTitle + " ( " + x.LinkAccSettingDBId + " )",
			Value = x.LinkAccSettingDBId.ToString()
		})));
		List<WSspSelectProductImportFromExcelFields_Result> list2 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result)), (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result c) => c.IsActive.GetValueOrDefault() && c.Selector.GetValueOrDefault())));
		if (Enumerable.Any<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2))
		{
			if (list != null && list.Count > 0 && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBAll_Result>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list, (Func<CRMspSelectLinkAccSettingDBAll_Result, bool>)((CRMspSelectLinkAccSettingDBAll_Result x) => x.LinkAccSettingDBId > -1)) == null)
			{
				list2 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result x) => x.FieldName != "LinkAccSettingDBId")));
			}
			if (list2 != null && !Center.HaveModule)
			{
				list2 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result x) => x.FieldName != "PriceCId" && x.FieldName != "CostCId")));
			}
			ExcelPackage excelPackage = new ExcelPackage();
			ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.ProductImportExcelPropertiesTitle);
			int num = 0;
			foreach (WSspSelectProductImportFromExcelFields_Result item in list2)
			{
				num++;
				excelWorksheet.Cells[1, num].Value = item.FieldCaption;
			}
			if (!string.IsNullOrWhiteSpace(specFieldsJs))
			{
				List<string> lst = Enumerable.ToList<string>((IEnumerable<string>)specFieldsJs.Split(new char[1] { ',' }));
				foreach (WSspSelectProductSpecificationFields_Result item2 in Enumerable.ToList<WSspSelectProductSpecificationFields_Result>(Enumerable.Where<WSspSelectProductSpecificationFields_Result>((IEnumerable<WSspSelectProductSpecificationFields_Result>)_dbII.WSspSelectProductSpecificationFields(0, lCID, result), (Func<WSspSelectProductSpecificationFields_Result, bool>)((WSspSelectProductSpecificationFields_Result x) => Enumerable.FirstOrDefault<string>((IEnumerable<string>)lst, (Func<string, bool>)((string f) => int.Parse(f) == x.SpecificationFieldID)) != null))))
				{
					num++;
					string text = item2.specSHPTitle;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = item2.specTitle;
					}
					text = text + _ImportExcelSpecFieldsSeperator + item2.SpecificationFieldID + "-" + item2.specGroupId;
					excelWorksheet.Cells[1, num].Value = text;
				}
			}
			using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
			{
				excelRange.Style.Font.Bold = true;
				excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
				excelRange.Style.Font.Color.SetColor(Color.White);
			}
			excelPackage.Workbook.Properties.Title = Labels.ProductImportExcelPropertiesTitle;
			excelPackage.Workbook.Properties.Company = Labels.ProductImportExcelPropertiesCompany;
			excelPackage.SaveAs(base.Response.OutputStream);
			base.Response.Buffer = true;
			base.Response.AddHeader("content-disposition", "attachment; filename=CRM-Ideal.xls");
			base.Response.ContentType = "application/ms-excel";
			base.Response.Charset = "";
			base.Response.Flush();
			base.Response.End();
		}
		List<WSspSelectProductImportFromExcelFields_Result> list3 = new List<WSspSelectProductImportFromExcelFields_Result>();
		try
		{
			list3 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result));
			if (list != null && list.Count > 0 && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBAll_Result>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list, (Func<CRMspSelectLinkAccSettingDBAll_Result, bool>)((CRMspSelectLinkAccSettingDBAll_Result x) => x.LinkAccSettingDBId > -1)) == null)
			{
				list3 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list3, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result x) => x.FieldName != "LinkAccSettingDBId")));
			}
			if (list3 != null && !Center.HaveModule)
			{
				list3 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list3, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result x) => x.FieldName != "PriceCId" && x.FieldName != "CostCId")));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FieldList = list3;
		GetSpecificationFieldsList();
		GetPrdColor();
		GetPrdUnit();
		GetPriceGroup();
		GetCostGroup();
		GetUnit();
		WSProductSecondGroup wSProductSecondGroup = _dbTbl.WSProductSecondGroup.Find(model.Id);
		GetFirstGroup(wSProductSecondGroup?.FirstGroupId ?? 0);
		GetSecondGroup(wSProductSecondGroup?.FirstGroupId ?? 0);
		base.ViewBag.SelectedSecondGroupId = model.Id;
		base.ViewBag.SelectedFirstGroupId = wSProductSecondGroup?.FirstGroupId ?? 0;
		base.ViewBag.PrdSecondGroupId = model.Id;
		return View(model);
	}

	public JsonResult UploadFile(string field, int groupId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel
		{
			IsDone = true,
			Message = "",
			Tag = null
		};
		if (((NameObjectCollectionBase)base.Request.Files).Count > 0)
		{
			try
			{
				List<CRMspSelectLinkAccSettingDBAll_Result> list = CRMIdeal.Classes.Helper.OtherSystems.SelectLinkAccSettingDBAll();
				DateTime now = DateTime.Now;
				object[,] obj = null;
				int num = 0;
				int num2 = 0;
				HttpFileCollectionBase files = base.Request.Files;
				if (files != null && ((NameObjectCollectionBase)files).Count > 0)
				{
					byte[] buffer = new byte[base.Request.ContentLength];
					base.Request.InputStream.Read(buffer, 0, Convert.ToInt32(base.Request.ContentLength));
					using (ExcelPackage excelPackage = new ExcelPackage(base.Request.InputStream))
					{
						ExcelWorksheet excelWorksheet = Enumerable.First<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets);
						num = excelWorksheet.Dimension.End.Column;
						num2 = excelWorksheet.Dimension.End.Row;
						obj = new object[num2, num];
						obj = (object[,])excelWorksheet.Cells.Value;
					}
					if (num2 > 2000)
					{
						commonReturnResultViewModel.Message = Messages.msgErrorMaxImportProductExcelRowsLimit;
						commonReturnResultViewModel.IsDone = false;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					string text = "";
					string text2 = "";
					List<WSspSelectProductImportFromExcelFields_Result> list2 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result)), (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result c) => c.IsActive.GetValueOrDefault() && c.Selector.GetValueOrDefault())));
					string[] array = new string[list2.Count];
					int[] array2 = new int[list2.Count];
					string[] array3 = new string[list2.Count];
					int num3 = 0;
					foreach (WSspSelectProductImportFromExcelFields_Result item in list2)
					{
						if (text != "")
						{
							text += ", ";
						}
						text = ((item.GroupNum.GetValueOrDefault() == 2 && item.FieldName.ToLower() != "price" && item.FieldName.ToLower() != "pricepercent") ? ((!(item.FieldName == "PriceCId")) ? (text + "Price" + item.FieldName) : (text + item.FieldName)) : ((item.GroupNum.GetValueOrDefault() != 3 || !(item.FieldName.ToLower() != "cost")) ? (text + item.FieldName) : ((!(item.FieldName == "CostCId")) ? (text + "Cost" + item.FieldName) : (text + item.FieldName))));
						if (text2 != "")
						{
							text2 += ", ";
						}
						text2 = text2 + "{" + num3 + "}";
						array[num3] = item.FieldType ?? "";
						array2[num3] = (item.FieldSize.HasValue ? int.Parse(item.FieldSize.ToString()) : (-1));
						array3[num3] = item.FieldName;
						num3++;
					}
					int num4 = Array.FindIndex(array3, (string f) => f == "PrdFirstGroupId");
					int num5 = Array.FindIndex(array3, (string f) => f == "PrdSecondGroupId");
					int num6 = Array.FindIndex(array3, (string f) => f == "PrdUnitIdI");
					int num7 = Array.FindIndex(array3, (string f) => f == "PrdUnitIRate");
					int num8 = Array.FindIndex(array3, (string f) => f == "PrdUnitIRateCalcAuto");
					int num9 = Array.FindIndex(array3, (string f) => f == "PrdUnitIdII");
					int num10 = Array.FindIndex(array3, (string f) => f == "PrdUnitIIRate");
					int num11 = Array.FindIndex(array3, (string f) => f == "PrdUnitIIRateCalcAuto");
					int num12 = Array.FindIndex(array3, (string f) => f == "PrdCode");
					if (num4 >= 0 && num5 < 0)
					{
						commonReturnResultViewModel.Message = Messages.msgErrorMainGroupSelectedSubGroupRequired;
						commonReturnResultViewModel.IsDone = false;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					if (num5 >= 0 && num4 < 0)
					{
						commonReturnResultViewModel.Message = Messages.msgErrorSubGroupSelectedMainGroupRequired;
						commonReturnResultViewModel.IsDone = false;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					if (num7 >= 0 && num6 < 0)
					{
						commonReturnResultViewModel.Message = Messages.msgErrorUnitIRateSelectedUnitIRequired;
						commonReturnResultViewModel.IsDone = false;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					if (num8 >= 0 && num6 < 0)
					{
						commonReturnResultViewModel.Message = Messages.msgErrorUnitIRateCalcAutoSelectedUnitIRequired;
						commonReturnResultViewModel.IsDone = false;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					if (num10 >= 0 && num9 < 0)
					{
						commonReturnResultViewModel.Message = Messages.msgErrorUnitIIRateSelectedUnitIIRequired;
						commonReturnResultViewModel.IsDone = false;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					if (num11 >= 0 && num9 < 0)
					{
						commonReturnResultViewModel.Message = Messages.msgErrorUnitIIRateCalcAutoSelectedUnitIIRequired;
						commonReturnResultViewModel.IsDone = false;
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
					_db.Database.ExecuteSqlCommand("delete WSProductImportFromExcel where UserId={0}", UserLogin.CurrentUser.UserId);
					if (text != "")
					{
						text += ", ";
					}
					text += "UserId, AppType, [Message], LanguageID, FirstRegisterUserId, FirstRegisterDatePersian, FirstRegisterDate, PrdSpecificaionFieldValues";
					if (text2 != "")
					{
						text2 += ", ";
					}
					text2 = text2 + "{" + num3 + "}, ";
					num3++;
					text2 = text2 + "{" + num3 + "}, ";
					num3++;
					text2 = text2 + "{" + num3 + "}, ";
					num3++;
					text2 = text2 + "{" + num3 + "}, ";
					num3++;
					text2 = text2 + "{" + num3 + "}, ";
					num3++;
					text2 = text2 + "{" + num3 + "}, ";
					num3++;
					text2 = text2 + "{" + num3 + "}, ";
					num3++;
					text2 = text2 + "{" + num3 + "}";
					num3++;
					string sql = "INSERT INTO WSProductImportFromExcel (" + text + ") VALUES (" + text2 + ")";
					object[] array4 = new object[num3];
					if (!VersionBuyer.ProductImportExcel)
					{
						num2 = 3;
					}
					List<WSspSelectProductSpecificationFields_Result> list3 = Enumerable.ToList<WSspSelectProductSpecificationFields_Result>((IEnumerable<WSspSelectProductSpecificationFields_Result>)_dbII.WSspSelectProductSpecificationFields(0, lCID, result));
					if (list3 != null)
					{
						foreach (WSspSelectProductSpecificationFields_Result item2 in list3)
						{
							string text3 = item2.specSHPTitle;
							if (string.IsNullOrWhiteSpace(text3))
							{
								text3 = item2.specTitle;
							}
							text3 = text3 + _ImportExcelSpecFieldsSeperator + item2.SpecificationFieldID + "-" + item2.specGroupId;
							item2.specTitle = text3;
						}
					}
					int num13 = num;
					List<object> list4 = new List<object>();
					List<WSspSelectProductsWithCodeAndGroup_Result> list5 = new List<WSspSelectProductsWithCodeAndGroup_Result>();
					if (lCID != result)
					{
						for (int j = 1; j < num2; j++)
						{
							string text4 = "";
							int result2 = 0;
							if (num12 >= 0 && obj[j, num12] != null)
							{
								text4 = obj[j, num12].ToString() ?? "";
							}
							if (num5 >= 0 && obj[j, num5] != null)
							{
								int.TryParse(obj[j, num5].ToString(), out result2);
								if (result2 <= 0)
								{
									result2 = groupId;
								}
							}
							else
							{
								result2 = groupId;
							}
							if (!string.IsNullOrWhiteSpace(text4))
							{
								list4.Add(new
								{
									Code = text4,
									GroupId = result2
								});
							}
						}
						list5 = Enumerable.ToList<WSspSelectProductsWithCodeAndGroup_Result>((IEnumerable<WSspSelectProductsWithCodeAndGroup_Result>)_dbIII.WSspSelectProductsWithCodeAndGroup(JsonConvert.SerializeObject(list4), lCID, result));
					}
					for (int k = 1; k < num2; k++)
					{
						List<ProductSpecificationFieldValuesJsViewModel> list6 = new List<ProductSpecificationFieldValuesJsViewModel>();
						num = num13;
						string text5 = "";
						bool flag = false;
						int i;
						for (i = 0; i < num; i++)
						{
							if (Enumerable.Count<string>((IEnumerable<string>)array3) > i)
							{
								array4[i] = obj[k, i];
								switch (array3[i])
								{
								case "PrdCode":
									if (array4[i] != null)
									{
										if (string.IsNullOrWhiteSpace(array4[i].ToString() ?? ""))
										{
											if (text5 != "")
											{
												text5 += ", ";
											}
											text5 += string.Format(Messages.msgErrorIsNotEnteredItem, obj[0, i]);
											array4[i] = "";
										}
									}
									else
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += string.Format(Messages.msgErrorIsNotEnteredItem, obj[0, i]);
										array4[i] = "";
									}
									continue;
								case "PrdName":
									if (array4[i] != null)
									{
										if (string.IsNullOrWhiteSpace(array4[i].ToString() ?? ""))
										{
											if (text5 != "")
											{
												text5 += ", ";
											}
											text5 += string.Format(Messages.msgErrorIsNotEnteredItem, obj[0, i]);
											array4[i] = "";
										}
									}
									else
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += string.Format(Messages.msgErrorIsNotEnteredItem, obj[0, i]);
										array4[i] = "";
									}
									continue;
								case "PrdColorId":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result17 = 0;
									int.TryParse(array4[i].ToString(), out result17);
									if (result17 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									else if (_dbTbl.WSProductColor.Find(result17) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorPrdColorIsWrong;
									}
									continue;
								}
								case "PrdUnitId":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result11 = 0;
									int.TryParse(array4[i].ToString(), out result11);
									if (result11 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									else if (_dbTbl.WSProductUnits.Find(result11) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorPrdUnitIsWrong;
									}
									continue;
								}
								case "ProductPriceGroupId":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int productPriceGroupId = 0;
									int.TryParse(array4[i].ToString(), out productPriceGroupId);
									if (productPriceGroupId <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									else if (Enumerable.FirstOrDefault<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result), (Func<WSspSelectProductPriceGroup_Result, bool>)((WSspSelectProductPriceGroup_Result model) => model.ProductPriceGroupID == productPriceGroupId)) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorPriceGroupIsWrong;
									}
									continue;
								}
								case "CurrencyUnitId":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result18 = 0;
									int.TryParse(array4[i].ToString(), out result18);
									if (result18 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									else if (_dbTbl.WSCurrencyUnits.Find(result18) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorCostCurrencyUnitIsWrong;
									}
									continue;
								}
								case "ProductCostGroupId":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result5 = 0;
									int.TryParse(array4[i].ToString(), out result5);
									if (result5 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									else if (_dbTbl.WSProductCostGroup.Find(result5) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorCostGroupIsWrong;
									}
									continue;
								}
								case "PrdFirstGroupId":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result14 = 0;
									int.TryParse(array4[i].ToString(), out result14);
									int result15 = 0;
									if (obj[k, num5] != null)
									{
										int.TryParse(obj[k, num5].ToString(), out result15);
									}
									if (result14 <= 0)
									{
										continue;
									}
									if (_dbTbl.WSProductFirstGroup.Find(result14) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorProductFirstGroupIsWrong;
										flag = true;
										array4[i] = null;
									}
									else if (result15 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, num5]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
										flag = true;
									}
									continue;
								}
								case "PrdSecondGroupId":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result3 = 0;
									int.TryParse(array4[i].ToString(), out result3);
									int result4 = 0;
									if (obj[k, num4] != null)
									{
										int.TryParse(obj[k, num4].ToString(), out result4);
									}
									if (result3 <= 0)
									{
										continue;
									}
									WSProductSecondGroup wSProductSecondGroup = _dbTbl.WSProductSecondGroup.Find(result3);
									if (wSProductSecondGroup == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorProductSecondGroupIsWrong;
										array4[i] = null;
										flag = true;
									}
									if (result4 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, num4]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
										flag = true;
									}
									else if (wSProductSecondGroup != null && wSProductSecondGroup.FirstGroupId != result4)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += string.Format(Messages.msgErrorPrdSecondGroupNotBelongToFirstGroup, obj[0, i]);
										array4[i] = null;
										flag = true;
									}
									continue;
								}
								case "PrdUnitIdI":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result10 = 0;
									int.TryParse(array4[i].ToString(), out result10);
									if (result10 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									else if (_dbTbl.WSProductUnits.Find(result10) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorPrdUnitIsWrong;
									}
									continue;
								}
								case "PrdUnitIdII":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result16 = 0;
									int.TryParse(array4[i].ToString(), out result16);
									if (result16 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									else if (_dbTbl.WSProductUnits.Find(result16) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += Messages.msgErrorPrdUnitIsWrong;
									}
									continue;
								}
								case "PrdUnitIRate":
								{
									if (array4[i] == null)
									{
										continue;
									}
									decimal result19 = default(decimal);
									decimal.TryParse(array4[i].ToString(), out result19);
									int result20 = 0;
									if (obj[k, num6] != null)
									{
										int.TryParse(obj[k, num6].ToString(), out result20);
									}
									if (result19 != 0m && result20 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, num6]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
										flag = true;
									}
									continue;
								}
								case "PrdUnitIRateCalcAuto":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result6 = -1;
									int.TryParse(array4[i].ToString(), out result6);
									int result7 = 0;
									if (obj[k, num6] != null)
									{
										int.TryParse(obj[k, num6].ToString(), out result7);
									}
									if (result6 != -1 && result7 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, num6]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
										flag = true;
									}
									continue;
								}
								case "PrdUnitIIRate":
								{
									if (array4[i] == null)
									{
										continue;
									}
									decimal result8 = default(decimal);
									decimal.TryParse(array4[i].ToString(), out result8);
									int result9 = 0;
									if (obj[k, num9] != null)
									{
										int.TryParse(obj[k, num9].ToString(), out result9);
									}
									if (result8 > 0m && result9 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, num9]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
										flag = true;
									}
									continue;
								}
								case "PrdUnitIIRateCalcAuto":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int result12 = -1;
									int.TryParse(array4[i].ToString(), out result12);
									int result13 = 0;
									if (obj[k, num9] != null)
									{
										int.TryParse(obj[k, num9].ToString(), out result13);
									}
									if (result12 != -1 && result13 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, num9]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
										flag = true;
									}
									continue;
								}
								case "LinkAccSettingDBId":
								{
									if (array4[i] == null)
									{
										continue;
									}
									int LinkAccSettingDBId = 0;
									int.TryParse(array4[i].ToString(), out LinkAccSettingDBId);
									if (LinkAccSettingDBId != 0 && list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBAll_Result>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list, (Func<CRMspSelectLinkAccSettingDBAll_Result, bool>)((CRMspSelectLinkAccSettingDBAll_Result x) => x.LinkAccSettingDBId > -1)) != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBAll_Result>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list, (Func<CRMspSelectLinkAccSettingDBAll_Result, bool>)((CRMspSelectLinkAccSettingDBAll_Result x) => x.LinkAccSettingDBId == LinkAccSettingDBId)) == null)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += string.Format(Messages.msgErrorIsNotFound, Labels.ProductImportExcelValue);
									}
									continue;
								}
								}
								switch (array[i])
								{
								case "int":
								{
									if (array4[i] == null)
									{
										break;
									}
									int result22 = 0;
									int.TryParse(array4[i].ToString(), out result22);
									if (result22 <= 0)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									break;
								}
								case "nvarchar":
								{
									if (array4[i] == null)
									{
										break;
									}
									int num14 = array2[i];
									if (num14 > 0 && array4[i].ToString().Length > num14)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += string.Format(Messages.msgErrorFieldLengthExceedsMax, obj[0, i], num14);
										array4[i] = null;
									}
									break;
								}
								case "bit":
									if (array4[i] != null && !(array4[i].ToString() == "0") && !(array4[i].ToString() == "1"))
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 += string.Format(Messages.msgErrorFieldMustBeZeroOrOne, obj[0, i]);
										array4[i] = null;
									}
									break;
								case "numeric":
								{
									if (array4[i] == null)
									{
										break;
									}
									decimal result21 = default(decimal);
									decimal.TryParse(array4[i].ToString(), out result21);
									if (result21 <= 0m)
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + Labels.ProductImportExcelValue + " " + obj[0, i]?.ToString() + " " + Messages.msgErrorNumericAndMoreZero;
										array4[i] = null;
									}
									break;
								}
								case "datestring":
									if (array4[i] != null && !Regex.IsMatch(array4[i].ToString(), "(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$"))
									{
										if (text5 != "")
										{
											text5 += ", ";
										}
										text5 = text5 + "مقدار " + obj[0, i]?.ToString() + " باید تاریخ با فرمت yyyy/MM/dd باشد";
										array4[i] = null;
									}
									break;
								}
							}
							else if (obj[0, i].ToString().Contains(_ImportExcelSpecFieldsSeperator))
							{
								WSspSelectProductSpecificationFields_Result wSspSelectProductSpecificationFields_Result = Enumerable.FirstOrDefault<WSspSelectProductSpecificationFields_Result>((IEnumerable<WSspSelectProductSpecificationFields_Result>)list3, (Func<WSspSelectProductSpecificationFields_Result, bool>)((WSspSelectProductSpecificationFields_Result x) => x.specTitle == obj[0, i].ToString()));
								if (wSspSelectProductSpecificationFields_Result != null)
								{
									ProductSpecificationFieldValuesJsViewModel productSpecificationFieldValuesJsViewModel = new ProductSpecificationFieldValuesJsViewModel();
									productSpecificationFieldValuesJsViewModel.FId = wSspSelectProductSpecificationFields_Result.SpecificationFieldID;
									productSpecificationFieldValuesJsViewModel.FV = (obj[k, i] ?? "").ToString();
									list6.Add(productSpecificationFieldValuesJsViewModel);
								}
							}
						}
						num -= list6.Count;
						array4[num] = UserLogin.CurrentUser.UserId;
						array4[num + 1] = "web";
						array4[num + 2] = text5;
						array4[num + 3] = result;
						array4[num + 4] = UserLogin.CurrentUser.UserId;
						array4[num + 5] = now.ToString("yyyyMMdd", new PersianCulture());
						array4[num + 6] = now;
						if (list6.Count > 0)
						{
							array4[num + 7] = JsonConvert.SerializeObject(list6);
						}
						else
						{
							array4[num + 7] = "";
						}
						if (lCID != result)
						{
							string code = "";
							if (obj[k, num12] != null)
							{
								code = obj[k, num12].ToString();
							}
							int sgId = 0;
							if (obj[k, num5] != null)
							{
								int.TryParse(obj[k, num5].ToString(), out sgId);
							}
							if (sgId == 0)
							{
								sgId = groupId;
							}
							if (Enumerable.FirstOrDefault<WSspSelectProductsWithCodeAndGroup_Result>((IEnumerable<WSspSelectProductsWithCodeAndGroup_Result>)list5, (Func<WSspSelectProductsWithCodeAndGroup_Result, bool>)((WSspSelectProductsWithCodeAndGroup_Result x) => x.PrdCode == code && x.PrdGroupID == sgId)) == null)
							{
								flag = true;
								text5 += string.Format(Messages.msgErrorProductNotFoundForCodeAndGroup, code, sgId);
							}
						}
						try
						{
							if (!flag)
							{
								_db.Database.ExecuteSqlCommand(sql, array4);
								continue;
							}
							commonReturnResultViewModel.IsDone = false;
							if (commonReturnResultViewModel.Message != "")
							{
								commonReturnResultViewModel.Message += ", ";
							}
							commonReturnResultViewModel.Message += k;
						}
						catch (Exception e)
						{
							commonReturnResultViewModel.IsDone = false;
							if (commonReturnResultViewModel.Message != "")
							{
								commonReturnResultViewModel.Message += ", ";
							}
							commonReturnResultViewModel.Message += k;
							ErrorSignal.FromCurrentContext().Raise(e);
						}
					}
					_db.Database.ExecuteSqlCommand("update WSProductImportFromExcel set PriceDocDate =replace(replace(PriceDocDate, '/', ''), '-', ''), CostDocDate =replace(replace(CostDocDate, '/', ''), '-', '')");
					CheckDuplicateInProduct(field);
					commonReturnResultViewModel.Tag = obj;
				}
				if (commonReturnResultViewModel.Message != "")
				{
					commonReturnResultViewModel.Message = Messages.msgErrorLoadingInfoEnteredInRow + " " + commonReturnResultViewModel.Message;
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorLoadingInfoEntered;
			}
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult DoImport(string isUpdate, string priceDocDate, string costDocDate, string checkDuplicateField, int groupId)
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
		bool flag = true;
		try
		{
			if (string.IsNullOrEmpty(priceDocDate))
			{
				priceDocDate = DateTime.Now.ToString("yyyyMMdd");
			}
			if (string.IsNullOrEmpty(costDocDate))
			{
				costDocDate = DateTime.Now.ToString("yyyyMMdd");
			}
			bool.TryParse(isUpdate.ToLower(), out var result3);
			DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(priceDocDate));
			DateTime value2 = DateTime.Parse(PersianDate.GetFormatetdDate(costDocDate));
			DateTime now = DateTime.Now;
			DateTime dateTime = default(DateTime);
			string text = "";
			if (!string.IsNullOrEmpty(priceDocDate))
			{
				text = PersianDate.GetFormatetdDate(priceDocDate.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
					priceDocDate = dateTime.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
					priceDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
					priceDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				value = dateTime;
			}
			if (!string.IsNullOrEmpty(costDocDate))
			{
				text = PersianDate.GetFormatetdDate(costDocDate.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
					costDocDate = dateTime.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
					costDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
					costDocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				value2 = dateTime;
			}
			if (_db.WSspImportProductsFromExcelToTable(UserLogin.CurrentUser.UserId, checkDuplicateField, result3, value, priceDocDate, value2, costDocDate, groupId, Configuration.AppType, now.ToString("yyyyMMdd", new PersianCulture()), now, short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, CRMIdeal.Cache.Setting.Warehouse.Get().Id, lCID, result, result2) < 0)
			{
				flag = false;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			flag = false;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			flag = false;
		}
		return Json(flag, JsonRequestBehavior.AllowGet);
	}

	public List<ProductImportFromExcelFieldsViewModel> MakeExportList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<ProductImportFromExcelFieldsViewModel> list = new List<ProductImportFromExcelFieldsViewModel>();
		try
		{
			List<WSspSelectProductImportFromExcelFields_Result> list2 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result), (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result model) => model.Selector.GetValueOrDefault())));
			if (Enumerable.Any<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2))
			{
				List<CRMspSelectLinkAccSettingDBAll_Result> list3 = CRMIdeal.Classes.Helper.OtherSystems.SelectLinkAccSettingDBAll();
				if (list3 != null && list3.Count > 0 && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBAll_Result>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list3, (Func<CRMspSelectLinkAccSettingDBAll_Result, bool>)((CRMspSelectLinkAccSettingDBAll_Result x) => x.LinkAccSettingDBId > -1)) == null)
				{
					list2 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result x) => x.FieldName != "LinkAccSettingDBId")));
				}
				if (list2 != null && !Center.HaveModule)
				{
					list2 = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result x) => x.FieldName != "PriceCId" && x.FieldName != "CostCId")));
				}
				List<string> list4 = Enumerable.ToList<string>(Enumerable.Select<WSspSelectProductImportFromExcelFields_Result, string>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result item) => item.GroupNum.GetValueOrDefault() == 1)), (Func<WSspSelectProductImportFromExcelFields_Result, string>)((WSspSelectProductImportFromExcelFields_Result item) => item.FieldName)));
				List<string> list5 = Enumerable.ToList<string>(Enumerable.Select<WSspSelectProductImportFromExcelFields_Result, string>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result item) => item.GroupNum.GetValueOrDefault() == 2)), (Func<WSspSelectProductImportFromExcelFields_Result, string>)((WSspSelectProductImportFromExcelFields_Result item) => item.FieldName)));
				List<string> list6 = Enumerable.ToList<string>(Enumerable.Select<WSspSelectProductImportFromExcelFields_Result, string>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list2, (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result item) => item.GroupNum.GetValueOrDefault() == 3)), (Func<WSspSelectProductImportFromExcelFields_Result, string>)((WSspSelectProductImportFromExcelFields_Result item) => item.FieldName)));
				List<WSspSelectProductImportFromExcel_Result> list7 = new List<WSspSelectProductImportFromExcel_Result>();
				list7 = ((!VersionBuyer.ProductImportExcel) ? Enumerable.ToList<WSspSelectProductImportFromExcel_Result>(Enumerable.Take<WSspSelectProductImportFromExcel_Result>(Enumerable.Where<WSspSelectProductImportFromExcel_Result>((IEnumerable<WSspSelectProductImportFromExcel_Result>)Enumerable.ToList<WSspSelectProductImportFromExcel_Result>((IEnumerable<WSspSelectProductImportFromExcel_Result>)_db.WSspSelectProductImportFromExcel()), (Func<WSspSelectProductImportFromExcel_Result, bool>)((WSspSelectProductImportFromExcel_Result model) => model.UserId == UserLogin.CurrentUser.UserId)), 2)) : Enumerable.ToList<WSspSelectProductImportFromExcel_Result>(Enumerable.Where<WSspSelectProductImportFromExcel_Result>((IEnumerable<WSspSelectProductImportFromExcel_Result>)Enumerable.ToList<WSspSelectProductImportFromExcel_Result>((IEnumerable<WSspSelectProductImportFromExcel_Result>)_db.WSspSelectProductImportFromExcel()), (Func<WSspSelectProductImportFromExcel_Result, bool>)((WSspSelectProductImportFromExcel_Result model) => model.UserId == UserLogin.CurrentUser.UserId))));
				foreach (WSspSelectProductImportFromExcel_Result item in list7)
				{
					ProductImportFromExcelFieldsViewModel productImportFromExcelFieldsViewModel = new ProductImportFromExcelFieldsViewModel();
					productImportFromExcelFieldsViewModel.Id = item.Id;
					productImportFromExcelFieldsViewModel.Selector = item.Selector;
					productImportFromExcelFieldsViewModel.RelationId = item.RelationId;
					productImportFromExcelFieldsViewModel.IsDuplicate = item.IsDuplicate;
					productImportFromExcelFieldsViewModel.FindedPrdId = item.FindedPrdId;
					productImportFromExcelFieldsViewModel.InsertedPrdId = item.InsertedPrdId;
					productImportFromExcelFieldsViewModel.ErrorMessage = item.Message;
					productImportFromExcelFieldsViewModel.IsValid = string.IsNullOrEmpty(item.Message);
					if (!string.IsNullOrEmpty(item.DuplicatedIds))
					{
						if (!string.IsNullOrEmpty(productImportFromExcelFieldsViewModel.ErrorMessage))
						{
							productImportFromExcelFieldsViewModel.ErrorMessage += ", ";
						}
						productImportFromExcelFieldsViewModel.ErrorMessage += "اطلاعات تکراری می باشد";
					}
					productImportFromExcelFieldsViewModel.DuplicatedIds = item.DuplicatedIds;
					productImportFromExcelFieldsViewModel.InsertedPriceIds = item.InsertedPriceIds;
					productImportFromExcelFieldsViewModel.InsertedCostIds = item.InsertedCostIds;
					productImportFromExcelFieldsViewModel.UpdatedPrdIds = item.UpdatedPrdIds;
					productImportFromExcelFieldsViewModel.UpdatedPriceIds = item.UpdatedPriceIds;
					productImportFromExcelFieldsViewModel.UpdatedCostIds = item.UpdatedCostIds;
					if (Enumerable.Any<string>((IEnumerable<string>)list4))
					{
						string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdCode")));
						productImportFromExcelFieldsViewModel.PrdCodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdName")));
						productImportFromExcelFieldsViewModel.PrdNameVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdLatinName")));
						productImportFromExcelFieldsViewModel.PrdLatinNameVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdType")));
						productImportFromExcelFieldsViewModel.PrdTypeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdDesign")));
						productImportFromExcelFieldsViewModel.PrdDesignVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSize")));
						productImportFromExcelFieldsViewModel.PrdSizeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdColorId")));
						productImportFromExcelFieldsViewModel.PrdColorIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdUnitId")));
						productImportFromExcelFieldsViewModel.PrdUnitIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdMinQty")));
						productImportFromExcelFieldsViewModel.PrdMinQtyVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdMaxQty")));
						productImportFromExcelFieldsViewModel.PrdMaxQtyVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSleepDay")));
						productImportFromExcelFieldsViewModel.PrdSleepDayVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdFirstSerial")));
						productImportFromExcelFieldsViewModel.PrdFirstSerialVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSecondSerial")));
						productImportFromExcelFieldsViewModel.PrdSecondSerialVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdThirdSerial")));
						productImportFromExcelFieldsViewModel.PrdThirdSerialVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdFirstBarcode")));
						productImportFromExcelFieldsViewModel.PrdFirstBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSecondBarcode")));
						productImportFromExcelFieldsViewModel.PrdSecondBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdThirdBarcode")));
						productImportFromExcelFieldsViewModel.PrdThirdBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdDescription")));
						productImportFromExcelFieldsViewModel.PrdDescriptionVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdBarCode")));
						productImportFromExcelFieldsViewModel.PrdBarCodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdBarCodeTypeId")));
						productImportFromExcelFieldsViewModel.PrdBarCodeTypeIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdAutoNumBarcode")));
						productImportFromExcelFieldsViewModel.PrdAutoNumBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdAutoNumBarCodeTypeId")));
						productImportFromExcelFieldsViewModel.PrdAutoNumBarCodeTypeIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdAutoCharBarcode")));
						productImportFromExcelFieldsViewModel.PrdAutoCharBarcodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("prdAutoCharBarCodeTypeId")));
						productImportFromExcelFieldsViewModel.PrdAutoCharBarCodeTypeIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdModel")));
						productImportFromExcelFieldsViewModel.PrdModelVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdInactiveInSale")));
						productImportFromExcelFieldsViewModel.PrdInactiveInSaleVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdInactiveInBuy")));
						productImportFromExcelFieldsViewModel.PrdInactiveInBuyVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPIsActive")));
						productImportFromExcelFieldsViewModel.PrdSHPIsActiveVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPTitle")));
						productImportFromExcelFieldsViewModel.PrdSHPTitleVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPCode")));
						productImportFromExcelFieldsViewModel.PrdSHPCodeVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPModel")));
						productImportFromExcelFieldsViewModel.PrdSHPModelVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPDescription")));
						productImportFromExcelFieldsViewModel.PrdSHPDescriptionVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPDescriptionII")));
						productImportFromExcelFieldsViewModel.PrdSHPDescriptionIIVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPStockManageTypeId")));
						productImportFromExcelFieldsViewModel.PrdSHPStockManageTypeIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPStockManualyCount")));
						productImportFromExcelFieldsViewModel.PrdSHPStockManualyCountVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPHiddenPriceInNoStock")));
						productImportFromExcelFieldsViewModel.PrdSHPHiddenPriceInNoStockVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPSelfSupplier")));
						productImportFromExcelFieldsViewModel.PrdSHPSelfSupplierVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPOtherSupplierId")));
						productImportFromExcelFieldsViewModel.PrdSHPOtherSupplierIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdSHPQtyFromTracing")));
						productImportFromExcelFieldsViewModel.PrdSHPQtyFromTracingVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdQtyCanDecimal")));
						productImportFromExcelFieldsViewModel.PrdQtyCanDecimalVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdCommissionDisable")));
						productImportFromExcelFieldsViewModel.PrdCommissionDisableVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdCommissionPercentRate")));
						productImportFromExcelFieldsViewModel.PrdCommissionPercentRateVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdIsDefault")));
						productImportFromExcelFieldsViewModel.PrdIsDefaultVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdInActive")));
						productImportFromExcelFieldsViewModel.PrdInActiveVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdKind")));
						productImportFromExcelFieldsViewModel.PrdKindVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdDefQuantity")));
						productImportFromExcelFieldsViewModel.PrdDefQuantityVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdJustDefQuantity")));
						productImportFromExcelFieldsViewModel.PrdJustDefQuantityVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdMinQuantity")));
						productImportFromExcelFieldsViewModel.PrdMinQuantityVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list4, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PrdMaxQuantity")));
						productImportFromExcelFieldsViewModel.PrdMaxQuantityVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
					}
					else
					{
						productImportFromExcelFieldsViewModel.PrdCodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdNameVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdLatinNameVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdTypeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdDesignVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSizeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdColorIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdUnitIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdMinQtyVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdMaxQtyVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSleepDayVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdFirstSerialVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSecondSerialVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdThirdSerialVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdFirstBarcodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSecondBarcodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdThirdBarcodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdDescriptionVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdBarCodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdBarCodeTypeIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdAutoNumBarCodeTypeIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdAutoCharBarcodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdAutoCharBarCodeTypeIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdModelVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdInactiveInSaleVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdInactiveInBuyVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPIsActiveVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPTitleVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPCodeVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPModelVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPDescriptionVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPDescriptionIIVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPStockManageTypeIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPStockManualyCountVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPHiddenPriceInNoStockVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPSelfSupplierVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPOtherSupplierIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdSHPQtyFromTracingVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdQtyCanDecimalVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdCommissionDisableVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdCommissionPercentRateVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdIsDefaultVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdInActiveVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdKindVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdDefQuantityVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdJustDefQuantityVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdMinQuantityVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PrdMaxQuantityVisibale = "hidden";
					}
					productImportFromExcelFieldsViewModel.PrdCode = item.PrdCode;
					productImportFromExcelFieldsViewModel.PrdName = item.PrdName;
					productImportFromExcelFieldsViewModel.PrdLatinName = item.PrdLatinName;
					productImportFromExcelFieldsViewModel.PrdType = item.PrdType;
					productImportFromExcelFieldsViewModel.PrdDesign = item.PrdDesign;
					productImportFromExcelFieldsViewModel.PrdSize = item.PrdSize;
					productImportFromExcelFieldsViewModel.PrdColorId = item.PrdColorId;
					productImportFromExcelFieldsViewModel.PrdUnitId = item.PrdUnitId;
					productImportFromExcelFieldsViewModel.PrdMinQty = item.PrdMinQty;
					productImportFromExcelFieldsViewModel.PrdMaxQty = item.PrdMaxQty;
					productImportFromExcelFieldsViewModel.PrdSleepDay = item.PrdSleepDay;
					productImportFromExcelFieldsViewModel.PrdFirstSerial = item.PrdFirstSerial;
					productImportFromExcelFieldsViewModel.PrdSecondSerial = item.PrdSecondSerial;
					productImportFromExcelFieldsViewModel.PrdThirdSerial = item.PrdThirdSerial;
					productImportFromExcelFieldsViewModel.PrdFirstBarcode = item.PrdFirstBarcode;
					productImportFromExcelFieldsViewModel.PrdSecondBarcode = item.PrdSecondBarcode;
					productImportFromExcelFieldsViewModel.PrdThirdBarcode = item.PrdThirdBarcode;
					productImportFromExcelFieldsViewModel.PrdDescription = item.PrdDescription;
					productImportFromExcelFieldsViewModel.PrdBarCode = item.PrdBarCode;
					productImportFromExcelFieldsViewModel.PrdBarCodeTypeId = item.PrdBarCodeTypeId;
					productImportFromExcelFieldsViewModel.PrdAutoNumBarcode = item.PrdAutoNumBarcode;
					productImportFromExcelFieldsViewModel.PrdAutoNumBarCodeTypeId = item.PrdAutoNumBarCodeTypeId;
					productImportFromExcelFieldsViewModel.PrdAutoCharBarcode = item.PrdAutoCharBarcode;
					productImportFromExcelFieldsViewModel.prdAutoCharBarCodeTypeId = item.prdAutoCharBarCodeTypeId;
					productImportFromExcelFieldsViewModel.PrdModel = item.PrdModel;
					productImportFromExcelFieldsViewModel.PrdInactiveInSale = item.PrdInactiveInSale;
					productImportFromExcelFieldsViewModel.PrdInactiveInBuy = item.PrdInactiveInBuy;
					productImportFromExcelFieldsViewModel.PrdSHPIsActive = item.PrdSHPIsActive;
					productImportFromExcelFieldsViewModel.PrdSHPTitle = item.PrdSHPTitle;
					productImportFromExcelFieldsViewModel.PrdSHPCode = item.PrdSHPCode;
					productImportFromExcelFieldsViewModel.PrdSHPModel = item.PrdSHPModel;
					productImportFromExcelFieldsViewModel.PrdSHPDescription = item.PrdSHPDescription;
					productImportFromExcelFieldsViewModel.PrdSHPDescriptionII = item.PrdSHPDescriptionII;
					productImportFromExcelFieldsViewModel.PrdSHPStockManageTypeId = item.PrdSHPStockManageTypeId;
					productImportFromExcelFieldsViewModel.PrdSHPStockManualyCount = item.PrdSHPStockManualyCount;
					productImportFromExcelFieldsViewModel.PrdSHPHiddenPriceInNoStock = item.PrdSHPHiddenPriceInNoStock;
					productImportFromExcelFieldsViewModel.PrdSHPSelfSupplier = item.PrdSHPSelfSupplier;
					productImportFromExcelFieldsViewModel.PrdSHPOtherSupplierId = item.PrdSHPOtherSupplierId;
					productImportFromExcelFieldsViewModel.PrdSHPQtyFromTracing = item.PrdSHPQtyFromTracing;
					productImportFromExcelFieldsViewModel.PrdQtyCanDecimal = item.PrdQtyCanDecimal;
					productImportFromExcelFieldsViewModel.PrdCommissionDisable = item.PrdCommissionDisable;
					productImportFromExcelFieldsViewModel.PrdCommissionPercentRate = item.PrdCommissionPercentRate;
					productImportFromExcelFieldsViewModel.PrdIsDefault = item.PrdIsDefault;
					productImportFromExcelFieldsViewModel.PrdInActive = item.PrdInActive;
					productImportFromExcelFieldsViewModel.PrdKind = item.PrdKind;
					productImportFromExcelFieldsViewModel.PrdDefQuantity = item.PrdDefQuantity;
					productImportFromExcelFieldsViewModel.PrdJustDefQuantity = item.PrdJustDefQuantity;
					productImportFromExcelFieldsViewModel.PrdMinQuantity = item.PrdMinQuantity;
					productImportFromExcelFieldsViewModel.PrdMaxQuantity = item.PrdMaxQuantity;
					if (Enumerable.Any<string>((IEnumerable<string>)list5))
					{
						string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DocDate")));
						productImportFromExcelFieldsViewModel.PriceDocDateVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DocNumber")));
						productImportFromExcelFieldsViewModel.PriceDocNumberVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Price")));
						productImportFromExcelFieldsViewModel.PriceVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CurrencyPrice")));
						productImportFromExcelFieldsViewModel.PriceCurrencyPriceVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CurrencyUnitId")));
						productImportFromExcelFieldsViewModel.PriceCurrencyUnitIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CooperationPrice")));
						productImportFromExcelFieldsViewModel.PriceCooperationPriceVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("PricePercent")));
						productImportFromExcelFieldsViewModel.PricePercentVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DiscountPrecent")));
						productImportFromExcelFieldsViewModel.PriceDiscountPrecentVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Discount")));
						productImportFromExcelFieldsViewModel.PriceDiscountVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("OtherPrice")));
						productImportFromExcelFieldsViewModel.PriceOtherPriceVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Description")));
						productImportFromExcelFieldsViewModel.PriceDescriptionVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list5, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("ProductPriceGroupId")));
						productImportFromExcelFieldsViewModel.PriceProductPriceGroupIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
					}
					else
					{
						productImportFromExcelFieldsViewModel.PriceDocDateVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceDocNumberVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceCurrencyPriceVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceCurrencyUnitIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceCooperationPriceVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PricePercentVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceDiscountPrecentVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceDiscountVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceOtherPriceVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceDescriptionVisibale = "hidden";
						productImportFromExcelFieldsViewModel.PriceProductPriceGroupIdVisibale = "hidden";
					}
					productImportFromExcelFieldsViewModel.PriceDocDate = item.PriceDocDate;
					productImportFromExcelFieldsViewModel.PriceDocNumber = item.PriceDocNumber;
					productImportFromExcelFieldsViewModel.Price = item.Price;
					productImportFromExcelFieldsViewModel.PriceCurrencyPrice = item.PriceCurrencyPrice;
					productImportFromExcelFieldsViewModel.PriceCurrencyUnitId = item.PriceCurrencyUnitId;
					productImportFromExcelFieldsViewModel.PriceCooperationPrice = item.PriceCooperationPrice;
					productImportFromExcelFieldsViewModel.PricePercent = item.PricePercent;
					productImportFromExcelFieldsViewModel.PriceDiscountPrecent = item.PriceDiscountPrecent;
					productImportFromExcelFieldsViewModel.PriceDiscount = item.PriceDiscount;
					productImportFromExcelFieldsViewModel.PriceOtherPrice = item.PriceOtherPrice;
					productImportFromExcelFieldsViewModel.PriceDescription = item.PriceDescription;
					productImportFromExcelFieldsViewModel.PriceProductPriceGroupId = item.PriceProductPriceGroupId;
					if (Enumerable.Any<string>((IEnumerable<string>)list6))
					{
						string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DocDate")));
						productImportFromExcelFieldsViewModel.CostDocDateVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("DocNumber")));
						productImportFromExcelFieldsViewModel.CostDocNumberVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Cost")));
						productImportFromExcelFieldsViewModel.CostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CurrencyCost")));
						productImportFromExcelFieldsViewModel.CostCurrencyCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("CurrencyUnitId")));
						productImportFromExcelFieldsViewModel.CostCurrencyUnitIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("TransportCost")));
						productImportFromExcelFieldsViewModel.CostTransportCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("ReleasingCost")));
						productImportFromExcelFieldsViewModel.CostReleasingCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("SlagCost")));
						productImportFromExcelFieldsViewModel.CostSlagCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("OtherCost")));
						productImportFromExcelFieldsViewModel.CostOtherCostVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("Description")));
						productImportFromExcelFieldsViewModel.CostDescriptionVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
						text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)list6, (Func<string, bool>)((string stringToCheck) => stringToCheck.Contains("ProductCostGroupId")));
						productImportFromExcelFieldsViewModel.CostProductCostGroupIdVisibale = ((text != null && Enumerable.Any<char>((IEnumerable<char>)text)) ? "visible" : "hidden");
					}
					else
					{
						productImportFromExcelFieldsViewModel.CostDocDateVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostDocNumberVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostCurrencyCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostCurrencyUnitIdVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostTransportCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostReleasingCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostSlagCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostOtherCostVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostDescriptionVisibale = "hidden";
						productImportFromExcelFieldsViewModel.CostProductCostGroupIdVisibale = "hidden";
					}
					productImportFromExcelFieldsViewModel.CostDocDate = item.CostDocDate;
					productImportFromExcelFieldsViewModel.CostDocNumber = item.CostDocNumber;
					productImportFromExcelFieldsViewModel.Cost = item.Cost;
					productImportFromExcelFieldsViewModel.CostCurrencyCost = item.CostCurrencyCost;
					productImportFromExcelFieldsViewModel.CostCurrencyUnitId = item.CostCurrencyUnitId;
					productImportFromExcelFieldsViewModel.CostTransportCost = item.CostTransportCost;
					productImportFromExcelFieldsViewModel.CostReleasingCost = item.CostReleasingCost;
					productImportFromExcelFieldsViewModel.CostSlagCost = item.CostSlagCost;
					productImportFromExcelFieldsViewModel.CostOtherCost = item.CostOtherCost;
					productImportFromExcelFieldsViewModel.CostDescription = item.CostDescription;
					productImportFromExcelFieldsViewModel.CostProductCostGroupId = item.CostProductCostGroupId;
					if (!productImportFromExcelFieldsViewModel.IsValid)
					{
						WSProductImportFromExcel wSProductImportFromExcel = _dbTbl.WSProductImportFromExcel.Find(productImportFromExcelFieldsViewModel.Id);
						wSProductImportFromExcel.Selector = false;
						productImportFromExcelFieldsViewModel.Selector = false;
						_dbTbl.Entry(wSProductImportFromExcel).State = EntityState.Modified;
						_dbTbl.SaveChanges();
					}
					list.Add(productImportFromExcelFieldsViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public string EmptyTank()
	{
		string text = "";
		try
		{
			_db.Database.ExecuteSqlCommand("delete WSProductImportFromExcel where UserId={0}", UserLogin.CurrentUser.UserId);
			return "1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public string ReturnInformation()
	{
		string text = "";
		try
		{
			string text2 = "";
			string text3 = "";
			string text4 = "";
			DbSet<WSProductImportFromExcel> wSProductImportFromExcel = _dbTbl.WSProductImportFromExcel;
			ParameterExpression val = Expression.Parameter(typeof(WSProductImportFromExcel), "c");
			foreach (WSProductImportFromExcel item in Enumerable.ToList<WSProductImportFromExcel>((IEnumerable<WSProductImportFromExcel>)Queryable.Where<WSProductImportFromExcel>((IQueryable<WSProductImportFromExcel>)wSProductImportFromExcel, Expression.Lambda<Func<WSProductImportFromExcel, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))))
			{
				if (item.InsertedPrdId.HasValue)
				{
					if (text2 != "")
					{
						text2 += ", ";
					}
					text2 += item.InsertedPrdId;
				}
				if (item.InsertedPriceIds != null)
				{
					if (text3 != "")
					{
						text3 += ", ";
					}
					if (item.InsertedPriceIds.EndsWith(","))
					{
						item.InsertedPriceIds = item.InsertedPriceIds.Substring(0, item.InsertedPriceIds.Length - 1);
					}
					text3 += item.InsertedPriceIds;
				}
				if (item.InsertedCostIds != null)
				{
					if (text4 != "")
					{
						text4 += ", ";
					}
					if (item.InsertedCostIds.EndsWith(","))
					{
						item.InsertedCostIds = item.InsertedCostIds.Substring(0, item.InsertedCostIds.Length - 1);
					}
					text4 += item.InsertedCostIds;
				}
			}
			_db.CRMspDeleteProductImportFromExcel(text2, text3, text4);
			return "1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}
}
