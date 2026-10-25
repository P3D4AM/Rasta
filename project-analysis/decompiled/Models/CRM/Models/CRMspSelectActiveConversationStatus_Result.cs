using System;

namespace CRM.Models;

public class CRMspSelectActiveConversationStatus_Result
{
	public int ConversationStatusID { get; set; }

	public short? StatusOrder { get; set; }

	public string Status { get; set; }

	public string StatusDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? ProgressPercent { get; set; }

	public Guid? GUId { get; set; }

	public int? GroupId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? EventPolicyIsActive { get; set; }

	public string SMSBodyPatternFormula { get; set; }

	public bool? SendSMSWeb { get; set; }

	public bool? SendSMSGSM { get; set; }

	public string EmailSubjectPatternFormula { get; set; }

	public string EmailBodyPatternFormula { get; set; }

	public bool? SendEmail { get; set; }

	public bool? SendImmediately { get; set; }

	public int? SendDelayDays { get; set; }

	public bool? SendForAllCmpPersons { get; set; }

	public bool? UserCanCheckBeforeSend { get; set; }

	public bool? ForcedStatus { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string ConversationStatusGroup { get; set; }

	public bool? FODefault { get; set; }

	public int? ProcessKindId { get; set; }

	public string ProcessKindTitle { get; set; }

	public bool? SendInCnvsAllarmDate { get; set; }

	public int? EmailUserInfoId { get; set; }

	public string EmailUserInfo { get; set; }

	public string SendSMSUserName { get; set; }

	public string SendSMSPassword { get; set; }

	public string SendSMSNumber { get; set; }

	public int? SendSMSProviderId { get; set; }

	public string SendSMSProviderName { get; set; }
}
