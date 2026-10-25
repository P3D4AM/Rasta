using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertCityViewModel : PublicParametersWithOutCenter
{
	public string ApiCityCode { get; set; }

	public string ApiCity { get; set; }

	public string ApiDescription { get; set; }

	public int ApiProvinceId { get; set; }

	public string ApiLinkAccCityIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
