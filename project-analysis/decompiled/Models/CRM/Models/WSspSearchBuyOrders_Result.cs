using System;

namespace CRM.Models;

public class WSspSearchBuyOrders_Result
{
	public long bordNumber { get; set; }

	public int bordCompanyId { get; set; }

	public int? bordCompanyPersonId { get; set; }

	public int? bordProjectId { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public DateTime? bordDateTime { get; set; }

	public string bordDate { get; set; }

	public string Company { get; set; }

	public string Person { get; set; }

	public string Project { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string BuyOrderOpr { get; set; }

	public int? bordReferUserId { get; set; }

	public string ReferUserName { get; set; }

	public int BuyOrderID { get; set; }
}
