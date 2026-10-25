using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmTimeAttendanceLogMetadata))]
public class CrmTimeAttendanceLog
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

	public int? LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }
}
