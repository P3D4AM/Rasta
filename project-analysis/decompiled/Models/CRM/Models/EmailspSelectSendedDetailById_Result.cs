using System;

namespace CRM.Models;

public class EmailspSelectSendedDetailById_Result
{
	public int EmailSendHeaderId { get; set; }

	public int UserId { get; set; }

	public string Sender { get; set; }

	public string Subject { get; set; }

	public string Body { get; set; }

	public DateTime StartDateTime { get; set; }

	public string StartDatePersian { get; set; }

	public DateTime? EndDateTime { get; set; }

	public string EndDatePersian { get; set; }

	public int PriorityId { get; set; }

	public int EmailUsersInfoId { get; set; }

	public int EmailSettingId { get; set; }

	public string OTP { get; set; }

	public int EmailSendDetailId { get; set; }

	public string EmailAddress { get; set; }

	public int? EmailCmpId { get; set; }

	public string CompanyName { get; set; }

	public int? EmailCmpPrsId { get; set; }

	public string PersonName { get; set; }

	public int? EmailCmpPrjId { get; set; }

	public string ProjectTitle { get; set; }

	public string EmailCmpPrsName { get; set; }

	public string EmailCmpName { get; set; }

	public string EmailPrsJob { get; set; }

	public DateTime SendDateTime { get; set; }

	public string SendDatePersian { get; set; }

	public DateTime? SendedDateTime { get; set; }

	public string SendedDatePersian { get; set; }

	public int StatusId { get; set; }

	public string StatusTitle { get; set; }

	public int? TryCount { get; set; }

	public string euNikeName { get; set; }

	public string euNikeEmail { get; set; }
}
