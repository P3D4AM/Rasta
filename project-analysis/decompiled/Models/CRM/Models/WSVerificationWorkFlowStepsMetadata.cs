using System;

namespace CRM.Models;

public class WSVerificationWorkFlowStepsMetadata
{
	public int VerificationWorkFlowStepId { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlowStepTitle { get; set; }

	public int? VerifyUserId { get; set; }

	public int? AlternateVerifyUserId { get; set; }

	public string VerifyText { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
