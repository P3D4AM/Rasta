using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollItems_LangMetadata))]
public class PayRollItems_Lang
{
	public int PayRollItemLangID { get; set; }

	public int PayRollItemId { get; set; }

	public int LanguageID { get; set; }

	public string ItemName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollItems PayRollItems { get; set; }
}
