using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectPreOrderItemsByPordId_Result
{
	public int PreOrderItemID { get; set; }

	public int PreOrderId { get; set; }

	public int pordIPrdId { get; set; }

	public double? pordIQuantity { get; set; }

	public decimal? pordIPrice { get; set; }

	public decimal? pordITotalPrice { get; set; }

	public int? pordIPrdUnitId { get; set; }

	public int? pordIWHId { get; set; }

	public string pordIWrhsName { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public decimal? pordIPriceSum { get; set; }

	public decimal? pordIDiscountSum { get; set; }

	public decimal? pordIDiscountISum { get; set; }

	public decimal? pordITaxSum { get; set; }

	public string pordIPrdUnit { get; set; }

	public string pordICurrencyUnit { get; set; }

	public int? pordILinkAccItemId { get; set; }

	public string pordILinkAccItemIdStr { get; set; }

	public string pordILinkAccWHIdStr { get; set; }

	public int? LinkAccItemId { get; set; }

	public double? pordIFCR { get; set; }

	public double? pordIFCRI { get; set; }

	public double? pordIQuantityTotal { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public int? SepQuotationRef { get; set; }

	public int? SepQuotationNumber { get; set; }

	public int? SepQuotationItemId { get; set; }

	public decimal? SepQuotationItemQuantity { get; set; }

	public decimal? SepQuotationItemNetPrice { get; set; }

	public string SepQuotationItemTitle { get; set; }

	public string SepQuotationItemCode { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public bool? PrdQtyNoFCR { get; set; }

	public int? SepQuotationItemRef { get; set; }

	public DateTime? pordILinkAccFirstTransferDate { get; set; }

	public DateTime? pordILinkAccLastTransferDate { get; set; }

	public string pordILinkAccFirstTransferDateStr { get; set; }

	public string pordILinkAccLastTransferDateStr { get; set; }
}
