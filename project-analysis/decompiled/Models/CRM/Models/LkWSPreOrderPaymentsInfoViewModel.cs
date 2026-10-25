using System;

namespace CRM.Models;

public class LkWSPreOrderPaymentsInfoViewModel
{
	public long RowNumber { get; set; }

	public int PreOrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int pordpayTypeId { get; set; }

	public string pordpayType { get; set; }

	public int pordpayPreOrderId { get; set; }

	public decimal pordpayAmount { get; set; }

	public string pordpayDocNumber { get; set; }

	public string pordpayDocDate { get; set; }

	public decimal? pordpayDocAmount { get; set; }

	public string pordpayDescription { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? pordpayDocDateTime { get; set; }

	public string pordpayLinkAccHeaderNumber { get; set; }

	public string pordpayLinkAccVoucherNumber { get; set; }

	public string pordpayLinkAccHeaderIdStr { get; set; }

	public string pordpayLinkAccDetailIdStr { get; set; }

	public string pordpayLinkAccVoucherIdStr { get; set; }

	public string pordpayLinkAccPayType { get; set; }

	public string pordpayAccountNumber { get; set; }

	public string pordpayLinkAccData { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }
}
