namespace CRMIdealApi.ApiModels;

public class ReturnPrdQuantityViewModel : PublicParameters
{
	public int? ApiPrdId { get; set; }

	public int? ApiWHId { get; set; }

	public int? ApiPrdCurrId { get; set; }

	public double? ApiPrdFCR { get; set; }

	public double? ApiPrdFCRI { get; set; }

	public string ApiPrdTracing { get; set; }
}
