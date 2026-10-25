using System;

namespace CRM.Models;

public class WSspSelectDiscountStrategy_Result
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

	public string DisStTypeValuesJson { get; set; }
}
