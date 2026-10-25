using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderDefaultSettingMetadata))]
public class WSOrderDefaultSetting
{
	public int OrderSettingID { get; set; }

	public string Title { get; set; }

	public string Subject { get; set; }

	public int? GuarantyId { get; set; }

	public decimal? TaxIndex { get; set; }

	public bool? CalculateTax { get; set; }

	public string SpecialWord { get; set; }

	public string DescriptionI { get; set; }

	public string DescriptionII { get; set; }

	public int? PrintFormatId { get; set; }

	public int? RightLogoId { get; set; }

	public int? LeftLogoId { get; set; }

	public int? SignatureId { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string SettingTitle { get; set; }

	public Guid? GUId { get; set; }

	public string SigningI { get; set; }

	public string SigningII { get; set; }

	public string SigningIII { get; set; }

	public string AccountNumberI { get; set; }

	public string AccountShabaNumberI { get; set; }

	public string AccountNumberII { get; set; }

	public string AccountShabaNumberII { get; set; }

	public int? ReferUserId { get; set; }

	public int? OrderOprID { get; set; }

	public bool? AutoGenerateOrdSerial { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string Note { get; set; }

	public int? CurrencyUnitId { get; set; }

	public int? DeliveryTermId { get; set; }

	public int? VerifierRequestId { get; set; }

	public int? DefWHId { get; set; }

	public int? DefPrdPriceGroupId { get; set; }

	public int? SellerId { get; set; }

	public int? EmailUsersInfoId { get; set; }

	public int? EmailUserDefaultSettingId { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int? SaleCenterId { get; set; }

	public int? DefPayTypeId { get; set; }

	public int? SettlementTypeId { get; set; }

	public int? DefAutoAddCnvsCmpQuickRegisterDefSettingId { get; set; }

	public string DefAutoAddCnvsDesc { get; set; }

	public bool? IsDefIssueQuickOrder { get; set; }

	public bool? AutoInsertOrdPay { get; set; }

	public decimal? TaxIndexItem { get; set; }

	public bool? CalculateTaxItem { get; set; }

	public bool? AddPrdValidity { get; set; }

	public string AddPrdValidityPrjTitle { get; set; }

	public short? PublicMode { get; set; }

	public int? CurrencyUnitIdI { get; set; }

	public int? SaleAreaId { get; set; }

	public bool? ActiveInOrder { get; set; }

	public bool? ActiveInQuickOrder { get; set; }

	public string AccessUserJson { get; set; }

	public bool? IsDefIssueOrder { get; set; }

	public virtual EmailUserDefaultSetting EmailUserDefaultSetting { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual WSDeliveryTerms WSDeliveryTerms { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSGuaranty WSGuaranty { get; set; }

	public virtual WSLogo WSLogo { get; set; }

	public virtual WSLogo WSLogo1 { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderDefaultSetting_Lang> WSOrderDefaultSetting_Lang { get; set; }

	public virtual WSOrderOpr WSOrderOpr { get; set; }

	public virtual WSOrderPaymentTypes WSOrderPaymentTypes { get; set; }

	public virtual WSProductPriceGroup WSProductPriceGroup { get; set; }

	public virtual WSSaleAreas WSSaleAreas { get; set; }

	public virtual WSSaleCenters WSSaleCenters { get; set; }

	public virtual WSSettlementType WSSettlementType { get; set; }

	public virtual WSSignature WSSignature { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual CrmCompanyQuickRegisterDefSetting CrmCompanyQuickRegisterDefSetting1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public WSOrderDefaultSetting()
	{
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderDefaultSetting_Lang = (ICollection<WSOrderDefaultSetting_Lang>)new HashSet<WSOrderDefaultSetting_Lang>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
