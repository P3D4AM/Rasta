using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdatePersonTitleViewModel : PublicParametersWithOutCenter
{
	public int ApiPersonTitleId { get; set; }

	public string ApiPersonTitle { get; set; }

	public string ApiLinkAccTitleIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }
}
