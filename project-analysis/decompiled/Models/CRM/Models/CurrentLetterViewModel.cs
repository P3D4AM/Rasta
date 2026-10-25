namespace CRM.Models;

public class CurrentLetterViewModel
{
	public SecspSelectLettersByType_Result Letter { get; set; }

	public int CurrentId { get; set; }

	public int NextId { get; set; }

	public int PreviousId { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public int CompanyId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int FirstId { get; set; }

	public int LastId { get; set; }

	public WSspSelectVerificationWorkFlowStepLast_Result LastVerificationStep { get; set; }
}
