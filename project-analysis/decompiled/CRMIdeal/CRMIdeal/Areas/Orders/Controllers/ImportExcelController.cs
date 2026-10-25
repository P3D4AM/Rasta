using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Orders.Controllers;

public class ImportExcelController : Controller
{
	public class OrderImportFromExcelViewModel
	{
		public int OrderOprID { get; set; }

		public string OrdTitle { get; set; }

		public long OrdNumber { get; set; }

		public string OrdDate { get; set; }

		public DateTime OrdDateTime { get; set; }

		public int OrdCompanyNumber { get; set; }

		public string OrdCompanyPersonName { get; set; }

		public string OrdProjectTitle { get; set; }

		public string OrdSubject { get; set; }

		public int OrdItemCount { get; set; }

		public decimal OrdItemsAmount { get; set; }

		public decimal OrdInstallAmount { get; set; }

		public decimal OrdDiscount { get; set; }

		public decimal OrdSumAmount { get; set; }

		public decimal OrdTax { get; set; }

		public decimal OrdTaxIndex { get; set; }

		public bool OrdCalculateTax { get; set; }

		public decimal OrdTotalAmount { get; set; }

		public string OrdTotalAmountStr { get; set; }

		public bool OrdIsVerified { get; set; }

		public string OrdVerifiedRegisterDate { get; set; }

		public int OrdStatusId { get; set; }

		public bool OrdIsFixed { get; set; }

		public int OrdGuarantyId { get; set; }

		public string OrdSpecialWord { get; set; }

		public string OrdDescriptionI { get; set; }

		public string OrdDescriptionII { get; set; }

		public int OrdPrintFormatId { get; set; }

		public int OrdRLogoId { get; set; }

		public int OrdLLogoId { get; set; }

		public string OrdSigningI { get; set; }

		public string OrdSigningII { get; set; }

		public string OrdSigningIII { get; set; }

		public string OrdAccountNumberI { get; set; }

		public string OrdAccountShabaNumberI { get; set; }

		public string OrdAccountNumberII { get; set; }

		public string OrdAccountShabaNumberII { get; set; }

		public int OrdVerifierId { get; set; }

		public int OrdSettlementTypeId { get; set; }

		public decimal OrdTransportation { get; set; }

		public int OrdReferUserId { get; set; }

		public decimal OrdDiscountPercent { get; set; }

		public string OrdDiscountTitle { get; set; }

		public decimal OrdRound { get; set; }

		public string OrdNote { get; set; }

		public string OrdcmpTitle { get; set; }

		public string OrdDeliveryDate { get; set; }

		public string OrdSerial { get; set; }

		public int OrdVerifierRequestId { get; set; }

		public int OrdVerificationWorkFlowId { get; set; }

		public int OrdCurrencyUnitId { get; set; }

		public int OrdDeliveryTermId { get; set; }

		public string OrdIPrdCode { get; set; }

		public float OrdIQuantity { get; set; }

		public decimal OrdIPrice { get; set; }

		public string OrdIDescription { get; set; }

		public string OrdIQuantityDesc { get; set; }

		public decimal OrdIDiscountI { get; set; }

		public decimal OrdIDiscount { get; set; }

		public decimal OrdIDiscountPercent { get; set; }

		public int OrdIPrdUnitId { get; set; }

		public int OrdICurrencyUnitId { get; set; }

		public int OrdIOrderView { get; set; }

		public decimal OrdIFCR { get; set; }

		public decimal OrdITax { get; set; }

		public decimal OrdITaxIndex { get; set; }

		public bool OrdICalculateTax { get; set; }

		public bool OrdINotVisible { get; set; }

		public float OrdIFCRI { get; set; }

		public bool OrdINotInSum { get; set; }

		public int OrdIWHId { get; set; }

		public decimal OrdIRound { get; set; }

		public decimal OrdIRoundPlus { get; set; }

		public float OrdIPricePartRate { get; set; }

		public decimal OrdIPricePartI { get; set; }

		public decimal OrdIPricePartII { get; set; }

		public int OrdIPrdPriceGroupID { get; set; }

		public string OrdITracing { get; set; }

		public int OrdIDeliveryTermId { get; set; }

		public string OrdIDeliveryDate { get; set; }

		public decimal OrdITaxSum { get; set; }

		public decimal OrdIPriceSum { get; set; }

		public decimal OrdITotalPrice { get; set; }

		public decimal OrdIDiscountSum { get; set; }

		public decimal OrdIDiscountISum { get; set; }

		public decimal OrdIDiscountIPercent { get; set; }

		public string ImportDate { get; set; }

		public DateTime? ImportDateTime { get; set; }

		public int OrdpayTypeId { get; set; }

		public decimal OrdpayAmount { get; set; }

		public string OrdpayDocNumber { get; set; }

		public string OrdpayDocDate { get; set; }

		public DateTime? OrdpayDocDateTime { get; set; }

		public string OrdpayDescription { get; set; }

		public decimal OrdpayDocAmount { get; set; }

		public string OrdpayBankDocNumber { get; set; }
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actOrdImportExcel")]
	public ActionResult Index()
	{
		base.ViewBag.IsBuying = VersionBuyer.OrdImportExcel;
		return View();
	}

	public ActionResult _PartialSelectFields(string message = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectOrderImportFromExcelFields_Result> list = new List<WSspSelectOrderImportFromExcelFields_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)_db.WSspSelectOrderImportFromExcelFields(lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FieldList = list;
		OrderOprID();
		OrdStatus();
		OrdGuaranty();
		OrdPrintFormat();
		OrdLogo();
		OrdSettelementType();
		OrdReferUser();
		OrdCurrencyUnit();
		OrdDeliveryTerm();
		OrdPrdUnit();
		OrdWH();
		OrdPrdPriceGroup();
		OrdPayType();
		base.ViewBag.Message = message;
		List<WSspSelectOrderImportFromExcel_Result> list2 = Enumerable.ToList<WSspSelectOrderImportFromExcel_Result>((IEnumerable<WSspSelectOrderImportFromExcel_Result>)_db.WSspSelectOrderImportFromExcel());
		if (list2 != null && Enumerable.Any<WSspSelectOrderImportFromExcel_Result>((IEnumerable<WSspSelectOrderImportFromExcel_Result>)list2))
		{
			return PartialView("_PartialImportedData");
		}
		return PartialView("_PartialSelectFields");
	}

