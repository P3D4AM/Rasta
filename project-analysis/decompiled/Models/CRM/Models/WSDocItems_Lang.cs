using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDocItems_LangMetadata))]
public class WSDocItems_Lang
{
	public int WSDocItemsLangID { get; set; }

	public int DocItemID { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public string PrdNickname { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDocItems WSDocItems { get; set; }
}
