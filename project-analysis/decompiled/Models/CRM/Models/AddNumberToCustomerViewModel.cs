using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class AddNumberToCustomerViewModel
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpTitleId")]
	public int? cmpTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpActivityType")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpActivityType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpGroupId")]
	public int? cmpGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpSubGroupId")]
	public int? cmpSubGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpGroupIdII")]
	public int? cmpGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpGroupIdIII")]
	public int? cmpGroupIdIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpGroupIdIV")]
	public int? cmpGroupIdIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpTypeId")]
	public int? cmpTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpPresentationId")]
	public int? cmpPresentationId { get; set; }

	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpTel")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTel { get; set; }

	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelUpTo { get; set; }

	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPreTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpTelII")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelII { get; set; }

	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelUpToII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpFax")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpCountryId")]
	public int? cmpCountryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpProvinceId")]
	public int? cmpProvinceId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpCityId")]
	public int? cmpCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpAddress")]
	[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpPostBox")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPostBox { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddNumberToCustomerCmpReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cmpReferUserId { get; set; }

	public int Mode { get; set; }

	public string Person { get; set; }

	public string cmpName_Lang { get; set; }

	public string cmpActivityType_Lang { get; set; }

	public string cmpAddress_Lang { get; set; }
}
