using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCallHistoryMetadata
{
	public int CallHistoryID { get; set; }

	public int CallTypeId { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PhoneNumber { get; set; }

	public int? CompanyID { get; set; }

	public string CallTime { get; set; }

	public string CallDate { get; set; }

	public string CallDay { get; set; }

	public int UserID { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? LineNumber { get; set; }

	public string CallerIDDetectData { get; set; }

	public Guid? GUId { get; set; }

	public string StartTime { get; set; }

	public string EndTime { get; set; }

	public string Duration { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? NumberEditedUserId { get; set; }

	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Note { get; set; }

	public int? NoteRegisterUserId { get; set; }

	public int? NoteEditedUserId { get; set; }

	public string AppType { get; set; }
}
