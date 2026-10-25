using System;

namespace CRM.Models;

public class InstallmentPayOrderViewModel
{
	public int Row { get; set; }

	public string DateStr { get; set; }

	public DateTime? Date { get; set; }

	public decimal? Amount { get; set; }

	public int? Day { get; set; }
}
