namespace Mobile.Models;

public class SMSIrReceiveMessageResponseViewModel
{
	public int status { get; set; }

	public string message { get; set; }

	public SMSIrReceiveMessageDataResponseViewModel[] data { get; set; }
}
