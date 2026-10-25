using System;

namespace CRM.Models;

public class CRMspDySearchPreOrders_Result
{
	public int PreOrderID { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public string PreOrderOpr { get; set; }

	public string PordInfo { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public string TxtHelp { get; set; }
}
