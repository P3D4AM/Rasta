using System;

namespace CRM.Models;

public class WSspReturnOrderFromPreOrder_Result
{
	public int OrderID { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public string UserName { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? ordPrintFormatId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string OrderInfo { get; set; }

	public DateTime? ordDateTime { get; set; }
}
