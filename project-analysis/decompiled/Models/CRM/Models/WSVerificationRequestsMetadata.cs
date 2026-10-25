using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSVerificationRequestsMetadata
{
	[Key]
	public int VerificationRequestId { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public DateTime VerificationReqDateTime { get; set; }

	public int VerificationReqUserId { get; set; }

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
}
