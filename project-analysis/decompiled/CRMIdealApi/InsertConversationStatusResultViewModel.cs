using CRMIdealApi.ApiModels;

public class InsertConversationStatusResultViewModel : PublicParametersWithOutCenter
{
	public int? ApiConversationStatusGroupId { get; set; }

	public int? ApiConversationStatusId { get; set; }

	public string ApiResultTitle { get; set; }

	public string ApiResultDesc { get; set; }

	public bool? ApiEventPolicyActive { get; set; }

	public bool? ApiOTPSendActive { get; set; }

	public bool? ApiIssuePordActive { get; set; }

	public bool? ApiIssueOrdActive { get; set; }

	public bool? ApiIssueDyFormActive { get; set; }

	public bool? ApiNeedDyFormChecked { get; set; }

	public int? ApiNeedDyFormCheckedFormId { get; set; }

	public bool? ApiPrjFinished { get; set; }

	public bool? ApiNoCnvsDup { get; set; }

	public string ApiStatusResultUsedUserIds { get; set; }

	public int? ApiDoingTimeEndDeadlineMin { get; set; }

	public int? ApiDoingTimeEndCnvsStatusId { get; set; }

	public int? ApiDoingTimeEndCnvsStatusResultId { get; set; }

	public string ApiDoingTimeEndCallerCnvsStatusResultIds { get; set; }

	public int? ApiCnvsCountLimit { get; set; }

	public int? ApiCnvsDoingTimeLimit { get; set; }

	public bool? ApiCnvsDoingTimeNotNull { get; set; }

	public bool? ApiCnvsRemindDateNotNull { get; set; }

	public bool? ApiCnvsRemindDateForAllarmNotNull { get; set; }

	public int? ApiCnvsTopicId { get; set; }

	public int? ApiCnvsReferUserId { get; set; }

	public bool? ApiCnvsReferUserNoChange { get; set; }

	public int? ApiCnvsRemindDay { get; set; }

	public string ApiCnvsDesc { get; set; }

	public string ApiCnvsReferDesc { get; set; }

	public bool? ApiUpdateCmpGroupActive { get; set; }

	public string ApiUpdateCmpGroupActiveJson { get; set; }

	public bool? ApiIsDefault { get; set; }

	public bool? ApiDeActive { get; set; }

	public int? ApiOrderView { get; set; }
}
