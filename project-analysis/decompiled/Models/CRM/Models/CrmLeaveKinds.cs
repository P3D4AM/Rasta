using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLeaveKindsMetadata))]
public class CrmLeaveKinds
{
	public int LeaveKindID { get; set; }

	public string LeaveKind { get; set; }

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

	public virtual ICollection<CrmLeaveKinds_Lang> CrmLeaveKinds_Lang { get; set; }

	public virtual Users Users { get; set; }

	public CrmLeaveKinds()
	{
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmLeaveKinds_Lang = (ICollection<CrmLeaveKinds_Lang>)new HashSet<CrmLeaveKinds_Lang>();
	}
}
