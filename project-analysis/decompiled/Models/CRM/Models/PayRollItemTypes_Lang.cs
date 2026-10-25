using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollItemTypes_LangMetadata))]
public class PayRollItemTypes_Lang
{
	public int PayRollItemTypeLangID { get; set; }

	public int PayRollItemTypeId { get; set; }

	public int LanguageID { get; set; }

	public string ItemType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollItemTypes PayRollItemTypes { get; set; }
}
