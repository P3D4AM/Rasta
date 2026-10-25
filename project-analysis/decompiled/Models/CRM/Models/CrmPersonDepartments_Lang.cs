using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmPersonDepartments_LangMetadata))]
public class CrmPersonDepartments_Lang
{
	public int CrmPersonDepartmentsLangID { get; set; }

	public int PersonDepartmentId { get; set; }

	public int LanguageID { get; set; }

	public string PersonDepartment { get; set; }

	public virtual CrmPersonDepartments CrmPersonDepartments { get; set; }

	public virtual Languages Languages { get; set; }
}
