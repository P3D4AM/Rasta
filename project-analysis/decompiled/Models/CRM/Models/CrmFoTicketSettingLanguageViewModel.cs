using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoTicketSettingLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketSubjSelectLoadDefaultContext")]
	public bool? TicketSubjSelectLoadDefaultContext { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketSubjectDefaultContext")]
	public string TicketSubjectDefaultContext { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketDescTooltip")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TicketDescTooltip { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingUserDepartment")]
	public int? DepartmentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingUserDepartmentDefaultTicketUser")]
	public int? DefaultTicketUserId { get; set; }

	public string TicketReferMultiUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketCanAddNewSubject")]
	public bool? TicketCanAddNewSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketAllowInCurrntCount")]
	public int? TicketAllowInCurrntCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketAllowAddBeforeAnswerCount")]
	public int? TicketAllowAddBeforeAnswerCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketAutoCloseAfterDay")]
	public int? TicketAutoCloseAfterDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingUserDepartmentTicketFooterText")]
	[UIHint("RichText")]
	[AllowHtml]
	public string TicketFooterText { get; set; }

	public int? TicketAddProjectTypeId { get; set; }

	public string TicketProjectTitleAndTitleGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketFileAttachCount")]
	public int? TicketFileAttachCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketSendIntMsg")]
	public bool? TicketSendIntMsg { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketFullRemindDate")]
	public bool? TicketFullRemindDate { get; set; }

	public string TicketDescTooltip_Lang { get; set; }

	public string TicketSubjectDefaultContext_Lang { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string TicketFooterText_Lang { get; set; }

	public string TicketAutoReplyAfterSetDoingTimeDesc_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketCountCurrentWithStop")]
	public bool? TicketCountCurrentWithStop { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketAutoReplyAfterSetDoingTime")]
	public bool? TicketAutoReplyAfterSetDoingTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketAutoReplyAfterSetDoingTimeTopic")]
	public int? TicketAutoReplyAfterSetDoingTimeTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingTicketAutoReplyAfterSetDoingTimeDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TicketAutoReplyAfterSetDoingTimeDesc { get; set; }

	public bool? TicketDelayAllarm { get; set; }

	public int? TicketDelayAllarmDay { get; set; }

	public string TicketDelayAllarmTime { get; set; }

	public string TicketDelayAllarmReceivers { get; set; }

	public string TicketDelayAllarmReceiversName { get; set; }

	public string TicketDelayAllarmMessage { get; set; }

	public string TicketDelayAllarmMessage_Lang { get; set; }

	public bool? TicketDelayAllarmSendSMS { get; set; }

	public int? TicketDelayAllarmSendSMSProviderId { get; set; }

	public string TicketDelayAllarmSendSMSNumber { get; set; }

	public bool? TicketBusyAllarm { get; set; }

	public int? TicketBusyAllarmAllMsgCnt { get; set; }

	public int? TicketBusyAllarmUserRepCnt { get; set; }

	public string TicketBusyAllarmReceivers { get; set; }

	public string TicketBusyAllarmReceiversName { get; set; }

	public string TicketBusyAllarmMessage { get; set; }

	public string TicketBusyAllarmMessage_Lang { get; set; }

	public bool? TicketBusyAllarmSendSMS { get; set; }

	public int? TicketBusyAllarmSendSMSProviderId { get; set; }

	public string TicketBusyAllarmSendSMSNumber { get; set; }

	public bool? TicketUnhappyAllarm { get; set; }

	public int? TicketUnhappyAllarmMinVote { get; set; }

	public string TicketUnhappyAllarmReceivers { get; set; }

	public string TicketUnhappyAllarmReceiversName { get; set; }

	public string TicketUnhappyAllarmMessage { get; set; }

	public string TicketUnhappyAllarmMessage_Lang { get; set; }

	public bool? TicketUnhappyAllarmSendSMS { get; set; }

	public int? TicketUnhappyAllarmSendSMSProviderId { get; set; }

	public string TicketUnhappyAllarmSendSMSNumber { get; set; }

	public bool? TicketColorAllarm { get; set; }

	public string TicketColorAllarmJs { get; set; }

	public int? TicketClosedCanReplayAfterDays { get; set; }

	public int? TicketDescMaxLen { get; set; }
}
