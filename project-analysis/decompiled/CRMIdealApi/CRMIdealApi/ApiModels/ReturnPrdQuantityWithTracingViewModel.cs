namespace CRMIdealApi.ApiModels;

public class ReturnPrdQuantityWithTracingViewModel : PublicParameters
{
	public string ApiTracing { get; set; }

	public int? ApiWHId { get; set; }

	public int? ApiPrdId { get; set; }

	public string ApiPrdCode { get; set; }
}
