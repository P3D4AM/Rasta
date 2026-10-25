using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSPreOrderCommissions_LangMetadata
{
	[Key]
	public int WSPreOrderCommissionLangID { get; set; }

	public int PreOrderCommissionId { get; set; }

	public int LanguageID { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public string CommRateDesc { get; set; }

	public string CommDesc { get; set; }
}
