using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationReferUsersMetadata))]
public class CrmConversationReferUsers
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

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual CrmConversation CrmConversation { get; set; }

	public virtual CrmConversationPriority CrmConversationPriority { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }
}
