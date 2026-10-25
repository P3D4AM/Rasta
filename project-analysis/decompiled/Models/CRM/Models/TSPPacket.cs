namespace CRM.Models;

public class TSPPacket<T>
{
	public string uid { get; set; }

	public string packetType { get; set; }

	public bool retry { get; set; }

	public T data { get; set; }

	public string encryptionKeyId { get; set; }

	public string symmetrickey { get; set; }

	public string iv { get; set; }

	public string fiscalId { get; set; }

	public string dataSignature { get; set; }
}
