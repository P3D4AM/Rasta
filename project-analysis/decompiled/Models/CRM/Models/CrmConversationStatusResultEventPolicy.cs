using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusResultEventPolicyMetadata))]
public class CrmConversationStatusResultEventPolicy
{
	public int ConversationStatusResultEventPolicyId { get; set; }

	public int ConversationStatusGroupId { get; set; }

	public int ConversationStatusId { get; set; }

	public int ConversationStatusResultId { get; set; }

	public int EventPolicyTypeId { get; set; }

	public int? EventPolicyReceiverId { get; set; }

	public string EventPolicySetting { get; set; }

	public int? EventPolicySendTimeType { get; set; }

	public int? EventPolicySendTimeValue { get; set; }

	public bool? EventPolicyUserCheckBeforeSend { get; set; }

	public string EventPolicyShortDescription { get; set; }

	public string EventPolicyBigDescription { get; set; }

	public bool? DeActive { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? EventPolicySendTimeValueII { get; set; }

	public virtual ICollection<CrmConversationStatusResultEventPolicy_Lang> CrmConversationStatusResultEventPolicy_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual CrmConversationStatusResult CrmConversationStatusResult { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmConversationStatusResultEventPolicy()
	{
		CrmConversationStatusResultEventPolicy_Lang = (ICollection<CrmConversationStatusResultEventPolicy_Lang>)new HashSet<CrmConversationStatusResultEventPolicy_Lang>();
	}
}
