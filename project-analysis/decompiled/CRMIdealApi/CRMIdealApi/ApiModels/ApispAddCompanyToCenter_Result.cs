namespace CRMIdealApi.ApiModels;

public class ApispAddCompanyToCenter_Result
{
	public int? ApiCompanyId { get; set; }

	public string ApiCompanyCurrentCenterIds { get; set; }

	public bool? ApiCompanyCenterAdded { get; set; }

	public bool? ApiCompanyCenterExists { get; set; }

	public string ApiPersonIds { get; set; }

	public string ApiPersonIdsInfoJson { get; set; }
}
