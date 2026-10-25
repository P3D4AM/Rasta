using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class AddTelToCmpAndPrsViewModel
{
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddTelToCmpAndPrsCompanyName")]
	public string CompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTel")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTel")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTelII")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPreTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelII")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelIIDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelIIDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFax")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFaxDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFaxDesc { get; set; }

	public int CompanyPersonID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddTelToCmpAndPrsPersonName")]
	public string PersonName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsPreTel")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTel")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelII")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFax")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFaxDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFaxDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsMobile")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsMobile { get; set; }

	public string cmpTelDesc_Lang { get; set; }

	public string cmpTelIIDesc_Lang { get; set; }

	public string cmpFaxDesc_Lang { get; set; }

	public string prsTelDesc_Lang { get; set; }

	public string prsFaxDesc_Lang { get; set; }
}
