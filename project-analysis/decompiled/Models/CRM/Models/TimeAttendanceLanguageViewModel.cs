using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class TimeAttendanceLanguageViewModel
{
	public int? TimeAttendanceId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmDate")]
	public DateTime? tmDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmDate")]
	public string tmDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmUser")]
	public int? tmUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmUser")]
	public string tmUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryBase")]
	public string tmEntryBase { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryTime")]
	public string tmEntryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryDelay")]
	public int? tmEntryDelay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryRegisterIpAddress")]
	public string tmEntryRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitBase")]
	public string tmExitBase { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitTime")]
	public string tmExitTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitHurry")]
	public int? tmExitHurry { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitRegisterIpAddress")]
	public string tmExitRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctmDescriptionRequest")]
	public string tmDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryChanges")]
	public string tmEntryChanges { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitChanges")]
	public string tmExitChanges { get; set; }

	public int? tmExitHurryAllowMin { get; set; }

	public int? tmEntryDelayAllowMin { get; set; }

	public int? TimeAttendanceDetailId { get; set; }

	public int? Mode { get; set; }

	public string tmEntryDelayStr { get; set; }

	public string tmExitHurryStr { get; set; }

	public int? tmLeaveId { get; set; }

	public int? tmLeaveTypeId { get; set; }

	public string tmLeaveType { get; set; }

	public int? tmShiftWorkingTimeId { get; set; }

	public bool? tmEntryIsTemp { get; set; }

	public bool? tmExitIsTemp { get; set; }
}
