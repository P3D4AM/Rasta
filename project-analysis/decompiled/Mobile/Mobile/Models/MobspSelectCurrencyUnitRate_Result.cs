namespace Mobile.Models;

public class MobspSelectCurrencyUnitRate_Result
{
	public int CurrencyUnitRateId { get; set; }

	public int SrcCurrencyUnitId { get; set; }

	public string SrcCurrencyUnit { get; set; }

	public int DestCurrencyUnitId { get; set; }

	public string DestCurrencyUnit { get; set; }

	public double CurrencyRate { get; set; }

	public long? rn { get; set; }
}
