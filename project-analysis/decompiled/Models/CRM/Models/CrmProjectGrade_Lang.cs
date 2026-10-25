using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectGrade_LangMetadata))]
public class CrmProjectGrade_Lang
{
	public int CrmProjectGradeID { get; set; }

	public int ProjectGradeID { get; set; }

	public int LanguageID { get; set; }

	public string ProjectGrade { get; set; }

	public virtual CrmProjectGrade CrmProjectGrade { get; set; }

	public virtual Languages Languages { get; set; }
}
