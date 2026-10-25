using System;
using System.Collections.Generic;

namespace CRM.Models;

public class VerificationWorkflowViewModel
{
	public int? ObjectTypeId { get; set; }

	public int? ObjectId { get; set; }

	public dynamic ObjectInfo { get; set; }

	public int? ReplaceUserId { get; set; }

	public string ReplaceUser { get; set; }

	public bool? ReplaceUserIsVerified { get; set; }

	public string ReplaceUserIsVerifiedDate { get; set; }

	public string ReplaceUserIsVerifiedDateI { get; set; }

	public int? ReplaceUserIntMsgId { get; set; }

	public int? SellerUserId { get; set; }

	public string SellerUserName { get; set; }

	public int? ReferUserId { get; set; }

	public string ReferUserName { get; set; }

	public int? SuppUserId { get; set; }

	public string SuppUserName { get; set; }

	public int? SupReferUserId { get; set; }

	public string SupReferUserName { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUserName { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ResponsibleUserName { get; set; }

	public int? CmpReferUserId { get; set; }

	public string CmpReferUserName { get; set; }

	public int? CmpSuppUserId { get; set; }

	public string CmpSuppUserName { get; set; }

	public int? SaleCenterReferUserId { get; set; }

	public string SaleCenterReferUserName { get; set; }

	public WSspSelectVerificationWorkFlowWithId_Result Workflow { get; set; }

	public List<WSspSelectVerificationWorkFlowSteps_Result> WorkFlowSteps { get; set; }

	public WSspSelectVerificationRequests_Result VerificationRequest { get; set; }

	public List<WSspSelectVerificationRequestsByReqId_Result> VerificationRequestDetails { get; set; }

	public bool? UnableToStart { get; set; }

	public string UnableToStartReason { get; set; }

	public bool? IsCanceled { get; set; }

	public int? CancelerUserId { get; set; }

	public string CancelerUser { get; set; }

	public DateTime? CanceledDate { get; set; }

	public string CanceledDatePersian { get; set; }
}
