using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCompanyAddressType_LangMetadata
{
	[Key]
	public int CrmCompanyAddressTypeLangID { get; set; }

	public int CompanyAddressTypeId { get; set; }

	public int LanguageID { get; set; }

	public string CompanyAddressTypeName { get; set; }
}
