using System;

namespace CRM.Models;

public class WSspReturnPreOrderFromStockSupply_Result
{
	public int PreOrderID { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? PreOrderOprID { get; set; }

	public string PreOrderOpr { get; set; }

	public string PreOrderInfo { get; set; }

	public long? pordNumberRevision { get; set; }
}
