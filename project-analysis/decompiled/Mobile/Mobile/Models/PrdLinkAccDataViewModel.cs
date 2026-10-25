using System;

namespace Mobile.Models;

public class PrdLinkAccDataViewModel
{
	public int? DBId { get; set; }

	public string DbName { get; set; }

	public string DbTitle { get; set; }

	public string Id { get; set; }

	public string Code { get; set; }

	public DateTime? FTDate { get; set; }

	public DateTime? LTDate { get; set; }

	public string IdWithLbl { get; set; }

	public string CodeWithLbl { get; set; }

	public string FTDateWithLbl { get; set; }

	public string LTDateWithLbl { get; set; }
}
