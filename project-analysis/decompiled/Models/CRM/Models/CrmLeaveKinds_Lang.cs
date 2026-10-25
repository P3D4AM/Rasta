using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLeaveKinds_LangMetadata))]
public class CrmLeaveKinds_Lang
{
	public int CrmLeaveKindLangID { get; set; }

	public int LeaveKindID { get; set; }

	public int LanguageID { get; set; }

	public string LeaveKind { get; set; }

	public virtual CrmLeaveKinds CrmLeaveKinds { get; set; }

	public virtual Languages Languages { get; set; }
}
