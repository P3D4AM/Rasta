using System;

namespace CRM.Models;

public class CrmConversationTopicsMetadata
{
	public int ConversationTopicsID { get; set; }

	public short? TopicOrder { get; set; }

	public string Topic { get; set; }

	public string TopicDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
