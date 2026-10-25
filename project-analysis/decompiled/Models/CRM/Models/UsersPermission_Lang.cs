using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UsersPermission_LangMetadata))]
public class UsersPermission_Lang
{
	public int UsersPermissionLangID { get; set; }

	public int ID { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual UsersPermission UsersPermission { get; set; }
}
