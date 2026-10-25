using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspCheckDuplicateCompanyViewModel
{
	public int CompanyID { get; set; }

	public int cmpId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string cmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTitleId")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string CompanyWithTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTel")]
	public string cmpTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelII")]
	public string cmpTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFax")]
	public string cmpFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCountryId")]
	public string Country { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public string Provice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public string City { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddress")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CheckDupPrsLName")]
	public string prsName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CheckDupPrsTel")]
	public string prsTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelII")]
	public string prsTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CheckDupPrsFax")]
	public string prsFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CheckDupPrsMobile")]
	public string prsMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CheckDupPrsEmail")]
	public string prsEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CheckDupPrsEmailII")]
	public string prsEmailII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNumber")]
	public int? cmpNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpReferUserId")]
	public string ReferUser { get; set; }
}
