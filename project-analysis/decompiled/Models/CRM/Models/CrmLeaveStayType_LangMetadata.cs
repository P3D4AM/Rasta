using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLeaveStayType_LangMetadata
{
	[Key]
	public int CrmLeaveStayTypeLangID { get; set; }

	public int LeaveStayTypeID { get; set; }

	public int LanguageID { get; set; }

	public string LeaveStayType { get; set; }
}
