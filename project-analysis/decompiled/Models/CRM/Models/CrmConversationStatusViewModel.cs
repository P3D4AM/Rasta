using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationStatusViewModel
{
	[Key]
	public int ConversationStatusID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusOrder")]
	public short? StatusOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatus")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Status { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusDesc")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string StatusDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsProgressPercent")]
	public int? ProgressPercent { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusGroupId")]
	public int? GroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusGroupId")]
	public string GroupIdTitle { get; set; }

	public bool? EventPolicyIsActive { get; set; }

	public string SMSBodyPatternFormula { get; set; }

	public bool? SendSMSWeb { get; set; }

	public bool? SendSMSGSM { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusEmailSubjectPatternFormula")]
	public string EmailSubjectPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusEmailBodyPatternFormula")]
	public string EmailBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendEmail")]
	public bool? SendEmail { get; set; }

	public bool? SendImmediately { get; set; }

	public int? SendDelayDays { get; set; }

	public bool? SendForAllCmpPersons { get; set; }

	public bool? UserCanCheckBeforeSend { get; set; }

	public string RegisterUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public bool? ForcedStatus { get; set; }

	public bool? FODefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusProcessKindId")]
	public int? ProcessKindId { get; set; }

	public string ProcessKindTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendInCnvsAllarmDate")]
	public bool? SendInCnvsAllarmDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusEmailUserInfo")]
	public int? EmailUserInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusEmailUserInfo")]
	public string EmailUserInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSUserName")]
	public string SendSMSUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSPassword")]
	public string SendSMSPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSNumber")]
	public string SendSMSNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSProvider")]
	public int? SendSMSProviderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusSendSMSProvider")]
	public string SendSMSProviderName { get; set; }
}
