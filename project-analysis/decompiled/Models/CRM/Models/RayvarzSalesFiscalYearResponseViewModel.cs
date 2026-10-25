namespace CRM.Models;

public class RayvarzSalesFiscalYearResponseViewModel
{
	public bool? isValidationsApplied { get; set; }

	public long? salesFiscalYearId { get; set; }

	public long? fiscalYear { get; set; }

	public string startDate { get; set; }

	public string endDate { get; set; }
}
