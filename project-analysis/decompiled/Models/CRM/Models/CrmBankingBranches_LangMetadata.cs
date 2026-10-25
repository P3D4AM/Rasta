using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmBankingBranches_LangMetadata
{
	[Key]
	public int CrmBankingBrancheLangID { get; set; }

	public int BankingBranchID { get; set; }

	public int LanguageID { get; set; }

	public string BranchName { get; set; }

	public string BranchAddress { get; set; }

	public string BranchDesc { get; set; }
}
