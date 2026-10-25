using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageDetailsMetadata))]
public class CrmInternalMessageDetails
{
	public int InternalMessageDetailID { get; set; }

	public int? msgdInternalMessageId { get; set; }

	public int msgdTypeId { get; set; }

	public int? msgdOldTypeId { get; set; }

	public int msgdFromUserId { get; set; }

	public int msgdToUserId { get; set; }

	public string msgdSendDate { get; set; }

	public string msgdSendTime { get; set; }

	public DateTime msgdSendDateTime { get; set; }

	public string msgdReceiveDate { get; set; }

	public string msgdReceiveTime { get; set; }

	public DateTime? msgdReceiveDateTime { get; set; }

	public bool? msgdIsRead { get; set; }

	public string msgdReadDate { get; set; }

	public string msgdReadTime { get; set; }

	public DateTime? msgdReadDateTime { get; set; }

	public int? msgdPriorityId { get; set; }

	public bool? msgdIsDraft { get; set; }

	public bool? msgdIsDeleted { get; set; }

	public string msgdAttachFile { get; set; }

	public int? msgdAttachRecId { get; set; }

	public string msgdAttachRecDesc { get; set; }

	public int? msgdGroupId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? msgdAttachRecIdI { get; set; }

	public string msgdAttachRecDescI { get; set; }

	public string msgdExtraData { get; set; }

	public int? msgdCId { get; set; }

	public virtual CrmInternalMessage CrmInternalMessage { get; set; }

	public virtual CrmInternalMessageGroup CrmInternalMessageGroup { get; set; }

	public virtual CrmInternalMessageType CrmInternalMessageType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }
}
