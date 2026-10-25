using System;

namespace CRMIdealApi.ApiModels;

public class ApispLkSelectFiscalYear_Result
{
	public int? ApiFiscalYearId { get; set; }

	public string ApiTitle { get; set; }

	public DateTime? ApiStartDate { get; set; }

	public DateTime? ApiEndDate { get; set; }
}
