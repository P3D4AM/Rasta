using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSPreOrderLanguageViewModel
{
	[Key]
	public int PreOrderID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordNumber")]
	[RegularExpression("^\\d+$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public long pordNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblpordDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string pordDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? pordCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordCompanyPersonId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? pordCompanyPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordProjectId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? pordProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordSubject")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDiscount")]
	public decimal? pordDiscount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordTaxIndex")]
	public decimal? pordTaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordCalculateTax")]
	public bool? pordCalculateTax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordVerifierRequestId")]
	public int? pordVerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordStatusId")]
	public int? pordStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordGuarantyId")]
	public int? pordGuarantyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordPayConditionId")]
	public int? pordPayConditionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDeliveryTimeId")]
	public int? pordDeliveryTimeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordCreditDurationId")]
	public int? pordCreditDurationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordSpecialWord")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordSpecialWord { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDescriptionI")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordDescriptionI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDescriptionII")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordDescriptionII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordPrintFormatId")]
	public int? pordPrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordRLogoId")]
	public int? pordRLogoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordLLogoId")]
	public int? pordLLogoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordSigningI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordSigningI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordSigningII")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordSigningII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordSigningIII")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordSigningIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordAccountNumberI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordAccountNumberI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordAccountShabaNumberI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordAccountShabaNumberI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordAddress")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordTelephone")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordTelephone { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordFax")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordWebSite")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordWebSite { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordEmail")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDiscountTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordDiscountTitle { get; set; }

	[Range(typeof(decimal), "0", "100", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorMustBetweenRange")]
	public decimal? pordDiscountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordTransportation")]
	public decimal? pordTransportation { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? pordReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordRound")]
	public decimal? pordRound { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordcmpTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordcmpTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDeliveryTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordDeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderOprID")]
	public int? PreOrderOprID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordExpireDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordExpireDate { get; set; }

	public DateTime? pordExpireDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordExpireTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordExpireTime { get; set; }

	public string AppType { get; set; }

	public int? pordItemCount { get; set; }

	public decimal? pordItemsAmount { get; set; }

	public decimal? pordInstallAmount { get; set; }

	public DateTime? pordDeliveryDateTime { get; set; }

	public DateTime? pordDateTime { get; set; }

	public DateTime? pordImportDateTime { get; set; }

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

	public decimal? pordSumAmount { get; set; }

	public decimal? pordTax { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordTotalAmountStr { get; set; }

	public bool? pordIsVerified { get; set; }

	public int? pordVerifierId { get; set; }

	public DateTime? pordVerifiedRegisterDate { get; set; }

	public string pordVerifiedRegisterDatePersian { get; set; }

	public bool? pordIsFixed { get; set; }

	public int? pordDescriptionId { get; set; }

	public string pordAccountNumberII { get; set; }

	public string pordAccountShabaNumberII { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordVerificationWorkFlowId")]
	public int? pordVerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordCurrencyUnitId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? pordCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordNumberRevision")]
	[RegularExpression("^\\d+$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public long? pordNumberRevision { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDeliveryTermId")]
	public int? pordDeliveryTermId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDeliveryEndDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordDeliveryEndDate { get; set; }

	public DateTime? pordDeliveryEndDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDeliveryEndTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordDeliveryEndTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordNumRef")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordNumRef { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordTypeId")]
	public int? pordTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefWHId")]
	public int? pordDefWHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefPrdPriceGroupId")]
	public int? pordDefPrdPriceGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordSellerId")]
	public int? pordSellerId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordEmailUsersInfoId")]
	public int? pordEmailUsersInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordEmailUserDefaultSettingId")]
	public int? pordEmailUserDefaultSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordSaleCenterId")]
	public int? pordSaleCenterId { get; set; }

	public string pordSaleCenterName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefPayTypeId")]
	public int? pordDefPayTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDeadlineDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordDeadlineDatePersian { get; set; }

	public DateTime? pordDeadlineDate { get; set; }

	public int? pordDefaultSettingId { get; set; }

	public string pordDeliveryDay { get; set; }

	public string pordDeliveryEndDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordCurrencyUnitIdI")]
	public int? pordCurrencyUnitIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordCurrencyUnitIRate")]
	public double? pordCurrencyUnitIRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordSaleAreaId")]
	public int? pordSaleAreaId { get; set; }

	public string pordTitle_Lang { get; set; }

	public string pordSubject_Lang { get; set; }

	public string pordTotalAmountStr_Lang { get; set; }

	public string pordSpecialWord_Lang { get; set; }

	public string pordDescriptionI_Lang { get; set; }

	public string pordDescriptionII_Lang { get; set; }

	public string pordSigningI_Lang { get; set; }

	public string pordSigningII_Lang { get; set; }

	public string pordSigningIII_Lang { get; set; }

	public string pordAddress_Lang { get; set; }

	public string pordDiscountTitle_Lang { get; set; }

	public string pordcmpTitle_Lang { get; set; }
}
