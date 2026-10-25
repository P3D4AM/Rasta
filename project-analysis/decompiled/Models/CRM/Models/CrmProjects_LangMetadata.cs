namespace CRM.Models;

public class CrmProjects_LangMetadata
{
	public int CrmProjectsLangID { get; set; }

	public int ProjectID { get; set; }

	public int LanguageID { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public string prjPostFix { get; set; }
}
