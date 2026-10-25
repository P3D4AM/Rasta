using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCompanyGroupViewModel : PublicParametersWithOutCenter
{
	public int ApiCompanyGroupId { get; set; }

	public string ApiGroupName { get; set; }

	public string ApiGroupDesc { get; set; }

	public int? ApiOrderView { get; set; }

	public float? ApiScoreRate { get; set; }

	public string ApiLinkAccGroupIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }
}
