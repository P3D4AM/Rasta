using System.Collections.Generic;

namespace CRM.Models;

public class TSPInvBodyRequest<T>
{
	public List<TSPPacket<T>> packets { get; set; }

	public string signature { get; set; }

	public string signatureKeyId { get; set; }
}
