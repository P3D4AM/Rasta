using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollList_LangMetadata))]
public class PayRollList_Lang
{
	public int PayRollListLangID { get; set; }

	public int PayRollListId { get; set; }

	public int LanguageID { get; set; }

	public string ListTitle { get; set; }

	public int ListYear { get; set; }

	public int? ListMonth { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollList PayRollList { get; set; }
}
