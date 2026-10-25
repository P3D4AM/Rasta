using System.Collections.Generic;

namespace Mobile.Models;

public class ReminderCartableViewModel
{
	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? ProjectId { get; set; }

	public string ProjectTitle { get; set; }

	public int? ConversationId { get; set; }

	public int? CnvsPersonId { get; set; }

	public int? UserId { get; set; }

	public string RequestDate { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }

	public int CountPage { get; set; }
}
