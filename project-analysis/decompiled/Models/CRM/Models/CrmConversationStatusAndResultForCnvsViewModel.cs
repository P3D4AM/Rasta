using System.Collections.Generic;

namespace CRM.Models;

public class CrmConversationStatusAndResultForCnvsViewModel
{
	public List<CrmConversationStatusResultForCnvsViewModel> CnvsStatusResult { get; set; }

	public string StatusUsedUserIds { get; set; }

	public string StatusUsedUserNames { get; set; }
}
