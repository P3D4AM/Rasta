namespace CRM.Models;

public class TSPAsyncResponse<T>
{
	public string uid { get; set; }

	public string packetType { get; set; }

	public T data { get; set; }

	public string referenceNumber { get; set; }

	public string errorCode { get; set; }

	public string errorDetail { get; set; }
}
