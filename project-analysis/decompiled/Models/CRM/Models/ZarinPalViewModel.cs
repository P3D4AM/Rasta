namespace CRM.Models;

public class ZarinPalViewModel
{
	public long? RefId { get; set; }

	public decimal? Amount { get; set; }

	public string ErrorMessage { get; set; }

	public int? CrmOrderId { get; set; }

	public long? CrmOrdNumber { get; set; }

	public int? CrmPreOrderId { get; set; }

	public long? CrmPordNumber { get; set; }
}
