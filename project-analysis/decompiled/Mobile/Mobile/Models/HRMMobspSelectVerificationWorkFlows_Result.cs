namespace Mobile.Models;

public class HRMMobspSelectVerificationWorkFlows_Result
{
	public int VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public bool SequenceObservation { get; set; }

	public int? ObjectType { get; set; }

	public string VerifyRequestText { get; set; }
}
