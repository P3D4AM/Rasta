namespace CRMIdealApi.ApiModels;

public class InsertUpdateCenterProductsViewModel : PublicParametersWithOutCenter
{
	public int? ApiPrdId { get; set; }

	public string ApiPrdCode { get; set; }

	public int? ApiCenterId { get; set; }

	public string ApiCenterCode { get; set; }

	public bool? ApiIsActive { get; set; }

	public bool? ApiShpShowAfterLogin { get; set; }
}
