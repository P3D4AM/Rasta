using System;

namespace CRM.Models;

public class WSspSelectPreOrderDiscountStrategyById_Result
{
	public int DiscountStrategyId { get; set; }

	public string DisStTitle { get; set; }

	public int DisStSystemPartId { get; set; }

	public string DisStSystemPartTitle { get; set; }

	public int DisStDiscountStrategyTypeId { get; set; }

	public string DisStDiscountStrategyType { get; set; }

	public string DisStTypeValues { get; set; }

	public DateTime? DisStExpireDate { get; set; }

	public string DisStExpireDatePersian { get; set; }

	public int? UserId { get; set; }

	public string UserName { get; set; }

	public int? PrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public int? RollId { get; set; }

	public string RollName { get; set; }

	public decimal? DisPer { get; set; }

	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public bool? MnBgIsReturn { get; set; }

	public int? MnBgExpireDay { get; set; }

	public string DisStTitle_Lang { get; set; }
}
