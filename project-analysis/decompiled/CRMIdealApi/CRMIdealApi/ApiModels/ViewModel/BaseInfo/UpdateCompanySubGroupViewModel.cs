using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCompanySubGroupViewModel : PublicParametersWithOutCenter
{
	public int ApiCompanySubGroupId { get; set; }

	public string ApiSubGroupName { get; set; }

	public string ApiSubGroupDesc { get; set; }

	public int ApiGroupId { get; set; }

	public int? ApiOrderView { get; set; }

	public float? ApiScoreRate { get; set; }

	public string ApiLinkAccSubGroupIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }
}
