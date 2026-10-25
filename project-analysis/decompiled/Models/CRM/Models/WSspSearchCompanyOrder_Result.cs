using System;

namespace CRM.Models;

public class WSspSearchCompanyOrder_Result
{
	public int OrderID { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string OrderOpr { get; set; }

	public string OrdInfo { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordTotalAmountStr { get; set; }

	public string TxtHelp { get; set; }
}
