using System.Collections.Generic;

namespace CRM.Models.ViewModel.AI;

public class AIAnswerViewModel
{
	public int ProjectId { get; set; }

	public List<int> PromptIds { get; set; }

	public List<int> ConversationIds { get; set; }
}
