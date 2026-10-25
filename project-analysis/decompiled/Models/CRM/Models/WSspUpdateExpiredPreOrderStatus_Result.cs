using System;

namespace CRM.Models;

public class WSspUpdateExpiredPreOrderStatus_Result
{
	public int PreOrderID { get; set; }

	public int? PreOrderOprID { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public string pordLinkAccData { get; set; }

	public DateTime? pordLinkAccFirstTransferDate { get; set; }

	public DateTime? pordLinkAccLastTransferDate { get; set; }
}
