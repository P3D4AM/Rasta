using System;

namespace CRM.Models;

public class LkWSOrderPaymentsInfoViewModel
{
	public long RowNumber { get; set; }

	public int OrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int ordpayTypeId { get; set; }

	public string ordpayType { get; set; }

	public int ordpayOrderId { get; set; }

	public decimal ordpayAmount { get; set; }

	public string ordpayDocNumber { get; set; }

	public string ordpayDocDate { get; set; }

	public string ordpayDescription { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public decimal? ordpayDocAmount { get; set; }

	public int? ordpayLinkAccHeaderId { get; set; }

	public string ordpayLinkAccHeaderNumber { get; set; }

	public int? ordpayLinkAccDetailId { get; set; }

	public int? ordpayLinkAccVoucherId { get; set; }

	public string ordpayLinkAccVoucherNumber { get; set; }

	public string ordpayLinkAccHeaderIdStr { get; set; }

	public string ordpayLinkAccDetailIdStr { get; set; }

	public string ordpayLinkAccVoucherIdStr { get; set; }

	public string LinkAccOrdPayTypeIdStr { get; set; }

	public string PayTypeLinkAccData { get; set; }

	public string ordpayLinkAccPayType { get; set; }

	public string ordpayCardNumber { get; set; }

	public string ordpayAccountNumber { get; set; }

	public string ordpayLinkAccData { get; set; }
}
