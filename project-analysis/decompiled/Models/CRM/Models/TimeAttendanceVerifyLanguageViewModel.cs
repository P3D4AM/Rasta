using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class TimeAttendanceVerifyLanguageViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "tmDate")]
	public string tmDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmDate")]
	public string tmDatePersianStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryTime")]
	public string tmEntryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryTime")]
	public string tmCurrentEntryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryRegisterIpAddress")]
	public string tmEntryRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryRegisterIpAddress")]
	public string tmCurrentEntryRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctmDescriptionRequest")]
	public string tmEntryDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitTime")]
	public string tmExitTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitTime")]
	public string tmCurrentExitTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitRegisterIpAddress")]
	public string tmExitRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitRegisterIpAddress")]
	public string tmCurrentExitRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctmDescriptionRequest")]
	public string tmExitDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmUser")]
	public int? tmUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmUser")]
	public string tmUser { get; set; }

	public bool? EntryRequestIsVerified { get; set; }

	public bool? ExitRequestIsVerified { get; set; }

	public bool? VerifyEntryRequest { get; set; }

	public bool? VerifyExitRequest { get; set; }

	public bool? UnVerifyEntryRequest { get; set; }

	public bool? UnVerifyExitRequest { get; set; }

	public string EntryUserLat { get; set; }

	public string EntryUserLng { get; set; }

	public string ExitUserLat { get; set; }

	public string ExitUserLng { get; set; }

	public int? EntryRequestId { get; set; }

	public int? EntryMessageId { get; set; }

	public int? EntryMessageDetailId { get; set; }

	public int? EntryMsgdTypeId { get; set; }

	public int? ExitRequestId { get; set; }

	public int? ExitMessageId { get; set; }

	public int? ExitMessageDetailId { get; set; }

	public int? ExitMsgdTypeId { get; set; }

	public bool? SetReadWhenDone { get; set; }

	public bool? VerifyEntryRequestIsRequired { get; set; }

	public bool? HasTwoRequests { get; set; }

	public int? RequestId { get; set; }

	public int? MessageId { get; set; }

	public int? MessageDetailId { get; set; }

	public int? MsgdTypeId { get; set; }

	public int? MsgdFromUserId { get; set; }

	public int? MsgdPriorityId { get; set; }

	public int? MsgdAttachRecId { get; set; }

	public int? MsgdAttachRecIdI { get; set; }

	public string tmDescription { get; set; }

	public string MapUserLat { get; set; }

	public string MapUserLng { get; set; }

	public int? tmEntryTimeVerifyUserId { get; set; }

	public DateTime? tmEntryTimeVerifyDate { get; set; }

	public string tmEntryTimeVerifyDatePersian { get; set; }

	public int? tmExitTimeVerifyUserId { get; set; }

	public DateTime? tmExitTimeVerifyDate { get; set; }

	public string tmExitTimeVerifyDatePersian { get; set; }

	public int? ShiftWorkingId { get; set; }

	public int? ShiftWorkingTimeId { get; set; }

	public DateTime? tmEntryBaseDateTime { get; set; }

	public string tmEntryBaseDatePersian { get; set; }

	public string tmEntryBaseDateI { get; set; }

	public int? tmEntryDelayAllowMin { get; set; }

	public DateTime? tmExitBaseDateTime { get; set; }

	public string tmExitBaseDatePersian { get; set; }

	public string tmExitBaseDateI { get; set; }

	public int? tmExitHurryAllowMin { get; set; }
}
