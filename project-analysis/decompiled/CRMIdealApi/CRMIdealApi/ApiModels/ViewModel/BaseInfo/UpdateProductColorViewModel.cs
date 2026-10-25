using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateProductColorViewModel : PublicParametersWithOutCenter
{
	public int ApiProductColorId { get; set; }

	public string ApiColor { get; set; }

	public string ApiColorDescription { get; set; }

	public string ApiColorCode { get; set; }

	public string ApiColorEn { get; set; }

	public string ApiLinkAccColorIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }
}
