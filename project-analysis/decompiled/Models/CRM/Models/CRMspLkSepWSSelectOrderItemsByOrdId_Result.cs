using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectOrderItemsByOrdId_Result
{
	public int OrderItemID { get; set; }

	public int OrderId { get; set; }

	public int ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public string ordIPrdUnit { get; set; }

	public int? ordICurrencyUnitId { get; set; }

	public string ordICurrencyUnit { get; set; }

	public double? ordIFCR { get; set; }

	public bool? ordINotVisible { get; set; }

	public double? ordIFCRI { get; set; }

	public bool? ordINotInSum { get; set; }

	public int? ordIWHId { get; set; }

	public string ordIWrhsName { get; set; }

	public decimal? ordIRound { get; set; }

	public decimal? ordIRoundPlus { get; set; }

	public string ordITracing { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public int? ordILinkAccItemId { get; set; }

	public string ordILinkAccItemIdStr { get; set; }

	public string ordILinkAccWHIdStr { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public int? ordIPrdUnitIdI { get; set; }

	public string ordIPrdUnitI { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public int? ordIPrdColorId { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? SepInvoiceId { get; set; }

	public int? SepInvoiceNumber { get; set; }

	public int? SepInvoiceItemId { get; set; }

	public decimal? SepInvoiceItemQuantity { get; set; }

	public decimal? SepInvoiceItemNetPrice { get; set; }

	public string SepInvoiceItemTitle { get; set; }

	public string SepInvoiceItemCode { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public bool? PrdQtyNoFCR { get; set; }

	public int? SepInvoiceItemRef { get; set; }

	public DateTime? ordILinkAccFirstTransferDate { get; set; }

	public DateTime? ordILinkAccLastTransferDate { get; set; }

	public string ordILinkAccFirstTransferDateStr { get; set; }

	public string ordILinkAccLastTransferDateStr { get; set; }
}
