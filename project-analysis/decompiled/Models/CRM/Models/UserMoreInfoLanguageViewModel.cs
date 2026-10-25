using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UserMoreInfoLanguageViewModel
{
	[Key]
	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoFName")]
	public string FName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoLName")]
	public string LName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoTel")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Tel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoTelDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoMobile")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Mobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoMobileII")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string MobileII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoAddress")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Address { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoFatherName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FatherName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoNationalCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string NationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoIdentityNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string IdentityNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMoreInfoInsuranceCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InsuranceCode { get; set; }

	public string FName_Lang { get; set; }

	public string LName_Lang { get; set; }

	public string TelDesc_Lang { get; set; }

	public string Address_Lang { get; set; }

	public string FatherName_Lang { get; set; }
}
