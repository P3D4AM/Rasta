using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLeaveKinds_LangMetadata
{
	[Key]
	public int CrmLeaveKindLangID { get; set; }

	public int LeaveKindID { get; set; }

	public int LanguageID { get; set; }

	public string LeaveKind { get; set; }
}
