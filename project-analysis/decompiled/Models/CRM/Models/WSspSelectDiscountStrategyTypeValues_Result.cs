using System;

namespace CRM.Models;

public class WSspSelectDiscountStrategyTypeValues_Result
{
	public long? DisStTypeValueId { get; set; }

	public int? UserId { get; set; }

	public string UserName { get; set; }

	public int? RollId { get; set; }

	public string RollName { get; set; }

	public int? PrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public decimal? DisPer { get; set; }

	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public bool? MnBgIsReturn { get; set; }

	public int? MnBgExpireDay { get; set; }
}
