using System.Collections.Generic;

namespace CRM.Models;

public class OrderDetailsViewModel
{
	public string Message { get; set; }

	public bool IsFind { get; set; }

	public decimal? AllPayRemain { get; set; }

	public string PrintFormatFileName { get; set; }

	public WSspSelectOrderById_Result Order { get; set; }

	public List<WSspSelectOrderItems_Result> OrderItems { get; set; }

	public List<WSspSelectOrderPayments_Result> OrderPayments { get; set; }
}
