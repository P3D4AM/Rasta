namespace CRM.Models;

public class TSPBodyRequest<T>
{
	public TSPPacket<T> packet { get; set; }

	public string signature { get; set; }

	public string signatureKeyId { get; set; }
}
