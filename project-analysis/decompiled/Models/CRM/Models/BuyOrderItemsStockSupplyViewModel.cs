using System;

namespace CRM.Models;

public class BuyOrderItemsStockSupplyViewModel
{
	public int? StockSupplyId { get; set; }

	public long? stsupNumber { get; set; }

	public string stsupDate { get; set; }

	public DateTime? stsupDateTime { get; set; }

	public string stsupInfo { get; set; }
}
