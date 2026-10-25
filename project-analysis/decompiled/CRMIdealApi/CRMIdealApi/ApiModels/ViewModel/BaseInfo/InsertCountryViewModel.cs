using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertCountryViewModel : PublicParametersWithOutCenter
{
	public string ApiCountryCode { get; set; }

	public string ApiCountry { get; set; }

	public string ApiCountryDescription { get; set; }

	public string ApiLinkAccCountryIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
