using System;

namespace CRM.Models;

public class EmailspSelectEmailSendHeaderByDate_Result
{
	public int EmailSendHeaderId { get; set; }

	public int UserId { get; set; }

	public string Subject { get; set; }

	public string Body { get; set; }

	public DateTime StartDateTime { get; set; }

	public string StartDatePersian { get; set; }

	public DateTime? EndDateTime { get; set; }

	public string EndDatePersian { get; set; }

	public int PriorityId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public int EmailUsersInfoId { get; set; }

	public int EmailSettingId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string OTP { get; set; }

	public int? CId { get; set; }

	public string BodyNoHtml { get; set; }

	public string ReceiveMessageId { get; set; }

	public string ReceiveUID { get; set; }
}
