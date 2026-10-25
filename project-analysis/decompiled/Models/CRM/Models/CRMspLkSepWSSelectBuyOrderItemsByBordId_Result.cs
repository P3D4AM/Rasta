using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectBuyOrderItemsByBordId_Result
{
	public int BuyOrderItemID { get; set; }

	public int BuyOrderId { get; set; }

	public int bordIPrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public double? bordIQuantity { get; set; }

	public decimal? bordICost { get; set; }

	public decimal? bordITotalCost { get; set; }

	public int? bordIPrdUnitId { get; set; }

	public string bordIPrdUnit { get; set; }

	public int? bordICurrencyUnitId { get; set; }

	public string bordICurrencyUnit { get; set; }

	public double? bordIFCR { get; set; }

	public bool? bordINotVisible { get; set; }

	public double? bordIFCRI { get; set; }

	public bool? bordINotInSum { get; set; }

	public int? bordIWHId { get; set; }

	public string bordIWrhsName { get; set; }

	public string bordITracing { get; set; }

	public decimal? bordICostSum { get; set; }

	public decimal? bordIDiscountISum { get; set; }

	public decimal? bordIDiscountSum { get; set; }

	public decimal? bordITaxSum { get; set; }

	public int? bordILinkAccItemId { get; set; }

	public string bordILinkAccWHIdStr { get; set; }

	public double? bordIQuantityTotal { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public bool? PrdQtyNoFCR { get; set; }

	public int? bordIPrdUnitIdI { get; set; }

	public string bordIPrdUnitI { get; set; }

	public double? bordIPrdUnitIRateResult { get; set; }

	public int? bordIPrdColorId { get; set; }

	public int? bordLinkAccBuyOrderId { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public int? SepInvoiceId { get; set; }

	public int? SepInvoiceNumber { get; set; }

	public int? SepInvoiceItemId { get; set; }

	public decimal? SepInvoiceItemQuantity { get; set; }

	public decimal? SepInvoiceItemNetPrice { get; set; }

	public int? SepInvoiceItemRef { get; set; }

	public string SepInvoiceItemTitle { get; set; }

	public string SepInvoiceItemCode { get; set; }

	public DateTime? bordILinkAccFirstTransferDate { get; set; }

	public DateTime? bordILinkAccLastTransferDate { get; set; }

	public string bordILinkAccFirstTransferDateStr { get; set; }

	public string bordILinkAccLastTransferDateStr { get; set; }
}
