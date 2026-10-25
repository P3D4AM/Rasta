using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class CurrentConversationViewModel
{
	public CRMspSelectCrmConversationWithID_Result Conversation { get; set; }

	public int ConversationCurrentId { get; set; }

	public int ConversationNextId { get; set; }

	public int ConversationPreviousId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int ConversationFirstId { get; set; }

	public int ConversationLastId { get; set; }

	public List<CRMspSelectFilesDirectory_Result> FilesList { get; set; }

	public string CnvsDoingTime { get; set; }

	public List<SelectListItem> KnowledgeTankList { get; set; }
}
