using System;

namespace CRM.Models;

public class WSspRpt_PrintBuyOrderPayments_Result
{
	public string bordpayType { get; set; }

	public int BuyOrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int bordpayTypeId { get; set; }

	public int bordpayOrderId { get; set; }

	public int? bordpayDocId { get; set; }

	public int? bordpayDocTypeId { get; set; }

	public decimal bordpayAmount { get; set; }

	public string bordpayDocNumber { get; set; }

	public string bordpayDocDate { get; set; }

	public string bordpayDescription { get; set; }

	public int? bordpayFirstRegisterUserId { get; set; }

	public string bordpayFirstRegisteDatePersian { get; set; }

	public DateTime? bordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? bordpayDocDateTime { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public decimal? bordpayDocAmount { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? bordpayLinkAccHeaderId { get; set; }

	public string bordpayLinkAccHeaderNumber { get; set; }

	public int? bordpayLinkAccDetailId { get; set; }

	public int? bordpayLinkAccVoucherId { get; set; }

	public string bordpayLinkAccVoucherNumber { get; set; }

	public bool? bordpayDeActive { get; set; }

	public string bordpayLinkAccPayType { get; set; }

	public string bordpayAccountNumber { get; set; }

	public DateTime? bordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? bordpayLinkAccLastTransferDate { get; set; }

	public string bordpayLinkAccHeaderIdStr { get; set; }

	public string bordpayLinkAccDetailIdStr { get; set; }

	public string bordpayLinkAccVoucherIdStr { get; set; }

	public decimal? bordpayAmountTemp { get; set; }

	public string bordpayDocDateTemp { get; set; }

	public DateTime? bordpayDocDateTimeTemp { get; set; }

	public int? bordpayHeadingUpDay { get; set; }

	public decimal? bordpayHeadingUpAmount { get; set; }

	public bool? bordpayIsVerified { get; set; }

	public int? bordpayVerifierId { get; set; }

	public string bordpayVerifier { get; set; }

	public DateTime? bordpayVerifiedRegisterDate { get; set; }

	public string bordpayVerifiedRegisterDatePersian { get; set; }

	public string bordpayLinkAccData { get; set; }
}
