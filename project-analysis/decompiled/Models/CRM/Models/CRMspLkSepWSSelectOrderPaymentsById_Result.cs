using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectOrderPaymentsById_Result
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

	public DateTime? ImportDateTime { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public decimal? ordpayDocAmount { get; set; }

	public int? PreOrderPaymentId { get; set; }

	public string ordpayBankDocNumber { get; set; }

	public int? ordpayLinkAccHeaderId { get; set; }

	public string ordpayLinkAccHeaderNumber { get; set; }

	public int? ordpayLinkAccDetailId { get; set; }

	public int? ordpayLinkAccVoucherId { get; set; }

	public string ordpayLinkAccVoucherNumber { get; set; }

	public string ordpayLinkAccHeaderIdStr { get; set; }

	public string ordpayLinkAccDetailIdStr { get; set; }

	public string ordpayLinkAccVoucherIdStr { get; set; }

	public string ordpayLinkAccPayType { get; set; }

	public int? ordpayCompanyMoneyBagId { get; set; }

	public bool? ordpayDeActive { get; set; }

	public decimal? ordpayAmountTemp { get; set; }

	public string PayTypeTitle { get; set; }

	public int? SepDetailType { get; set; }

	public string SepDetailTypeTitle { get; set; }

	public int? OrderOprType { get; set; }

	public DateTime? ordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? ordpayLinkAccLastTransferDate { get; set; }

	public string ordpayLinkAccFirstTransferDateStr { get; set; }

	public string ordpayLinkAccLastTransferDateStr { get; set; }
}
