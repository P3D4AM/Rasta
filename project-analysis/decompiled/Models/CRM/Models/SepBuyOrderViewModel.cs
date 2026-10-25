using System;

namespace CRM.Models;

public class SepBuyOrderViewModel
{
	public int? InventoryPurchaseInvoiceID { get; set; }

	public string Vendor { get; set; }

	public int? Number { get; set; }

	public DateTime? Date { get; set; }

	public string DatePersian { get; set; }

	public decimal? TotalNetPrice { get; set; }

	public int? ItemCount { get; set; }

	public int? BuyOrderId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }

	public int? bordLinkAccBuyOrderId { get; set; }

	public long? bordNumber { get; set; }

	public string Company { get; set; }

	public decimal? bordTotalAmount { get; set; }
}
