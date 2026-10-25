using System;

namespace CRM.Models;

public class WSspSelectCostSheetItemsById_Result
{
	public int CostSheetItemId { get; set; }

	public int CostSheetId { get; set; }

	public int CostSheetProductId { get; set; }

	public string CostSheetProduct { get; set; }

	public int? ctshPrdGroupId { get; set; }

	public string ctshPrdGroup { get; set; }

	public int? ctshPrdFGroupId { get; set; }

	public string ctshPrdFGroup { get; set; }

	public double ctshIQuantity { get; set; }

	public double? ctshIWeight { get; set; }

	public decimal? ctshICost { get; set; }

	public decimal? ctshITotalCost { get; set; }

	public decimal? ctshIDesctCurrencyCost { get; set; }

	public decimal? ctshIDesctCurrencyTotalCost { get; set; }

	public decimal? ctshIPrice { get; set; }

	public decimal? ctshIPriceRounded { get; set; }

	public decimal? ctshITotalPrice { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public double? ctshIRoundRate { get; set; }

	public int? ctshIBuyOrderId { get; set; }

	public int? ctshIBuyOrderItemId { get; set; }

	public int? ctshIPreOrderItemId { get; set; }

	public long? bordNumber { get; set; }

	public int? bordReferUserId { get; set; }

	public string bordReferUser { get; set; }

	public string bordDate { get; set; }

	public int? bordCompanyId { get; set; }

	public string bordCompany { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public DateTime? bordDateTime { get; set; }

	public int? bordCurrencyUnitId { get; set; }

	public string bordCurrencyUnit { get; set; }

	public int? bordFacilityCmpId { get; set; }

	public string bordFacilityCmp { get; set; }

	public int? bordReqCmpId { get; set; }

	public string bordReqCmp { get; set; }

	public decimal? bordTotalFinalCost { get; set; }

	public int? PreOrderId { get; set; }

	public long? pordNumber { get; set; }

	public string pordDate { get; set; }

	public int? pordCompanyId { get; set; }

	public string pordCompany { get; set; }

	public int? pordCompanyNumber { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public string pordCompanyPerson { get; set; }

	public int? pordProjectId { get; set; }

	public string pordProjectTitle { get; set; }

	public string pordProjectInquiryNum { get; set; }

	public long? pordProjectNumR { get; set; }

	public string pordProjectNumRef { get; set; }

	public bool? pordIsVerified { get; set; }

	public bool? pordIsFixed { get; set; }

	public DateTime? pordDateTime { get; set; }

	public long? pordNumberRevision { get; set; }

	public int? pordReferUserId { get; set; }

	public string pordReferUser { get; set; }

	public int? pordCurrencyUnitId { get; set; }

	public string pordCurrencyUnit { get; set; }

	public int? pordDeliveryTermId { get; set; }

	public string pordDeliveryTerm { get; set; }

	public string pordDeliveryDate { get; set; }

	public DateTime? pordDeliveryDateTime { get; set; }

	public int? pordIPrdId { get; set; }

	public string PrdName { get; set; }

	public int? PrdSGroupId { get; set; }

	public string PrdSGName { get; set; }

	public int? PrdFGroupId { get; set; }

	public string PrdFGName { get; set; }

	public double? pordIQuantity { get; set; }

	public decimal? pordIPrice { get; set; }

	public decimal? pordITotalPrice { get; set; }

	public string pordIDescription { get; set; }

	public decimal? pordITax { get; set; }

	public int? pordIWHId { get; set; }

	public decimal? pordIPriceSum { get; set; }

	public decimal? pordIDiscountSum { get; set; }

	public decimal? pordIDiscountISum { get; set; }

	public decimal? pordITaxSum { get; set; }

	public int? pordIDeliveryTermId { get; set; }

	public string pordIDeliveryTerm { get; set; }

	public DateTime? pordIDeliveryDate { get; set; }

	public string pordIDeliveryDatePersian { get; set; }

	public decimal? SumPordPayAmount { get; set; }

	public string pordpayDocDate { get; set; }

	public DateTime? pordpayDocDateTime { get; set; }

	public decimal? LastPordpayAmount { get; set; }

	public string LastPordpayDocDate { get; set; }

	public DateTime? LastPordpayDocDateTime { get; set; }

	public decimal? SumPordCommAmount { get; set; }

	public int? prjCompanyId { get; set; }

	public string prjCompany { get; set; }

	public int? prjCompanyNumber { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ctshCmpProjectId { get; set; }

	public string ctshCmpProject { get; set; }

	public string prjInquiryNum { get; set; }

	public long? prjNumR { get; set; }

	public string prjNumRef { get; set; }

	public string pordNumRef { get; set; }

	public string prjNumRef1 { get; set; }

	public string bordNumRef { get; set; }

	public double? ctshILength { get; set; }

	public double? ctshIWidth { get; set; }
}
