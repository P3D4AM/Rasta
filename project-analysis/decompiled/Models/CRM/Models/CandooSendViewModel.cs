namespace CRM.Models;

public class CandooSendViewModel
{
	public string srcNum { get; set; }

	public string recipient { get; set; }

	public string body { get; set; }

	public long? customerId { get; set; }

	public int? type { get; set; }

	public int? retryCount { get; set; }

	public int? validityPeriod { get; set; }
}
