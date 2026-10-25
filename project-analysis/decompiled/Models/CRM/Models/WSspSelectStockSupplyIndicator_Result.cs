using System;

namespace CRM.Models;

public class WSspSelectStockSupplyIndicator_Result
{
	public string rptUserName { get; set; }

	public int? rptDate { get; set; }

	public string rptDay { get; set; }

	public int StockSupplyId { get; set; }

	public int StockSupplyOprId { get; set; }

	public int stsupReferUserId { get; set; }

	public string stsupReferUser { get; set; }

	public long stsupNumber { get; set; }

	public DateTime stsupDateTime { get; set; }

	public string stsupDate { get; set; }

	public int? stsupCompanyId { get; set; }

	public string Company { get; set; }

	public int? stsupCompanyPersonId { get; set; }

	public string Person { get; set; }

	public int? stsupProjectId { get; set; }

	public string Project { get; set; }

	public string CompanyTel { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string CompanyNationalCode { get; set; }

	public string CompanySpecialPoint { get; set; }

	public string CompanyCountry { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string CompanyAddress { get; set; }

	public string CompanyZipcode { get; set; }

	public string CompanyPostBox { get; set; }

	public string PersonNationalCode { get; set; }

	public string PersonMobile { get; set; }

	public bool? stsupIsFixed { get; set; }

	public bool? stsupIsCanceled { get; set; }

	public bool? stsupIsVerified { get; set; }

	public int? stsupVerifierRequestId { get; set; }

	public string stsupVerifierRequest { get; set; }

	public int? stsupVerifierId { get; set; }

	public string stsupVerifier { get; set; }

	public DateTime? stsupVerifiedRegisterDate { get; set; }

	public string stsupVerifiedRegisterDatePersian { get; set; }

	public int? stsupVerificationWorkFlowId { get; set; }

	public string stsupVerificationWorkFlow { get; set; }

	public string LastVerificationWorkFlowStep { get; set; }

	public string LastVerifyUser { get; set; }

	public DateTime? LastVerifyDateTime { get; set; }

	public int? stsupPrintFormatId { get; set; }

	public string stsupPrintFormat { get; set; }

	public string stsupNote { get; set; }

	public int? stsupItemCount { get; set; }

	public double? stsupItemsQty { get; set; }

	public int? stsupPreOrderId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int StockSupplyItemId { get; set; }

	public int stsupIPrdId { get; set; }

	public string stsupIPrdName { get; set; }

	public string stsupIPrdLatinName { get; set; }

	public string stsupIPrdCode { get; set; }

	public string stsupIPrdFGName { get; set; }

	public string stsupIPrdSGName { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public int? PrdColorId { get; set; }

	public string PrdColor { get; set; }

	public double stsupIQuantity { get; set; }

	public string stsupIDescription { get; set; }

	public string stsupIQuantityDesc { get; set; }

	public int? stsupIPrdUnitId { get; set; }

	public string stsupIPrdUnit { get; set; }

	public int? stsupIOrderView { get; set; }

	public double? stsupIFCR { get; set; }

	public double? stsupIFCRI { get; set; }

	public int? stsupIWHId { get; set; }

	public string stsupIWrhsName { get; set; }

	public string stsupITracing { get; set; }

	public int? stsupIPrdUnitIdI { get; set; }

	public string stsupIPrdUnitI { get; set; }

	public double? stsupIPrdUnitIRateResult { get; set; }

	public double? stsupIPrdUnitIRate { get; set; }

	public int? stsupIPrdColorId { get; set; }

	public string stsupIPrdColor { get; set; }

	public string stsupIPrdNickname { get; set; }

	public int? stsupIPreOrderId { get; set; }

	public int? stsupIPreOrderItemId { get; set; }

	public double? pordIQuantity { get; set; }

	public double? pordIFCR { get; set; }

	public double? pordIFCRI { get; set; }

	public string stsupIBuyOrderIds { get; set; }

	public string stsupIBuyOrders { get; set; }

	public string stsupIBuyOrderItemIds { get; set; }

	public string stsupIBuyOrderItems { get; set; }

	public string stsupILinkAccWHIdStr { get; set; }

	public double? BuyOrderItemQuantity { get; set; }

	public double? RemainedQuantity { get; set; }

	public decimal? stsupICost { get; set; }

	public double? stsupIPrdWeight { get; set; }

	public int? stsupIPrdUnitIdII { get; set; }

	public string stsupIPrdUnitII { get; set; }

	public double? stsupIPrdUnitIIRateResult { get; set; }

	public double? PrdUnitIRate { get; set; }

	public double? PrdUnitIIRate { get; set; }
}
