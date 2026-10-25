namespace CRM.Models;

public class SMSIrGetDeliveyDataResponseViewModel
{
	public int messageId { get; set; }

	public string mobile { get; set; }

	public string messageText { get; set; }

	public long lineNumber { get; set; }

	public int deliveryState { get; set; }
}
