using System;

namespace CRM.Models;

public class CrmConversationReferUsersMetadata
{
	public int ConversationReferUserID { get; set; }

	public int ConversationId { get; set; }

	public int ReferUserId { get; set; }

	public int UserId { get; set; }

	public int? PriorityId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
