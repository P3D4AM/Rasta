using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdatePayConditionViewModel : PublicParametersWithOutCenter
{
	public int ApiPayConditionId { get; set; }

	public string ApiPayCondition { get; set; }

	public int? ApiOrderView { get; set; }

	public string ApiLinkAccPayConditionIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }
}
