using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class SelectPreOrderWithPrdTracingResultViewModel
{
	public int? ApiPageSize { get; set; }

	public int? ApiPageNumber { get; set; }

	public int? ApiTotalPages { get; set; }

	public int? ApiTotalRows { get; set; }

	public List<ApispSelectPreOrderWithPrdTracing_Result> ApiPreOrdersList { get; set; }
}
