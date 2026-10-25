using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class UserGroups_LangMetadata
{
	[Key]
	public int UserGroupLangID { get; set; }

	public int UserGroupId { get; set; }

	public int LanguageID { get; set; }

	public string GroupName { get; set; }
}
