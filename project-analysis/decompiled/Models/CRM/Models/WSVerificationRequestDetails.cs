using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSVerificationRequestDetailsMetadata))]
public class WSVerificationRequestDetails
{
	public int VerificationRequestDetailId { get; set; }

	public int VerificationRequestId { get; set; }

	public int ObjectId { get; set; }

	public int ObjectType { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public int VerificationWorkFlowStepId { get; set; }

	public int? VerifyUserId { get; set; }

	public DateTime? VerifyDateTime { get; set; }

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

	public int? VerifyReqResultId { get; set; }

	public int? VerifyReqAltIntMsgId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSVerificationRequestDetails_Lang> WSVerificationRequestDetails_Lang { get; set; }

	public virtual WSVerificationRequests WSVerificationRequests { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WSVerificationWorkFlowSteps WSVerificationWorkFlowSteps { get; set; }

	public virtual CrmInternalMessage CrmInternalMessage { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public WSVerificationRequestDetails()
	{
		WSVerificationRequestDetails_Lang = (ICollection<WSVerificationRequestDetails_Lang>)new HashSet<WSVerificationRequestDetails_Lang>();
	}
}
