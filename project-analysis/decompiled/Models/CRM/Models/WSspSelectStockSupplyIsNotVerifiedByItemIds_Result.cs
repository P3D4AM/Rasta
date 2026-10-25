using System;

namespace CRM.Models;

public class WSspSelectStockSupplyIsNotVerifiedByItemIds_Result
{
	public int StockSupplyId { get; set; }

	public int StockSupplyOprId { get; set; }

	public string StockSupplyOpr { get; set; }

	public int stsupReferUserId { get; set; }

	public string stsupReferUser { get; set; }

	public long stsupNumber { get; set; }

	public DateTime stsupDateTime { get; set; }

	public string stsupDate { get; set; }

	public string stsupIPrdName { get; set; }

	public string stsupIPrdCode { get; set; }
}
