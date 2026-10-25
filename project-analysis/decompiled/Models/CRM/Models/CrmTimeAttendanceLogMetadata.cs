using System;

namespace CRM.Models;

public class CrmTimeAttendanceLogMetadata
{
	public int TimeAttendanceLogId { get; set; }

	public DateTime tmlDate { get; set; }

	public string tmlDatePersian { get; set; }

	public int tmlTypeId { get; set; }

	public int tmlUserId { get; set; }

	public DateTime tmlEntryTime { get; set; }

	public string tmlEntryRegisterIP { get; set; }

	public DateTime? tmlExitTime { get; set; }

	public string tmlExitRegisterIP { get; set; }

	public string tmlDescription { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public short tmlYear1 { get; set; }

	public int tmlDay { get; set; }

	public int tmlDayOfWeek { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
