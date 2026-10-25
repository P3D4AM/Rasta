using System.Collections.Generic;

namespace CRM.Models;

public class CRMspSelectCompanyConversationsByProjectViewModel
{
	public List<CRMspSelectCompanyConversationsByProject_Result> ConversationItemsList { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public string CmpAddress { get; set; }

	public string CmpSpecialPoint { get; set; }

	public string CurrentDay { get; set; }

	public string CurrentDate { get; set; }

	public string CurrentTime { get; set; }
}
