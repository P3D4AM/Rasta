using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSVerificationWorkFlowStepsMetadata))]
public class WSVerificationWorkFlowSteps
{
	public int VerificationWorkFlowStepId { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlowStepTitle { get; set; }

	public int? VerifyUserId { get; set; }

	public int? AlternateVerifyUserId { get; set; }

	public string VerifyText { get; set; }

	public int? OrderView { get; set; }

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

	public bool? VerificationWorkFlowStepCanBack { get; set; }

	public bool? VerificationWorkFlowStepObjCanEdit { get; set; }

	public int? AutoReferToAltMin { get; set; }

	public string AutoReferToAltTxt { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSVerificationRequestDetails> WSVerificationRequestDetails { get; set; }

	public virtual ICollection<WSVerificationRequests> WSVerificationRequests { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual ICollection<WSVerificationWorkFlowSteps_Lang> WSVerificationWorkFlowSteps_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public WSVerificationWorkFlowSteps()
	{
		WSVerificationRequestDetails = (ICollection<WSVerificationRequestDetails>)new HashSet<WSVerificationRequestDetails>();
		WSVerificationRequests = (ICollection<WSVerificationRequests>)new HashSet<WSVerificationRequests>();
		WSVerificationWorkFlowSteps_Lang = (ICollection<WSVerificationWorkFlowSteps_Lang>)new HashSet<WSVerificationWorkFlowSteps_Lang>();
	}
}
