using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusResultEventPolicy_LangMetadata))]
public class CrmConversationStatusResultEventPolicy_Lang
{
	public int CrmConversationStatusResultEventPolicyLangID { get; set; }

	public int ConversationStatusResultEventPolicyId { get; set; }

	public int LanguageID { get; set; }

	public string EventPolicySetting { get; set; }

	public string EventPolicyShortDescription { get; set; }

	public string EventPolicyBigDescription { get; set; }

	public virtual CrmConversationStatusResultEventPolicy CrmConversationStatusResultEventPolicy { get; set; }

	public virtual Languages Languages { get; set; }
}
