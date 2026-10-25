using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetIssueBuyOrderPayViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "ctshBordPayImportDate")]
	public string bordpayImportDate { get; set; }

	public string bordpayImportDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordPayTypeId")]
	public int? bordpayTypeId { get; set; }

	public string bordpayType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordPayAmount")]
	public decimal? bordpayAmount { get; set; }
}
