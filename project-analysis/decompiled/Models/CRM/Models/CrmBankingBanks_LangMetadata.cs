using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmBankingBanks_LangMetadata
{
	[Key]
	public int CrmBankingBankLangID { get; set; }

	public int BankingBankID { get; set; }

	public int LanguageID { get; set; }

	public string BankName { get; set; }

	public string BankDesc { get; set; }
}
