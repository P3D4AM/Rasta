using System;

namespace CRM.Models;

public class SepDocViewModel
{
	public int? InventoryId { get; set; }

	public string Stock { get; set; }

	public string DestinationStock { get; set; }

	public string Customer { get; set; }

	public int? Number { get; set; }

	public DateTime? Date { get; set; }

	public string DatePersian { get; set; }

	public int? ItemCount { get; set; }

	public int? DocId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }

	public int? DocLinkAccDocId { get; set; }

	public int? DocNumber { get; set; }

	public string Company { get; set; }

	public int? StockWHId { get; set; }

	public int? DestinationStockWHId { get; set; }
}
