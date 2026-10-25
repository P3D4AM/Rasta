namespace Mobile.Models;

public class SMSIrBulkToSendResponseViewModel
{
	public int status { get; set; }

	public string message { get; set; }

	public SMSIrBulkToSendDataResponseViewModel data { get; set; }
}
