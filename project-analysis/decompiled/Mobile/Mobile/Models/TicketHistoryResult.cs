using System.Collections.Generic;

namespace Mobile.Models;

public class TicketHistoryResult
{
	public MobspSelectTicketConversationHistoryWithProjectId_Result Ticket { get; set; }

	public List<FileDirectoryViewModel> FileList { get; set; }
}
