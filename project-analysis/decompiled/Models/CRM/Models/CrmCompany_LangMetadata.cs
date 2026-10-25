using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCompany_LangMetadata
{
	[Key]
	public int CrmCompanyLangID { get; set; }

	public int CompanyID { get; set; }

	public int LanguageID { get; set; }

	public string cmpName { get; set; }

	public string cmpFame { get; set; }

	public string cmpActivityType { get; set; }

	public string cmpTelDesc { get; set; }

	public string cmpTelIIDesc { get; set; }

	public string cmpFaxDesc { get; set; }

	public string cmpAddress { get; set; }

	public string cmpAddressDesc { get; set; }

	public string cmpInteresting { get; set; }

	public string cmpSpecialPoint { get; set; }

	public string cmpDescription { get; set; }

	public string cmpSpecialWordForCI { get; set; }

	public string cmpInquiry { get; set; }
}
