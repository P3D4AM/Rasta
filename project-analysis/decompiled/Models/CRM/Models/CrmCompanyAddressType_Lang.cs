using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyAddressType_LangMetadata))]
public class CrmCompanyAddressType_Lang
{
	public int CrmCompanyAddressTypeLangID { get; set; }

	public int CompanyAddressTypeId { get; set; }

	public int LanguageID { get; set; }

	public string CompanyAddressTypeName { get; set; }

	public virtual CrmCompanyAddressType CrmCompanyAddressType { get; set; }

	public virtual Languages Languages { get; set; }
}
