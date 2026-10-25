namespace CRMIdealApi.ApiModels;

public class SelectOrderWithPrdTracingViewModel : PublicParameters
{
	public string ApiTracing { get; set; }

	public string ApiFromDate { get; set; }

	public string ApiToDate { get; set; }

	public int? ApiPageSize { get; set; }

	public int? ApiPageNumber { get; set; }
}
