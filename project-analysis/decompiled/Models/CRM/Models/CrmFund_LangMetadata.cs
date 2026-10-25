using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmFund_LangMetadata
{
	[Key]
	public int CrmFundLangID { get; set; }

	public int FundId { get; set; }

	public int LanguageID { get; set; }

	public string FundDesc { get; set; }
}
