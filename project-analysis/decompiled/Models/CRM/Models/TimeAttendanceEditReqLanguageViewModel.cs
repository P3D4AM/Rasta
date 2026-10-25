using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class TimeAttendanceEditReqLanguageViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "tmDate")]
	public string tmDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmUser")]
	public int? tmUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmUser")]
	public string tmUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryTime")]
	public string tmCurrentEntryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryTime")]
	public string tmEntryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryRegisterIpAddress")]
	public string tmEntryRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryRegisterIpAddress")]
	public string tmCurrentEntryRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitTime")]
	public string tmExitTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitTime")]
	public string tmCurrentExitTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitRegisterIpAddress")]
	public string tmExitRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitRegisterIpAddress")]
	public string tmCurrentExitRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctmDescriptionRequest")]
	public string tmDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmDescription")]
	public string tmDescription_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmIsEntryRequest")]
	public bool? IsEntryRequest { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmIsExitRequest")]
	public bool? IsExitRequest { get; set; }

	public bool? IsEntryRequestDuplicate { get; set; }

	public bool? IsExitRequestDuplicate { get; set; }

	public int? ResendEntryRequestId { get; set; }

	public int? ResendExitRequestId { get; set; }

	public bool? EntryRequestIsRequired { get; set; }

	public int? tmShiftWorkingID { get; set; }

	public int? tmShiftWorkingTimeID { get; set; }

	public int? tmLeaveId { get; set; }

	public int? tmLeaveTypeId { get; set; }

	public int? tmExitTimeLateAllowMin { get; set; }

	public int? tmEntryTimeSoonAllowMin { get; set; }
}
