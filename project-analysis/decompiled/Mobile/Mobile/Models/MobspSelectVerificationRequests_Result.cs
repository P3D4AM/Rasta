using System;

namespace Mobile.Models;

public class MobspSelectVerificationRequests_Result
{
	public int VerificationRequestId { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public bool? SequenceObservation { get; set; }

	public DateTime VerificationReqDateTime { get; set; }

	public int VerificationReqUserId { get; set; }

	public string VerificationReqUser { get; set; }

	public string VerificationReqText { get; set; }

	public int VerificationReqObjectId { get; set; }

	public int VerificationReqObjectType { get; set; }

	public bool? VerificationReqExpired { get; set; }

	public DateTime? VerificationReqExpiredDateTime { get; set; }

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

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? VerificationReqExpiredStepId { get; set; }

	public string VerificationReqExpiredText { get; set; }

	public string VerificationReqExpiredDatePersian { get; set; }

	public string VerificationReqExpiredText_Lang { get; set; }

	public int? ReplaceUserId { get; set; }

	public string ReplaceUser { get; set; }

	public DateTime? ReplaceUserVerifiedDate { get; set; }

	public string ReplaceUserVerifiedDatePersian { get; set; }

	public bool? ReplaceUserIsVerified { get; set; }
}
