using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCompanyMoneyBag_LangMetadata
{
	[Key]
	public int CrmCompanyMoneyBagLangID { get; set; }

	public int CompanyMoneyBagId { get; set; }

	public int LanguageID { get; set; }

	public string CmpMnBgDesc { get; set; }
}
