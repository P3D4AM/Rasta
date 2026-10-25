using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmInternalMessageViewModel
{
	[Key]
	public int InternalMessageID { get; set; }

	public string ImportDate { get; set; }

	public int? msgMasterId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgSubject")]
	public string msgSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgBody")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string msgBody { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgFromUserId")]
	public int msgFromUserId { get; set; }

	public int? msgAttachRecId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? msgTypeId { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgActiveInCycle")]
	public bool? msgActiveInCycle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgActiveInCycle")]
	public bool MsgActiveInCycle1
	{
		get
		{
			if (msgActiveInCycle.HasValue)
			{
				return msgActiveInCycle != false;
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "msgLastGroupId")]
	public int? msgLastGroupId { get; set; }

	public int? msgIsFinalised { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgToUsersTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string msgToUsersTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ReplyPriorityID")]
	public int? ReplyPriorityID { get; set; }

	public string LoadMessage { get; set; }

	public int messageAttachRecId { get; set; }

	public string SendMode { get; set; }

	public bool IsForwardMessage { get; set; }

	public int AttachRecId { get; set; }

	public string EnableChkActiveInCycle { get; set; }

	public string HelpParameters { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCanInsertCnvsWithIntMsg")]
	public bool CanInsertCnvsWithIntMsg { get; set; }

	public int ProjectId { get; set; }

	public int CompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsTopicId")]
	public int? cnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsDesc")]
	[MaxLength(10000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsPersonId")]
	public int? cnvsPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsUserId")]
	public int? cnvsUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsReferUserId")]
	public int? cnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsStatusId")]
	public int? cnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsStatusResultId")]
	public int? cnvsStatusResultId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsRemindDate")]
	public DateTime? cnvsRemindDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsRemindTime")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsRemindDateForAllarm")]
	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public string cnvsDesc_Lang { get; set; }

	public string cnvsReferDesc_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsFOCmpCanSee")]
	public bool? cnvsFOCmpCanSee { get; set; }

	public bool? cnvsIsTicket { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public string AttachRecDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsReferredRemindOk")]
	public bool? CnvsReferredRemindOk { get; set; }

	public int? CnvsReferredId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmInternalMessageCnvsPrjTicketStop")]
	public bool? prjTicketStop { get; set; }

	public int? PrjFirstCnvsUserId { get; set; }

	public int? LastCnvsPersonId { get; set; }

	public int? CmpReferUserId { get; set; }

	public int? CmpSuppUserId { get; set; }

	public string msgSubject_Lang { get; set; }

	public string msgBody_Lang { get; set; }

	public int? msgAttachRecIdI { get; set; }

	public string msgAttachRecDescI { get; set; }

	public bool IsCloseTicket { get; set; }

	public string IntMsgReceivers { get; set; }

	public int? msgCId { get; set; }
}
