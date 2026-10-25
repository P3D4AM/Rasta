using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollItemTypes_LangMetadata
{
	[Key]
	public int PayRollItemTypeLangID { get; set; }

	public string ItemType { get; set; }
}
