using System;

namespace CRM.Models;

public class WSspSelectCurrencyUnitRateTop1_Result
{
	public int CurrencyUnitRateId { get; set; }

	public int SrcCurrencyUnitId { get; set; }

	public string SrcCurrencyUnit { get; set; }

	public int DestCurrencyUnitId { get; set; }

	public string DestCurrencyUnit { get; set; }

	public double CurrencyRate { get; set; }

	public DateTime RateDate { get; set; }

	public string RateDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
