using System;

namespace CRMIdealApi.ApiModels;

public class IssueOrderPaymentsViewModel
{
	public int? OrdPayTypeId { get; set; }

	public int? OrdPayDocId { get; set; }

	public int? OrdPayDocTypeId { get; set; }

	public decimal? OrdPayAmount { get; set; }

	public string OrdPayDocNumber { get; set; }

	public string OrdPayDescription { get; set; }

	public DateTime? OrdPayDocDateTime { get; set; }

	public decimal? OrdPayDocAmount { get; set; }

	public int? PreOrderPaymentId { get; set; }

	public string OrdpayBankDocNumber { get; set; }

	public int? OrdpayBankingBankID { get; set; }

	public int? OrdpayBankingBranchID { get; set; }

	public int? OrdpayBankingAccountID { get; set; }

	public int? OrdpayCashId { get; set; }

	public int? OrdpayGroupIdI { get; set; }

	public int? OrdpayGroupIdII { get; set; }

	public string OrdpayChqSayadNumber { get; set; }

	public string OrdpayChqSerialNumber { get; set; }

	public string TspOrdPayIinn { get; set; }

	public string TspOrdPayAcn { get; set; }

	public string TspOrdPayTrmn { get; set; }

	public int? TspOrdPayPmt { get; set; }

	public string OrdpayDocDayTemp { get; set; }
}
