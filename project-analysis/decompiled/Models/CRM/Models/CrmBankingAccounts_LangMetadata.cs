using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmBankingAccounts_LangMetadata
{
	[Key]
	public int CrmBankingAccountLangID { get; set; }

	public int BankingAccountID { get; set; }

	public int LanguageID { get; set; }

	public string AccountTitle { get; set; }

	public string AccountDesc { get; set; }
}
