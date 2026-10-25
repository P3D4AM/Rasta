using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderMetadata))]
public class WSOrder
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

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? ordVerifierId { get; set; }

	public int? ordSettlementTypeId { get; set; }

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

	public int? ordDeliveryTermId { get; set; }

	public string ordDeliveryEndDate { get; set; }

	public DateTime? ordDeliveryEndDateTime { get; set; }

	public string ordDeliveryEndTime { get; set; }

	public string ordNumRef { get; set; }

	public int? ordDefWHId { get; set; }

	public int? ordDefPrdPriceGroupId { get; set; }

	public int? ordSellerId { get; set; }

	public int? ordEmailUsersInfoId { get; set; }

	public int? ordEmailUserDefaultSettingId { get; set; }

	public int? ordSaleCenterId { get; set; }

	public int? ordDefPayTypeId { get; set; }

	public int? ordAutoAddCnvsCmpQuickRegisterDefSettingId { get; set; }

	public int? ordAutoAddCnvsStatusId { get; set; }

	public string ordAutoAddCnvsDesc { get; set; }

	public long? ordDailyCounter { get; set; }

	public string ordLinkAccTransferKey { get; set; }

	public string ordLinkAccTransferResult { get; set; }

	public DateTime? ordDeadlineDate { get; set; }

	public string ordDeadlineDatePersian { get; set; }

	public int? ordTspSettingId { get; set; }

	public string TspOrdIdentify { get; set; }

	public string TspOrdInno { get; set; }

	public int? TspOrdIns { get; set; }

	public string TspOrdIrtaxid { get; set; }

	public int? TspOrdFt { get; set; }

	public string TspOrdBillid { get; set; }

	public int? TspOrdSetm { get; set; }

	public decimal? TspOrdTax17 { get; set; }

	public DateTime? TspOrdSendDate { get; set; }

	public string TspOrdSendDatePersian { get; set; }

	public DateTime? TspOrdLastEditDate { get; set; }

	public string TspOrdLastEditDatePersian { get; set; }

	public string TspOrdUID { get; set; }

	public string TspOrdReferenceNumber { get; set; }

	public string TspOrdStatus { get; set; }

	public string TspOrdMessage { get; set; }

	public string TspOrdCdcn { get; set; }

	public DateTime? TspOrdCdcd { get; set; }

	public string TspOrdCdcdPersian { get; set; }

	public int? ordDefaultSettingId { get; set; }

	public double? ordItemsQty { get; set; }

	public decimal? ordItemsDiscount { get; set; }

	public decimal? ordItemsTax { get; set; }

	public string ordDeliveryDay { get; set; }

	public string ordDeliveryEndDay { get; set; }

	public string TspOrdStatusResult { get; set; }

	public bool? ordLinkAccConflict { get; set; }

	public DateTime? ordLinkAccFirstTransferDate { get; set; }

	public DateTime? ordLinkAccLastTransferDate { get; set; }

	public string BuyOrderIds { get; set; }

	public decimal? ordGrossProfit { get; set; }

	public decimal? ordMoneySleep { get; set; }

	public decimal? ordSaleNetProfit { get; set; }

	public decimal? ordSumOtherComm { get; set; }

	public decimal? ordSumSaleComm { get; set; }

	public decimal? ordSumBuyComm { get; set; }

	public decimal? ordSumMangComm { get; set; }

	public decimal? ordNetProfit { get; set; }

	public int? ordCurrencyUnitIdI { get; set; }

	public double? ordCurrencyUnitIRate { get; set; }

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

	public string ordLinkAccData { get; set; }

	public string ordEditAfterFixInfoJs { get; set; }

	public string ordCompanyPersonIds { get; set; }

	public int? ordGroupId { get; set; }

	public int? ordCId { get; set; }

	public string TspOrdSbc { get; set; }

	public string TspOrdScln { get; set; }

	public string TspOrdScc { get; set; }

	public string TspOrdCrn { get; set; }

	public int? ordShpCartPayTypeId { get; set; }

	public int? ordSaleAreaId { get; set; }

	public int? ordRefOrderId { get; set; }

	public decimal? TspOrdInsp { get; set; }

	public string DocIds { get; set; }

	public DateTime? ordCalcScoreDate { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual EmailUserDefaultSetting EmailUserDefaultSetting { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual TspSetting TspSetting { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual WSDeliveryTerms WSDeliveryTerms { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSGuaranty WSGuaranty { get; set; }

	public virtual WSLogo WSLogo { get; set; }

	public virtual WSLogo WSLogo1 { get; set; }

	public virtual ICollection<WSOrder_Lang> WSOrder_Lang { get; set; }

	public virtual WSOrderOpr WSOrderOpr { get; set; }

	public virtual WSOrderPaymentTypes WSOrderPaymentTypes { get; set; }

	public virtual WSOrderStatus WSOrderStatus { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual WSProductPriceGroup WSProductPriceGroup { get; set; }

	public virtual WSSaleCenters WSSaleCenters { get; set; }

	public virtual WSSettlementType WSSettlementType { get; set; }

	public virtual WSSignature WSSignature { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual ICollection<WSOrderDiscounts> WSOrderDiscounts { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual WSOrderGroups WSOrderGroups { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSSaleAreas WSSaleAreas { get; set; }

	public virtual ICollection<WSOrder> WSOrder1 { get; set; }

	public virtual WSOrder WSOrder2 { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus { get; set; }

	public virtual ICollection<Scores> Scores { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual WSOrderDefaultSetting WSOrderDefaultSetting { get; set; }

	public virtual CrmCompanyQuickRegisterDefSetting CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public virtual Users Users5 { get; set; }

	public virtual Users Users6 { get; set; }

	public virtual Users Users7 { get; set; }

	public WSOrder()
	{
		WSOrder_Lang = (ICollection<WSOrder_Lang>)new HashSet<WSOrder_Lang>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderDiscounts = (ICollection<WSOrderDiscounts>)new HashSet<WSOrderDiscounts>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrder1 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		Scores = (ICollection<Scores>)new HashSet<Scores>();
	}
}