	public ActionResult GenerateExcelWithSelectedFields(CommonTreeViewItemViewModel model)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<WSspSelectOrderImportFromExcelFields_Result> list = Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)_db.WSspSelectOrderImportFromExcelFields(lCID, result)), (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result c) => c.IsActive.GetValueOrDefault() && c.Selector.GetValueOrDefault())));
			if (Enumerable.Any<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)list))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OrderImportExcelPropertiesTitle);
				int num = 0;
				foreach (WSspSelectOrderImportFromExcelFields_Result item in list)
				{
					num++;
					excelWorksheet.Cells[1, num].Value = item.FieldCaption;
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.OrderImportExcelPropertiesTitle;
				excelPackage.SaveAs(base.Response.OutputStream);
				base.Response.Buffer = true;
				base.Response.AddHeader("content-disposition", "attachment; filename=CRM-Ideal.xls");
				base.Response.ContentType = "application/ms-excel";
				base.Response.Charset = "";
				base.Response.Flush();
				base.Response.End();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[AjaxOnly]
	public string UpdateSelectorStatus(int recId, int mode)
	{
		string text = "";
		try
		{
			bool value = mode == 1;
			if (recId > 0)
			{
				_db.WSspUpdateOrderImportFromExcelFieldsSelector(recId, value);
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

	[AjaxOnly]
	public ActionResult UpdateSelectorAllStatus(int groupNum, bool mode)
	{
		string text = "";
		try
		{
			if (groupNum > 0)
			{
				_db.WSspUpdateOrderImportFromExcelFieldsSelectorAll(groupNum, mode);
				text = "1|" + Messages.msgSuccessAction;
				return RedirectToAction("_PartialSelectFields", "ImportExcel", (object)new
				{
					area = "Orders",
					message = ""
				});
			}
			text = "-1|" + Messages.ErrorNotFound;
			return RedirectToAction("_PartialSelectFields", "ImportExcel", (object)new
			{
				area = "Orders",
				message = text
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "-1|" + Messages.msgErrorRunFunction;
			return RedirectToAction("_PartialSelectFields", "ImportExcel", (object)new
			{
				area = "Orders",
				message = text
			});
		}
	}

	public void OrderOprID()
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
					Text = item.Name + " (" + item.OrderOprID + ")",
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderOpr = list;
	}

	public void OrdStatus()
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
			List<WSspSelectOrderStatus_Result> list2 = Enumerable.ToList<WSspSelectOrderStatus_Result>((IEnumerable<WSspSelectOrderStatus_Result>)_db.WSspSelectOrderStatus(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectOrderStatus_Result, SelectListItem>((IEnumerable<WSspSelectOrderStatus_Result>)list2, (Func<WSspSelectOrderStatus_Result, SelectListItem>)((WSspSelectOrderStatus_Result item) => new SelectListItem
			{
				Text = item.OrderStatus + " (" + item.OrderStatusId + ")",
				Value = item.OrderStatusId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderStatus = list;
	}

	public void OrdGuaranty()
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
			List<WSspSelectGuaranty_Result> list2 = Enumerable.ToList<WSspSelectGuaranty_Result>((IEnumerable<WSspSelectGuaranty_Result>)_db.WSspSelectGuaranty(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectGuaranty_Result, SelectListItem>((IEnumerable<WSspSelectGuaranty_Result>)list2, (Func<WSspSelectGuaranty_Result, SelectListItem>)((WSspSelectGuaranty_Result item) => new SelectListItem
			{
				Text = item.Guaranty + " (" + item.GuarantyID + ")",
				Value = item.GuarantyID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderGuaranty = list;
	}

	public void OrdPrintFormat()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<spSelectPrintFormat_Result> list2 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 2);
			list.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
			{
				Text = item.Title + " (" + item.PrintFormatID + ")",
				Value = item.PrintFormatID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderPrintFormat = list;
	}

	public void OrdLogo()
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
			List<WSspSelectLogo_Result> list2 = Enumerable.ToList<WSspSelectLogo_Result>((IEnumerable<WSspSelectLogo_Result>)_db.WSspSelectLogo(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectLogo_Result, SelectListItem>((IEnumerable<WSspSelectLogo_Result>)list2, (Func<WSspSelectLogo_Result, SelectListItem>)((WSspSelectLogo_Result item) => new SelectListItem
			{
				Text = item.LogoDescription + " (" + item.LogoID + ")",
				Value = item.LogoID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderLogo = list;
	}

	public void OrdSettelementType()
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
			List<WSspSettlementType_Result> list2 = Enumerable.ToList<WSspSettlementType_Result>((IEnumerable<WSspSettlementType_Result>)_db.WSspSettlementType(lCID, result));
			list.AddRange(Enumerable.Select<WSspSettlementType_Result, SelectListItem>((IEnumerable<WSspSettlementType_Result>)list2, (Func<WSspSettlementType_Result, SelectListItem>)((WSspSettlementType_Result item) => new SelectListItem
			{
				Text = item.Name + " (" + item.Id + ")",
				Value = item.Id.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderSettelementType = list;
	}

	public void OrdReferUser()
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName + " (" + item.LinkedUserId + ")",
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderReferUser = list;
	}

	public void OrdCurrencyUnit()
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
				Text = item.CurrencyUnit + " (" + item.CurrencyUnitID + ")",
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderCurrencyUnit = list;
	}

	public void OrdDeliveryTerm()
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
			List<WSspSelectDeliveryTerms_Result> list2 = Enumerable.ToList<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)_db.WSspSelectDeliveryTerms(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectDeliveryTerms_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTerms_Result>)list2, (Func<WSspSelectDeliveryTerms_Result, SelectListItem>)((WSspSelectDeliveryTerms_Result item) => new SelectListItem
			{
				Text = item.DeliveryTerm + " (" + item.DeliveryTermId + ")",
				Value = item.DeliveryTermId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderDeliveryTerm = list;
	}

	public void OrdPrdUnit()
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
				Text = item.Unit + " (" + item.ProductUnitID + ")",
				Value = item.ProductUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderPrdUnit = list;
	}

	public void OrdWH()
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
				Text = item.WrhsName + " (" + item.WareHouseID + ")",
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderWH = list;
	}

	public void OrdPrdPriceGroup()
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
				Text = item.ProductPriceGroupName + " (" + item.ProductPriceGroupID + ")",
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderPriceGroup = list;
	}

	public void OrdPayType()
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
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType + " (" + item.OrderPaymentTypeId + ")",
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderPayType = list;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actOrdImportExcel")]
	public ActionResult _PartialImportedData()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectOrderImportFromExcelFields_Result> list = new List<WSspSelectOrderImportFromExcelFields_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)_db.WSspSelectOrderImportFromExcelFields(lCID, result)), (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result c) => c.IsActive.GetValueOrDefault() && c.Selector.GetValueOrDefault())));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		List<WSspSelectOrderImportFromExcelFields_Result> list2 = Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)list, (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result x) => x.GroupNum.GetValueOrDefault() == 5)));
		List<WSspSelectOrderImportFromExcelFields_Result> list3 = Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)list, (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result x) => x.GroupNum.GetValueOrDefault() == 10)));
		List<WSspSelectOrderImportFromExcelFields_Result> list4 = Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)list, (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result x) => x.GroupNum.GetValueOrDefault() == 15)));
		if (list2.Count <= 0)
		{
			return RedirectToAction("_PartialSelectFields", "ImportExcel", (object)new
			{
				area = "Orders",
				message = Messages.msgErrorOrderImportExcelSelectItemBeforePayment
			});
		}
		if (list4.Count > 0 && list3.Count <= 0)
		{
			return RedirectToAction("_PartialSelectFields", "ImportExcel", (object)new
			{
				area = "Orders",
				message = Messages.msgErrorOrderImportExcelSelectItemBeforePayment
			});
		}
		return PartialView("_PartialImportedData");
	}

	public JsonResult UploadFile(string field)
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
		int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
		string text = "";
		if (!VersionBuyer.OrdImportExcel)
		{
			int result3 = 0;
			int.TryParse(SysSeting.Get().OrdImpUsedCount.ToString(), out result3);
			if (result3 >= 5)
			{
				CommonReturnResultViewModel data = new CommonReturnResultViewModel
				{
					IsDone = false,
					Message = string.Format(Messages.ImportExcelBuyModuleWithCount, "5"),
					Tag = null
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
		}
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
				_ = DateTime.Now;
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
					string text2 = "";
					string text3 = "";
					bool flag = false;
					List<WSspSelectOrderImportFromExcelFields_Result> list = new List<WSspSelectOrderImportFromExcelFields_Result>();
					list = Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)_db.WSspSelectOrderImportFromExcelFields(lCID, result)), (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result c) => c.IsActive.GetValueOrDefault() && c.Selector.GetValueOrDefault())));
					int i;
					for (i = 0; i < list.Count; i++)
					{
						WSspSelectOrderImportFromExcelFields_Result wSspSelectOrderImportFromExcelFields_Result = Enumerable.FirstOrDefault<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)list, (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result x) => x.FieldCaption == obj[0, i].ToString())));
						if (wSspSelectOrderImportFromExcelFields_Result == null || string.IsNullOrWhiteSpace(wSspSelectOrderImportFromExcelFields_Result.FieldName))
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = Messages.msgErrorOnFindColumnName + "|" + obj[0, i].ToString();
						}
						else if ("[ordDate],[ordDeliveryDate],[ImportDate],[ordpayDocDate]".Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
						{
							if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
							{
								if (text2 != "")
								{
									text2 += ",";
								}
								text2 += wSspSelectOrderImportFromExcelFields_Result.FieldName;
							}
							if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName + "Time"))
							{
								if (text2 != "")
								{
									text2 += ",";
								}
								text2 = text2 + wSspSelectOrderImportFromExcelFields_Result.FieldName + "Time";
							}
							if (!text2.ToLower().Contains("ordTime".ToLower()))
							{
								if (text2 != "")
								{
									text2 += ",";
								}
								text2 += "ordTime";
							}
						}
						else if ("[ordIDeliveryDatePersian]".Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
						{
							if (!text2.Contains("ordIDeliveryDate"))
							{
								if (text2 != "")
								{
									text2 += ",";
								}
								text2 += "ordIDeliveryDate";
							}
							if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
							{
								if (text2 != "")
								{
									text2 += ",";
								}
								text2 += wSspSelectOrderImportFromExcelFields_Result.FieldName;
							}
						}
						else if ("[ordVerifiedRegisterDatePersian]".Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
						{
							if (!text2.Contains("ordVerifiedRegisterDate"))
							{
								if (text2 != "")
								{
									text2 += ",";
								}
								text2 += "ordVerifiedRegisterDate";
							}
							if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
							{
								if (text2 != "")
								{
									text2 += ",";
								}
								text2 += wSspSelectOrderImportFromExcelFields_Result.FieldName;
							}
						}
						else if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
						{
							if (text2 != "")
							{
								text2 += ",";
							}
							text2 += wSspSelectOrderImportFromExcelFields_Result.FieldName;
						}
					}
					if (text2 != "")
					{
						text2 += ",";
					}
					text2 += " ordITaxSum";
					text2 += ", ordIPriceSum";
					text2 += ", ordITotalPrice";
					text2 += ", ordIDiscountSum";
					text2 += ", ordITax";
					bool flag2 = false;
					if (list.FindIndex((WSspSelectOrderImportFromExcelFields_Result x) => x.FieldName == "ordIDiscount") < 0)
					{
						text2 += ", ordIDiscount";
						flag2 = true;
					}
					bool flag3 = false;
					if (list.FindIndex((WSspSelectOrderImportFromExcelFields_Result x) => x.FieldName == "ordICalculateTax") < 0)
					{
						text2 += ", ordICalculateTax";
						flag3 = true;
					}
					if (num2 > 1000)
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Tag = "SysError";
						commonReturnResultViewModel.Message = string.Format(Messages.msgErrorMaxImportIs, "1000");
					}
					if (commonReturnResultViewModel.IsDone)
					{
						_db.WSspDeleteOrderImportFromExcel();
						object[] array = new object[list.Count];
						int num3 = 0;
						int num4 = 0;
						string text4 = "";
						for (int j = 1; j < num2; j++)
						{
							text3 = "";
							long ordNumber = 0L;
							if (flag)
							{
								continue;
							}
							OrderImportFromExcelViewModel orderImportFromExcelViewModel = new OrderImportFromExcelViewModel();
							for (int k = 0; k < num; k++)
							{
								string ExcelCurrCol = "";
								string text5 = "";
								array[k] = obj[j, k];
								ExcelCurrCol = ((obj[0, k] == null) ? "" : obj[0, k].ToString());
								text5 = ((array[k] == null) ? "NULL" : array[k].ToString());
								WSspSelectOrderImportFromExcelFields_Result wSspSelectOrderImportFromExcelFields_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)list, (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result x) => x.FieldCaption == ExcelCurrCol)));
								string arg = wSspSelectOrderImportFromExcelFields_Result2.FieldCaption ?? "NULL";
								string text6 = wSspSelectOrderImportFromExcelFields_Result2.FieldName ?? "NULL";
								string arg2 = wSspSelectOrderImportFromExcelFields_Result2.FieldType ?? "NULL";
								wSspSelectOrderImportFromExcelFields_Result2.FieldSize.GetValueOrDefault();
								bool? notNull = wSspSelectOrderImportFromExcelFields_Result2.NotNull;
								if (text5 == "NULL")
								{
									if ("[ordIDeliveryDatePersian],[ordDate],[ordDeliveryDate],[ImportDate],[ordpayDocDate],[ordVerifiedRegisterDatePersian]".ToLower().Contains(text6.ToLower()))
									{
										if (text3 != "")
										{
											text3 += ",";
										}
										text3 = text3 + text5 + "," + text5;
									}
									else if (notNull.GetValueOrDefault())
									{
										if (text != "")
										{
											text += ",";
										}
										text += string.Format(Messages.msgErrorIsNotEntered, arg);
										text5 = null;
									}
									else
									{
										if (text3 != "")
										{
											text3 += ",";
										}
										text3 += text5;
									}
									continue;
								}
								try
								{
									if (wSspSelectOrderImportFromExcelFields_Result2 != null)
									{
										if (text6.ToLower() == "ordNumber".ToLower())
										{
											long result4 = 0L;
											long.TryParse(text5.ToString(), out result4);
											orderImportFromExcelViewModel.OrdNumber = result4;
											ordNumber = result4;
										}
										else if (text6.ToLower() == "OrdIFCR".ToLower())
										{
											orderImportFromExcelViewModel.OrdIFCR = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIFCRI".ToLower())
										{
											orderImportFromExcelViewModel.OrdIFCRI = float.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIDiscount".ToLower())
										{
											orderImportFromExcelViewModel.OrdIDiscount = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIDiscountI".ToLower())
										{
											orderImportFromExcelViewModel.OrdIDiscountI = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIPrice".ToLower())
										{
											orderImportFromExcelViewModel.OrdIPrice = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIRound".ToLower())
										{
											orderImportFromExcelViewModel.OrdIRound = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIRoundPlus".ToLower())
										{
											orderImportFromExcelViewModel.OrdIRoundPlus = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdITax".ToLower())
										{
											orderImportFromExcelViewModel.OrdITax = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIQuantity".ToLower())
										{
											orderImportFromExcelViewModel.OrdIQuantity = float.Parse(text5);
										}
										else if (text6.ToLower() == "OrdITaxIndex".ToLower())
										{
											orderImportFromExcelViewModel.OrdITaxIndex = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdITaxSum".ToLower())
										{
											orderImportFromExcelViewModel.OrdITaxSum = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIDiscountPercent".ToLower())
										{
											orderImportFromExcelViewModel.OrdIDiscountPercent = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdIPriceSum".ToLower())
										{
											orderImportFromExcelViewModel.OrdIPriceSum = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "OrdITotalPrice".ToLower())
										{
											orderImportFromExcelViewModel.OrdITotalPrice = decimal.Parse(text5);
										}
										else if (text6.ToLower() == "ordIDiscountSum".ToLower())
										{
											orderImportFromExcelViewModel.OrdIDiscountSum = decimal.Parse(text5);
										}
									}
									else
									{
										commonReturnResultViewModel.IsDone = false;
										commonReturnResultViewModel.Message = Messages.msgErrorOnFindColumnName;
									}
								}
								catch (Exception)
								{
									commonReturnResultViewModel.IsDone = false;
									commonReturnResultViewModel.Message = Messages.msgErrorValueType;
								}
								if (list[k].NotNull.GetValueOrDefault())
								{
									if ("int,bigint,smallint".Contains(list[k].FieldType.ToLower()))
									{
										long result5 = 0L;
										long.TryParse(text5, out result5);
										if (result5 <= 0)
										{
											if (text != "")
											{
												text += ",";
											}
											text = text + Labels.OrderImportExcelValue + " " + list[k].FieldCaption + " " + Messages.msgErrorNumericAndMoreZero;
											text5 = null;
										}
										switch (list[k].FieldName)
										{
										case "OrderOprID":
										{
											int OrderOprID = 0;
											int.TryParse(text5, out OrderOprID);
											if (OrderOprID <= 0)
											{
												break;
											}
											List<WSspSelectOrderOpr_Result> list4 = Order.SelectOrderOpr(0);
											if (list4 != null && Enumerable.FirstOrDefault<WSspSelectOrderOpr_Result>((IEnumerable<WSspSelectOrderOpr_Result>)list4, (Func<WSspSelectOrderOpr_Result, bool>)((WSspSelectOrderOpr_Result l) => l.OrderOprID == OrderOprID)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text += Messages.msgErrorOrderOprIsWrong;
											}
											break;
										}
										case "ordStatusId":
										{
											int ordStatusId = 0;
											int.TryParse(text5, out ordStatusId);
											if (ordStatusId > 0 && Enumerable.FirstOrDefault<WSspSelectOrderStatus_Result>((IEnumerable<WSspSelectOrderStatus_Result>)_db.WSspSelectOrderStatus(lCID, result), (Func<WSspSelectOrderStatus_Result, bool>)((WSspSelectOrderStatus_Result l) => l.OrderStatusId == ordStatusId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrderStatusIsWrong;
											}
											break;
										}
										case "ordGuarantyId":
										{
											int ordGuarantyId = 0;
											int.TryParse(text5, out ordGuarantyId);
											if (ordGuarantyId > 0 && Enumerable.FirstOrDefault<WSspSelectGuaranty_Result>((IEnumerable<WSspSelectGuaranty_Result>)_db.WSspSelectGuaranty(lCID, result), (Func<WSspSelectGuaranty_Result, bool>)((WSspSelectGuaranty_Result l) => l.GuarantyID == ordGuarantyId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrderGarantyIsWrong;
											}
											break;
										}
										case "ordPrintFormatId":
										{
											int ordPrintFormatId = 0;
											int.TryParse(text5, out ordPrintFormatId);
											if (ordPrintFormatId <= 0)
											{
												break;
											}
											spSelectPrintFormat_Result spSelectPrintFormat_Result = new spSelectPrintFormat_Result();
											List<spSelectPrintFormat_Result> list3 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 2);
											if (list3 != null)
											{
												spSelectPrintFormat_Result = Enumerable.FirstOrDefault<spSelectPrintFormat_Result>((IEnumerable<spSelectPrintFormat_Result>)list3, (Func<spSelectPrintFormat_Result, bool>)((spSelectPrintFormat_Result l) => l.PrintFormatID == ordPrintFormatId));
											}
											if (spSelectPrintFormat_Result != null && spSelectPrintFormat_Result.PrintFormatID == 0)
											{
												spSelectPrintFormat_Result = null;
											}
											if (spSelectPrintFormat_Result == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrderPrintFormatIsWrong;
											}
											break;
										}
										case "ordRLogoId":
										{
											int ordRLogoId = 0;
											int.TryParse(text5, out ordRLogoId);
											if (ordRLogoId > 0 && Enumerable.FirstOrDefault<WSspSelectLogo_Result>((IEnumerable<WSspSelectLogo_Result>)_db.WSspSelectLogo(lCID, result), (Func<WSspSelectLogo_Result, bool>)((WSspSelectLogo_Result l) => l.LogoID == ordRLogoId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdRLogoIdIsWrong;
											}
											break;
										}
										case "ordLLogoId":
										{
											int ordLLogoId = 0;
											int.TryParse(text5, out ordLLogoId);
											if (ordLLogoId > 0 && Enumerable.FirstOrDefault<WSspSelectLogo_Result>((IEnumerable<WSspSelectLogo_Result>)_db.WSspSelectLogo(lCID, result), (Func<WSspSelectLogo_Result, bool>)((WSspSelectLogo_Result l) => l.LogoID == ordLLogoId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdLLogoIdIsWrong;
											}
											break;
										}
										case "ordSettlementTypeId":
										{
											int ordSettlementTypeId = 0;
											int.TryParse(text5, out ordSettlementTypeId);
											if (ordSettlementTypeId > 0 && Enumerable.FirstOrDefault<WSspSettlementType_Result>((IEnumerable<WSspSettlementType_Result>)_db.WSspSettlementType(lCID, result), (Func<WSspSettlementType_Result, bool>)((WSspSettlementType_Result l) => l.Id == ordSettlementTypeId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdSettlementTypeIdIsWrong;
											}
											break;
										}
										case "ordReferUserId":
										{
											int result6 = 0;
											int.TryParse(text5, out result6);
											if (result6 > 0 && CRMIdeal.Classes.Helper.User.SelectUsersById(result6) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdReferUserIdIsWrong;
											}
											break;
										}
										case "ordCurrencyUnitId":
										{
											int ordCurrencyUnitId = 0;
											int.TryParse(text5, out ordCurrencyUnitId);
											if (ordCurrencyUnitId > 0 && Enumerable.FirstOrDefault<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result), (Func<WSspSelectCurrencyUnits_Result, bool>)((WSspSelectCurrencyUnits_Result l) => l.CurrencyUnitID == ordCurrencyUnitId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdCurrencyUnitIdIsWrong;
											}
											break;
										}
										case "ordDeliveryTermId":
										{
											int ordDeliveryTermId = 0;
											int.TryParse(text5, out ordDeliveryTermId);
											if (ordDeliveryTermId > 0 && Enumerable.FirstOrDefault<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)_db.WSspSelectDeliveryTerms(lCID, result), (Func<WSspSelectDeliveryTerms_Result, bool>)((WSspSelectDeliveryTerms_Result l) => l.DeliveryTermId == ordDeliveryTermId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdDeliveryTermIdIsWrong;
											}
											break;
										}
										case "ordIPrdUnitId":
										{
											int ordIPrdUnitId = 0;
											int.TryParse(text5, out ordIPrdUnitId);
											if (ordIPrdUnitId > 0 && Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result), (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result l) => l.ProductUnitID == ordIPrdUnitId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdIPrdUnitIdIsWrong;
											}
											break;
										}
										case "ordIWHId":
										{
											int ordIWHId = 0;
											int.TryParse(text5, out ordIWHId);
											if (ordIWHId <= 0)
											{
												break;
											}
											WSspSelectWareHouse_Result wSspSelectWareHouse_Result = new WSspSelectWareHouse_Result();
											List<WSspSelectWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse(-1, -1);
											if (list2 != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list2))
											{
												wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result l) => l.WareHouseID == ordIWHId));
											}
											if (wSspSelectWareHouse_Result == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdIWHIdIsWrong;
											}
											break;
										}
										case "ordIPrdPriceGroupID":
										{
											int ordIPrdPriceGroupID = 0;
											int.TryParse(text5, out ordIPrdPriceGroupID);
											if (ordIPrdPriceGroupID > 0 && Enumerable.FirstOrDefault<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result), (Func<WSspSelectProductPriceGroup_Result, bool>)((WSspSelectProductPriceGroup_Result l) => l.ProductPriceGroupID == ordIPrdPriceGroupID)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdIPrdPriceGroupIDIsWrong;
											}
											break;
										}
										case "ordIDeliveryTermId":
										{
											int ordIDeliveryTermId = 0;
											int.TryParse(text5, out ordIDeliveryTermId);
											if (ordIDeliveryTermId > 0 && Enumerable.FirstOrDefault<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)_db.WSspSelectDeliveryTerms(lCID, result), (Func<WSspSelectDeliveryTerms_Result, bool>)((WSspSelectDeliveryTerms_Result l) => l.DeliveryTermId == ordIDeliveryTermId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdIDeliveryTermIdIsWrong;
											}
											break;
										}
										case "ordpayTypeId":
										{
											int ordpayTypeId = 0;
											int.TryParse(text5, out ordpayTypeId);
											if (ordpayTypeId > 0 && Enumerable.FirstOrDefault<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value), (Func<WSspSelectActiveOrderPaymentTypes_Result, bool>)((WSspSelectActiveOrderPaymentTypes_Result l) => l.OrderPaymentTypeId == ordpayTypeId)) == null)
											{
												if (text != "")
												{
													text += ",";
												}
												text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdpayTypeIdIsWrong;
											}
											break;
										}
										}
									}
									else if ("decimal,float,numeric".Contains(list[k].FieldType.ToLower()))
									{
										decimal result7 = default(decimal);
										decimal.TryParse(text5, out result7);
										if (result7 <= 0m)
										{
											if (text != "")
											{
												text += ",";
											}
											text = text + Labels.OrderImportExcelValue + " " + list[k].FieldCaption + " " + Messages.msgErrorNumericAndMoreZero;
											text5 = null;
										}
									}
									else if ("char,varchar,nchar,nvarchar,ntext".Contains(list[k].FieldType.ToLower()))
									{
										if (string.IsNullOrWhiteSpace(text5))
										{
											if (text != "")
											{
												text += ",";
											}
											text = text + Labels.OrderImportExcelValue + " " + list[k].FieldCaption + " " + Messages.MsgErrorEnterRequireInformation;
											text5 = null;
										}
										else if (text5.Length > list[k].FieldSize)
										{
											if (text != "")
											{
												text += ",";
											}
											text += string.Format(Messages.msgErrorOrdLength, text5, list[k].FieldSize.ToString());
											text5 = null;
										}
									}
									else if ("datetime".Contains(list[k].FieldType))
									{
										try
										{
											DateTime.Parse(text5);
										}
										catch (Exception)
										{
											if (text != "")
											{
												text += ",";
											}
											text = text + Labels.OrderImportExcelValue + " " + list[k].FieldCaption + " " + Messages.WrongDateTime;
											text5 = null;
										}
									}
									else
									{
										"bit".Contains(list[k].FieldType);
									}
								}
								if (text3 != "")
								{
									text3 += ",";
								}
								if ("int,bigint,smallint".Contains(list[k].FieldType.ToLower()))
								{
									try
									{
										long.Parse(text5.ToString());
										text3 += (string.IsNullOrWhiteSpace(text5.ToString()) ? "NULL" : text5.ToString());
									}
									catch (Exception)
									{
										commonReturnResultViewModel.IsDone = false;
										commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, arg, j.ToString(), arg2);
										text3 += "NULL";
									}
								}
								else if ("decimal,float,numeric".Contains(list[k].FieldType.ToLower()))
								{
									try
									{
										double.Parse(text5.ToString());
										text3 += (string.IsNullOrWhiteSpace(text5.ToString()) ? "NULL" : text5.ToString());
									}
									catch (Exception)
									{
										commonReturnResultViewModel.IsDone = false;
										commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, arg, j.ToString(), arg2);
										text3 += "NULL";
									}
								}
								else if ("char,varchar,nchar,nvarchar,ntext".Contains(list[k].FieldType.ToLower()))
								{
									if ("[ordDate],[ordDeliveryDate],[ImportDate],[ordpayDocDate]".Contains(text6))
									{
										try
										{
											DateTime ordDateTime = default(DateTime);
											string text7 = "";
											try
											{
												if (!string.IsNullOrEmpty(text5))
												{
													text7 = PersianDate.GetFormatetdDate(text5.Replace("/", ""));
													switch (lCID)
													{
													case 1065:
														ordDateTime = DateTime.Parse(text7 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
														text5 = ordDateTime.ToString("yyyyMMdd");
														break;
													case 1025:
														ordDateTime = DateTime.Parse(text7 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
														text5 = ordDateTime.ToString("yyyyMMdd", new PersianCulture());
														break;
													default:
														ordDateTime = DateTime.Parse(text7 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
														text5 = ordDateTime.ToString("yyyyMMdd", new PersianCulture());
														break;
													}
												}
											}
											catch (Exception e)
											{
												ErrorSignal.FromCurrentContext().Raise(e);
												base.ViewBag.Error = Messages.WrongDateTime;
											}
											if (text5 != null)
											{
												text5 = text5.Replace("/", "").Replace("-", "").Replace("_", "")
													.Replace(".", "")
													.Replace(",", "")
													.Replace("\\", "");
											}
											orderImportFromExcelViewModel.OrdDate = text5;
											orderImportFromExcelViewModel.OrdDateTime = ordDateTime;
											text3 = text3 + "'" + text5 + "'";
											if (text3 != "")
											{
												text3 += ",";
											}
											text3 = text3 + "'" + ordDateTime.ToString(new CultureInfo("en-US")) + "'";
											if ("[ordDate]".ToLower().Contains(text6.ToLower()))
											{
												if (text3 != "")
												{
													text3 += ",";
												}
												text3 = text3 + "'" + ordDateTime.ToString("hh:mm:ss", new PersianCulture()) + "'";
											}
										}
										catch (Exception)
										{
											text3 += "NULL";
											if (text3 != "")
											{
												text3 += ",";
											}
											text3 += "NULL";
											if ("[ordDate]".ToLower().Contains(text6.ToLower()))
											{
												if (text3 != "")
												{
													text3 += ",";
												}
												text3 += "'NULL'";
											}
											commonReturnResultViewModel.IsDone = false;
											commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, arg, j.ToString(), arg2);
											text3 += "NULL";
										}
									}
									else if ("[ordIDeliveryDatePersian]".Contains(text6))
									{
										try
										{
											DateTime dateTime = default(DateTime);
											string text8 = "";
											try
											{
												if (!string.IsNullOrEmpty(text5))
												{
													text8 = PersianDate.GetFormatetdDate(text5.Replace("/", ""));
													switch (lCID)
													{
													case 1065:
														dateTime = DateTime.Parse(text8 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
														text5 = dateTime.ToString("yyyyMMdd");
														break;
													case 1025:
														dateTime = DateTime.Parse(text8 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
														text5 = dateTime.ToString("yyyyMMdd", new PersianCulture());
														break;
													default:
														dateTime = DateTime.Parse(text8 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
														text5 = dateTime.ToString("yyyyMMdd", new PersianCulture());
														break;
													}
												}
											}
											catch (Exception e2)
											{
												ErrorSignal.FromCurrentContext().Raise(e2);
												base.ViewBag.Error = Messages.WrongDateTime;
											}
											if (text5 != null)
											{
												text5 = text5.Replace("/", "").Replace("-", "").Replace("_", "")
													.Replace(".", "")
													.Replace(",", "")
													.Replace("\\", "");
											}
											text3 = text3 + "'" + dateTime.ToString(new CultureInfo("en-US")) + "'";
											if (text3 != "")
											{
												text3 += ",";
											}
											text3 = text3 + "'" + text5 + "'";
										}
										catch (Exception)
										{
											text3 += "NULL";
											if (text3 != "")
											{
												text3 += ",";
											}
											text3 += "NULL";
											commonReturnResultViewModel.IsDone = false;
											commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, arg, j.ToString(), arg2);
											text3 += "NULL";
										}
									}
									else if ("[ordVerifiedRegisterDatePersian]".Contains(text6))
									{
										try
										{
											DateTime dateTime2 = default(DateTime);
											string text9 = "";
											try
											{
												if (!string.IsNullOrEmpty(text5))
												{
													text9 = PersianDate.GetFormatetdDate(text5.Replace("/", ""));
													switch (lCID)
													{
													case 1065:
														dateTime2 = DateTime.Parse(text9 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
														text5 = dateTime2.ToString("yyyyMMdd");
														break;
													case 1025:
														dateTime2 = DateTime.Parse(text9 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
														text5 = dateTime2.ToString("yyyyMMdd", new PersianCulture());
														break;
													default:
														dateTime2 = DateTime.Parse(text9 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
														text5 = dateTime2.ToString("yyyyMMdd", new PersianCulture());
														break;
													}
												}
											}
											catch (Exception e3)
											{
												ErrorSignal.FromCurrentContext().Raise(e3);
												base.ViewBag.Error = Messages.WrongDateTime;
											}
											if (text5 != null)
											{
												text5 = text5.Replace("/", "").Replace("-", "").Replace("_", "")
													.Replace(".", "")
													.Replace(",", "")
													.Replace("\\", "");
											}
											text3 = text3 + "'" + dateTime2.ToString(new CultureInfo("en-US")) + "'";
											if (text3 != "")
											{
												text3 += ",";
											}
											text3 = text3 + "'" + text5 + "'";
										}
										catch (Exception)
										{
											text3 += "NULL";
											if (text3 != "")
											{
												text3 += ",";
											}
											text3 += "NULL";
											commonReturnResultViewModel.IsDone = false;
											commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, wSspSelectOrderImportFromExcelFields_Result2.FieldCaption, j.ToString(), arg2);
											text3 += "NULL";
										}
									}
									else
									{
										text3 = text3 + "'" + (string.IsNullOrWhiteSpace(text5.ToString()) ? "NULL" : text5.ToString()) + "'";
									}
								}
								else if ("datetime,date".Contains(list[k].FieldType.ToLower()))
								{
									try
									{
										DateTime.Parse(text5.ToString());
										text3 = text3 + "'" + (string.IsNullOrWhiteSpace(text5.ToString()) ? "NULL" : text5.ToString()) + "'";
									}
									catch (Exception)
									{
										text3 += "NULL";
										commonReturnResultViewModel.IsDone = false;
										commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, wSspSelectOrderImportFromExcelFields_Result2.FieldCaption, j.ToString(), arg2);
										text3 += "NULL";
									}
								}
								else if ("bit".Contains(list[k].FieldType))
								{
									int result8 = 0;
									int.TryParse(text5.ToString(), out result8);
									text3 = ((result8 != 1) ? (text3 + "0") : (text3 + "1"));
								}
							}
							double result9 = 1.0;
							double result10 = 1.0;
							orderImportFromExcelViewModel.OrdNumber = ordNumber;
							_ = orderImportFromExcelViewModel.OrdIFCR;
							if (orderImportFromExcelViewModel.OrdIFCR != 0m)
							{
								double.TryParse(orderImportFromExcelViewModel.OrdIFCR.ToString(), out result9);
							}
							_ = orderImportFromExcelViewModel.OrdIFCRI;
							if (orderImportFromExcelViewModel.OrdIFCRI != 0f)
							{
								double.TryParse(orderImportFromExcelViewModel.OrdIFCRI.ToString(), out result10);
							}
							decimal.TryParse(orderImportFromExcelViewModel.OrdIDiscount.ToString(), out var result11);
							decimal.TryParse(orderImportFromExcelViewModel.OrdIDiscountI.ToString(), out var _);
							decimal.TryParse(orderImportFromExcelViewModel.OrdIPrice.ToString(), out var result13);
							decimal.TryParse(orderImportFromExcelViewModel.OrdIRound.ToString(), out var result14);
							decimal.TryParse(orderImportFromExcelViewModel.OrdIRoundPlus.ToString(), out var result15);
							decimal.TryParse(orderImportFromExcelViewModel.OrdITax.ToString(), out var result16);
							decimal num5 = (decimal)((double)orderImportFromExcelViewModel.OrdIQuantity * result9 * result10);
							decimal num6 = result13 - result11 - result14 + result15;
							decimal.TryParse(orderImportFromExcelViewModel.OrdITaxIndex.ToString(), out var result17);
							if (result17 != 0m)
							{
								orderImportFromExcelViewModel.OrdITaxSum = num5 * num6 * result17 / 100m;
								result16 = num6 * result17 / 100m;
							}
							else
							{
								orderImportFromExcelViewModel.OrdITaxSum = num5 * result16;
							}
							decimal.TryParse(orderImportFromExcelViewModel.OrdIDiscountPercent.ToString(), out var result18);
							if (result18 != 0m)
							{
								orderImportFromExcelViewModel.OrdIDiscountSum = result13 * num5 * result18 / 100m;
								result11 = result13 * result18 / 100m;
							}
							else
							{
								orderImportFromExcelViewModel.OrdIDiscountSum = num5 * result11;
							}
							if (orderImportFromExcelViewModel.OrdIDiscountSum != 0m)
							{
								orderImportFromExcelViewModel.OrdIDiscount = result11;
							}
							if (orderImportFromExcelViewModel.OrdITaxSum != 0m)
							{
								orderImportFromExcelViewModel.OrdITax = result16;
								orderImportFromExcelViewModel.OrdICalculateTax = true;
								flag3 = true;
							}
							num6 = result13 - result11 - result14 + result15;
							orderImportFromExcelViewModel.OrdIPriceSum = num5 * num6;
							orderImportFromExcelViewModel.OrdITotalPrice = orderImportFromExcelViewModel.OrdIPriceSum + orderImportFromExcelViewModel.OrdITaxSum;
							try
							{
								if (text3 != "")
								{
									text3 += ",";
								}
								text3 += (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdITaxSum.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdITaxSum.ToString());
								text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdIPriceSum.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdIPriceSum.ToString());
								text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdITotalPrice.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdITotalPrice.ToString());
								text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdIDiscountSum.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdIDiscountSum.ToString());
								text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdITax.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdITax.ToString());
								if (flag2)
								{
									text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdIDiscount.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdIDiscount.ToString());
								}
								if (flag3)
								{
									text3 = text3 + "," + ((!orderImportFromExcelViewModel.OrdICalculateTax) ? "0" : "1");
								}
							}
							catch (Exception)
							{
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = Messages.msgErrorOnFindColumnName;
							}
							num3++;
							if (num4 >= 500)
							{
								try
								{
									_db.Database.ExecuteSqlCommand("INSERT INTO [WSOrderImportFromExcel] (" + text2 + ") VALUES" + text4);
								}
								catch (Exception e4)
								{
									commonReturnResultViewModel.IsDone = false;
									if (commonReturnResultViewModel.Message != "")
									{
										commonReturnResultViewModel.Message += ", ";
									}
									commonReturnResultViewModel.Message += j;
									ErrorSignal.FromCurrentContext().Raise(e4);
								}
								num4 = 0;
								text4 = "";
							}
							else
							{
								text4 = text4 + ((text4 != "") ? "," : "") + "(" + text3 + ")";
								num4++;
							}
						}
						if (!string.IsNullOrWhiteSpace(text4))
						{
							try
							{
								_db.Database.ExecuteSqlCommand("INSERT INTO [WSOrderImportFromExcel] (" + text2 + ") VALUES" + text4);
							}
							catch (Exception e5)
							{
								commonReturnResultViewModel.IsDone = false;
								if (commonReturnResultViewModel.Message != "")
								{
									commonReturnResultViewModel.Message += ", ";
								}
								commonReturnResultViewModel.Message += num2 / 1000;
								ErrorSignal.FromCurrentContext().Raise(e5);
							}
							num4 = 0;
							text4 = "";
						}
						commonReturnResultViewModel.Tag = obj;
					}
				}
				if (commonReturnResultViewModel.Message != "")
				{
					if (commonReturnResultViewModel.Tag.ToString().Contains("SysError"))
					{
						commonReturnResultViewModel.Message = commonReturnResultViewModel.Message + ". " + text;
					}
					else
					{
						commonReturnResultViewModel.Message = Messages.msgErrorLoadingInfoEnteredInRow + " " + commonReturnResultViewModel.Message + ". " + text;
					}
				}
			}
			catch (IndexOutOfRangeException e6)
			{
				ErrorSignal.FromCurrentContext().Raise(e6);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorOrderImportExcelNotEqualColumnsByExcel;
			}
			catch (Exception ex10)
			{
				ErrorSignal.FromCurrentContext().Raise(ex10);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorLoadingInfoEntered + "\n" + ex10.Message;
			}
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public void UploadFileData(object[,] obj, int noOfRow, int noOfCol)
	{
		try
		{
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			new CRMTabelEntities();
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string text = "";
			CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel
			{
				IsDone = true,
				Message = "",
				Tag = null
			};
			string text2 = "";
			string text3 = "";
			bool flag = false;
			List<WSspSelectOrderImportFromExcelFields_Result> list = new List<WSspSelectOrderImportFromExcelFields_Result>();
			list = Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)Enumerable.ToList<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)cRMSpEntities.WSspSelectOrderImportFromExcelFields(lCID, result2)), (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result c) => c.IsActive.GetValueOrDefault() && c.Selector.GetValueOrDefault())));
			int i;
			for (i = 0; i < list.Count; i++)
			{
				WSspSelectOrderImportFromExcelFields_Result wSspSelectOrderImportFromExcelFields_Result = Enumerable.FirstOrDefault<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)list, (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result x) => x.FieldCaption == obj[0, i].ToString())));
				if (wSspSelectOrderImportFromExcelFields_Result == null || string.IsNullOrWhiteSpace(wSspSelectOrderImportFromExcelFields_Result.FieldName))
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.msgErrorOnFindColumnName + "|" + obj[0, i].ToString();
				}
				else if ("[ordDate],[ordDeliveryDate],[ImportDate],[ordpayDocDate]".Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
				{
					if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
					{
						if (text2 != "")
						{
							text2 += ",";
						}
						text2 += wSspSelectOrderImportFromExcelFields_Result.FieldName;
					}
					if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName + "Time"))
					{
						if (text2 != "")
						{
							text2 += ",";
						}
						text2 = text2 + wSspSelectOrderImportFromExcelFields_Result.FieldName + "Time";
					}
					if (!text2.ToLower().Contains("ordTime".ToLower()))
					{
						if (text2 != "")
						{
							text2 += ",";
						}
						text2 += "ordTime";
					}
				}
				else if ("[ordIDeliveryDatePersian]".Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
				{
					if (!text2.Contains("ordIDeliveryDate"))
					{
						if (text2 != "")
						{
							text2 += ",";
						}
						text2 += "ordIDeliveryDate";
					}
					if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
					{
						if (text2 != "")
						{
							text2 += ",";
						}
						text2 += wSspSelectOrderImportFromExcelFields_Result.FieldName;
					}
				}
				else if ("[ordVerifiedRegisterDatePersian]".Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
				{
					if (!text2.Contains("ordVerifiedRegisterDate"))
					{
						if (text2 != "")
						{
							text2 += ",";
						}
						text2 += "ordVerifiedRegisterDate";
					}
					if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
					{
						if (text2 != "")
						{
							text2 += ",";
						}
						text2 += wSspSelectOrderImportFromExcelFields_Result.FieldName;
					}
				}
				else if (!text2.Contains(wSspSelectOrderImportFromExcelFields_Result.FieldName))
				{
					if (text2 != "")
					{
						text2 += ",";
					}
					text2 += wSspSelectOrderImportFromExcelFields_Result.FieldName;
				}
			}
			if (text2 != "")
			{
				text2 += ",";
			}
			text2 += " ordITaxSum";
			text2 += ", ordIPriceSum";
			text2 += ", ordITotalPrice";
			text2 += ", ordIDiscountSum";
			text2 += ", ordITax";
			bool flag2 = false;
			if (list.FindIndex((WSspSelectOrderImportFromExcelFields_Result x) => x.FieldName == "ordIDiscount") < 0)
			{
				text2 += ", ordIDiscount";
				flag2 = true;
			}
			bool flag3 = false;
			if (list.FindIndex((WSspSelectOrderImportFromExcelFields_Result x) => x.FieldName == "ordICalculateTax") < 0)
			{
				text2 += ", ordICalculateTax";
				flag3 = true;
			}
			if (noOfRow > 1000)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Tag = "SysError";
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorMaxImportIs, "1000");
			}
			if (!commonReturnResultViewModel.IsDone)
			{
				return;
			}
			cRMSpEntities.WSspDeleteOrderImportFromExcel();
			object[] array = new object[list.Count];
			int num = 0;
			int num2 = 0;
			string text4 = "";
			for (int j = 1; j < noOfRow; j++)
			{
				text3 = "";
				long ordNumber = 0L;
				if (flag)
				{
					continue;
				}
				OrderImportFromExcelViewModel orderImportFromExcelViewModel = new OrderImportFromExcelViewModel();
				for (int k = 0; k < noOfCol; k++)
				{
					string ExcelCurrCol = "";
					string text5 = "";
					array[k] = obj[j, k];
					ExcelCurrCol = ((obj[0, k] == null) ? "" : obj[0, k].ToString());
					text5 = ((array[k] == null) ? "NULL" : array[k].ToString());
					WSspSelectOrderImportFromExcelFields_Result wSspSelectOrderImportFromExcelFields_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderImportFromExcelFields_Result>(Enumerable.Where<WSspSelectOrderImportFromExcelFields_Result>((IEnumerable<WSspSelectOrderImportFromExcelFields_Result>)list, (Func<WSspSelectOrderImportFromExcelFields_Result, bool>)((WSspSelectOrderImportFromExcelFields_Result x) => x.FieldCaption == ExcelCurrCol)));
					string arg = wSspSelectOrderImportFromExcelFields_Result2.FieldCaption ?? "NULL";
					string text6 = wSspSelectOrderImportFromExcelFields_Result2.FieldName ?? "NULL";
					string arg2 = wSspSelectOrderImportFromExcelFields_Result2.FieldType ?? "NULL";
					wSspSelectOrderImportFromExcelFields_Result2.FieldSize.GetValueOrDefault();
					bool? notNull = wSspSelectOrderImportFromExcelFields_Result2.NotNull;
					if (text5 == "NULL")
					{
						if ("[ordIDeliveryDatePersian],[ordDate],[ordDeliveryDate],[ImportDate],[ordpayDocDate],[ordVerifiedRegisterDatePersian]".ToLower().Contains(text6.ToLower()))
						{
							if (text3 != "")
							{
								text3 += ",";
							}
							text3 = text3 + text5 + "," + text5;
						}
						else if (notNull.GetValueOrDefault())
						{
							if (text != "")
							{
								text += ",";
							}
							text += string.Format(Messages.msgErrorIsNotEntered, arg);
							text5 = null;
						}
						else
						{
							if (text3 != "")
							{
								text3 += ",";
							}
							text3 += text5;
						}
						continue;
					}
					try
					{
						if (wSspSelectOrderImportFromExcelFields_Result2 != null)
						{
							if (text6.ToLower() == "ordNumber".ToLower())
							{
								long result3 = 0L;
								long.TryParse(text5.ToString(), out result3);
								orderImportFromExcelViewModel.OrdNumber = result3;
								ordNumber = result3;
							}
							else if (text6.ToLower() == "OrdIFCR".ToLower())
							{
								orderImportFromExcelViewModel.OrdIFCR = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIFCRI".ToLower())
							{
								orderImportFromExcelViewModel.OrdIFCRI = float.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIDiscount".ToLower())
							{
								orderImportFromExcelViewModel.OrdIDiscount = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIDiscountI".ToLower())
							{
								orderImportFromExcelViewModel.OrdIDiscountI = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIPrice".ToLower())
							{
								orderImportFromExcelViewModel.OrdIPrice = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIRound".ToLower())
							{
								orderImportFromExcelViewModel.OrdIRound = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIRoundPlus".ToLower())
							{
								orderImportFromExcelViewModel.OrdIRoundPlus = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdITax".ToLower())
							{
								orderImportFromExcelViewModel.OrdITax = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIQuantity".ToLower())
							{
								orderImportFromExcelViewModel.OrdIQuantity = float.Parse(text5);
							}
							else if (text6.ToLower() == "OrdITaxIndex".ToLower())
							{
								orderImportFromExcelViewModel.OrdITaxIndex = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdITaxSum".ToLower())
							{
								orderImportFromExcelViewModel.OrdITaxSum = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIDiscountPercent".ToLower())
							{
								orderImportFromExcelViewModel.OrdIDiscountPercent = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdIPriceSum".ToLower())
							{
								orderImportFromExcelViewModel.OrdIPriceSum = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "OrdITotalPrice".ToLower())
							{
								orderImportFromExcelViewModel.OrdITotalPrice = decimal.Parse(text5);
							}
							else if (text6.ToLower() == "ordIDiscountSum".ToLower())
							{
								orderImportFromExcelViewModel.OrdIDiscountSum = decimal.Parse(text5);
							}
						}
						else
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = Messages.msgErrorOnFindColumnName;
						}
					}
					catch (Exception)
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorValueType;
					}
					if (list[k].NotNull.GetValueOrDefault())
					{
						if ("int,bigint,smallint".Contains(list[k].FieldType.ToLower()))
						{
							long result4 = 0L;
							long.TryParse(text5, out result4);
							if (result4 <= 0)
							{
								if (text != "")
								{
									text += ",";
								}
								text = text + Labels.OrderImportExcelValue + " " + list[k].FieldCaption + " " + Messages.msgErrorNumericAndMoreZero;
								text5 = null;
							}
							switch (list[k].FieldName)
							{
							case "OrderOprID":
							{
								int OrderOprID = 0;
								int.TryParse(text5, out OrderOprID);
								if (OrderOprID <= 0)
								{
									break;
								}
								List<WSspSelectOrderOpr_Result> list4 = Order.SelectOrderOpr(0);
								if (list4 != null && Enumerable.FirstOrDefault<WSspSelectOrderOpr_Result>((IEnumerable<WSspSelectOrderOpr_Result>)list4, (Func<WSspSelectOrderOpr_Result, bool>)((WSspSelectOrderOpr_Result l) => l.OrderOprID == OrderOprID)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text += Messages.msgErrorOrderOprIsWrong;
								}
								break;
							}
							case "ordStatusId":
							{
								int ordStatusId = 0;
								int.TryParse(text5, out ordStatusId);
								if (ordStatusId > 0 && Enumerable.FirstOrDefault<WSspSelectOrderStatus_Result>((IEnumerable<WSspSelectOrderStatus_Result>)cRMSpEntities.WSspSelectOrderStatus(lCID, result2), (Func<WSspSelectOrderStatus_Result, bool>)((WSspSelectOrderStatus_Result l) => l.OrderStatusId == ordStatusId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrderStatusIsWrong;
								}
								break;
							}
							case "ordGuarantyId":
							{
								int ordGuarantyId = 0;
								int.TryParse(text5, out ordGuarantyId);
								if (ordGuarantyId > 0 && Enumerable.FirstOrDefault<WSspSelectGuaranty_Result>((IEnumerable<WSspSelectGuaranty_Result>)cRMSpEntities.WSspSelectGuaranty(lCID, result2), (Func<WSspSelectGuaranty_Result, bool>)((WSspSelectGuaranty_Result l) => l.GuarantyID == ordGuarantyId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrderGarantyIsWrong;
								}
								break;
							}
							case "ordPrintFormatId":
							{
								int ordPrintFormatId = 0;
								int.TryParse(text5, out ordPrintFormatId);
								if (ordPrintFormatId <= 0)
								{
									break;
								}
								spSelectPrintFormat_Result spSelectPrintFormat_Result = new spSelectPrintFormat_Result();
								List<spSelectPrintFormat_Result> list3 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result, 2);
								if (list3 != null)
								{
									spSelectPrintFormat_Result = Enumerable.FirstOrDefault<spSelectPrintFormat_Result>((IEnumerable<spSelectPrintFormat_Result>)list3, (Func<spSelectPrintFormat_Result, bool>)((spSelectPrintFormat_Result l) => l.PrintFormatID == ordPrintFormatId));
								}
								if (spSelectPrintFormat_Result != null && spSelectPrintFormat_Result.PrintFormatID == 0)
								{
									spSelectPrintFormat_Result = null;
								}
								if (spSelectPrintFormat_Result == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrderPrintFormatIsWrong;
								}
								break;
							}
							case "ordRLogoId":
							{
								int ordRLogoId = 0;
								int.TryParse(text5, out ordRLogoId);
								if (ordRLogoId > 0 && Enumerable.FirstOrDefault<WSspSelectLogo_Result>((IEnumerable<WSspSelectLogo_Result>)cRMSpEntities.WSspSelectLogo(lCID, result2), (Func<WSspSelectLogo_Result, bool>)((WSspSelectLogo_Result l) => l.LogoID == ordRLogoId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdRLogoIdIsWrong;
								}
								break;
							}
							case "ordLLogoId":
							{
								int ordLLogoId = 0;
								int.TryParse(text5, out ordLLogoId);
								if (ordLLogoId > 0 && Enumerable.FirstOrDefault<WSspSelectLogo_Result>((IEnumerable<WSspSelectLogo_Result>)cRMSpEntities.WSspSelectLogo(lCID, result2), (Func<WSspSelectLogo_Result, bool>)((WSspSelectLogo_Result l) => l.LogoID == ordLLogoId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdLLogoIdIsWrong;
								}
								break;
							}
							case "ordSettlementTypeId":
							{
								int ordSettlementTypeId = 0;
								int.TryParse(text5, out ordSettlementTypeId);
								if (ordSettlementTypeId > 0 && Enumerable.FirstOrDefault<WSspSettlementType_Result>((IEnumerable<WSspSettlementType_Result>)cRMSpEntities.WSspSettlementType(lCID, result2), (Func<WSspSettlementType_Result, bool>)((WSspSettlementType_Result l) => l.Id == ordSettlementTypeId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdSettlementTypeIdIsWrong;
								}
								break;
							}
							case "ordReferUserId":
							{
								int result5 = 0;
								int.TryParse(text5, out result5);
								if (result5 > 0 && CRMIdeal.Classes.Helper.User.SelectUsersById(result5) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdReferUserIdIsWrong;
								}
								break;
							}
							case "ordCurrencyUnitId":
							{
								int ordCurrencyUnitId = 0;
								int.TryParse(text5, out ordCurrencyUnitId);
								if (ordCurrencyUnitId > 0 && Enumerable.FirstOrDefault<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)cRMSpEntities.WSspSelectCurrencyUnits(lCID, result2), (Func<WSspSelectCurrencyUnits_Result, bool>)((WSspSelectCurrencyUnits_Result l) => l.CurrencyUnitID == ordCurrencyUnitId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdCurrencyUnitIdIsWrong;
								}
								break;
							}
							case "ordDeliveryTermId":
							{
								int ordDeliveryTermId = 0;
								int.TryParse(text5, out ordDeliveryTermId);
								if (ordDeliveryTermId > 0 && Enumerable.FirstOrDefault<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)cRMSpEntities.WSspSelectDeliveryTerms(lCID, result2), (Func<WSspSelectDeliveryTerms_Result, bool>)((WSspSelectDeliveryTerms_Result l) => l.DeliveryTermId == ordDeliveryTermId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdDeliveryTermIdIsWrong;
								}
								break;
							}
							case "ordIPrdUnitId":
							{
								int ordIPrdUnitId = 0;
								int.TryParse(text5, out ordIPrdUnitId);
								if (ordIPrdUnitId > 0 && Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)cRMSpEntities.WSspSelectProductUnits(lCID, result2), (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result l) => l.ProductUnitID == ordIPrdUnitId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdIPrdUnitIdIsWrong;
								}
								break;
							}
							case "ordIWHId":
							{
								int ordIWHId = 0;
								int.TryParse(text5, out ordIWHId);
								if (ordIWHId <= 0)
								{
									break;
								}
								WSspSelectWareHouse_Result wSspSelectWareHouse_Result = new WSspSelectWareHouse_Result();
								List<WSspSelectWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse(-1, -1);
								if (list2 != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list2))
								{
									wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result l) => l.WareHouseID == ordIWHId));
								}
								if (wSspSelectWareHouse_Result == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdIWHIdIsWrong;
								}
								break;
							}
							case "ordIPrdPriceGroupID":
							{
								int ordIPrdPriceGroupID = 0;
								int.TryParse(text5, out ordIPrdPriceGroupID);
								if (ordIPrdPriceGroupID > 0 && Enumerable.FirstOrDefault<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)cRMSpEntities.WSspSelectProductPriceGroup(lCID, result2), (Func<WSspSelectProductPriceGroup_Result, bool>)((WSspSelectProductPriceGroup_Result l) => l.ProductPriceGroupID == ordIPrdPriceGroupID)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdIPrdPriceGroupIDIsWrong;
								}
								break;
							}
							case "ordIDeliveryTermId":
							{
								int ordIDeliveryTermId = 0;
								int.TryParse(text5, out ordIDeliveryTermId);
								if (ordIDeliveryTermId > 0 && Enumerable.FirstOrDefault<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)cRMSpEntities.WSspSelectDeliveryTerms(lCID, result2), (Func<WSspSelectDeliveryTerms_Result, bool>)((WSspSelectDeliveryTerms_Result l) => l.DeliveryTermId == ordIDeliveryTermId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdIDeliveryTermIdIsWrong;
								}
								break;
							}
							case "ordpayTypeId":
							{
								int ordpayTypeId = 0;
								int.TryParse(text5, out ordpayTypeId);
								if (ordpayTypeId > 0 && Enumerable.FirstOrDefault<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)cRMSpIEntities.WSspSelectActiveOrderPaymentTypes(lCID, result2, value), (Func<WSspSelectActiveOrderPaymentTypes_Result, bool>)((WSspSelectActiveOrderPaymentTypes_Result l) => l.OrderPaymentTypeId == ordpayTypeId)) == null)
								{
									if (text != "")
									{
										text += ",";
									}
									text = text + Labels.OrderImportExcelValue + " " + ExcelCurrCol + " " + Messages.msgErrorOrdpayTypeIdIsWrong;
								}
								break;
							}
							}
						}
						else if ("decimal,float,numeric".Contains(list[k].FieldType.ToLower()))
						{
							decimal result6 = default(decimal);
							decimal.TryParse(text5, out result6);
							if (result6 <= 0m)
							{
								if (text != "")
								{
									text += ",";
								}
								text = text + Labels.OrderImportExcelValue + " " + list[k].FieldCaption + " " + Messages.msgErrorNumericAndMoreZero;
								text5 = null;
							}
						}
						else if ("char,varchar,nchar,nvarchar,ntext".Contains(list[k].FieldType.ToLower()))
						{
							if (string.IsNullOrWhiteSpace(text5))
							{
								if (text != "")
								{
									text += ",";
								}
								text = text + Labels.OrderImportExcelValue + " " + list[k].FieldCaption + " " + Messages.MsgErrorEnterRequireInformation;
								text5 = null;
							}
							else if (text5.Length > list[k].FieldSize)
							{
								if (text != "")
								{
									text += ",";
								}
								text += string.Format(Messages.msgErrorOrdLength, text5, list[k].FieldSize.ToString());
								text5 = null;
							}
						}
						else if ("datetime".Contains(list[k].FieldType))
						{
							try
							{
								DateTime.Parse(text5);
							}
							catch (Exception)
							{
								if (text != "")
								{
									text += ",";
								}
								text = text + Labels.OrderImportExcelValue + " " + list[k].FieldCaption + " " + Messages.WrongDateTime;
								text5 = null;
							}
						}
						else
						{
							"bit".Contains(list[k].FieldType);
						}
					}
					if (text3 != "")
					{
						text3 += ",";
					}
					if ("int,bigint,smallint".Contains(list[k].FieldType.ToLower()))
					{
						try
						{
							long.Parse(text5.ToString());
							text3 += (string.IsNullOrWhiteSpace(text5.ToString()) ? "NULL" : text5.ToString());
						}
						catch (Exception)
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, arg, j.ToString(), arg2);
							text3 += "NULL";
						}
					}
					else if ("decimal,float,numeric".Contains(list[k].FieldType.ToLower()))
					{
						try
						{
							double.Parse(text5.ToString());
							text3 += (string.IsNullOrWhiteSpace(text5.ToString()) ? "NULL" : text5.ToString());
						}
						catch (Exception)
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, arg, j.ToString(), arg2);
							text3 += "NULL";
						}
					}
					else if ("char,varchar,nchar,nvarchar,ntext".Contains(list[k].FieldType.ToLower()))
					{
						if ("[ordDate],[ordDeliveryDate],[ImportDate],[ordpayDocDate]".Contains(text6))
						{
							try
							{
								DateTime ordDateTime = default(DateTime);
								string text7 = "";
								try
								{
									if (!string.IsNullOrEmpty(text5))
									{
										text7 = PersianDate.GetFormatetdDate(text5.Replace("/", ""));
										switch (lCID)
										{
										case 1065:
											ordDateTime = DateTime.Parse(text7 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
											text5 = ordDateTime.ToString("yyyyMMdd");
											break;
										case 1025:
											ordDateTime = DateTime.Parse(text7 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
											text5 = ordDateTime.ToString("yyyyMMdd", new PersianCulture());
											break;
										default:
											ordDateTime = DateTime.Parse(text7 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
											text5 = ordDateTime.ToString("yyyyMMdd", new PersianCulture());
											break;
										}
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
									base.ViewBag.Error = Messages.WrongDateTime;
								}
								if (text5 != null)
								{
									text5 = text5.Replace("/", "").Replace("-", "").Replace("_", "")
										.Replace(".", "")
										.Replace(",", "")
										.Replace("\\", "");
								}
								orderImportFromExcelViewModel.OrdDate = text5;
								orderImportFromExcelViewModel.OrdDateTime = ordDateTime;
								text3 = text3 + "'" + text5 + "'";
								if (text3 != "")
								{
									text3 += ",";
								}
								text3 = text3 + "'" + ordDateTime.ToString(new CultureInfo("en-US")) + "'";
								if ("[ordDate]".ToLower().Contains(text6.ToLower()))
								{
									if (text3 != "")
									{
										text3 += ",";
									}
									text3 = text3 + "'" + ordDateTime.ToString("hh:mm:ss", new PersianCulture()) + "'";
								}
							}
							catch (Exception)
							{
								text3 += "NULL";
								if (text3 != "")
								{
									text3 += ",";
								}
								text3 += "NULL";
								if ("[ordDate]".ToLower().Contains(text6.ToLower()))
								{
									if (text3 != "")
									{
										text3 += ",";
									}
									text3 += "'NULL'";
								}
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, arg, j.ToString(), arg2);
								text3 += "NULL";
							}
						}
						else if ("[ordIDeliveryDatePersian]".Contains(text6))
						{
							try
							{
								DateTime dateTime = default(DateTime);
								string text8 = "";
								try
								{
									if (!string.IsNullOrEmpty(text5))
									{
										text8 = PersianDate.GetFormatetdDate(text5.Replace("/", ""));
										switch (lCID)
										{
										case 1065:
											dateTime = DateTime.Parse(text8 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
											text5 = dateTime.ToString("yyyyMMdd");
											break;
										case 1025:
											dateTime = DateTime.Parse(text8 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
											text5 = dateTime.ToString("yyyyMMdd", new PersianCulture());
											break;
										default:
											dateTime = DateTime.Parse(text8 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
											text5 = dateTime.ToString("yyyyMMdd", new PersianCulture());
											break;
										}
									}
								}
								catch (Exception e2)
								{
									ErrorSignal.FromCurrentContext().Raise(e2);
									base.ViewBag.Error = Messages.WrongDateTime;
								}
								if (text5 != null)
								{
									text5 = text5.Replace("/", "").Replace("-", "").Replace("_", "")
										.Replace(".", "")
										.Replace(",", "")
										.Replace("\\", "");
								}
								text3 = text3 + "'" + dateTime.ToString(new CultureInfo("en-US")) + "'";
								if (text3 != "")
								{
									text3 += ",";
								}
								text3 = text3 + "'" + text5 + "'";
							}
							catch (Exception)
							{
								text3 += "NULL";
								if (text3 != "")
								{
									text3 += ",";
								}
								text3 += "NULL";
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, arg, j.ToString(), arg2);
								text3 += "NULL";
							}
						}
						else if ("[ordVerifiedRegisterDatePersian]".Contains(text6))
						{
							try
							{
								DateTime dateTime2 = default(DateTime);
								string text9 = "";
								try
								{
									if (!string.IsNullOrEmpty(text5))
									{
										text9 = PersianDate.GetFormatetdDate(text5.Replace("/", ""));
										switch (lCID)
										{
										case 1065:
											dateTime2 = DateTime.Parse(text9 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
											text5 = dateTime2.ToString("yyyyMMdd");
											break;
										case 1025:
											dateTime2 = DateTime.Parse(text9 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
											text5 = dateTime2.ToString("yyyyMMdd", new PersianCulture());
											break;
										default:
											dateTime2 = DateTime.Parse(text9 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
											text5 = dateTime2.ToString("yyyyMMdd", new PersianCulture());
											break;
										}
									}
								}
								catch (Exception e3)
								{
									ErrorSignal.FromCurrentContext().Raise(e3);
									base.ViewBag.Error = Messages.WrongDateTime;
								}
								if (text5 != null)
								{
									text5 = text5.Replace("/", "").Replace("-", "").Replace("_", "")
										.Replace(".", "")
										.Replace(",", "")
										.Replace("\\", "");
								}
								text3 = text3 + "'" + dateTime2.ToString(new CultureInfo("en-US")) + "'";
								if (text3 != "")
								{
									text3 += ",";
								}
								text3 = text3 + "'" + text5 + "'";
							}
							catch (Exception)
							{
								text3 += "NULL";
								if (text3 != "")
								{
									text3 += ",";
								}
								text3 += "NULL";
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, wSspSelectOrderImportFromExcelFields_Result2.FieldCaption, j.ToString(), arg2);
								text3 += "NULL";
							}
						}
						else
						{
							text3 = text3 + "'" + (string.IsNullOrWhiteSpace(text5.ToString()) ? "NULL" : text5.ToString()) + "'";
						}
					}
					else if ("datetime,date".Contains(list[k].FieldType.ToLower()))
					{
						try
						{
							DateTime.Parse(text5.ToString());
							text3 = text3 + "'" + (string.IsNullOrWhiteSpace(text5.ToString()) ? "NULL" : text5.ToString()) + "'";
						}
						catch (Exception)
						{
							text3 += "NULL";
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = string.Format(Messages.msgErrorOrderValueType, wSspSelectOrderImportFromExcelFields_Result2.FieldCaption, j.ToString(), arg2);
							text3 += "NULL";
						}
					}
					else if ("bit".Contains(list[k].FieldType))
					{
						int result7 = 0;
						int.TryParse(text5.ToString(), out result7);
						text3 = ((result7 != 1) ? (text3 + "0") : (text3 + "1"));
					}
				}
				double result8 = 1.0;
				double result9 = 1.0;
				orderImportFromExcelViewModel.OrdNumber = ordNumber;
				_ = orderImportFromExcelViewModel.OrdIFCR;
				if (orderImportFromExcelViewModel.OrdIFCR != 0m)
				{
					double.TryParse(orderImportFromExcelViewModel.OrdIFCR.ToString(), out result8);
				}
				_ = orderImportFromExcelViewModel.OrdIFCRI;
				if (orderImportFromExcelViewModel.OrdIFCRI != 0f)
				{
					double.TryParse(orderImportFromExcelViewModel.OrdIFCRI.ToString(), out result9);
				}
				decimal.TryParse(orderImportFromExcelViewModel.OrdIDiscount.ToString(), out var result10);
				decimal.TryParse(orderImportFromExcelViewModel.OrdIDiscountI.ToString(), out var _);
				decimal.TryParse(orderImportFromExcelViewModel.OrdIPrice.ToString(), out var result12);
				decimal.TryParse(orderImportFromExcelViewModel.OrdIRound.ToString(), out var result13);
				decimal.TryParse(orderImportFromExcelViewModel.OrdIRoundPlus.ToString(), out var result14);
				decimal.TryParse(orderImportFromExcelViewModel.OrdITax.ToString(), out var result15);
				decimal num3 = (decimal)((double)orderImportFromExcelViewModel.OrdIQuantity * result8 * result9);
				decimal num4 = result12 - result10 - result13 + result14;
				decimal.TryParse(orderImportFromExcelViewModel.OrdITaxIndex.ToString(), out var result16);
				if (result16 != 0m)
				{
					orderImportFromExcelViewModel.OrdITaxSum = num3 * num4 * result16 / 100m;
					result15 = num4 * result16 / 100m;
				}
				else
				{
					orderImportFromExcelViewModel.OrdITaxSum = num3 * result15;
				}
				decimal.TryParse(orderImportFromExcelViewModel.OrdIDiscountPercent.ToString(), out var result17);
				if (result17 != 0m)
				{
					orderImportFromExcelViewModel.OrdIDiscountSum = result12 * num3 * result17 / 100m;
					result10 = result12 * result17 / 100m;
				}
				else
				{
					orderImportFromExcelViewModel.OrdIDiscountSum = num3 * result10;
				}
				if (orderImportFromExcelViewModel.OrdIDiscountSum != 0m)
				{
					orderImportFromExcelViewModel.OrdIDiscount = result10;
				}
				if (orderImportFromExcelViewModel.OrdITaxSum != 0m)
				{
					orderImportFromExcelViewModel.OrdITax = result15;
					orderImportFromExcelViewModel.OrdICalculateTax = true;
					flag3 = true;
				}
				num4 = result12 - result10 - result13 + result14;
				orderImportFromExcelViewModel.OrdIPriceSum = num3 * num4;
				orderImportFromExcelViewModel.OrdITotalPrice = orderImportFromExcelViewModel.OrdIPriceSum + orderImportFromExcelViewModel.OrdITaxSum;
				try
				{
					if (text3 != "")
					{
						text3 += ",";
					}
					text3 += (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdITaxSum.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdITaxSum.ToString());
					text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdIPriceSum.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdIPriceSum.ToString());
					text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdITotalPrice.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdITotalPrice.ToString());
					text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdIDiscountSum.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdIDiscountSum.ToString());
					text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdITax.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdITax.ToString());
					if (flag2)
					{
						text3 = text3 + "," + (string.IsNullOrWhiteSpace(orderImportFromExcelViewModel.OrdIDiscount.ToString()) ? "NULL" : orderImportFromExcelViewModel.OrdIDiscount.ToString());
					}
					if (flag3)
					{
						text3 = text3 + "," + ((!orderImportFromExcelViewModel.OrdICalculateTax) ? "0" : "1");
					}
				}
				catch (Exception)
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.msgErrorOnFindColumnName;
				}
				num++;
				if (num2 >= 1000)
				{
					try
					{
						cRMSpEntities.Database.ExecuteSqlCommand("INSERT INTO [WSOrderImportFromExcel] (" + text2 + ") VALUES" + text4);
					}
					catch (Exception e4)
					{
						commonReturnResultViewModel.IsDone = false;
						if (commonReturnResultViewModel.Message != "")
						{
							commonReturnResultViewModel.Message += ", ";
						}
						commonReturnResultViewModel.Message += j;
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					num2 = 0;
					text4 = "";
				}
				else
				{
					text4 = text4 + ((text4 != "") ? "," : "") + "(" + text3 + ")";
					num2++;
				}
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				try
				{
					cRMSpEntities.Database.ExecuteSqlCommand("INSERT INTO [WSOrderImportFromExcel] (" + text2 + ") VALUES" + text4);
				}
				catch (Exception e5)
				{
					commonReturnResultViewModel.IsDone = false;
					if (commonReturnResultViewModel.Message != "")
					{
						commonReturnResultViewModel.Message += ", ";
					}
					commonReturnResultViewModel.Message += noOfRow / 1000;
					ErrorSignal.FromCurrentContext().Raise(e5);
				}
				num2 = 0;
				text4 = "";
			}
			commonReturnResultViewModel.Tag = obj;
		}
		catch (Exception ex10)
		{
			Public.InsExceptToElmah(ex10);
		}
	}

	[AjaxOnly]
	public ActionResult Imported_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectOrderImportFromExcel_Result> enumerable = new List<WSspSelectOrderImportFromExcel_Result>();
		try
		{
			enumerable = Enumerable.ToList<WSspSelectOrderImportFromExcel_Result>((IEnumerable<WSspSelectOrderImportFromExcel_Result>)_db.WSspSelectOrderImportFromExcel());
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string DeleteOrderImportFromExcel()
	{
		string result = "";
		try
		{
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteOrderImportFromExcel());
			if (mct_Result != null && mct_Result.Result > 0)
			{
				result = "";
			}
			else if (mct_Result != null && mct_Result.Result == 0)
			{
				result = Messages.RedundancyMessage;
			}
		}
		catch (Exception ex)
		{
			result = ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actOrdImportExcel")]
	public ActionResult _PartialImportToCrm()
	{
		return PartialView("_PartialImportToCrm");
	}

	public string StartImportToCrm()
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		ObjectParameter objectParameter = new ObjectParameter("result", "");
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			_db.WSspImportOrdersFromExcelMultiRec(value, registerDatePersian, userId, id, value3, value2, appType, result, objectParameter, centerId);
			text = objectParameter.Value.ToString();
			if (!VersionBuyer.OrdImportExcel)
			{
				int result2 = 0;
				int.TryParse(SysSeting.Get().OrdImpUsedCount.ToString(), out result2);
				CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
				if (crmsysSetting != null)
				{
					crmsysSetting.OrdImpUsedCount = result2 + 1;
					_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					SysSeting.Update();
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = ex.Message;
		}
		return text;
	}

	[AjaxOnly]
	public ActionResult ImportToCrm_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectOrderImportFromExcel_Result> enumerable = new List<WSspSelectOrderImportFromExcel_Result>();
		try
		{
			enumerable = Enumerable.ToList<WSspSelectOrderImportFromExcel_Result>((IEnumerable<WSspSelectOrderImportFromExcel_Result>)_db.WSspSelectOrderImportFromExcel());
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string DeleteImportedDataToCrm()
	{
		string result = "";
		try
		{
			_db.WSspDeleteOrderImportExcelFromCrm();
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
