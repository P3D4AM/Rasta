using System;

namespace Mobile.Models;

public class PayLinkAccDataViewModel
{
	public int? DBId { get; set; }

	public string DbName { get; set; }

	public string DbTitle { get; set; }

	public string HeaderId { get; set; }

	public string Number { get; set; }

	public string DetailId { get; set; }

	public string VoucherId { get; set; }

	public string VoucherNumber { get; set; }

	public string Type { get; set; }

	public DateTime? FTDate { get; set; }

	public DateTime? LTDate { get; set; }

	public int? PayId { get; set; }

	public string HeaderIdWithLbl { get; set; }

	public string NumberWithLbl { get; set; }

	public string DetailIdWithLbl { get; set; }

	public string VoucherIdWithLbl { get; set; }

	public string VoucherNumberWithLbl { get; set; }

	public string TypeWithLbl { get; set; }

	public string FTDateWithLbl { get; set; }

	public string LTDateWithLbl { get; set; }

	public string PayInfoWithLbl { get; set; }
}
