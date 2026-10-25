namespace Mobile.Models;

public class MobspPrdSalePriceHistory_Result
{
	public decimal? LastPrice { get; set; }

	public string LastPriceLastCmp { get; set; }

	public int? LastPriceLastCmpId { get; set; }

	public decimal? minPrice { get; set; }

	public string minPriceLastCmp { get; set; }

	public int? minPriceLastCmpId { get; set; }

	public decimal? maxPrice { get; set; }

	public string maxPriceLastCmp { get; set; }

	public int? maxPriceLastCmpId { get; set; }

	public decimal? avePrice { get; set; }

	public string avePriceLastCmp { get; set; }

	public int? avePriceLastCmpId { get; set; }
}
