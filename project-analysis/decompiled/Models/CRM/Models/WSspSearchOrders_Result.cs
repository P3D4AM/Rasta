using System;

namespace CRM.Models;

public class WSspSearchOrders_Result
{
	public long ordNumber { get; set; }

	public int ordCompanyId { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public int? ordProjectId { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string ordDate { get; set; }

	public string Company { get; set; }

	public string Person { get; set; }

	public string Project { get; set; }

	public int? OrderOprId { get; set; }

	public string OrderOpr { get; set; }

	public int OrderID { get; set; }

	public int ordReferUserId { get; set; }

	public string ReferUserName { get; set; }

	public int? ordSellerId { get; set; }

	public string SellerUserName { get; set; }
}
