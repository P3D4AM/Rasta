using System;

namespace CRM.Models;

public class WSspReturnOrderFromBuyOrder_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public int? ordPrintFormatId { get; set; }

	public string UserName { get; set; }

	public string ordReferUserName { get; set; }

	public string BuyOrderIds { get; set; }

	public string OrderInfo { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUserName { get; set; }
}
