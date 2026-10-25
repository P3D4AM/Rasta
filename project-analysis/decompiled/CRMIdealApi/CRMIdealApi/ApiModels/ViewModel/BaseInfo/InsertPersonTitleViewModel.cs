using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertPersonTitleViewModel : PublicParametersWithOutCenter
{
	public string ApiPersonTitle { get; set; }

	public string ApiLinkAccTitleIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
