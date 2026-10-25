using System;

namespace CRM.Models;

public class CrmConversationStatusGroupsMetadata
{
	public int ConversationStatusGroupID { get; set; }

	public string ConversationStatusGroup { get; set; }

	public string ConversationStatusGroupDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
