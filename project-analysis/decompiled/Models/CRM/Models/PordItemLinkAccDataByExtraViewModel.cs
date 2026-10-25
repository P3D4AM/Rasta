using System;

namespace CRM.Models;

public class PordItemLinkAccDataByExtraViewModel
{
	public int? DBId { get; set; }

	public string Id { get; set; }

	public DateTime? FTDate { get; set; }

	public DateTime? LTDate { get; set; }

	public string ExtraField { get; set; }
}
