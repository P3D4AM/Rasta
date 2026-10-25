using System;

namespace CRM.Models;

public class CandooErrorResponseViewModel
{
	public long? statusCode { get; set; }

	public DateTime? timestamp { get; set; }

	public string message { get; set; }

	public string description { get; set; }
}
