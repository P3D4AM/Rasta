using System.Collections.Generic;

namespace CRM.Models;

public class TSPResultRequest<T>
{
	public long timestamp { get; set; }

	public TSPAsyncResponse<T> result { get; set; }

	public string signature { get; set; }

	public string signatureKeyId { get; set; }

	public List<TSPErrorResponse> errors { get; set; }

	public TSPErrorResponseI error { get; set; }
}
