using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectPreOrderPayments_Result
{
	public string ApiImportDate { get; set; }

	public int ApiPordpayTypeId { get; set; }

	public string ApiPordpayType { get; set; }

	public int ApiPordpayPreOrderId { get; set; }

	public string ApiPordpayPreOrder { get; set; }

	public int? ApiPordpayDocId { get; set; }

	public int? ApiPordpayDocTypeId { get; set; }

	public decimal ApiPordpayAmount { get; set; }

	public string ApiPordpayDocNumber { get; set; }

	public string ApiPordpayDocDate { get; set; }

	public decimal? ApiPordpayDocAmount { get; set; }

	public string ApiPordpayDescription { get; set; }

	public int ApiFPId { get; set; }

	public DateTime? ApiImportDateTime { get; set; }

	public DateTime? ApiPordpayDocDateTime { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiAppType { get; set; }

	public int? ApiPreOrderPaymentId { get; set; }

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

	public string ApiPordpayBankingBank { get; set; }

	public int? ApiPordpayBankingBranchID { get; set; }

	public string ApiPordpayBankingBranch { get; set; }

	public int? ApiPordpayBankingAccountID { get; set; }

	public string ApiPordpayBankingAccount { get; set; }

	public int? ApiPordpayCashId { get; set; }

	public string ApiPordpayCash { get; set; }

	public int? ApiPordpayGroupIdI { get; set; }

	public string ApiPordpayGroupI { get; set; }

	public int? ApiPordpayGroupIdII { get; set; }

	public string ApiPordpayGroupII { get; set; }

	public string ApiPordpayChqSayadNumber { get; set; }

	public string ApiPordpayChqSerialNumber { get; set; }

	public int? ApiPordpayDocDayTemp { get; set; }

	public string ApiPordpayBranchCode { get; set; }

	public string ApiPordpayBankName { get; set; }

	public string ApiPordpayBranchName { get; set; }
}
