using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UserGroups_LangMetadata))]
public class UserGroups_Lang
{
	public int UserGroupLangID { get; set; }

	public int UserGroupId { get; set; }

	public int LanguageID { get; set; }

	public string GroupName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual UserGroups UserGroups { get; set; }
}
