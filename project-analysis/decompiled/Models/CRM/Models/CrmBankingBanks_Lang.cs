using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmBankingBanks_LangMetadata))]
public class CrmBankingBanks_Lang
{
	public int CrmBankingBankLangID { get; set; }

	public int BankingBankID { get; set; }

	public int LanguageID { get; set; }

	public string BankName { get; set; }

	public string BankDesc { get; set; }

	public virtual CrmBankingBanks CrmBankingBanks { get; set; }

	public virtual Languages Languages { get; set; }
}
