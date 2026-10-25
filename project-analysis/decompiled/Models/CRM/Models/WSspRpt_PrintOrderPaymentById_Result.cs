using System;

namespace CRM.Models;

public class WSspRpt_PrintOrderPaymentById_Result
{
	public int OrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int ordpayTypeId { get; set; }

	public string ordpayType { get; set; }

	public int? ordpayTypeKind { get; set; }

	public int? ordpayTypeMode { get; set; }

	public int ordpayOrderId { get; set; }

	public int? ordpayDocId { get; set; }

	public int? ordpayDocTypeId { get; set; }

	public decimal ordpayAmount { get; set; }

	public string ordpayDocNumber { get; set; }

	public string ordpayDocDate { get; set; }

	public string ordpayDescription { get; set; }

	public int? ordpayFirstRegisterUserId { get; set; }

	public string ordpayFirstRegisteDatePersian { get; set; }

	public DateTime? ordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public Guid? GUId { get; set; }

	public decimal? ordpayDocAmount { get; set; }

	public int? PreOrderPaymentId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? ordpayLinkAccHeaderId { get; set; }

	public string ordpayLinkAccHeaderNumber { get; set; }

	public int? ordpayLinkAccDetailId { get; set; }

	public int? ordpayLinkAccVoucherId { get; set; }

	public string ordpayLinkAccVoucherNumber { get; set; }

	public string ordpayBankDocNumber { get; set; }

	public string ordpayLinkAccHeaderIdStr { get; set; }

	public string ordpayLinkAccDetailIdStr { get; set; }

	public string ordpayLinkAccVoucherIdStr { get; set; }

	public int? ordpayCompanyMoneyBagId { get; set; }

	public bool? ordpayDeActive { get; set; }

	public decimal? ordpayAmountTemp { get; set; }

	public bool? ordpayIsVerified { get; set; }

	public int? ordpayVerifierId { get; set; }

	public string ordpayVerifier { get; set; }

	public DateTime? ordpayVerifiedRegisterDate { get; set; }

	public string ordpayVerifiedRegisterDatePersian { get; set; }

	public string ordpayFileTypeJson { get; set; }

	public string ordpayLinkAccPayType { get; set; }

	public string ordpayCardNumber { get; set; }

	public string ordpayAccountNumber { get; set; }

	public DateTime? ordpayBankDocDate { get; set; }

	public string ordpayBankDocDatePersian { get; set; }

	public decimal? ordpayBankDocAmount { get; set; }

	public string ordpayBankDocDesc { get; set; }

	public string ordpayBankDocDescI { get; set; }

	public int? ordpayBankDocRegisterUserId { get; set; }

	public string ordpayBankDocRegisterUser { get; set; }

	public DateTime? ordpayBankDocRegisterDate { get; set; }

	public string ordpayBankDocRegisterDatePersian { get; set; }

	public DateTime? ordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? ordpayLinkAccLastTransferDate { get; set; }

	public string ordpayDocDateTemp { get; set; }

	public DateTime? ordpayDocDateTimeTemp { get; set; }

	public string ordpayLinkAccData { get; set; }

	public int? ordpayHeadingUpDay { get; set; }

	public decimal? ordpayHeadingUpAmount { get; set; }

	public int? ordpayCId { get; set; }

	public string CenterName { get; set; }

	public int? ordpayBankingBankID { get; set; }

	public string ordpayBankingBank { get; set; }

	public int? ordpayBankingBranchID { get; set; }

	public string ordpayBankingBranch { get; set; }

	public int? ordpayBankingAccountID { get; set; }

	public string ordpayBankingAccount { get; set; }

	public int? ordpayCashId { get; set; }

	public string ordpayCash { get; set; }

	public int? ordpayGroupIdI { get; set; }

	public string ordpayGroupI { get; set; }

	public int? ordpayGroupIdII { get; set; }

	public string ordpayGroupII { get; set; }

	public string ordpayChqSayadNumber { get; set; }

	public string ordpayChqSerialNumber { get; set; }

	public string TspOrdPayIinn { get; set; }

	public string TspOrdPayAcn { get; set; }

	public string TspOrdPayTrmn { get; set; }

	public int? TspOrdPayPmt { get; set; }

	public int? ordpayDocDayTemp { get; set; }

	public string ordpayBankName { get; set; }

	public string ordpayBranchName { get; set; }

	public string ordpayBranchCode { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public int ordCompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public string CompanyPersonName { get; set; }

	public int? ordProjectId { get; set; }

	public string ProjectTitle { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordTotalAmountStr { get; set; }

	public int? ordReferUserId { get; set; }

	public string ordReferUserName { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

	public string ordNumRef { get; set; }

	public int? ordGroupId { get; set; }

	public string OrderGroupName { get; set; }

	public int? ordSellerId { get; set; }

	public string ordSellerName { get; set; }

	public DateTime? ordDeadlineDate { get; set; }

	public string ordDeadlineDatePersian { get; set; }

	public int? rptUserId { get; set; }

	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }
}
