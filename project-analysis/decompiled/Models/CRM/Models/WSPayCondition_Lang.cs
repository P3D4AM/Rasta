using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPayCondition_LangMetadata))]
public class WSPayCondition_Lang
{
	public int WSPayConditionLangID { get; set; }

	public int PayConditionID { get; set; }

	public int LanguageID { get; set; }

	public string PayCondition { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPayCondition WSPayCondition { get; set; }
}
