using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationStatusLanguageViewModel
{
	[Key]
	public int ConversationStatusID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusOrder")]
	public short? StatusOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Status { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDesc")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string StatusDesc { get; set; }

	public string StatusColor { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsProgressPercent")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ProgressPercent { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? GroupId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusEventPolicyIsActive")]
	public bool? EventPolicyIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSmsBodyPatternFormula")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SMSBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSmsWeb")]
	public bool? SendSMSWeb { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSmsGsm")]
	public bool? SendSMSGSM { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusEmailSubjectPatternFormula")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailSubjectPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusEmailBodyPatternFormula")]
	[UIHint("RichText")]
	[AllowHtml]
	public string EmailBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendEmail")]
	public bool? SendEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendImmediately")]
	public bool? SendImmediately { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendDelayDays")]
	public int? SendDelayDays { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendForAllCmpPersons")]
	public bool? SendForAllCmpPersons { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusUserCanCheckBeforeSend")]
	public bool? UserCanCheckBeforeSend { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusForcedStatus")]
	public bool? ForcedStatus { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusProcessKindId")]
	public int? ProcessKindId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendInCnvsAllarmDate")]
	public bool? SendInCnvsAllarmDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusEmailUserInfo")]
	public int? EmailUserInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSUserName")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendSMSUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSPassword")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendSMSPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendSMSNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSProvider")]
	public int? SendSMSProviderId { get; set; }

	public string StatusUsedUserIds { get; set; }

	public string StatusUsedUsers { get; set; }

	public string DoingTimeEndCallerCnvsStatusIds { get; set; }

	public bool? NoRegCnvsOlderStatus { get; set; }

	public int? CnvsCountLimit { get; set; }

	public int? CnvsDoingTimeLimit { get; set; }

	public bool? DeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDeadlineIsActive")]
	public bool? DeadlineIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDeadlineMinutes")]
	public long? DeadlineMinutes { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDeadlineStartResult")]
	public int? DeadlineStartResultId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDeadlineFinishStatus")]
	public int? DeadlineFinishStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDeadlineFinishResult")]
	public int? DeadlineFinishResultId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDeadlineEventPolicy")]
	[UIHint("RichText")]
	[AllowHtml]
	public string DeadlineEventPolicyJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDeadlineStartDate")]
	public string DeadlineStartDatePersian { get; set; }

	public DateTime? DeadlineStartDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDeadlineFinishDate")]
	public string DeadlineFinishDatePersian { get; set; }

	public DateTime? DeadlineFinishDate { get; set; }

	public string Status_Lang { get; set; }

	public string StatusDesc_Lang { get; set; }
}
