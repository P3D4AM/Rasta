using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollList_LangMetadata
{
	[Key]
	public int PayRollListLangID { get; set; }

	public int PayRollListId { get; set; }

	public int LanguageID { get; set; }

	public string ListTitle { get; set; }

	public int ListYear { get; set; }
}
