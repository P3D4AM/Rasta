using System;

namespace CRMIdealApi.ApiModels;

public class UpdatePreOrderPaymentsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiPreOrderId { get; set; }

	public int ApiPreOrderPaymentId { get; set; }

	public string ApiImportDate { get; set; }

	public DateTime? ApiImportDateTime { get; set; }

	public int? ApiPordPayTypeId { get; set; }

	public int? ApiPordPayDocId { get; set; }

	public int? ApiPordPayDocTypeId { get; set; }

	public decimal? ApiPordPayAmount { get; set; }

	public string ApiPordPayDocNumber { get; set; }

	public string ApiPordPayDescription { get; set; }

	public string ApiPordPayDocDate { get; set; }

	public DateTime? ApiPordPayDocDateTime { get; set; }

	public decimal? ApiPordPayDocAmount { get; set; }

	public int? LanguageId { get; set; }

	public int? ApiPordpayLinkAccHeaderId { get; set; }

	public string ApiPordpayLinkAccHeaderNumber { get; set; }

	public int? ApiPordpayLinkAccDetailId { get; set; }

	public int? ApiPordpayLinkAccVoucherId { get; set; }

	public string ApiPordpayLinkAccVoucherNumber { get; set; }

	public string ApiPordpayLinkAccHeaderIdStr { get; set; }

	public string ApiPordpayLinkAccDetailIdStr { get; set; }

	public string ApiPordpayLinkAccVoucherIdStr { get; set; }

	public string ApiPordpayLinkAccPayType { get; set; }

	public DateTime? ApiPordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiPordpayLinkAccLastTransferDate { get; set; }

	public string ApiPordpayLinkAccData { get; set; }

	public int? ApiPordpayBankingBankID { get; set; }

	public int? ApiPordpayBankingBranchID { get; set; }

	public int? ApiPordpayBankingAccountID { get; set; }

	public int? ApiPordpayCashId { get; set; }

	public int? ApiPordpayGroupIdI { get; set; }

	public int? ApiPordpayGroupIdII { get; set; }

	public string ApiPordpayChqSayadNumber { get; set; }

	public string ApiPordpayChqSerialNumber { get; set; }

	public int? ApiPordpayDocDayTemp { get; set; }

	public string ApiPordpayBankName { get; set; }

	public string ApiPordpayBranchName { get; set; }

	public string ApiPordpayBranchCode { get; set; }
}
