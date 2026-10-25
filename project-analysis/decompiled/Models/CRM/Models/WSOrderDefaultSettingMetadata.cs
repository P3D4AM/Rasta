using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderDefaultSettingMetadata
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
}
