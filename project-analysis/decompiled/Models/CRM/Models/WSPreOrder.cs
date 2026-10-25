using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderMetadata))]
public class WSPreOrder
{
	public int PreOrderID { get; set; }

	public string pordTitle { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public string pordSubject { get; set; }

	public int? pordItemCount { get; set; }

	public decimal? pordItemsAmount { get; set; }

	public decimal? pordInstallAmount { get; set; }

	public decimal? pordDiscount { get; set; }

	public decimal? pordSumAmount { get; set; }

	public decimal? pordTax { get; set; }

	public decimal? pordTaxIndex { get; set; }

	public bool? pordCalculateTax { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordTotalAmountStr { get; set; }

	public bool? pordIsVerified { get; set; }

	public int? pordVerifierId { get; set; }

	public int? pordVerifierRequestId { get; set; }

	public DateTime? pordVerifiedRegisterDate { get; set; }

	public string pordVerifiedRegisterDatePersian { get; set; }

	public int? pordStatusId { get; set; }

	public bool? pordIsFixed { get; set; }

	public int? pordGuarantyId { get; set; }

	public int? pordPayConditionId { get; set; }

	public int? pordDeliveryTimeId { get; set; }

	public int? pordCreditDurationId { get; set; }

	public string pordSpecialWord { get; set; }

	public string pordDescriptionI { get; set; }

	public string pordDescriptionII { get; set; }

	public int? pordDescriptionId { get; set; }

	public int? pordPrintFormatId { get; set; }

	public int? pordRLogoId { get; set; }

	public int? pordLLogoId { get; set; }

	public string pordSigningI { get; set; }

	public string pordSigningII { get; set; }

	public string pordSigningIII { get; set; }

	public string pordAccountNumberI { get; set; }

	public string pordAccountShabaNumberI { get; set; }

	public string pordAccountNumberII { get; set; }

	public string pordAccountShabaNumberII { get; set; }

	public string pordAddress { get; set; }

	public string pordTelephone { get; set; }

	public string pordFax { get; set; }

	public string pordWebSite { get; set; }

	public string pordEmail { get; set; }

	public int? pordSignatureId { get; set; }

	public string pordImportDate { get; set; }

	public int? pordFirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string pordDay { get; set; }

	public string pordTime { get; set; }

	public Guid? GUId { get; set; }

	public string pordDiscountTitle { get; set; }

	public decimal? pordDiscountPercent { get; set; }

	public decimal? pordTransportation { get; set; }

	public int? pordReferUserId { get; set; }

	public decimal? pordRound { get; set; }

	public string pordcmpTitle { get; set; }

	public DateTime? pordDateTime { get; set; }

	public DateTime? pordImportDateTime { get; set; }

	public string pordDeliveryDate { get; set; }

	public DateTime? pordDeliveryDateTime { get; set; }

	public string pordDeliveryTime { get; set; }

	public int? PreOrderOprID { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? pordVerificationWorkFlowId { get; set; }

	public string pordExpireDate { get; set; }

	public DateTime? pordExpireDateTime { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public int? pordCurrencyUnitId { get; set; }

	public long? pordNumberRevision { get; set; }

	public int? pordDeliveryTermId { get; set; }

	public string pordCostSheetIds { get; set; }

	public int? pordParentPreOrderId { get; set; }

	public string pordDeliveryEndDate { get; set; }

	public DateTime? pordDeliveryEndDateTime { get; set; }

	public string pordDeliveryEndTime { get; set; }

	public string pordNumRef { get; set; }

	public int? pordTypeId { get; set; }

	public int? pordDefWHId { get; set; }

	public int? pordDefPrdPriceGroupId { get; set; }

	public int? pordSellerId { get; set; }

	public int? pordEmailUsersInfoId { get; set; }

	public int? pordEmailUserDefaultSettingId { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public int? pordSaleCenterId { get; set; }

	public int? pordDefPayTypeId { get; set; }

	public int? pordAutoAddCnvsCmpQuickRegisterDefSettingId { get; set; }

	public int? pordAutoAddCnvsStatusId { get; set; }

	public string pordAutoAddCnvsDesc { get; set; }

	public DateTime? pordDeadlineDate { get; set; }

	public string pordDeadlineDatePersian { get; set; }

	public int? pordDefaultSettingId { get; set; }

	public double? pordItemsQty { get; set; }

	public decimal? pordItemsDiscount { get; set; }

	public decimal? pordItemsTax { get; set; }

	public string pordDeliveryDay { get; set; }

	public string pordDeliveryEndDay { get; set; }

	public DateTime? pordLinkAccFirstTransferDate { get; set; }

	public DateTime? pordLinkAccLastTransferDate { get; set; }

	public int? pordCurrencyUnitIdI { get; set; }

	public double? pordCurrencyUnitIRate { get; set; }

	public decimal? pordItemsAmountCurrencyI { get; set; }

	public decimal? pordInstallAmountCurrencyI { get; set; }

	public decimal? pordDiscountCurrencyI { get; set; }

	public decimal? pordSumAmountCurrencyI { get; set; }

	public decimal? pordTaxCurrencyI { get; set; }

	public decimal? pordTotalAmountCurrencyI { get; set; }

	public string pordTotalAmountCurrencyIStr { get; set; }

	public decimal? pordTransportationCurrencyI { get; set; }

	public decimal? pordRoundCurrencyI { get; set; }

	public decimal? pordItemsDiscountCurrencyI { get; set; }

	public decimal? pordItemsTaxCurrencyI { get; set; }

	public string pordLinkAccData { get; set; }

	public string pordEditAfterFixInfoJs { get; set; }

	public int? pordCId { get; set; }

	public int? pordShpCartPayTypeId { get; set; }

	public int? pordChangeStatusUserId { get; set; }

	public DateTime? pordChangeStatusDate { get; set; }

	public string pordChangeStatusDatePersian { get; set; }

	public int? pordSaleAreaId { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual EmailUserDefaultSetting EmailUserDefaultSetting { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets { get; set; }

	public virtual WSCreditDuration WSCreditDuration { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSDeliveryTime WSDeliveryTime { get; set; }

	public virtual ICollection<WSDiscountCodeHistory> WSDiscountCodeHistory { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSGuaranty WSGuaranty { get; set; }

	public virtual WSLogo WSLogo { get; set; }

	public virtual WSLogo WSLogo1 { get; set; }

	public virtual WSPayCondition WSPayCondition { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder1 { get; set; }

	public virtual WSPreOrder WSPreOrder2 { get; set; }

	public virtual WSPreOrderOpr WSPreOrderOpr { get; set; }

	public virtual WSPreOrderStatus WSPreOrderStatus { get; set; }

	public virtual WSPreOrderTypes WSPreOrderTypes { get; set; }

	public virtual WSProductPriceGroup WSProductPriceGroup { get; set; }

	public virtual WSSaleCenters WSSaleCenters { get; set; }

	public virtual WSSignature WSSignature { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public virtual WSOrderPaymentTypes WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual WSDeliveryTerms WSDeliveryTerms { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual ICollection<WSPreOrderDiscounts> WSPreOrderDiscounts { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSSaleAreas WSSaleAreas { get; set; }

	public virtual ICollection<WSPreOrder_Lang> WSPreOrder_Lang { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual WSPreOrderDefaultSetting WSPreOrderDefaultSetting { get; set; }

	public virtual CrmCompanyQuickRegisterDefSetting CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public virtual Users Users5 { get; set; }

	public virtual Users Users6 { get; set; }

	public virtual Users Users7 { get; set; }

	public WSPreOrder()
	{
		WSCostSheets = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSDiscountCodeHistory = (ICollection<WSDiscountCodeHistory>)new HashSet<WSDiscountCodeHistory>();
		WSPreOrder1 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderCommissions = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		WSPreOrderPrdGroupMustExistReasons = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSPreOrderDiscounts = (ICollection<WSPreOrderDiscounts>)new HashSet<WSPreOrderDiscounts>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSPreOrder_Lang = (ICollection<WSPreOrder_Lang>)new HashSet<WSPreOrder_Lang>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
	}
}
