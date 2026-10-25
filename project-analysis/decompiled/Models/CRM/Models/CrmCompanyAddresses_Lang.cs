using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyAddresses_LangMetadata))]
public class CrmCompanyAddresses_Lang
{
	public int CrmCompanyAddressLangID { get; set; }

	public int CompanyAddressId { get; set; }

	public int LanguageID { get; set; }

	public string CompanyAddress { get; set; }

	public string cmpaddDesc { get; set; }

	public virtual CrmCompanyAddresses CrmCompanyAddresses { get; set; }

	public virtual Languages Languages { get; set; }
}
