using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmBankingAccountType_LangMetadata))]
public class CrmBankingAccountType_Lang
{
	public int CrmBankingAccountTypeLangID { get; set; }

	public int BankingAccountTypeID { get; set; }

	public int LanguageID { get; set; }

	public string AccountType { get; set; }

	public virtual CrmBankingAccountType CrmBankingAccountType { get; set; }

	public virtual Languages Languages { get; set; }
}
