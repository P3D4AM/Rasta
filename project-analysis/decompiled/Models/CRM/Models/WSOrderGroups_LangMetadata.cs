using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSOrderGroups_LangMetadata
{
	[Key]
	public int WSOrderGroupLangID { get; set; }

	public int OrderGroupId { get; set; }

	public int LanguageID { get; set; }

	public string OrderGroupName { get; set; }
}
