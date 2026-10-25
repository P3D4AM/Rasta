using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderPayments_Result
{
	public int ApiOrderPaymentId { get; set; }

	public string ApiImportDate { get; set; }

	public int ApiOrdpayTypeId { get; set; }

	public string ApiOrdpayType { get; set; }

	public int ApiOrdpayOrderId { get; set; }

	public int? ApiOrdpayDocId { get; set; }

	public int? ApiOrdpayDocTypeId { get; set; }

	public decimal ApiOrdpayAmount { get; set; }

	public string ApiOrdpayDocNumber { get; set; }

	public string ApiOrdpayDocDate { get; set; }

	public string ApiOrdpayDescription { get; set; }

	public int ApiFPId { get; set; }

	public DateTime? ApiImportDateTime { get; set; }

	public DateTime? ApiOrdpayDocDateTime { get; set; }

	public decimal? ApiOrdpayDocAmount { get; set; }

	public int? ApiPreOrderPaymentId { get; set; }

	public string ApiOrdpayBankDocNumber { get; set; }

	public short ApiMonth1 { get; set; }

	public int ApiEditUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiOrdpayCId { get; set; }

	public string ApiOrdpayCenterName { get; set; }

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

	public string ApiOrdpayBankingBank { get; set; }

	public int? ApiOrdpayBankingBranchID { get; set; }

	public string ApiOrdpayBankingBranch { get; set; }

	public int? ApiOrdpayBankingAccountID { get; set; }

	public string ApiOrdpayBankingAccount { get; set; }

	public int? ApiOrdpayCashId { get; set; }

	public string ApiOrdpayCash { get; set; }

	public int? ApiOrdpayGroupIdI { get; set; }

	public string ApiOrdpayGroupI { get; set; }

	public int? ApiOrdpayGroupIdII { get; set; }

	public string ApiOrdpayGroupII { get; set; }

	public string ApiOrdpayChqSayadNumber { get; set; }

	public string ApiOrdpayChqSerialNumber { get; set; }

	public string ApiTspOrdPayIinn { get; set; }

	public string ApiTspOrdPayAcn { get; set; }

	public string ApiTspOrdPayTrmn { get; set; }

	public int? ApiTspOrdPayPmt { get; set; }

	public int? ApiOrdpayDocDayTemp { get; set; }

	public string ApiOrdpayBranchCode { get; set; }

	public string ApiOrdpayBankName { get; set; }

	public string ApiOrdpayBranchName { get; set; }
}
