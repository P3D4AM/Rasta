using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectConversationStatus_Result
{
	public int ApiConversationStatusID { get; set; }

	public short? ApiStatusOrder { get; set; }

	public string ApiStatus { get; set; }

	public string ApiStatusDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiProgressPercent { get; set; }

	public int? ApiGroupId { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public bool? ApiEventPolicyIsActive { get; set; }

	public string ApiSMSBodyPatternFormula { get; set; }

	public bool? ApiSendSMSWeb { get; set; }

	public bool? ApiSendSMSGSM { get; set; }

	public string ApiEmailSubjectPatternFormula { get; set; }

	public string ApiEmailBodyPatternFormula { get; set; }

	public bool? ApiSendEmail { get; set; }

	public bool? ApiSendImmediately { get; set; }

	public int? ApiSendDelayDays { get; set; }

	public bool? ApiSendForAllCmpPersons { get; set; }

	public bool? ApiUserCanCheckBeforeSend { get; set; }

	public bool? ApiForcedStatus { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }

	public string ApiConversationStatusGroup { get; set; }

	public bool? ApiFODefault { get; set; }
}
