using System;

namespace CRMIdealApi.ApiModels;

public class VerifyOrderViewModel : PublicParameters
{
	public int ApiRollId { get; set; }

	public int ApiOrderId { get; set; }

	public int ApiVerifierUserId { get; set; }

	public DateTime ApiVerifyDate { get; set; }

	public int? ApiCompanyId { get; set; }

	public DateTime? ApiFromDate { get; set; }

	public DateTime? ApiToDate { get; set; }

	public bool? ApiCalcAutoScoreInIssue { get; set; }

	public bool? ApiCalcAutoScoreInVerify { get; set; }

	public bool? ApiUpdateCompanyGroups { get; set; }
}
