using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyMoneyBag_LangMetadata))]
public class CrmCompanyMoneyBag_Lang
{
	public int CrmCompanyMoneyBagLangID { get; set; }

	public int CompanyMoneyBagId { get; set; }

	public int LanguageID { get; set; }

	public string CmpMnBgDesc { get; set; }

	public virtual CrmCompanyMoneyBag CrmCompanyMoneyBag { get; set; }

	public virtual Languages Languages { get; set; }
}
