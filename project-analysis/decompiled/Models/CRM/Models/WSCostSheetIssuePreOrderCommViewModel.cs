using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetIssuePreOrderCommViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommDate")]
	public string pordCommDatePersian { get; set; }

	public string pordCommDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommUserId")]
	public int? pordCommUserId { get; set; }

	public string pordCommUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommBaseAmount")]
	public decimal? pordCommBaseAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommAmount")]
	public decimal? pordCommAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommAmountCurrUnId")]
	public int? pordCommAmountCurrUnId { get; set; }

	public string pordCommAmountCurrUn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommAmountCurrencyRate")]
	public double? pordCommAmountCurrencyRate { get; set; }
}
