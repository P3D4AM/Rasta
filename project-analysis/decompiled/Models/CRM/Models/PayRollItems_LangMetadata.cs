using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollItems_LangMetadata
{
	[Key]
	public int PayRollItemLangID { get; set; }

	public int PayRollItemId { get; set; }

	public int LanguageID { get; set; }

	public string ItemName { get; set; }
}
