using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmTelegBotMessageTypeMetadata))]
public class CrmTelegBotMessageType
{
	public int TelegBotMessageTypeId { get; set; }

	public string MessageType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public virtual ICollection<CrmTelegBotChatMessage> CrmTelegBotChatMessage { get; set; }

	public virtual Languages Languages { get; set; }

	public CrmTelegBotMessageType()
	{
		CrmTelegBotChatMessage = (ICollection<CrmTelegBotChatMessage>)new HashSet<CrmTelegBotChatMessage>();
	}
}
