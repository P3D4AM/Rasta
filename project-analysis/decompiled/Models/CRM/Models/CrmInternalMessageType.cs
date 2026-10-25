using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageTypeMetadata))]
public class CrmInternalMessageType
{
	public int InternalMessageTypeID { get; set; }

	public string MessageType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? OrderView { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails { get; set; }

	public virtual ICollection<CrmInternalMessageType_Lang> CrmInternalMessageType_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmInternalMessageType()
	{
		CrmInternalMessage = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmInternalMessageDetails = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		CrmInternalMessageType_Lang = (ICollection<CrmInternalMessageType_Lang>)new HashSet<CrmInternalMessageType_Lang>();
	}
}
