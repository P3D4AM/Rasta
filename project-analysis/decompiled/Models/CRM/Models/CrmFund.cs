using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFundMetadata))]
public class CrmFund
{
	public int FundId { get; set; }

	public int FundGroupId { get; set; }

	public int CrmUserId { get; set; }

	public DateTime FundDate { get; set; }

	public string FundDatePersian { get; set; }

	public long FundNumber { get; set; }

	public decimal? FundCredit { get; set; }

	public decimal? FundDebit { get; set; }

	public decimal? FundRemain { get; set; }

	public string FundDesc { get; set; }

	public int? FundOrderView { get; set; }

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

	public int? FundVerificationWorkFlowId { get; set; }

	public int? FundVerifierId { get; set; }

	public bool? FundIsVerified { get; set; }

	public int? FundVerifierRequestId { get; set; }

	public DateTime? FundVerifiedRegisterDate { get; set; }

	public string FundVerifiedRegisterDatePersian { get; set; }

	public virtual CrmFundGroups CrmFundGroups { get; set; }

	public virtual ICollection<CrmFund_Lang> CrmFund_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public CrmFund()
	{
		CrmFund_Lang = (ICollection<CrmFund_Lang>)new HashSet<CrmFund_Lang>();
	}
}
