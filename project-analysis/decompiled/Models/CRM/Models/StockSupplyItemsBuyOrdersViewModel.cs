using System;

namespace CRM.Models;

public class StockSupplyItemsBuyOrdersViewModel
{
	public int BuyOrderID { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string BuyOrderOpr { get; set; }

	public long bordNumber { get; set; }

	public string bordDate { get; set; }

	public DateTime? bordDateTime { get; set; }
}
