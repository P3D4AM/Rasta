using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLeaveStayType_LangMetadata))]
public class CrmLeaveStayType_Lang
{
	public int CrmLeaveStayTypeLangID { get; set; }

	public int LeaveStayTypeID { get; set; }

	public int LanguageID { get; set; }

	public string LeaveStayType { get; set; }

	public virtual CrmLeaveStayType CrmLeaveStayType { get; set; }

	public virtual Languages Languages { get; set; }
}
