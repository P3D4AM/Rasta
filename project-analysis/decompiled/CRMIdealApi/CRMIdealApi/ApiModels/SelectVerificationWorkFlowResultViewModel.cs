using System;

namespace CRMIdealApi.ApiModels;

public class SelectVerificationWorkFlowResultViewModel
{
	public int VerificationWorkFlowId { get; set; }

	public int? ObjectType { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public string VerifyRequestText { get; set; }

	public bool SequenceObservation { get; set; }

	public bool IsActive { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int? LanguageId { get; set; }
}
