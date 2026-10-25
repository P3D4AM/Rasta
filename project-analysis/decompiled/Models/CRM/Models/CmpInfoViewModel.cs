using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CmpInfoViewModel
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTypeId")]
	public int? cmpTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupId")]
	public int? cmpGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSubGroupId")]
	public int? cmpSubGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdII")]
	public int? cmpGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIII")]
	public int? cmpGroupIdIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIV")]
	public int? cmpGroupIdIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpRegistrationNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpRegistrationNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEconomicCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpEconomicCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNationalCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpNationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddress")]
	[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpZipCode { get; set; }

	public int pordId { get; set; }

	public string cmpName { get; set; }

	public string MultiGroups { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEffectiveDatePersian")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string cmpEffectiveDatePersian { get; set; }

	public string cmpAddress_Lang { get; set; }
}
