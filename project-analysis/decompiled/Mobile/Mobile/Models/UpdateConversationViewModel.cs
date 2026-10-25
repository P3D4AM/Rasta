namespace Mobile.Models;

public class UpdateConversationViewModel
{
	public string Conversation { get; set; }

	public int CompanyId { get; set; }

	public int ProjectId { get; set; }

	public int ConversationId { get; set; }

	public int CnvsReferUserId { get; set; }

	public int? LanguageId { get; set; }

	public bool? IsCloseTicket { get; set; }

	public int? CenterId { get; set; }
}
