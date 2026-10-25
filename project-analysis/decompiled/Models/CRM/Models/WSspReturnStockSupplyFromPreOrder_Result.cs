using System;

namespace CRM.Models;

public class WSspReturnStockSupplyFromPreOrder_Result
{
	public int StockSupplyId { get; set; }

	public int StockSupplyOprId { get; set; }

	public string StockSupplyOpr { get; set; }

	public int stsupReferUserId { get; set; }

	public string stsupReferUser { get; set; }

	public long stsupNumber { get; set; }

	public DateTime stsupDateTime { get; set; }

	public string stsupDate { get; set; }

	public string stsupInfo { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }
}
