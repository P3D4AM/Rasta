using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderDefaultSettingLanguageViewModel
{
	[Key]
	public int OrderSettingID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSubject")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Subject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetGuarantyId")]
	public int? GuarantyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetTaxIndex")]
	public decimal? TaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetCalculateTax")]
	public bool? CalculateTax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSpecialWord")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SpecialWord { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetNote")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Note { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetDescriptionI")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DescriptionI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetDescriptionII")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DescriptionII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetPrintFormatId")]
	public int? PrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetRightLogoId")]
	public int? RightLogoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetLeftLogoId")]
	public int? LeftLogoId { get; set; }

	public int? SignatureId { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSettingTitle")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SettingTitle { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSigningI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SigningI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSigningII")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SigningII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSigningIII")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SigningIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetAccountNumberI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountNumberI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetAccountShabaNumberI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountShabaNumberI { get; set; }

	public string AccountNumberII { get; set; }

	public string AccountShabaNumberII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetReferUserId")]
	public int? ReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetOrderOprID")]
	public int? OrderOprID { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetAutoGenerateOrdSerial")]
	public bool? AutoGenerateOrdSerial { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string Title_Lang { get; set; }

	public string Subject_Lang { get; set; }

	public string SpecialWord_Lang { get; set; }

	public string DescriptionI_Lang { get; set; }

	public string DescriptionII_Lang { get; set; }

	public string SigningI_Lang { get; set; }

	public string SigningII_Lang { get; set; }

	public string SigningIII_Lang { get; set; }

	public string Note_Lang { get; set; }

	public string SettingTitle_Lang { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string AppTypeHelp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetCurrencyUnitId")]
	public int? CurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetDeliveryTermId")]
	public int? DeliveryTermId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetVerifierRequestId")]
	public int? VerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetWHId")]
	public int? DefWHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetPrdPriceGroupId")]
	public int? DefPrdPriceGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSellerId")]
	public int? SellerId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetEmailUsersInfoId")]
	public int? EmailUsersInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetEmailUserDefaultSettingId")]
	public int? EmailUserDefaultSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetVerificationWorkFlowId")]
	public int? VerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSaleCenterId")]
	public int? SaleCenterId { get; set; }

	public string SaleCenterName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetPayTypeId")]
	public int? DefPayTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetSettlementTypeId")]
	public int? SettlementTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetIsDefIssueQuickOrder")]
	public bool? IsDefIssueQuickOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetAutoInsertOrdPay")]
	public bool? AutoInsertOrdPay { get; set; }

	public int? SaveDefIssueQuickOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetTaxIndexItem")]
	public decimal? TaxIndexItem { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetCalculateTaxItem")]
	public bool? CalculateTaxItem { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetAddPrdValidity")]
	public bool? AddPrdValidity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetAddPrdValidityPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AddPrdValidityPrjTitle { get; set; }

	public string AddPrdValidityPrjTitle_Lang { get; set; }

	public int? CurrencyUnitIdI { get; set; }

	public int? SaleAreaId { get; set; }

	public short? PublicMode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetActiveInOrder")]
	public bool? ActiveInOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetActiveInQuickOrder")]
	public bool? ActiveInQuickOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefSetIsDefIssueOrder")]
	public bool? IsDefIssueOrder { get; set; }

	public string AccessUserJson { get; set; }

	public int? SaveDefSettings { get; set; }
}
