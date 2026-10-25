namespace Mobile.Models;

public class SMSIrBulkToSendDataResponseViewModel
{
	public string PackId { get; set; }

	public int[] MessageIds { get; set; }

	public decimal? Cost { get; set; }
}
