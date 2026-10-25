using System;

namespace Mobile.Models;

public class MobspSelectPreOrderPayments_Result
{
	public int PreOrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int pordpayTypeId { get; set; }

	public int pordpayPreOrderId { get; set; }

	public int? pordpayDocId { get; set; }

	public int? pordpayDocTypeId { get; set; }

	public decimal pordpayAmount { get; set; }

	public string pordpayDocNumber { get; set; }

	public string pordpayDocDate { get; set; }

	public decimal? pordpayDocAmount { get; set; }

	public string pordpayDescription { get; set; }

	public int? pordpayFirstRegisterUserId { get; set; }

	public string pordpayFirstRegisteDatePersian { get; set; }

	public DateTime? pordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? pordpayDocDateTime { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? pordpayCompanyMoneyBagId { get; set; }

	public bool? pordpayDeActive { get; set; }

	public decimal? pordpayAmountTemp { get; set; }

	public bool? pordpayIsVerified { get; set; }

	public int? pordpayVerifierId { get; set; }

	public DateTime? pordpayVerifiedRegisterDate { get; set; }

	public string pordpayVerifiedRegisterDatePersian { get; set; }

	public string pordpayFileTypeJson { get; set; }

	public string pordpayType { get; set; }

	public string RegisterUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string pordpayVerifier { get; set; }

	public string pordpayFileTypeJsonByName { get; set; }

	public string pordpayAccountNumber { get; set; }

	public string pordpayDocDateTemp { get; set; }

	public DateTime? pordpayDocDateTimeTemp { get; set; }

	public string pordpayLinkAccData { get; set; }

	public bool? IsSentToLinkAcc { get; set; }

	public int? pordpayLinkAccHeaderId { get; set; }

	public string pordpayLinkAccHeaderNumber { get; set; }

	public int? pordpayLinkAccDetailId { get; set; }

	public int? pordpayLinkAccVoucherId { get; set; }

	public string pordpayLinkAccVoucherNumber { get; set; }

	public string pordpayLinkAccHeaderIdStr { get; set; }

	public string pordpayLinkAccDetailIdStr { get; set; }

	public string pordpayLinkAccVoucherIdStr { get; set; }

	public int? OrderPaymentId { get; set; }

	public string OrderInfo { get; set; }

	public int? pordpayBankingBankID { get; set; }

	public int? pordpayBankingBranchID { get; set; }

	public int? pordpayBankingAccountID { get; set; }

	public int? pordpayCashId { get; set; }

	public int? pordpayGroupIdI { get; set; }

	public int? pordpayGroupIdII { get; set; }

	public string pordpayChqSayadNumber { get; set; }

	public string pordpayChqSerialNumber { get; set; }

	public int? pordpayDocDayTemp { get; set; }

	public string pordpayBankName { get; set; }

	public string pordpayBranchCode { get; set; }

	public string pordpayBranchName { get; set; }

	public int? pordpayDeActiveUserId { get; set; }

	public string pordpayDeActiveUser { get; set; }

	public DateTime? pordpayDeActiveDate { get; set; }

	public string pordpayDeActiveDatePersian { get; set; }
}
