using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCompanyGroupIIViewModel : PublicParametersWithOutCenter
{
	public int ApiCompanyGroupIIId { get; set; }

	public string ApiGroupIIName { get; set; }

	public string ApiGroupIIDesc { get; set; }

	public int? ApiOrderView { get; set; }

	public float? ApiScoreRate { get; set; }

	public float? ApiRate { get; set; }

	public string ApiLinkAccGroupIIIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }
}
