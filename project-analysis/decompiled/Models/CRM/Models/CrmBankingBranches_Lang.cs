using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmBankingBranches_LangMetadata))]
public class CrmBankingBranches_Lang
{
	public int CrmBankingBrancheLangID { get; set; }

	public int BankingBranchID { get; set; }

	public int LanguageID { get; set; }

	public string BranchName { get; set; }

	public string BranchAddress { get; set; }

	public string BranchDesc { get; set; }

	public virtual CrmBankingBranches CrmBankingBranches { get; set; }

	public virtual Languages Languages { get; set; }
}
