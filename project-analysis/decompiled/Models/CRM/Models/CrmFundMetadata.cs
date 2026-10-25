using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmFundMetadata
{
	[Key]
	public int FundId { get; set; }

	public int FundGroupId { get; set; }

	public int CrmUserId { get; set; }

	public DateTime FundDate { get; set; }

	public string FundDatePersian { get; set; }

	public long FundNumber { get; set; }

	public decimal? FundCredit { get; set; }

	public decimal? FundDebit { get; set; }

	public decimal? FundRemain { get; set; }

	public string FundDesc { get; set; }

	public int? FundOrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
