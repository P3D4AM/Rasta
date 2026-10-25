using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSBuyOrderDefaultSettingLanguageViewModel
{
	[Key]
	public int BuyOrderDefaultSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetReferUserId")]
	public int ReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetSettingTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SettingTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetBuyOrderOprId")]
	public int? BuyOrderOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetSubject")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Subject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetTaxIndex")]
	public decimal? TaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetCalculateTax")]
	public bool? CalculateTax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetTaxIndexItem")]
	public decimal? TaxIndexItem { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetCalculateTaxItem")]
	public bool? CalculateTaxItem { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetPrintFormatId")]
	public int? PrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetNote")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Note { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetCurrencyUnitId")]
	public int? CurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetDeliveryTerm")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DeliveryTerm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetVerificationWorkFlowId")]
	public int? VerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetIsPublic")]
	public bool? IsPublic { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefSetCurrencyUnitIdI")]
	public int? CurrencyUnitIdI { get; set; }

	public string SettingTitle_Lang { get; set; }

	public string Title_Lang { get; set; }

	public string Subject_Lang { get; set; }

	public string Note_Lang { get; set; }

	public string DeliveryTerm_Lang { get; set; }
}
