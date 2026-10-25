using System;

namespace Mobile.Models;

public class TimeAttendanceVerifyEditRequestViewModel
{
	public int? EntryRequestId { get; set; }

	public int? ExitRequestId { get; set; }

	public string tmDatePersian { get; set; }

	public int tmUserId { get; set; }

	public string tmEntryTime { get; set; }

	public string tmEntryRegisterIP { get; set; }

	public string tmExitTime { get; set; }

	public string tmExitRegisterIP { get; set; }

	public bool? VerifyEntryRequest { get; set; }

	public bool? UnVerifyEntryRequest { get; set; }

	public bool? VerifyExitRequest { get; set; }

	public bool? UnVerifyExitRequest { get; set; }

	public int? LanguageId { get; set; }

	public int? tmEntryTimeVerifyUserId { get; set; }

	public DateTime? tmEntryTimeVerifyDate { get; set; }

	public string tmEntryTimeVerifyDatePersian { get; set; }

	public int? tmExitTimeVerifyUserId { get; set; }

	public DateTime? tmExitTimeVerifyDate { get; set; }

	public string tmExitTimeVerifyDatePersian { get; set; }
}
