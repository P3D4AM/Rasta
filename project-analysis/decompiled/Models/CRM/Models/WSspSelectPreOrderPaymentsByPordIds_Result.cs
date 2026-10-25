using System;

namespace CRM.Models;

public class WSspSelectPreOrderPaymentsByPordIds_Result
{
	public int PreOrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int pordpayTypeId { get; set; }

	public string pordpayType { get; set; }

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

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? pordpayDocDateTime { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? pordpayLinkAccHeaderId { get; set; }

	public string pordpayLinkAccHeaderNumber { get; set; }

	public int? pordpayLinkAccDetailId { get; set; }

	public int? pordpayLinkAccVoucherId { get; set; }

	public string pordpayLinkAccVoucherNumber { get; set; }

	public string pordpayLinkAccHeaderIdStr { get; set; }

	public string pordpayLinkAccDetailIdStr { get; set; }

	public string pordpayLinkAccVoucherIdStr { get; set; }

	public int? pordpayCompanyMoneyBagId { get; set; }

	public bool? pordpayDeActive { get; set; }

	public decimal? pordpayAmountTemp { get; set; }

	public bool? pordpayIsVerified { get; set; }

	public int? pordpayVerifierId { get; set; }

	public string pordpayVerifier { get; set; }

	public DateTime? pordpayVerifiedRegisterDate { get; set; }

	public string pordpayVerifiedRegisterDatePersian { get; set; }

	public string pordpayFileTypeJson { get; set; }

	public string pordpayLinkAccPayType { get; set; }

	public string pordpayAccountNumber { get; set; }

	public DateTime? pordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? pordpayLinkAccLastTransferDate { get; set; }

	public string pordpayDocDateTemp { get; set; }

	public DateTime? pordpayDocDateTimeTemp { get; set; }

	public string pordpayLinkAccData { get; set; }

	public int? pordpayCId { get; set; }

	public string CenterName { get; set; }

	public int? pordpayBankingBankID { get; set; }

	public string pordpayBankingBank { get; set; }

	public int? pordpayBankingBranchID { get; set; }

	public string pordpayBankingBranch { get; set; }

	public int? pordpayBankingAccountID { get; set; }

	public string pordpayBankingAccount { get; set; }

	public int? pordpayCashId { get; set; }

	public string pordpayCash { get; set; }

	public int? pordpayGroupIdI { get; set; }

	public string pordpayGroupI { get; set; }

	public int? pordpayGroupIdII { get; set; }

	public string pordpayGroupII { get; set; }

	public string pordpayChqSayadNumber { get; set; }

	public string pordpayChqSerialNumber { get; set; }

	public int? pordpayDocDayTemp { get; set; }
}
