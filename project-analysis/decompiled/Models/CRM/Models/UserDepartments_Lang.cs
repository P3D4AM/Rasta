using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UserDepartments_LangMetadata))]
public class UserDepartments_Lang
{
	public int UserDepartmentsLangID { get; set; }

	public int DepartmentID { get; set; }

	public int LanguageID { get; set; }

	public string Department { get; set; }

	public string TicketFooterText { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual UserDepartments UserDepartments { get; set; }
}
