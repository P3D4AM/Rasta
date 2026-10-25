using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmBankingAccountType_LangMetadata
{
	[Key]
	public int CrmBankingAccountTypeLangID { get; set; }

	public int BankingAccountTypeID { get; set; }

	public int LanguageID { get; set; }

	public string AccountType { get; set; }
}
