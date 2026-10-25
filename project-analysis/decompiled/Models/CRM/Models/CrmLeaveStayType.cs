using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLeaveStayTypeMetadata))]
public class CrmLeaveStayType
{
	public int LeaveStayTypeID { get; set; }

	public string LeaveStayType { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? OrderView { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<CrmLeaveStayType_Lang> CrmLeaveStayType_Lang { get; set; }

	public virtual Users Users { get; set; }

	public CrmLeaveStayType()
	{
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmLeaveStayType_Lang = (ICollection<CrmLeaveStayType_Lang>)new HashSet<CrmLeaveStayType_Lang>();
	}
}
