using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateProvinceViewModel : PublicParametersWithOutCenter
{
	public int ApiProvinceId { get; set; }

	public string ApiProvinceCode { get; set; }

	public string ApiProvince { get; set; }

	public string ApiDescription { get; set; }

	public int ApiCountryId { get; set; }

	public string ApiLinkAccProvinceIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }
}
