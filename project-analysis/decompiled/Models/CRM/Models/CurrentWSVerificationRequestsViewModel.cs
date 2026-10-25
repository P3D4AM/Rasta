using System.Collections.Generic;

namespace CRM.Models;

public class CurrentWSVerificationRequestsViewModel
{
	public WSspSelectVerificationRequests_Result VerificationRequest { get; set; }

	public List<WSspSelectVerificationRequestDetails_Result> VerificationRequestDetail { get; set; }

	public int VerificationRequestCurrentId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }
}
