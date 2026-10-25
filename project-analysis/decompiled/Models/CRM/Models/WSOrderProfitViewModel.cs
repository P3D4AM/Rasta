using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderProfitViewModel
{
	[Key]
	public int OrderID { get; set; }

	public string ordDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordGrossProfit")]
	public decimal? ordGrossProfit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordMoneySleep")]
	public decimal? ordMoneySleep { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSaleNetProfit")]
	public decimal? ordSaleNetProfit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSumOtherComm")]
	public decimal? ordSumOtherComm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSumSaleComm")]
	public decimal? ordSumSaleComm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSumBuyComm")]
	public decimal? ordSumBuyComm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSumMangComm")]
	public decimal? ordSumMangComm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordNetProfit")]
	public decimal? ordNetProfit { get; set; }
}
