using System;

namespace Mobile.Models;

public class MobspSelectConversationCallHistory_Result
{
	public int CallHistoryID { get; set; }

	public int CallTypeId { get; set; }

	public string CallType { get; set; }

	public string PhoneNumber { get; set; }

	public int? CompanyID { get; set; }

	public string CallDate { get; set; }

	public int? LineNumber { get; set; }

	public string Duration { get; set; }

	public int? CompanyPersonId { get; set; }

	public DateTime? CallDateTime { get; set; }

	public int? ConversationID { get; set; }
}
