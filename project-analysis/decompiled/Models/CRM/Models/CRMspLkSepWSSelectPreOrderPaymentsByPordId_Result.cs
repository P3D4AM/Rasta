using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result
{
	public int PreOrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int pordpayTypeId { get; set; }

	public int pordpayPreOrderId { get; set; }

	public decimal pordpayAmount { get; set; }

	public string pordpayDocNumber { get; set; }

	public string pordpayDocDate { get; set; }

	public decimal? pordpayDocAmount { get; set; }

	public string pordpayDescription { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? pordpayDocDateTime { get; set; }

	public string PayTypeTitle { get; set; }

	public int? pordpayLinkAccHeaderId { get; set; }

	public string pordpayLinkAccHeaderNumber { get; set; }

	public int? pordpayLinkAccDetailId { get; set; }

	public int? pordpayLinkAccVoucherId { get; set; }

	public string pordpayLinkAccVoucherNumber { get; set; }

	public string pordpayLinkAccHeaderIdStr { get; set; }

	public string pordpayLinkAccDetailIdStr { get; set; }

	public string pordpayLinkAccVoucherIdStr { get; set; }

	public int? LinkAccHeaderId { get; set; }

	public int? LinkAccDetailId { get; set; }

	public int? LinkAccVoucherId { get; set; }

	public string pordpayLinkAccPayType { get; set; }

	public int? SepHeaderId { get; set; }

	public string SepHeaderNumber { get; set; }

	public int? SepDetailId { get; set; }

	public int? SepVoucherId { get; set; }

	public int? SepVoucherNumber { get; set; }

	public int? SepDetailType { get; set; }

	public string SepDetailTypeTitle { get; set; }

	public decimal? SepHeaderTotalAmount { get; set; }

	public DateTime? pordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? pordpayLinkAccLastTransferDate { get; set; }

	public string pordpayLinkAccFirstTransferDateStr { get; set; }

	public string pordpayLinkAccLastTransferDateStr { get; set; }

	public int? pordpayLinkAccRefundChequeId { get; set; }

	public string pordpayLinkAccRefundChequeNum { get; set; }

	public int? pordpayLinkAccRefundChequeVoucherId { get; set; }

	public string pordpayLinkAccRefundChequeVoucherNum { get; set; }

	public int? SepRefundChequeId { get; set; }

	public int? SepRefundChequeNum { get; set; }

	public int? SepRefundChequeVoucherId { get; set; }

	public int? SepRefundChequeVoucherNum { get; set; }
}
