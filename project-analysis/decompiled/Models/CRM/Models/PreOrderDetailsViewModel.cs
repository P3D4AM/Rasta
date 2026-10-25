using System.Collections.Generic;

namespace CRM.Models;

public class PreOrderDetailsViewModel
{
	public string Message { get; set; }

	public bool IsFind { get; set; }

	public decimal? AllPayRemain { get; set; }

	public string PrintFormatFileName { get; set; }

	public WSspSelectPreOrderWithId_Result PreOrder { get; set; }

	public List<WSspSelectPreOrderItems_Result> PreOrderItems { get; set; }

	public List<WSspSelectPreOrderPayments_Result> PreOrderPayments { get; set; }
}
