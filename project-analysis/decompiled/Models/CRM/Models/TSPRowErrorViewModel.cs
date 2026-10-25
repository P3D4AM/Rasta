using System;

namespace CRM.Models;

public class TSPRowErrorViewModel
{
	public int? OrderID { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string OrderOpr { get; set; }

	public string CompanyName { get; set; }

	public string ErrorMessage { get; set; }
}
