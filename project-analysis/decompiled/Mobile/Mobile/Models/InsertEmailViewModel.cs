using System;

namespace Mobile.Models;

public class InsertEmailViewModel
{
	public string EmailSubject { get; set; }

	public string EmailBody { get; set; }

	public int EmailPriorityId { get; set; }

	public int EmailUsersInfoId { get; set; }

	public int EmailSettingId { get; set; }

	public string EmailAddress { get; set; }

	public int? EmailCmpId { get; set; }

	public int? EmailCmpPrsId { get; set; }

	public int? EmailCmpPrjId { get; set; }

	public string EmailCmpPrsName { get; set; }

	public string EmailCmpName { get; set; }

	public string EmailPrsJob { get; set; }

	public DateTime EmailStartDateTime { get; set; }

	public string EmailStartDatePersian { get; set; }

	public bool? IsNeedPdf { get; set; }

	public int? LanguageId { get; set; }
}
