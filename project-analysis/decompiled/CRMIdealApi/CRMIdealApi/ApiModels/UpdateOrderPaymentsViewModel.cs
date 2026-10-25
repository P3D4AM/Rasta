using System;

namespace CRMIdealApi.ApiModels;

public class UpdateOrderPaymentsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiOrderId { get; set; }

	public int ApiOrderPaymentId { get; set; }

	public string ApiImportDate { get; set; }

	public DateTime? ApiImportDateTime { get; set; }

	public int? ApiOrdPayTypeId { get; set; }

	public int? ApiOrdPayDocId { get; set; }

	public int? ApiOrdPayDocTypeId { get; set; }

	public decimal? ApiOrdPayAmount { get; set; }

	public string ApiOrdPayDocNumber { get; set; }

	public string ApiOrdPayDescription { get; set; }

	public string ApiOrdPayDocDate { get; set; }

	public DateTime? ApiOrdPayDocDateTime { get; set; }

	public decimal? ApiOrdPayDocAmount { get; set; }

	public int? ApiPreOrderPaymentId { get; set; }

	public string ApiOrdpayBankDocNumber { get; set; }

	public int? LanguageId { get; set; }

	public int? ApiOrdpayLinkAccHeaderId { get; set; }

	public string ApiOrdpayLinkAccHeaderNumber { get; set; }

	public int? ApiOrdpayLinkAccDetailId { get; set; }

	public int? ApiOrdpayLinkAccVoucherId { get; set; }

	public string ApiOrdpayLinkAccVoucherNumber { get; set; }

	public string ApiOrdpayLinkAccHeaderIdStr { get; set; }

	public string ApiOrdpayLinkAccDetailIdStr { get; set; }

	public string ApiOrdpayLinkAccVoucherIdStr { get; set; }

	public string ApiOrdpayLinkAccPayType { get; set; }

	public DateTime? ApiOrdpayLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiOrdpayLinkAccLastTransferDate { get; set; }

	public string ApiOrdpayLinkAccData { get; set; }

	public int? ApiOrdpayBankingBankID { get; set; }

	public int? ApiOrdpayBankingBranchID { get; set; }

	public int? ApiOrdpayBankingAccountID { get; set; }

	public int? ApiOrdpayCashId { get; set; }

	public int? ApiOrdpayGroupIdI { get; set; }

	public int? ApiOrdpayGroupIdII { get; set; }

	public string ApiOrdpayChqSayadNumber { get; set; }

	public string ApiOrdpayChqSerialNumber { get; set; }

	public string ApiTspOrdPayIinn { get; set; }

	public string ApiTspOrdPayAcn { get; set; }

	public string ApiTspOrdPayTrmn { get; set; }

	public int? ApiTspOrdPayPmt { get; set; }

	public int? ApiOrdpayDocDayTemp { get; set; }

	public string ApiOrdpayBankName { get; set; }

	public string ApiOrdpayBranchName { get; set; }

	public string ApiOrdpayBranchCode { get; set; }
}
