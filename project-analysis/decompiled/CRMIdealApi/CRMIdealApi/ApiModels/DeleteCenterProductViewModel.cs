namespace CRMIdealApi.ApiModels;

public class DeleteCenterProductViewModel : PublicParametersWithOutCenter
{
	public int? ApiCenterProductID { get; set; }

	public int? ApiPrdId { get; set; }

	public int? ApiCenterId { get; set; }
}
