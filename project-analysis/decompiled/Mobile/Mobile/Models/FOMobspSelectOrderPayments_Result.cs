using System;

namespace Mobile.Models;

public class FOMobspSelectOrderPayments_Result
{
	public int OrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int ordpayTypeId { get; set; }

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

	public string PayTypeTitle { get; set; }

	public bool? ordpayDeActive { get; set; }

	public decimal? ordpayAmountTemp { get; set; }

	public bool? ordpayIsVerified { get; set; }

	public int? ordpayVerifierId { get; set; }

	public string ordpayVerifier { get; set; }

	public DateTime? ordpayVerifiedRegisterDate { get; set; }

	public string ordpayVerifiedRegisterDatePersian { get; set; }

	public string ordpayFileTypeJson { get; set; }

	public string ordpayFileTypeJsonByName { get; set; }

	public bool? ordpayTypeIsActivePayOnline { get; set; }

	public bool? ordpayTypeIsActiveAddFile { get; set; }
}
