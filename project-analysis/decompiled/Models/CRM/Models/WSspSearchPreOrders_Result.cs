using System;

namespace CRM.Models;

public class WSspSearchPreOrders_Result
{
	public long pordNumber { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public DateTime? pordDateTime { get; set; }

	public string pordDate { get; set; }

	public string Company { get; set; }

	public string Person { get; set; }

	public string Project { get; set; }

	public int? PreOrderOprID { get; set; }

	public int? pordTypeId { get; set; }

	public string PreOrderOpr { get; set; }

	public string PreOrderType { get; set; }

	public int PreOrderID { get; set; }

	public int pordReferUserId { get; set; }

	public string ReferUserName { get; set; }

	public int? pordSellerId { get; set; }

	public string SellerUserName { get; set; }
}
