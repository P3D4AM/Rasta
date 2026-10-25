using System;

namespace CRM.Models;

public class CrmTelegBotMessageTypeMetadata
{
	public int TelegBotMessageTypeId { get; set; }

	public string MessageType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }
}
