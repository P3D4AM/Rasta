using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmConversationStatusResultEventPolicy_LangMetadata
{
	[Key]
	public int CrmConversationStatusResultEventPolicyLangID { get; set; }

	public int ConversationStatusResultEventPolicyId { get; set; }

	public int LanguageID { get; set; }

	public string EventPolicySetting { get; set; }

	public string EventPolicyShortDescription { get; set; }

	public string EventPolicyBigDescription { get; set; }
}
