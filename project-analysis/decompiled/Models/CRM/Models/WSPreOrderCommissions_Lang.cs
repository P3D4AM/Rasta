using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderCommissions_LangMetadata))]
public class WSPreOrderCommissions_Lang
{
	public int WSPreOrderCommissionLangID { get; set; }

	public int PreOrderCommissionId { get; set; }

	public int LanguageID { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public string CommRateDesc { get; set; }

	public string CommDesc { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderCommissions WSPreOrderCommissions { get; set; }
}
