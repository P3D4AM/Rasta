using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

internal class WSOrderCommissions_LangMetadata
{
	[Key]
	public int WSOrderCommissionLangID { get; set; }

	public int OrderCommissionId { get; set; }

	public int LanguageID { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public string CommRateDesc { get; set; }

	public string CommDesc { get; set; }
}
