using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectBuyOrderPaymentsById_Result
{
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

	public DateTime? ImportDateTime { get; set; }

	public DateTime? bordpayDocDateTime { get; set; }

	public decimal? bordpayDocAmount { get; set; }

	public int? bordpayLinkAccHeaderId { get; set; }

	public string bordpayLinkAccHeaderNumber { get; set; }

	public int? bordpayLinkAccDetailId { get; set; }

	public int? bordpayLinkAccVoucherId { get; set; }

	public string bordpayLinkAccVoucherNumber { get; set; }

	public string bordpayLinkAccPayType { get; set; }

	public bool? bordpayDeActive { get; set; }

	public string PayTypeTitle { get; set; }

	public int? SepDetailType { get; set; }

	public string SepDetailTypeTitle { get; set; }

	public DateTime? bordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? bordpayLinkAccLastTransferDate { get; set; }

	public string bordpayLinkAccFirstTransferDateStr { get; set; }

	public string bordpayLinkAccLastTransferDateStr { get; set; }
}
