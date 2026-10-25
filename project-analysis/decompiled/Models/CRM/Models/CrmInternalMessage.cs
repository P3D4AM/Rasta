using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageMetadata))]
public class CrmInternalMessage
{
	public int InternalMessageID { get; set; }

	public int? msgMasterId { get; set; }

	public string msgSubject { get; set; }

	public string msgBody { get; set; }

	public int msgFromUserId { get; set; }

	public int? msgAttachRecId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? msgTypeId { get; set; }

	public Guid? GUId { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public int? msgLastGroupId { get; set; }

	public int? msgIsFinalised { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string ApiId { get; set; }

	public int? msgCompanyId { get; set; }

	public int? msgProjectId { get; set; }

	public int? msgAttachFileCount { get; set; }

	public int? msgCId { get; set; }

	public virtual CrmInternalMessageType CrmInternalMessageType { get; set; }

	public virtual ICollection<CrmInternalMessage_Lang> CrmInternalMessage_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual ICollection<WSVerificationRequestDetails> WSVerificationRequestDetails { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public CrmInternalMessage()
	{
		CrmInternalMessage_Lang = (ICollection<CrmInternalMessage_Lang>)new HashSet<CrmInternalMessage_Lang>();
		CrmInternalMessageDetails = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		WSVerificationRequestDetails = (ICollection<WSVerificationRequestDetails>)new HashSet<WSVerificationRequestDetails>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
	}
}
