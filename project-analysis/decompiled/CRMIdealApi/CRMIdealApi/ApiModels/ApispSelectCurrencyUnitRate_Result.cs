using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCurrencyUnitRate_Result
{
	public int CurrencyUnitRateId { get; set; }

	public int SrcCurrencyUnitId { get; set; }

	public string SrcCurrencyUnit { get; set; }

	public int DestCurrencyUnitId { get; set; }

	public string DestCurrencyUnit { get; set; }

	public double CurrencyRate { get; set; }

	public DateTime RateDate { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
