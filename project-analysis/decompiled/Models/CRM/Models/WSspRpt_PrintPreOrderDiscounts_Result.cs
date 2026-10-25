using System;

namespace CRM.Models;

public class WSspRpt_PrintPreOrderDiscounts_Result
{
	public int PreOrderDiscountId { get; set; }

	public int pordDisPreOrderId { get; set; }

	public int? pordDisDiscountStrategyId { get; set; }

	public string pordDisDiscountStrategy { get; set; }

	public int? DisStDiscountStrategyTypeId { get; set; }

	public string DisStDiscountStrategyType { get; set; }

	public string pordDisTitle { get; set; }

	public decimal? pordDisAmount { get; set; }

	public decimal? pordDisPercent { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? pordDisPrdId { get; set; }

	public string pordDisPrdName { get; set; }

	public string pordDisPrdCode { get; set; }
}
