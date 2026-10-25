using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCreditDuration_LangMetadata))]
public class WSCreditDuration_Lang
{
	public int WSCreditDurationLangID { get; set; }

	public int CreditDurationID { get; set; }

	public int LanguageID { get; set; }

	public string CreditDuration { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCreditDuration WSCreditDuration { get; set; }
}
