using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateConversationStatusViewModel : PublicParametersWithOutCenter
{
	public int ApiConversationStatusId { get; set; }

	public short? ApiStatusOrder { get; set; }

	public string ApiStatus { get; set; }

	public string ApiStatusDesc { get; set; }

	public int? ApiProgressPercent { get; set; }

	public int? ApiGroupId { get; set; }

	public bool? ApiForcedStatus { get; set; }

	public bool? ApiFODefault { get; set; }

	public int? ApiProcessKindId { get; set; }

	public bool? ApiSendInCnvsAllarmDate { get; set; }

	public string ApiStatusUsedUserIds { get; set; }

	public bool? ApiNoRegCnvsOlderStatus { get; set; }

	public int? ApiCnvsCountLimit { get; set; }

	public int? ApiCnvsDoingTimeLimit { get; set; }

	public bool? ApiDeActive { get; set; }

	public string ApiStatusColor { get; set; }

	public string ApiIVRLinkRule { get; set; }

	public bool? ApiDeadlineIsActive { get; set; }

	public long? ApiDeadlineMinutes { get; set; }

	public int? ApiDeadlineStartResultId { get; set; }

	public int? ApiDeadlineFinishStatusId { get; set; }

	public int? ApiDeadlineFinishResultId { get; set; }

	public DateTime? ApiDeadlineStartDate { get; set; }

	public string ApiDeadlineStartDatePersian { get; set; }

	public DateTime? ApiDeadlineFinishDate { get; set; }

	public string ApiDeadlineFinishDatePersian { get; set; }
}
