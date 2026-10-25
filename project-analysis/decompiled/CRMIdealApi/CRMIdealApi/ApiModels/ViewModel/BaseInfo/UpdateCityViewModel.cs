using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCityViewModel : PublicParametersWithOutCenter
{
	public int ApiCityId { get; set; }

	public string ApiCityCode { get; set; }

	public string ApiCity { get; set; }

	public string ApiDescription { get; set; }

	public int ApiProvinceId { get; set; }

	public string ApiLinkAccCityIdStr { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
