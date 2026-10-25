using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetIssuePreOrderPayViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "ctshPordPayImportDate")]
	public string pordpayImportDate { get; set; }

	public string pordpayImportDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordPayType")]
	public int? pordpayTypeId { get; set; }

	public string pordpayType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordPayAmount")]
	public decimal? pordpayAmount { get; set; }
}
