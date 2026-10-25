using System;

namespace CRMIdealApi.ApiModels;

public class IssuePreOrderPaymentsViewModel
{
	public int? PordpayTypeId { get; set; }

	public int? PordpayDocId { get; set; }

	public int? PordpayDocTypeId { get; set; }

	public decimal? PordpayAmount { get; set; }

	public string PordpayDocNumber { get; set; }

	public string PordpayDescription { get; set; }

	public DateTime? PordpayDocDateTime { get; set; }

	public decimal? PordpayDocAmount { get; set; }

	public int? PordpayBankingBankID { get; set; }

	public int? PordpayBankingBranchID { get; set; }

	public int? PordpayBankingAccountID { get; set; }

	public int? PordpayCashId { get; set; }

	public int? PordpayGroupIdI { get; set; }

	public int? PordpayGroupIdII { get; set; }

	public string PordpayChqSayadNumber { get; set; }

	public string PordpayChqSerialNumber { get; set; }

	public int? PordpayDocDayTemp { get; set; }
}
