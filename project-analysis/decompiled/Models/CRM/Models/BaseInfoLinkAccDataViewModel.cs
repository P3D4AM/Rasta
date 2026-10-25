using System;

namespace CRM.Models;

public class BaseInfoLinkAccDataViewModel
{
	public int? DBId { get; set; }

	public string Id { get; set; }

	public string Code { get; set; }

	public DateTime? FTDate { get; set; }

	public DateTime? LTDate { get; set; }
}
