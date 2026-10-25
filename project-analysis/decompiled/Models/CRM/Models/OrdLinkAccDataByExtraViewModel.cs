using System;

namespace CRM.Models;

public class OrdLinkAccDataByExtraViewModel
{
	public int? DBId { get; set; }

	public string Id { get; set; }

	public string Number { get; set; }

	public string VoucherId { get; set; }

	public string VoucherNumber { get; set; }

	public DateTime? FTDate { get; set; }

	public DateTime? LTDate { get; set; }

	public string ExtraField { get; set; }
}
