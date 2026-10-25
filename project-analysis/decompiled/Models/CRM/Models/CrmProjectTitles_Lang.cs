using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectTitles_LangMetadata))]
public class CrmProjectTitles_Lang
{
	public int CrmProjectTitlesLangID { get; set; }

	public int ProjectTitleID { get; set; }

	public int LanguageID { get; set; }

	public string ProjectTitle { get; set; }

	public string ProjectTitleDesc { get; set; }

	public string PrjPostFix { get; set; }

	public virtual CrmProjectTitles CrmProjectTitles { get; set; }

	public virtual Languages Languages { get; set; }
}
