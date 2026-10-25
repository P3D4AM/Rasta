namespace Mobile.Models;

public class SMSIrReceiveMessageDataResponseViewModel
{
	public string mobile { get; set; }

	public string messageText { get; set; }

	public long Number { get; set; }

	public int ReceivedDateTime { get; set; }
}
