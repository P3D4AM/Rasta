using System;

namespace CRM.Models;

public class WSspReturnDocForBuyOrder_Result
{
	public int DocID { get; set; }

	public int DocNumber { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string DocDate { get; set; }

	public int OprId { get; set; }

	public string DocOpr { get; set; }

	public int? OprType { get; set; }

	public string Info { get; set; }
}
