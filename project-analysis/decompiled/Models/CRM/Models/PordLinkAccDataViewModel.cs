using System;

namespace CRM.Models;

public class PordLinkAccDataViewModel
{
	public int? DBId { get; set; }

	public string DbName { get; set; }

	public string DbTitle { get; set; }

	public string Id { get; set; }

	public string Number { get; set; }

	public DateTime? FTDate { get; set; }

	public DateTime? LTDate { get; set; }

	public int? PordId { get; set; }

	public string IdWithLbl { get; set; }

	public string NumberWithLbl { get; set; }

	public string FTDateWithLbl { get; set; }

	public string LTDateWithLbl { get; set; }
}
