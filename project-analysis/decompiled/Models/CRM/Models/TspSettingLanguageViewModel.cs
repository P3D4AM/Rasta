using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class TspSettingLanguageViewModel
{
	[Key]
	public int TspSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspSettingTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingIdentify")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspIdentify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingPrivateKey")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string TspPrivateKey { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingSbc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspSbc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingScln")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspScln { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingScc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspScc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingCrn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspCrn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingBsrn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspBsrn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingTob")]
	public int? TspTob { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingCoName")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspCoName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingRegistrationNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspRegistrationNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingEconomicCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspEconomicCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingNationalCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspNationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingTel")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingCity")]
	public int? TspCityId { get; set; }

	public int? TspCountryId { get; set; }

	public int? TspProvinceId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingAddress")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingZipCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingSendDateType")]
	public int? TspSendDateType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TspSettingTspSendPay")]
	public bool? TspSendPay { get; set; }

	public string TspSettingTitle_Lang { get; set; }

	public string TspCoName_Lang { get; set; }

	public string TspAddress_Lang { get; set; }
}
