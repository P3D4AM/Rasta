using System;

namespace CRM.Models;

public class CRMspLkWSSelectOrderById_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public int? PreOrderId { get; set; }

	public int? PreOrderVerifierId { get; set; }

	public string ordTitle { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public int ordCompanyId { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public int? ordProjectId { get; set; }

	public string ordSubject { get; set; }

	public int? ordItemCount { get; set; }

	public decimal? ordItemsAmount { get; set; }

	public decimal? ordInstallAmount { get; set; }

	public decimal? ordDiscount { get; set; }

	public decimal? ordSumAmount { get; set; }

	public decimal? ordTax { get; set; }

	public decimal? ordTaxIndex { get; set; }

	public bool? ordCalculateTax { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordTotalAmountStr { get; set; }

	public bool? ordIsVerified { get; set; }

	public DateTime? ordVerifiedRegisterDate { get; set; }

	public string ordVerifiedRegisterDatePersian { get; set; }

	public int? ordStatusId { get; set; }

	public bool? ordIsFixed { get; set; }

	public string ordEditAfterFixInfoJs { get; set; }

	public int? ordGuarantyId { get; set; }

	public string ordSpecialWord { get; set; }

	public string ordDescriptionI { get; set; }

	public string ordDescriptionII { get; set; }

	public int? ordDescriptionId { get; set; }

	public int? ordPrintFormatId { get; set; }

	public int? ordRLogoId { get; set; }

	public int? ordLLogoId { get; set; }

	public string ordSigningI { get; set; }

	public string ordSigningII { get; set; }

	public string ordSigningIII { get; set; }

	public string ordAccountNumberI { get; set; }

	public string ordAccountShabaNumberI { get; set; }

	public string ordAccountNumberII { get; set; }

	public string ordAccountShabaNumberII { get; set; }

	public int? ordSignatureId { get; set; }

	public string ordImportDate { get; set; }

	public int? ordFirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? ordVerifierId { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public string ordSettlementType { get; set; }

	public string ordDay { get; set; }

	public string ordTime { get; set; }

	public Guid? GUId { get; set; }

	public decimal? ordTransportation { get; set; }

	public int? ordReferUserId { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public string ordDiscountTitle { get; set; }

	public decimal? ordRound { get; set; }

	public string ordNote { get; set; }

	public string ordcmpTitle { get; set; }

	public DateTime? ordDateTime { get; set; }

	public DateTime? ordImportDateTime { get; set; }

	public string ordDeliveryDate { get; set; }

	public DateTime? ordDeliveryDateTime { get; set; }

	public string ordDeliveryTime { get; set; }

	public string ordSerial { get; set; }

	public string AppType { get; set; }

	public int? ordVerifierRequestId { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? ordVerificationWorkFlowId { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

	public int? ordDeliveryTermId { get; set; }

	public string ordDeliveryTerm { get; set; }

	public string ordDeliveryEndDate { get; set; }

	public DateTime? ordDeliveryEndDateTime { get; set; }

	public string ordDeliveryEndTime { get; set; }

	public string ordNumRef { get; set; }

	public int? ordDefWHId { get; set; }

	public string ordDefWH { get; set; }

	public int? ordDefPrdPriceGroupId { get; set; }

	public string ordDefPrdPriceGroup { get; set; }

	public int? ordSellerId { get; set; }

	public string ordSeller { get; set; }

	public int? ordEmailUsersInfoId { get; set; }

	public int? ordEmailUserDefaultSettingId { get; set; }

	public string ordReferUser { get; set; }

	public string OrderOpr { get; set; }

	public int? ordSaleCenterId { get; set; }

	public string ordSaleCenter { get; set; }

	public string CompanyName { get; set; }

	public string ordLinkAccTransferKey { get; set; }

	public string ordLinkAccTransferResult { get; set; }

	public int? cmpReferUserId { get; set; }

	public int? cmpSuppUserId { get; set; }

	public bool? ordLinkAccConflict { get; set; }

	public DateTime? ordLinkAccFirstTransferDate { get; set; }

	public DateTime? ordLinkAccLastTransferDate { get; set; }

	public string ordLinkAccData { get; set; }

	public int? WrhsLinkAccWhId { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public string WrhsLinkAccWhIdStr { get; set; }

	public string WrhsLinkAccWhName { get; set; }

	public string WrhsLinkAccWareHouses { get; set; }

	public string LinkAccOrderOprIdStr { get; set; }

	public string OrderOprLinkAccData { get; set; }

	public string LinkAccSettlementTypeIdStr { get; set; }

	public string SettlementTypeLinkAccData { get; set; }

	public string LinkAccReferUserIdStr { get; set; }

	public string LinkAccReferUserCode { get; set; }

	public string ReferUserLinkAccData { get; set; }

	public string LinkAccCurrencyUnitIdStr { get; set; }

	public string CurrencyUnitLinkAccData { get; set; }

	public string LinkAccDeliveryTermIdStr { get; set; }

	public string DeliveryTermLinkAccData { get; set; }

	public string LinkAccPrdPriceGroupIdStr { get; set; }

	public string PrdPriceGroupLinkAccData { get; set; }

	public string LinkAccSellerUserIdStr { get; set; }

	public string LinkAccSellerUserCode { get; set; }

	public string SellerUserLinkAccData { get; set; }

	public string LinkAccSaleCenterIdStr { get; set; }

	public string SaleCenterLinkAccData { get; set; }

	public int? ordDefPayTypeId { get; set; }

	public string ordpayType { get; set; }

	public string LinkAccOrdPayTypeIdStr { get; set; }

	public string PayTypeLinkAccData { get; set; }

	public int? ordCurrencyUnitIdI { get; set; }

	public string ordCurrencyUnitI { get; set; }

	public string LinkAccCurrencyUnitIdStrI { get; set; }

	public string CurrencyUnitLinkAccDataI { get; set; }

	public double? ordCurrencyUnitIRate { get; set; }

	public decimal? ordGrossProfit { get; set; }

	public decimal? ordMoneySleep { get; set; }

	public decimal? ordSaleNetProfit { get; set; }

	public decimal? ordSumOtherComm { get; set; }

	public decimal? ordSumSaleComm { get; set; }

	public decimal? ordSumBuyComm { get; set; }

	public decimal? ordSumMangComm { get; set; }

	public decimal? ordNetProfit { get; set; }

	public decimal? ordItemsAmountCurrencyI { get; set; }

	public decimal? ordInstallAmountCurrencyI { get; set; }

	public decimal? ordDiscountCurrencyI { get; set; }

	public decimal? ordSumAmountCurrencyI { get; set; }

	public decimal? ordTaxCurrencyI { get; set; }

	public decimal? ordTotalAmountCurrencyI { get; set; }

	public string ordTotalAmountCurrencyIStr { get; set; }

	public decimal? ordTransportationCurrencyI { get; set; }

	public decimal? ordRoundCurrencyI { get; set; }

	public decimal? ordItemsDiscountCurrencyI { get; set; }

	public decimal? ordItemsTaxCurrencyI { get; set; }

	public decimal? ordGrossProfitCurrencyI { get; set; }

	public decimal? ordMoneySleepCurrencyI { get; set; }

	public decimal? ordSaleNetProfitCurrencyI { get; set; }

	public decimal? ordSumOtherCommCurrencyI { get; set; }

	public decimal? ordSumSaleCommCurrencyI { get; set; }

	public decimal? ordSumBuyCommCurrencyI { get; set; }

	public decimal? ordSumMangCommCurrencyI { get; set; }

	public decimal? ordNetProfitCurrencyI { get; set; }

	public string ordCompanyPersonIds { get; set; }

	public int? ordGroupId { get; set; }

	public string OrderGroupName { get; set; }

	public string LinkAccGroupIdStr { get; set; }

	public string OrdGroupLinkAccData { get; set; }

	public int? OprType { get; set; }

	public double? ordItemsQty { get; set; }

	public decimal? ordItemsDiscount { get; set; }

	public decimal? ordItemsTax { get; set; }

	public int? ordSaleAreaId { get; set; }

	public string ordSaleArea { get; set; }

	public string LinkAccSaleAreaIdStr { get; set; }

	public string SaleAreaLinkAccData { get; set; }
}
