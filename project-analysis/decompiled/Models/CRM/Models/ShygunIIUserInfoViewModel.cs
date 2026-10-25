using System;

namespace CRM.Models;

public class ShygunIIUserInfoViewModel
{
	public string JobNo { get; set; }

	public string JobName { get; set; }

	public string JobDescription { get; set; }

	public double? LendCover { get; set; }

	public double? DebtCover { get; set; }

	public double? DebtCoverDoc { get; set; }

	public double? CreditCoverDoc { get; set; }

	public decimal? RemainAccount { get; set; }

	public string Scode1Number { get; set; }

	public string Scode2Number { get; set; }

	public string JobScode1Number { get; set; }

	public string JobScode2Number { get; set; }

	public DateTime? JobCreate { get; set; }

	public string JobCreateStr { get; set; }

	public int? DiscountLevel { get; set; }

	public string Telephone1 { get; set; }

	public string Telephone2 { get; set; }

	public string Fax { get; set; }

	public string Email { get; set; }

	public string Web { get; set; }

	public string Address1 { get; set; }

	public string Address2 { get; set; }

	public string City { get; set; }

	public string Province { get; set; }

	public string ZipCode { get; set; }

	public string Country { get; set; }

	public string EconomicCode { get; set; }

	public string Tlx { get; set; }

	public string Title { get; set; }

	public string Mobile { get; set; }

	public string BankNumber1 { get; set; }

	public string BankNumber2 { get; set; }

	public string MelliCode { get; set; }

	public double? DefaultDiscountPer { get; set; }

	public string JobGroupNumber { get; set; }

	public string JobGroupName { get; set; }

	public string GuId { get; set; }

	public string JobGroupGuId { get; set; }

	public int? AccountTypeLaw { get; set; }

	public long RowNumber { get; set; }

	public int UserId { get; set; }
}
