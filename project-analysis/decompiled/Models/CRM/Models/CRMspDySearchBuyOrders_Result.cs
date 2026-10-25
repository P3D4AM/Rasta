using System;

namespace CRM.Models;

public class CRMspDySearchBuyOrders_Result
{
	public int BuyOrderID { get; set; }

	public long bordNumber { get; set; }

	public string bordDate { get; set; }

	public DateTime? bordDateTime { get; set; }

	public string BuyOrderOpr { get; set; }

	public string BordInfo { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public string TxtHelp { get; set; }
}
