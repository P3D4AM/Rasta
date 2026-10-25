using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class SelectOrderWithPrdTracingResultViewModel
{
	public int? ApiPageSize { get; set; }

	public int? ApiPageNumber { get; set; }

	public int? ApiTotalPages { get; set; }

	public int? ApiTotalRows { get; set; }

	public List<ApispSelectOrderWithPrdTracing_Result> ApiOrdersList { get; set; }
}
