using System;

namespace CRM.Models;

public class SepOrderViewModel
{
	public int? InvoiceId { get; set; }

	public string CustomerParty { get; set; }

	public int? Number { get; set; }

	public DateTime? Date { get; set; }

	public string DatePersian { get; set; }

	public decimal? NetPrice { get; set; }

	public int? ItemCount { get; set; }

	public int? OrderId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public long? OrdNumber { get; set; }

	public string Company { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public bool? ordLinkAccConflict { get; set; }
}
