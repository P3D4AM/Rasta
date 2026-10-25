using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCompanyAddresses_LangMetadata
{
	[Key]
	public int CrmCompanyAddressLangID { get; set; }

	public int CompanyAddressId { get; set; }

	public int LanguageID { get; set; }

	public string CompanyAddress { get; set; }

	public string cmpaddDesc { get; set; }
}
