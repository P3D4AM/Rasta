namespace CRMIdealApi.ApiModels;

public class SelectCenterProductsViewModel : PublicParametersWithOutCenter
{
	public int? ApiPrdId { get; set; }

	public string ApiPrdCode { get; set; }

	public int? ApiCenterId { get; set; }

	public string ApiCenterCode { get; set; }
}
