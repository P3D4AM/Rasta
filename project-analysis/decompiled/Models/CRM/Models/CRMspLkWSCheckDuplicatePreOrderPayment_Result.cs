using System;

namespace CRM.Models;

public class CRMspLkWSCheckDuplicatePreOrderPayment_Result
{
	public decimal? pordpayDocAmount { get; set; }

	public decimal? pordpayAmount { get; set; }

	public DateTime? pordpayDocDateTime { get; set; }

	public string pordpayDocNumber { get; set; }

	public int? AlreadySendPreOrderPaymentId { get; set; }

	public int? AlreadyPordpayLinkAccHeaderId { get; set; }

	public string AlreadyPordpayLinkAccHeaderNumber { get; set; }

	public int? AlreadyPordpayLinkAccDetailId { get; set; }

	public int? AlreadyPordpayLinkAccVoucherId { get; set; }

	public string AlreadyPordpayLinkAccVoucherNumber { get; set; }

	public string AlreadyPordpayLinkAccPayType { get; set; }

	public int? SepAlreadyOrdReceiptHeaderId { get; set; }

	public string AlreadyPordpayLinkAccHeaderIdStr { get; set; }

	public string AlreadyPordpayLinkAccDetailIdStr { get; set; }

	public string AlreadyPordpayLinkAccVoucherIdStr { get; set; }

	public string AlreadySendPordpayLinkAccData { get; set; }

	public bool? pordpayTypeIsChq { get; set; }
}
