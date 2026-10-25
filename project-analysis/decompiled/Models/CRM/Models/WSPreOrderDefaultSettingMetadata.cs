using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSPreOrderDefaultSettingMetadata
{
	[Key]
	public int PreOrderSettingID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetSubject")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Subject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetGuarantyId")]
	public int? GuarantyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetPayConditionId")]
	public int? PayConditionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetDeliveryTimeId")]
	public int? DeliveryTimeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetCreditDurationId")]
	public int? CreditDurationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetTaxIndex")]
	public decimal? TaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetCalculateTax")]
	public bool? CalculateTax { get; set; }

	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SpecialWord { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetDescriptionI")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DescriptionI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetDescriptionII")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DescriptionII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetPrintFormatId")]
	public int? PrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetRightLogoId")]
	public int? RightLogoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetLeftLogoId")]
	public int? LeftLogoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetSigningI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SigningI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetSigningII")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SigningII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetSigningIII")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SigningIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetAccountNumberI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountNumberI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetAccountShabaNumberI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountShabaNumberI { get; set; }

	public string AccountNumberII { get; set; }

	public string AccountShabaNumberII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetAddress")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Address { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetTelephone")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Telephone { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetFax")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Fax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetWebSite")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string WebSite { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetEmail")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Email { get; set; }

	public int? SignatureId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetVerifierRequestId")]
	public int? VerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetUserId")]
	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSettingTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SettingTitle { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetReferUserId")]
	public int? ReferUserId { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDefSetPreOrderOprID")]
	public int? PreOrderOprID { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
