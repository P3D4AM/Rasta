using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectsForbiddenForUser_LangMetadata))]
public class CrmProjectsForbiddenForUser_Lang
{
	public int CrmProjectsForbiddenForUserLangID { get; set; }

	public int ProjectsForbiddenForUserID { get; set; }

	public int LanguageID { get; set; }

	public string ForbiddenProjectTitle { get; set; }

	public virtual CrmProjectsForbiddenForUser CrmProjectsForbiddenForUser { get; set; }

	public virtual Languages Languages { get; set; }
}
