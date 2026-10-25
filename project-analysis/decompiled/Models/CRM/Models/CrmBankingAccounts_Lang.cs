using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmBankingAccounts_LangMetadata))]
public class CrmBankingAccounts_Lang
{
	public int CrmBankingAccountLangID { get; set; }

	public int BankingAccountID { get; set; }

	public int LanguageID { get; set; }

	public string AccountTitle { get; set; }

	public string AccountDesc { get; set; }

	public virtual CrmBankingAccounts CrmBankingAccounts { get; set; }

	public virtual Languages Languages { get; set; }
}
