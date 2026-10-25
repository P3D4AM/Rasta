namespace CRM.Models;

public class CurrentWSVerificationRequestDetailsViewModel
{
	public WSspSelectVerificationRequestDetails_Result VerificationRequestDetail { get; set; }

	public int VerificationReqDetailCurrentId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }
}
