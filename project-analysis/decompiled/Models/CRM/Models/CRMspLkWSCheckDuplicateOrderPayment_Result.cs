using System;

namespace CRM.Models;

public class CRMspLkWSCheckDuplicateOrderPayment_Result
{
	public decimal? ordpayDocAmount { get; set; }

	public decimal? ordpayAmount { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public string ordpayDocNumber { get; set; }

	public int? AlreadySendOrderPaymentId { get; set; }

	public int? AlreadyOrdpayLinkAccHeaderId { get; set; }

	public string AlreadyOrdpayLinkAccHeaderNumber { get; set; }

	public int? AlreadyOrdpayLinkAccDetailId { get; set; }

	public int? AlreadyOrdpayLinkAccVoucherId { get; set; }

	public string AlreadyOrdpayLinkAccVoucherNumber { get; set; }

	public string AlreadyOrdpayLinkAccPayType { get; set; }

	public int? SepAlreadyOrdReceiptHeaderId { get; set; }

	public string AlreadyOrdpayLinkAccHeaderIdStr { get; set; }

	public string AlreadyOrdpayLinkAccDetailIdStr { get; set; }

	public string AlreadyOrdpayLinkAccVoucherIdStr { get; set; }

	public string AlreadySendOrdpayLinkAccData { get; set; }

	public bool? ordpayTypeIsChq { get; set; }
}
