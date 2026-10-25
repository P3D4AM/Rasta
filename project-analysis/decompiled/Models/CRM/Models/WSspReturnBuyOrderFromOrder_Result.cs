using System;

namespace CRM.Models;

public class WSspReturnBuyOrderFromOrder_Result
{
	public int BuyOrderID { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string BuyOrderOpr { get; set; }

	public long bordNumber { get; set; }

	public string bordDate { get; set; }

	public DateTime? bordDateTime { get; set; }

	public int? bordReferUserId { get; set; }

	public string bordReferUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string BuyOrderInfo { get; set; }
}
