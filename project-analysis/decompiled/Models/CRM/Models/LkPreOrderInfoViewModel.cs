using System;

namespace CRM.Models;

public class LkPreOrderInfoViewModel
{
	public int? QuotationId { get; set; }

	public string CustomerParty { get; set; }

	public int? Number { get; set; }

	public DateTime? Date { get; set; }

	public string DatePersian { get; set; }

	public decimal? NetPrice { get; set; }

	public int? ItemCount { get; set; }

	public int? PreOrderId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public long? PordNumber { get; set; }

	public string Company { get; set; }

	public decimal? pordTotalAmount { get; set; }
}
