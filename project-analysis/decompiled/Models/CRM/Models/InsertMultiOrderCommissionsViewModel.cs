namespace CRM.Models;

public class InsertMultiOrderCommissionsViewModel
{
	public string CommDatePersian { get; set; }

	public int CommOrderId { get; set; }

	public int CommCmpId { get; set; }

	public decimal? CommBaseAmountDec { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public decimal CommBaseAmount { get; set; }

	public decimal? CommBaseAmountDecPercent { get; set; }

	public string CommBaseAmountDecDesc_Lang { get; set; }

	public string ListComm { get; set; }
}
