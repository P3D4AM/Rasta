using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSVerificationRequestsMetadata))]
public class WSVerificationRequests
{
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

	public int? VerificationReqExpiredStepId { get; set; }

	public string VerificationReqExpiredText { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSVerificationRequestDetails> WSVerificationRequestDetails { get; set; }

	public virtual ICollection<WSVerificationRequests_Lang> WSVerificationRequests_Lang { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WSVerificationWorkFlowSteps WSVerificationWorkFlowSteps { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public WSVerificationRequests()
	{
		WSVerificationRequestDetails = (ICollection<WSVerificationRequestDetails>)new HashSet<WSVerificationRequestDetails>();
		WSVerificationRequests_Lang = (ICollection<WSVerificationRequests_Lang>)new HashSet<WSVerificationRequests_Lang>();
	}
}
