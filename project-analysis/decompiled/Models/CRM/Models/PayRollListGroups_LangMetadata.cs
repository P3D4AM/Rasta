using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollListGroups_LangMetadata
{
	[Key]
	public int PayRollListGroupLangID { get; set; }

	public int PayRollListGroupId { get; set; }

	public int LanguageID { get; set; }

	public string ListGroupName { get; set; }
}
