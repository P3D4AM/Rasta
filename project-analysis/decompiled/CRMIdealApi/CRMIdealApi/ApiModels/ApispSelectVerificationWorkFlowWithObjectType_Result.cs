using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectVerificationWorkFlowWithObjectType_Result
{
	public int VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public bool SequenceObservation { get; set; }

	public bool IsActive { get; set; }

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

	public int? ObjectType { get; set; }

	public string VerifyRequestText { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }
}
