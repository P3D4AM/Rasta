using System;

namespace CRM.Models;

public class CRMspSelectPriorFund_Result
{
	public long? RowNum { get; set; }

	public int FundId { get; set; }

	public int FundGroupId { get; set; }

	public int CrmUserId { get; set; }

	public DateTime FundDate { get; set; }

	public string FundDatePersian { get; set; }

	public long FundNumber { get; set; }

	public decimal? FundCredit { get; set; }

	public decimal? FundDebit { get; set; }

	public decimal? FundRemain { get; set; }
}
