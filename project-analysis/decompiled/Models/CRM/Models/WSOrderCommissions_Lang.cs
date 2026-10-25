using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderCommissions_LangMetadata))]
public class WSOrderCommissions_Lang
{
	public int WSOrderCommissionLangID { get; set; }

	public int OrderCommissionId { get; set; }

	public int LanguageID { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public string CommRateDesc { get; set; }

	public string CommDesc { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderCommissions WSOrderCommissions { get; set; }
}
