namespace Mobile.Models;

public class CandooSendResponseViewModel
{
	public long? messageId { get; set; }

	public string srcNum { get; set; }

	public string recipient { get; set; }

	public long? customerId { get; set; }

	public string status { get; set; }

	public long? statusCode { get; set; }
}
