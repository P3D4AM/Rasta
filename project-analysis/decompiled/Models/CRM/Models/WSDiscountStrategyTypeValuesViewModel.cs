using System;

namespace CRM.Models;

public class WSDiscountStrategyTypeValuesViewModel
{
	public int? UserId { get; set; }

	public int? RollId { get; set; }

	public int? PrdId { get; set; }

	public decimal? DisPer { get; set; }

	public DateTime? ExpDate { get; set; }

	public bool? MnBgIsReturn { get; set; }

	public int? MnBgExpireDay { get; set; }
}
