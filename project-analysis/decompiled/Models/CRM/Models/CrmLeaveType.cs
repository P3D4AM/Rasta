using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLeaveTypeMetadata))]
public class CrmLeaveType
{
	public int LeaveTypeID { get; set; }

	public string LeaveType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? LeaveOpr { get; set; }

	public string TermText { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance { get; set; }

	public virtual Users Users { get; set; }

	public CrmLeaveType()
	{
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmTimeAttendance = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
	}
}
