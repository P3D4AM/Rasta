using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertCompanyGroupIIIViewModel : PublicParametersWithOutCenter
{
	public string ApiGroupIIIName { get; set; }

	public string ApiGroupIIIDesc { get; set; }

	public int? ApiOrderView { get; set; }

	public float? ApiScoreRate { get; set; }

	public string ApiLinkAccGroupIIIIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
