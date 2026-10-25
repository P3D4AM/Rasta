using System;

namespace CRM.Models;

public class LkOrderInfoViewModel
{
	public int? QuotationId { get; set; }

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

	public string ordLinkAccOrderNumber { get; set; }

	public long? ordNumber { get; set; }

	public string Company { get; set; }

	public decimal? ordTotalAmount { get; set; }
}
