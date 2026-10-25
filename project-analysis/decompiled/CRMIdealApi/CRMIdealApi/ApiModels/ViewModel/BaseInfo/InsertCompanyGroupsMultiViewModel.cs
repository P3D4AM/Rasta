using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertCompanyGroupsMultiViewModel : PublicParametersWithOutCenter
{
	public string ApiCompanyGroupsMultiName { get; set; }

	public string ApiCompanyGroupsMultiDesc { get; set; }

	public int? ApiOrderView { get; set; }

	public string ApiLinkAccGroupMultiIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
