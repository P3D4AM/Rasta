using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjects_LangMetadata))]
public class CrmProjects_Lang
{
	public int CrmProjectsLangID { get; set; }

	public int ProjectID { get; set; }

	public int LanguageID { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public string prjPostFix { get; set; }

	public string prjSubject { get; set; }

	public string prjTitleGroup { get; set; }

	public string prjDescI { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }
}
