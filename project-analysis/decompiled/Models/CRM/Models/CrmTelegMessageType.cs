using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmTelegMessageTypeMetadata))]
public class CrmTelegMessageType
{
	public int TelegMessageTypeId { get; set; }

	public string MessageType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public virtual ICollection<CrmTelegChatMessage> CrmTelegChatMessage { get; set; }

	public virtual Languages Languages { get; set; }

	public CrmTelegMessageType()
	{
		CrmTelegChatMessage = (ICollection<CrmTelegChatMessage>)new HashSet<CrmTelegChatMessage>();
	}
}
