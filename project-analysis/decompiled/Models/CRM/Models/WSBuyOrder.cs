using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderMetadata))]
public class WSBuyOrder
{
	public int BuyOrderID { get; set; }

	public int? BuyOrderOprId { get; set; }

	public int? PreBuyOrderId { get; set; }

	public int? PreBuyOrderVerifierId { get; set; }

	public string bordTitle { get; set; }

	public long bordNumber { get; set; }

	public string bordOrderNumber { get; set; }

	public string bordDate { get; set; }

	public string bordOrderDate { get; set; }

	public DateTime? bordOrderDateTime { get; set; }

	public int bordCompanyId { get; set; }

	public int? bordCompanyPersonId { get; set; }

	public int? bordProjectId { get; set; }

	public string bordSubject { get; set; }

	public int? bordItemCount { get; set; }

	public decimal? bordItemsAmount { get; set; }

	public decimal? bordDiscount { get; set; }

	public decimal? bordSumAmount { get; set; }

	public decimal? bordTax { get; set; }

	public decimal? bordTaxIndex { get; set; }

	public bool? bordCalculateTax { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public string bordTotalAmountStr { get; set; }

	public bool? bordIsVerified { get; set; }

	public int? bordStatusId { get; set; }

	public bool? bordIsFixed { get; set; }

	public int? bordPrintFormatId { get; set; }

	public string bordImportDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? bordVerifierId { get; set; }

	public DateTime? bordVerifiedRegisterDate { get; set; }

	public string bordVerifiedRegisterDatePersian { get; set; }

	public int? bordFirstRegisterUserId { get; set; }

	public int? bordSettlementTypeId { get; set; }

	public string bordDay { get; set; }

	public string bordTime { get; set; }

	public decimal? bordTransportation { get; set; }

	public int? bordReferUserId { get; set; }

	public decimal? bordRound { get; set; }

	public decimal? bordDiscountPercent { get; set; }

	public string bordDiscountTitle { get; set; }

	public string bordNote { get; set; }

	public DateTime? bordDateTime { get; set; }

	public DateTime? bordImportDateTime { get; set; }

	public string bordcmpTitle { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? bordLinkAccCodeId { get; set; }

	public string bordLinkAccCode { get; set; }

	public int? bordLinkAccBuyOrderId { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public int? bordLinkAccVoucherId { get; set; }

	public string bordLinkAccVoucherNumber { get; set; }

	public int? bordCurrencyUnitId { get; set; }

	public int? bordFacilityCmpId { get; set; }

	public int? bordFacilityPrsId { get; set; }

	public int? bordFacilityPrjId { get; set; }

	public int? bordReqCmpId { get; set; }

	public int? bordReqPrsId { get; set; }

	public int? bordReqPrjId { get; set; }

	public string bordDeliveryTerm { get; set; }

	public DateTime? bordDeliveryDate { get; set; }

	public string bordDeliveryDatePersian { get; set; }

	public bool? bordTaxCleared { get; set; }

	public DateTime? bordTaxClearedDate { get; set; }

	public string bordTaxClearedDatePersian { get; set; }

	public decimal? bordFacilityCost { get; set; }

	public decimal? bordFacilityCostPercent { get; set; }

	public DateTime? bordSupplierDeliveryDate { get; set; }

	public string bordSupplierDeliveryDatePersian { get; set; }

	public string bordForwarderName { get; set; }

	public decimal? bordFreightCost { get; set; }

	public int? bordFreightCurrUnId { get; set; }

	public double? bordFreightCurrencyRate { get; set; }

	public decimal? bordFinalFreightCost { get; set; }

	public string bordCustomsPart { get; set; }

	public decimal? bordCustomsFee { get; set; }

	public int? bordCustomsCurrUnId { get; set; }

	public double? bordCustomsCurrencyRate { get; set; }

	public decimal? bordFinalCustomsFee { get; set; }

	public DateTime? bordFinalDeliveryDate { get; set; }

	public string bordFinalDeliveryDatePersian { get; set; }

	public decimal? bordTotalFinalCost { get; set; }

	public decimal? bordCommission { get; set; }

	public int? bordCommissionCurrUnId { get; set; }

	public double? bordCommissionCurrencyRate { get; set; }

	public decimal? bordFinalCommission { get; set; }

	public int? bordCostSheetId { get; set; }

	public string bordNumRef { get; set; }

	public double? bordItemsQty { get; set; }

	public decimal? bordItemsDiscount { get; set; }

	public decimal? bordItemsTax { get; set; }

	public int? bordDefaultSettingId { get; set; }

	public int? bordVerificationWorkFlowId { get; set; }

	public DateTime? bordLinkAccFirstTransferDate { get; set; }

	public DateTime? bordLinkAccLastTransferDate { get; set; }

	public string bordLinkAccBuyOrderIdStr { get; set; }

	public int? bordCurrencyUnitIdI { get; set; }

	public double? bordCurrencyUnitIRate { get; set; }

	public decimal? bordItemsAmountCurrencyI { get; set; }

	public decimal? bordDiscountCurrencyI { get; set; }

	public decimal? bordSumAmountCurrencyI { get; set; }

	public decimal? bordTaxCurrencyI { get; set; }

	public decimal? bordTotalAmountCurrencyI { get; set; }

	public string bordTotalAmountCurrencyIStr { get; set; }

	public decimal? bordTransportationCurrencyI { get; set; }

	public decimal? bordRoundCurrencyI { get; set; }

	public decimal? bordItemsDiscountCurrencyI { get; set; }

	public decimal? bordItemsTaxCurrencyI { get; set; }

	public string bordLinkAccData { get; set; }

	public string bordEditAfterFixInfoJs { get; set; }

	public int? bordSuppUserId { get; set; }

	public int? bordCId { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons1 { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons2 { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits2 { get; set; }

	public virtual ICollection<WSBuyOrder_Lang> WSBuyOrder_Lang { get; set; }

	public virtual WSBuyOrderOpr WSBuyOrderOpr { get; set; }

	public virtual WSBuyOrderStatus WSBuyOrderStatus { get; set; }

	public virtual WSCostSheets WSCostSheets { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits3 { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmCompany CrmCompany1 { get; set; }

	public virtual CrmCompany CrmCompany2 { get; set; }

	public virtual WSBuyOrderDefaultSetting WSBuyOrderDefaultSetting { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits31 { get; set; }

	public virtual WSBuyOrder WSBuyOrder1 { get; set; }

	public virtual WSBuyOrder WSBuyOrder2 { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual CrmProjects CrmProjects1 { get; set; }

	public virtual CrmProjects CrmProjects2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public virtual Users Users5 { get; set; }

	public WSBuyOrder()
	{
		WSBuyOrder_Lang = (ICollection<WSBuyOrder_Lang>)new HashSet<WSBuyOrder_Lang>();
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderPayments = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSCostSheetItems = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
	}
}
