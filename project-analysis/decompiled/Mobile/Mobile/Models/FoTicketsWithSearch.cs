namespace Mobile.Models;

public class FoTicketsWithSearch
{
	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public bool? IsFinished { get; set; }

	public bool? IsAnswered { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }

	public int? LanguageId { get; set; }

	public bool? IsReadTicket { get; set; }

	public bool? IsStopTicket { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? CenterId { get; set; }

	public int? FoSettingId { get; set; }
}
